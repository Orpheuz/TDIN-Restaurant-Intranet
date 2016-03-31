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
        uint serviceID;
        OrderInterface listServer;
        AlterEventRepeater evRepeater;
        ArrayList orders;
        ArrayList tables;
        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);
        delegate void TakeOrdDelegate(Order order);
        delegate void ChOrderStateDlg(Order order);
        MetroForm form = new MetroForm();

        public KitchenBar(bool local)
        {
            this.local = local;
            RemotingConfiguration.Configure("KitchenBar.exe.config", false);
            InitializeComponent();
            listServer = (OrderInterface)RemoteNew.New(typeof(OrderInterface));
            serviceID = listServer.GetNewServiceID();
            if (this.local)
                this.Text = "Kitchen - " + serviceID.ToString();
            else this.Text = "Bar - " + serviceID.ToString();
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
            TakeOrdDelegate tkDlg;
            ListViewItem lvItem;
            ChOrderStateDlg chOrd;

            switch (op)
            {
                case Operation.New:
                    if (order.Local == Local.Kitchen && this.local == true)
                    {
                        lvAdd = new LVAddDelegate(itemListView.Items.Add);
                        lvItem = new ListViewItem(new string[] { order.Id.ToString(), order.Description, order.getStateString(), order.TableId.ToString(), order.Quantity.ToString(), order.Price.ToString() });
                        BeginInvoke(lvAdd, new object[] { lvItem });
                    }
                    if (order.Local == Local.Bar && this.local == false)
                    {
                        lvAdd = new LVAddDelegate(itemListView.Items.Add);
                        lvItem = new ListViewItem(new string[] { order.Id.ToString(), order.Description, order.getStateString(), order.TableId.ToString(), order.Quantity.ToString(), order.Price.ToString() });
                        BeginInvoke(lvAdd, new object[] { lvItem });
                    }
                    break;
                case Operation.Change:
                    if (order.OrderTaker == serviceID)
                    {
                        chOrd = new ChOrderStateDlg(ChangeState);
                        BeginInvoke(chOrd, new object[] { order });
                    }
                    break;
                case Operation.Taken:
                    tkDlg = new TakeOrdDelegate(TakeOrderDelegate);
                    BeginInvoke(tkDlg, new object[] { order });

                    if (order.OrderTaker == serviceID)
                    {
                        lvAdd = new LVAddDelegate(listView1.Items.Add);
                        lvItem = new ListViewItem(new string[] { order.Id.ToString(), order.Description, order.getStateString(), order.TableId.ToString(), order.Quantity.ToString(), order.Price.ToString() });
                        BeginInvoke(lvAdd, new object[] { lvItem });
                    }
                    break;
            }
        }

        private void ChangeState(Order order)
        {
            foreach (ListViewItem lvI in listView1.Items)
                if (Convert.ToInt32(lvI.SubItems[0].Text) == order.Id)
                {
                    lvI.SubItems[2].Text = order.getStateString();

                    break;
                }
        }

        private void TakeOrderDelegate(Order order)
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

        /* Client interface event handlers */

        private void NotMetOrders_Load(object sender, EventArgs e)
        {
            foreach (Order ord in orders)
            {
                if (ord.OrderTaker != 0)
                {
                    ListViewItem lvItem = new ListViewItem(new string[] { ord.Id.ToString(), ord.Description, ord.getStateString(), ord.TableId.ToString(), ord.Quantity.ToString(), ord.Price.ToString() });
                    itemListView.Items.Add(lvItem);
                }
            }
        }

        private void OrderRequests_Load(object sender, EventArgs e)
        {
            foreach (Order ord in orders)
            {
                if (ord.OrderTaker == serviceID)
                {
                    ListViewItem lvItem = new ListViewItem(new string[] { ord.Id.ToString(), ord.Description, ord.getStateString(), ord.TableId.ToString(), ord.Quantity.ToString(), ord.Price.ToString() });
                    itemListView.Items.Add(lvItem);
                }
            }
        }

        private void Room_FormClosed(object sender, FormClosedEventArgs e)
        {
            listServer.alterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);
        }

        private void takeOrderButton_Click(object sender, EventArgs e)
        {
            if (itemListView.SelectedItems.Count > 0)
            {
                uint id = Convert.ToUInt32(itemListView.SelectedItems[0].SubItems[0].Text);
                if (!listServer.TakeOrder(id, this.serviceID))
                {
                    MetroMessageBox.Show(this, "Order was already taken!", "Order taken", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MetroMessageBox.Show(this, "You need to select an item!", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void changeStateButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                uint id = Convert.ToUInt32(listView1.SelectedItems[0].SubItems[0].Text);
                if (!listServer.ChangeState(false, id))
                {
                    MetroMessageBox.Show(this, "Order is already ready!", "Order ready", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
