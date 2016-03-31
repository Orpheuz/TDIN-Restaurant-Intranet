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
        OrderInterface listServer;
        MetroForm addOrderForm;
        MetroForm CheckOrdersForm;
        AlterEventRepeater evRepeater;
        delegate void notificationDlg(Order order);

        public RoomWindow()
        {
            RemotingConfiguration.Configure("Room.exe.config", false);
            addOrderForm = new AddOrder();
            InitializeComponent();
            listServer = (OrderInterface)RemoteNew.New(typeof(OrderInterface));
            evRepeater = new AlterEventRepeater();
            evRepeater.alterEvent += new AlterDelegate(DoAlterations);
            listServer.alterEvent += new AlterDelegate(evRepeater.Repeater);
        }

        public void DoAlterations(Operation op, Order order)
        {
            notificationDlg ntfDlg;

            switch (op)
            {
                case Operation.Change:
                    if (order.State == OrderState.Ready)
                    {
                        ntfDlg = new notificationDlg(orderNotification);
                        BeginInvoke(ntfDlg, new object[] { order });
                    }
                    break;
            }
        }

        private void orderNotification(Order order)
        {
            timer1.Start();
            metroTile1.Text = "Order number " + order.Id + " is ready!";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (metroTile1.Style == MetroFramework.MetroColorStyle.Blue)
                metroTile1.Style = MetroFramework.MetroColorStyle.Silver;
            else metroTile1.Style = MetroFramework.MetroColorStyle.Blue;

            metroTile1.Refresh();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            metroTile1.Style = MetroFramework.MetroColorStyle.Blue;
            metroTile1.Text = "No order ready";
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            addOrderForm = new AddOrder();
            addOrderForm.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            CheckOrdersForm = new ReadyOrder();
            CheckOrdersForm.Show();
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
