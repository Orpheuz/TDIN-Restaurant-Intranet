using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace KitchenBar
{
    public partial class KitchenBar : MetroForm
    {
        bool local;
        OrderInterface listServer;
        AlterEventRepeater evRepeater;
        ArrayList orders;
        ArrayList tables;
        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);
        delegate void ChOrderStateDlg(Order order);
        MetroForm form = new MetroForm();

        public KitchenBar(bool local)
        {
            this.local = local;
            RemotingConfiguration.Configure("KitchenBar.exe.config", false);
            InitializeComponent();
            listServer = (OrderInterface)RemoteNew.New(typeof(OrderInterface));
            if (this.local)
                this.Text = "Kitchen";
            else this.Text = "Bar";
            orders = listServer.GetListOfOrders();
            tables = listServer.GetListOfTables();
            evRepeater = new AlterEventRepeater();
            evRepeater.alterEvent += new AlterDelegate(DoAlterations);
            listServer.alterEvent += new AlterDelegate(evRepeater.Repeater);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public void DoAlterations(Operation op, Order order)
        {
            LVAddDelegate lvAdd;
            ListViewItem lvItem;
            ChOrderStateDlg chOrd;

            switch (op)
            {
                case Operation.New:
                    if (order.Local == Local.Kitchen && this.local == true)
                    {
                        lvAdd = new LVAddDelegate(orderLV.Items.Add);
                        lvItem = new ListViewItem(new string[] { order.Id.ToString(), order.Description, order.getStateString(), order.TableId.ToString(), order.Quantity.ToString(), order.Price.ToString() });
                        BeginInvoke(lvAdd, new object[] { lvItem });
                    }
                    if (order.Local == Local.Bar && this.local == false)
                    {
                        lvAdd = new LVAddDelegate(orderLV.Items.Add);
                        lvItem = new ListViewItem(new string[] { order.Id.ToString(), order.Description, order.getStateString(), order.TableId.ToString(), order.Quantity.ToString(), order.Price.ToString() });
                        BeginInvoke(lvAdd, new object[] { lvItem });
                    }
                    break;
                case Operation.Change:
                    chOrd = new ChOrderStateDlg(ChangeState);
                    BeginInvoke(chOrd, new object[] { order });

                    break;
            }
        }

        private void ChangeState(Order order)
        {
            foreach (ListViewItem lvI in orderLV.Items)
                if (Convert.ToInt32(lvI.SubItems[0].Text) == order.Id)
                {
                    lvI.SubItems[2].Text = order.getStateString();

                    break;
                }
        }

        /* Client interface event handlers */

        private void Orders_Load(object sender, EventArgs e)
        {
            foreach (Order ord in orders)
            {
                ListViewItem lvItem = new ListViewItem(new string[] { ord.Id.ToString(), ord.Description, ord.getStateString(), ord.TableId.ToString(), ord.Quantity.ToString(), ord.Price.ToString() });
                orderLV.Items.Add(lvItem);
            }
        }

        private void Room_FormClosed(object sender, FormClosedEventArgs e)
        {
            listServer.alterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);
        }

        private void changeStateButton_Click(object sender, EventArgs e)
        {
            if (orderLV.SelectedItems.Count > 0)
            {
                uint id = Convert.ToUInt32(orderLV.SelectedItems[0].SubItems[0].Text);
                if (!listServer.ChangeState(false, id))
                {
                    MetroMessageBox.Show(this, "Order is already ready!", "Order ready", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MetroMessageBox.Show(this, "You need to select an order!", "No order selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
