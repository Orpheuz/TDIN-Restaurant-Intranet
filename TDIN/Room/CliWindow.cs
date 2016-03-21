using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Client
{
    public partial class CliWindow : MetroForm
    {
        OrderInterface listServer;
        AlterEventRepeater evRepeater;
        ArrayList orders;
        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);
        delegate void ChCommDelegate(Order order);

        public CliWindow()
        {
            RemotingConfiguration.Configure("Room.exe.config", false);
            InitializeComponent();
            listServer = (OrderInterface)RemoteNew.New(typeof(OrderInterface));
            orders = listServer.GetList();
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
                    lvAdd = new LVAddDelegate(itemListView.Items.Add);
                    ListViewItem lvItem = new ListViewItem(new string[] { order.Id.ToString(), order.Description, order.getStateString() });
                    BeginInvoke(lvAdd, new object[] { lvItem });
                    break;
                case Operation.Change:
                    chComm = new ChCommDelegate(ChangeState);
                    BeginInvoke(chComm, new object[] { order });
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

        private void CliWindow_Load(object sender, EventArgs e)
        {
            foreach (Order ord in orders)
            {
                ListViewItem lvItem = new ListViewItem(new string[] { ord.Id.ToString(), ord.Description, ord.getStateString() });
                itemListView.Items.Add(lvItem);
            }
        }

        private void CliWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            listServer.alterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            {
                MetroMessageBox.Show(this, "Need to fill the description!", "Insuficient values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Order ord = new Order(listServer.GetNewID(), metroTextBox1.Text);
            listServer.AddItem(ord);
            metroTextBox1.Text = "";
        }

        private void itemListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (itemListView.SelectedItems.Count > 0)
            {
                uint id = Convert.ToUInt32(itemListView.SelectedItems[0].SubItems[0].Text);
                if (!listServer.ChangeState(id))
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
