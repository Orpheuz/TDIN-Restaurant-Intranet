using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Room
{

    public partial class ReadyOrder : MetroForm
    {
        OrderInterface listServer;
        ArrayList orders;

        public ReadyOrder()
        {
            InitializeComponent();
            listServer = (OrderInterface)RemoteNew.New(typeof(OrderInterface));
            orders = listServer.GetListOfOrders();
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        /* Client interface event handlers */

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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (itemListView.SelectedItems.Count > 0)
            {
                uint id = Convert.ToUInt32(itemListView.SelectedItems[0].SubItems[0].Text);
                if (!listServer.ChangeState(true, id))
                {
                    MetroMessageBox.Show(this, "Order is already ready!", "Order ready", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    itemListView.SelectedItems[0].Remove();
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

