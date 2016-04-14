using MetroFramework.Forms;
using System.Collections;
using System.Drawing;

namespace Room
{
    public partial class TableInfo : MetroForm
    {
        public TableInfo(ArrayList orders, uint tableID)
        {
            InitializeComponent();
            buildInvoice(orders);
            this.Show();
            this.Text = "Orders from Table " + tableID.ToString();
        }

        private void buildInvoice(ArrayList orders)
        {
            uint price = 0;
            foreach(Order order in orders)
            {
                metroLabel1.Text += "\n" + order.Description + " - " + order.Price + "euros - " + order.Quantity + " portions";
                price += order.Price * order.Quantity;
            }

            metroLabel1.Text += "\n\n" + "Total price: " + price.ToString();

            this.ClientSize = new Size(457, orders.Count * 30 + 150);

        }
    }
}
