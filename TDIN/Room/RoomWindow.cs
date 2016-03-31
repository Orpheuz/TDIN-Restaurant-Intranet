﻿using MetroFramework;
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
        ArrayList descriptions;
        ArrayList tableIDs;
        ArrayList tables;
        ArrayList orders;
        AlterEventRepeater evRepeater;
        delegate void notificationDlg(Order order);
        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);

        public RoomWindow()
        {
            RemotingConfiguration.Configure("Room.exe.config", false);
            InitializeComponent();

            listServer = (OrderInterface)RemoteNew.New(typeof(OrderInterface));
            evRepeater = new AlterEventRepeater();
            evRepeater.alterEvent += new AlterDelegate(DoAlterations);
            listServer.alterEvent += new AlterDelegate(evRepeater.Repeater);
            orders = listServer.GetListOfOrders();
            tables = listServer.GetListOfTables();

            descriptions = new ArrayList();
            descriptions.Add("Massa à bolonhesa");
            descriptions.Add("Carne à alentejana");
            descriptions.Add("Bacalhau à brás");
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
                    break;
            }
        }

        private void orderNotification(Order order)
        {
            timer1.Start();
            notificationsTile.Text = "Order number " + order.Id + " is ready!";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (notificationsTile.Style == MetroFramework.MetroColorStyle.Blue)
                notificationsTile.Style = MetroFramework.MetroColorStyle.Silver;
            else notificationsTile.Style = MetroFramework.MetroColorStyle.Blue;

            notificationsTile.Refresh();
        }

        private void notificationsTile_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            notificationsTile.Style = MetroFramework.MetroColorStyle.Blue;
            notificationsTile.Text = "No order ready";
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
