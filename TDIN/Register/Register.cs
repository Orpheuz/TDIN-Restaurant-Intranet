using MetroFramework.Forms;
using System;
using System.Collections;
using System.Runtime.Remoting;

namespace Register
{
    public partial class Register : MetroForm
    {
        OrderSingleton orders;

        public Register()
        {
            RemotingConfiguration.Configure("Register.exe.config", false);
            InitializeComponent();

            orders = (OrderSingleton)Activator.GetObject(typeof(OrderSingleton), "tcp://localhost:9000/Register/ListServer");



        }

        private void table1_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(orders.ConsultTable(1), 1);
        }

        private void table2_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(orders.ConsultTable(2), 2);
        }

        private void table3_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(orders.ConsultTable(3), 3);
        }

        private void table4_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(orders.ConsultTable(4), 4);
        }

        private void table5_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(orders.ConsultTable(5), 5);
        }

        private void table6_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(orders.ConsultTable(6), 6);
        }

        private void table7_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(orders.ConsultTable(7), 7);
        }

        private void table8_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(orders.ConsultTable(8), 8);
        }

        private void table9_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(orders.ConsultTable(9), 9);
        }

        private void table10_Click(object sender, EventArgs e)
        {
            MetroForm tableInf = new TableInfo(orders.ConsultTable(10), 10);
        }
    }
}
