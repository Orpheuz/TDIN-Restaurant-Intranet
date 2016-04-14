using MetroFramework.Forms;
using System;
using System.Collections;
using System.Drawing;

namespace Register
{
    public partial class TableInfo : MetroForm
    {
        uint tableID;
        OrderSingleton ordersList;
        bool print;

        public TableInfo(ArrayList orders, uint tableID, bool print)
        {
            this.tableID = tableID;
            this.print = print;
            InitializeComponent();
            buildInvoice(orders);
            this.Show();
            this.Text = "Invoice from Table " + tableID.ToString();

            ordersList = (OrderSingleton)Activator.GetObject(typeof(OrderSingleton), "tcp://localhost:9000/Register/ListServer");
        }

        private void buildInvoice(ArrayList orders)
        {
            uint price = 0;
            foreach(Order order in orders)
            {
                metroLabel1.Text += "\n" + order.Description + " - " + order.Price + " euros - " + order.Quantity + " portions";
                price += order.Price * order.Quantity;
            }

            metroLabel1.Text += "\n\n" + "Total price: " + price.ToString();

            if(print)
            {
                this.ClientSize = new Size(457, orders.Count * 30 + 150);
                this.metroButton1.Hide();
            }
            else
            {
                this.ClientSize = new Size(457, orders.Count * 30 + 218);
                this.metroButton1.Location = new System.Drawing.Point(300, orders.Count * 30 + 170);
            }
        }

        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            ordersList.ProcessPayment(tableID);
            this.Close();
        }
    }
}
