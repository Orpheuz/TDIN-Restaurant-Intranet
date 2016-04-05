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
        OrderSingleton orders;
        AlterEventRepeater evRepeater;
        delegate void printDlg(uint tableID);

        public Register()
        {
            RemotingConfiguration.Configure("Register.exe.config", false);
            InitializeComponent();
            orders = (OrderSingleton)Activator.GetObject(typeof(OrderSingleton), "tcp://localhost:9000/Register/ListServer");

            evRepeater = new AlterEventRepeater();
            evRepeater.alterEvent += new AlterDelegate(DoAlterations);
            orders.alterEvent += new AlterDelegate(evRepeater.Repeater);
        }

        private void DoAlterations(Operation op, Order order)
        {
            printDlg prtDlg;

            switch (op)
            {
                case Operation.Print:
                    prtDlg = new printDlg(PrintDelegate);
                    BeginInvoke(prtDlg, new object[] { order.TableId });
                    break;
            }
        }

        private void PrintDelegate(uint tableID)
        {
            ArrayList temp = orders.ConsultTable(tableID, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 1, false);
        }

        private void table1_Click(object sender, EventArgs e)
        {
            ArrayList temp = orders.ConsultTable(1, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 1, false);
        }

        private void table2_Click(object sender, EventArgs e)
        {
            ArrayList temp = orders.ConsultTable(2, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 2, false);
        }

        private void table3_Click(object sender, EventArgs e)
        {
            ArrayList temp = orders.ConsultTable(3, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 3, false);
        }

        private void table4_Click(object sender, EventArgs e)
        {
            ArrayList temp = orders.ConsultTable(4, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 4, false);
        }

        private void table5_Click(object sender, EventArgs e)
        {
            ArrayList temp = orders.ConsultTable(5, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 5, false);
        }

        private void table6_Click(object sender, EventArgs e)
        {
            ArrayList temp = orders.ConsultTable(6, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 6, false);
        }

        private void table7_Click(object sender, EventArgs e)
        {
            ArrayList temp = orders.ConsultTable(7, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 7, false);
        }

        private void table8_Click(object sender, EventArgs e)
        {
            ArrayList temp = orders.ConsultTable(8, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 8, false);
        }

        private void table9_Click(object sender, EventArgs e)
        {
            ArrayList temp = orders.ConsultTable(9, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 9, false);
        }

        private void table10_Click(object sender, EventArgs e)
        {
            ArrayList temp = orders.ConsultTable(10, false);
            if (temp.Count == 0)
            {
                MetroMessageBox.Show(this, "Chose another table", "Table has no orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroForm tableInf = new TableInfo(temp, 10, false);
        }
    }
}
