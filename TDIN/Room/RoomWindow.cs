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
        ArrayList locations;
        ArrayList price;
        ArrayList tableIDs;
        ArrayList tables;
        ArrayList orders;
        AlterEventRepeater evRepeater;
        delegate void notificationDlg(Order order);
        delegate void changeRmOrderDelg(Order order);
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
            locations = new ArrayList();
            price = new ArrayList();
            descriptions.Add("Massa à bolonhesa");
            locations.Add(Local.Kitchen);
            price.Add(10);
            descriptions.Add("Carne à alentejana");
            locations.Add(Local.Kitchen);
            price.Add(15);
            descriptions.Add("Bacalhau à brás");
            locations.Add(Local.Kitchen);
            price.Add(18);
            descriptions.Add("Hamburger de frango");
            locations.Add(Local.Bar);
            price.Add(10);
            descriptions.Add("Tosta mista");
            locations.Add(Local.Bar);
            price.Add(3);
            descriptions.Add("Cachorro");
            locations.Add(Local.Bar);
            price.Add(6);
            descriptionComboBox.DataSource = descriptions;

            tableIDs = new ArrayList();
            for (uint i = 0; i < tables.Count; i++)
            {
                tableIDs.Add(i + 1);
            }
            tableComboBox.DataSource = tableIDs;
        }

        public void DoAlterations(Operation op, Order order)
        {
            LVAddDelegate lvAdd;
            notificationDlg ntfDlg;
            changeRmOrderDelg delOrdDlg;

            switch (op)
            {
                case Operation.Payment:
                    delOrdDlg = new changeRmOrderDelg(DeleteOrderDlg);
                    BeginInvoke(delOrdDlg, new object[] { order });
                    break;
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
                        delOrdDlg = new changeRmOrderDelg(DeleteOrderDlg);
                        BeginInvoke(delOrdDlg, new object[] { order });
                    }
                    break;
            }
        }

        private void DeleteOrderDlg(Order order)
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
            ArrayList temp = listServer.ConsultTable(1, true);
            if(temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 1);
        }

        private void table2_Click(object sender, EventArgs e)
        {
            ArrayList temp = listServer.ConsultTable(2, true);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 2);
        }

        private void table3_Click(object sender, EventArgs e)
        {
            ArrayList temp = listServer.ConsultTable(3, true);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 3);
        }

        private void table4_Click(object sender, EventArgs e)
        {
            ArrayList temp = listServer.ConsultTable(4, true);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 4);
        }

        private void table5_Click(object sender, EventArgs e)
        {
            ArrayList temp = listServer.ConsultTable(5, true);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 5);
        }

        private void table6_Click(object sender, EventArgs e)
        {
            ArrayList temp = listServer.ConsultTable(6, true);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 6);
        }

        private void table7_Click(object sender, EventArgs e)
        {
            ArrayList temp = listServer.ConsultTable(7, true);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 7);
        }

        private void table8_Click(object sender, EventArgs e)
        {
            ArrayList temp = listServer.ConsultTable(8, true);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 8);
        }

        private void table9_Click(object sender, EventArgs e)
        {
            ArrayList temp = listServer.ConsultTable(9, true);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 9);
        }

        private void table10_Click(object sender, EventArgs e)
        {
            ArrayList temp = listServer.ConsultTable(10, true);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 10);
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            tables = listServer.GetListOfTables();
            int index = descriptionComboBox.SelectedIndex;
            if (!(isTableAvailable((uint)tableComboBox.SelectedValue)))
            {
                MetroMessageBox.Show(this, "Chose other table", "Table is unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Order ord = new Order(listServer.GetNewID(), descriptionComboBox.SelectedValue.ToString(), (uint)quantityUpDown.Value, (uint)tableComboBox.SelectedValue, (Local)locations[index], Convert.ToUInt32(price[index]));
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
                if (ord.State == OrderState.Ready && !ord.PaymentDone)
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

        private void Room_FormClosed(object sender, FormClosedEventArgs e)
        {
            listServer.alterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            listServer.SerializeOrders();
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
