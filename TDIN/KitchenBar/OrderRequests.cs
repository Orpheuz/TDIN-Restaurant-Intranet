using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace KitchenBar
{
    public partial class OrderRequests : MetroForm
    {
        uint serviceID;
        OrderInterface listServer;
        AlterEventRepeater evRepeater;
        ArrayList orders;
        ArrayList tables;
        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);
        delegate void ChCommDelegate(Order order);

        public OrderRequests(uint serviceID)
        {
            this.serviceID = serviceID;
            InitializeComponent();
            listServer = (OrderInterface)RemoteNew.New(typeof(OrderInterface));
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
            ChCommDelegate chComm;

            switch (op)
            {
                case Operation.New:
                    if (order.OrderTaker == serviceID)
                    {
                        lvAdd = new LVAddDelegate(itemListView.Items.Add);
                        ListViewItem lvItem = new ListViewItem(new string[] { order.Id.ToString(), order.Description, order.getStateString(), order.TableId.ToString(), order.Quantity.ToString(), order.Price.ToString() });
                        BeginInvoke(lvAdd, new object[] { lvItem });
                    }
                    break;
                case Operation.Change:
                    if (order.OrderTaker == serviceID)
                    {
                        chComm = new ChCommDelegate(ChangeState);
                        BeginInvoke(chComm, new object[] { order });
                    }
                    break;
            }
        }

        private void ChangeState(Order order)
        {
            foreach (ListViewItem lvI in itemListView.Items)
                if (Convert.ToInt32(lvI.SubItems[0].Text) == order.Id)
                {
                    lvI.SubItems[2].Text = order.getStateString();

                    break;
                }
        }

        /* Client interface event handlers */

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

        private void OrderRequests_FormClosed(object sender, FormClosedEventArgs e)
        {
            listServer.alterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);
        }

        private void itemListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (itemListView.SelectedItems.Count > 0)
            {
                uint id = Convert.ToUInt32(itemListView.SelectedItems[0].SubItems[0].Text);
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
}
