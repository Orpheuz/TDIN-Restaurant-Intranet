using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Register
{
    public partial class Register : MetroForm
    {
        OrderSingleton ordersS;
        AlterEventRepeater evRepeater;
        delegate void printDlg(uint tableID);
        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);
        ArrayList orders;

        public Register()
        {
            RemotingConfiguration.Configure("Register.exe.config", false);
            InitializeComponent();
            ordersS = (OrderSingleton)Activator.GetObject(typeof(OrderSingleton), "tcp://localhost:9000/Register/ListServer");
            ordersS.DeserializeOrders();
            orders = ordersS.GetListOfOrders();
            evRepeater = new AlterEventRepeater();
            evRepeater.alterEvent += new AlterDelegate(DoAlterations);
            ordersS.alterEvent += new AlterDelegate(evRepeater.Repeater);
        }

        private void DoAlterations(Operation op, Order order)
        {
            printDlg prtDlg;
            LVAddDelegate lvAdd;
            ListViewItem lvItem;

            switch (op)
            {
                case Operation.Change:
                    if (order.State == OrderState.Delivered && order.PaymentDone)
                    {
                        lvAdd = new LVAddDelegate(orderLV.Items.Add);
                        lvItem = new ListViewItem(new string[] { order.Id.ToString(), order.Description, order.getStateString(), order.TableId.ToString(), order.Quantity.ToString(), order.Price.ToString() });
                        BeginInvoke(lvAdd, new object[] { lvItem });
                    }
                    break;
                case Operation.Print:
                    prtDlg = new printDlg(PrintDelegate);
                    BeginInvoke(prtDlg, new object[] { order.TableId });
                    break;
            }
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            foreach (Order ord in orders)
            {
                if (ord.PaymentDone && ord.Date.Day == DateTime.Now.Day && ord.Date.Month == DateTime.Now.Month && ord.Date.Year == DateTime.Now.Year)
                {
                    ListViewItem lvItem = new ListViewItem(new string[] { ord.Id.ToString(), ord.Description, ord.getStateString(), ord.TableId.ToString(), ord.Quantity.ToString(), ord.Price.ToString(), ord.Local.ToString() });
                    orderLV.Items.Add(lvItem);
                }
            }
        }

        private void PrintDelegate(uint tableID)
        {
            ArrayList temp = ordersS.ConsultTable(tableID, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 1, false);
        }

        private void table1_Click(object sender, EventArgs e)
        {
            ArrayList temp = ordersS.ConsultTable(1, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 1, false);
        }

        private void table2_Click(object sender, EventArgs e)
        {
            ArrayList temp = ordersS.ConsultTable(2, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 2, false);
        }

        private void table3_Click(object sender, EventArgs e)
        {
            ArrayList temp = ordersS.ConsultTable(3, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 3, false);
        }

        private void table4_Click(object sender, EventArgs e)
        {
            ArrayList temp = ordersS.ConsultTable(4, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 4, false);
        }

        private void table5_Click(object sender, EventArgs e)
        {
            ArrayList temp = ordersS.ConsultTable(5, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 5, false);
        }

        private void table6_Click(object sender, EventArgs e)
        {
            ArrayList temp = ordersS.ConsultTable(6, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 6, false);
        }

        private void table7_Click(object sender, EventArgs e)
        {
            ArrayList temp = ordersS.ConsultTable(7, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 7, false);
        }

        private void table8_Click(object sender, EventArgs e)
        {
            ArrayList temp = ordersS.ConsultTable(8, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 8, false);
        }

        private void table9_Click(object sender, EventArgs e)
        {
            ArrayList temp = ordersS.ConsultTable(9, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 9, false);
        }

        private void table10_Click(object sender, EventArgs e)
        {
            ArrayList temp = ordersS.ConsultTable(10, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 10, false);
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            ordersS.SerializeOrders();
            Console.ReadLine();
            ordersS.alterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);
        }
    }
}
