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

        public TableInfo(ArrayList orders, uint tableID)
        {
            this.tableID = tableID;
            InitializeComponent();
            buildInvoice(orders);
            this.Show();
            this.Text = "Orders from Table " + tableID.ToString();

            ordersList = (OrderSingleton)Activator.GetObject(typeof(OrderSingleton), "tcp://localhost:9000/Register/ListServer");
        }

        private void buildInvoice(ArrayList orders)
        {
            uint price = 0;
            foreach(Order order in orders)
            {
                metroLabel1.Text += "\n" + order.Description + " - " + order.Price + "eur - " + order.Quantity + " portions";
                price += order.Price * order.Quantity;
            }

            metroLabel1.Text += "\n\n" + "Total price: " + price.ToString();

            this.ClientSize = new Size(457, orders.Count * 30 + 150);

            this.metroButton1.Location = new System.Drawing.Point(300, orders.Count * 30 + 170);
        }

        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            ordersList.ProcessPayment(tableID);
            this.Close();
        }
    }
}
