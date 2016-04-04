using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room
{
    public partial class RoomWindow : MetroForm
    {
        uint serviceID;
        OrderInterface listServer;
        ArrayList descriptions;
        ArrayList tableIDs;
        ArrayList tables;
        ArrayList orders;
        AlterEventRepeater evRepeater;
        delegate void notificationDlg(Order order);
        delegate void deliveredOrderDelg(Order order);
        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);

        public RoomWindow()
        {
            RemotingConfiguration.Configure("Room.exe.config", false);
            InitializeComponent();
            listServer = (OrderInterface)RemoteNew.New(typeof(OrderInterface));
            evRepeater = new AlterEventRepeater();
            evRepeater.alterEvent += new AlterDelegate(DoAlterations);
            listServer.alterEvent += new AlterDelegate(evRepeater.Repeater);
            serviceID = listServer.GetNewServiceID();
            this.Text = "Room - " + serviceID.ToString();
            orders = listServer.GetListOfOrders();
            tables = listServer.GetListOfTables();

            descriptions = new ArrayList();
            descriptions.Add("Massa à bolonhesa");
            descriptions.Add("Carne à alentejana");
            descriptions.Add("Bacalhau à brás");
            descriptions.Add("Hamburger de frango");
            descriptionComboBox.DataSource = descriptions;

            tableIDs = new ArrayList();
            for (uint i = 0; i < tables.Count; i++)
            {
                tableIDs.Add(i);
            }
            tableComboBox.DataSource = tableIDs;
        }

        public void DoAlterations(Operation op, Order order)
        {
            LVAddDelegate lvAdd;
            notificationDlg ntfDlg;
            deliveredOrderDelg delOrdDlg;

            switch (op)
            {
                case Operation.Change:
                    if (order.State == OrderState.Ready)
                    {
                        ntfDlg = new notificationDlg(orderNotification);

                        lvAdd = new LVAddDelegate(itemListView.Items.Add);
                        ListViewItem lvItem = new ListViewItem(new string[] { order.Id.ToString(), order.Description, order.getStateString(), order.TableId.ToString(), order.Quantity.ToString(), order.Price.ToString() });

                        BeginInvoke(ntfDlg, new object[] { order });
                        BeginInvoke(lvAdd, new object[] { lvItem });
                    }
                    if(order.State == OrderState.Delivered)
                    {
                        delOrdDlg = new deliveredOrderDelg(DeliveredOrderDlg);
                        BeginInvoke(delOrdDlg, new object[] { order });
                    }
                    break;
            }
        }

        private void DeliveredOrderDlg(Order order)
        {
            foreach (ListViewItem item in itemListView.Items)
            {
                if (item.SubItems[0].Text == order.Id.ToString())
                {
                    itemListView.Items.Remove(item);
                    break;
                }
            }
        }

        private void orderNotification(Order order)
        {
            MetroForm not = new Popup(order.Id.ToString());
        }

        private void table1_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(listServer.ConsultTable(1), 1);
        }

        private void table2_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(listServer.ConsultTable(2), 2);
        }

        private void table3_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(listServer.ConsultTable(3), 3);
        }

        private void table4_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(listServer.ConsultTable(4), 4);
        }

        private void table5_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(listServer.ConsultTable(5), 5);
        }

        private void table6_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(listServer.ConsultTable(6), 6);
        }

        private void table7_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(listServer.ConsultTable(7), 7);
        }

        private void table8_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(listServer.ConsultTable(8), 8);
        }

        private void table9_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(listServer.ConsultTable(9), 9);
        }

        private void table10_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(listServer.ConsultTable(10), 10);
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            tables = listServer.GetListOfTables();
            Local localValue;
            if (radioButtonKitchen.Checked)
                localValue = Local.Kitchen;
            else localValue = Local.Bar;
            if (!(isTableAvailable((uint)tableComboBox.SelectedValue)))
            {
                MetroMessageBox.Show(this, "Chose other table", "Table is unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Order ord = new Order(listServer.GetNewID(), descriptionComboBox.SelectedValue.ToString(), (uint)quantityUpDown.Value, (uint)tableComboBox.SelectedValue, localValue, (uint)priceUpDown.Value);
            listServer.AddOrder(ord);
        }

        private bool isTableAvailable(uint id)
        {
            foreach (Table tab in tables)
            {
                if (tab.Id == id)
                {
                    return tab.Availability;
                }
            }
            return false;
        }

        private void ReadyOrder_Load(object sender, EventArgs e)
        {
            foreach (Order ord in orders)
            {
                if (ord.State == OrderState.Ready)
                {
                    ListViewItem lvItem = new ListViewItem(new string[] { ord.Id.ToString(), ord.Description, ord.getStateString(), ord.TableId.ToString(), ord.Quantity.ToString(), ord.Price.ToString() });
                    itemListView.Items.Add(lvItem);
                }
            }
        }

        private void deliverButton_Click(object sender, EventArgs e)
        {
            if (itemListView.SelectedItems.Count > 0)
            {
                uint id = Convert.ToUInt32(itemListView.SelectedItems[0].SubItems[0].Text);
                if (!listServer.ChangeState(true, id))
                {
                    MetroMessageBox.Show(this, "Couldn't change state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MetroMessageBox.Show(this, "You need to select an item!", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }

    class RemoteNew
    {
        private static Hashtable types = null;

        private static void InitTypeTable()
        {
            types = new Hashtable();
            foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
                types.Add(entry.ObjectType, entry);
        }

        public static object New(Type type)
        {
            if (types == null)
                InitTypeTable();
            WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)types[type];
            if (entry == null)
                throw new RemotingException("Type not found!");
            return RemotingServices.Connect(type, entry.ObjectUrl);
        }
    }
}
