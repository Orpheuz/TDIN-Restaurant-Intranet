using MetroFramework.Forms;
using System.Windows.Forms;

namespace KitchenBar
{
    public partial class ChoseLocal : MetroForm
    {
        MetroForm form = new MetroForm();
        public ChoseLocal()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, System.EventArgs e)
        {
            form = new NotMetOrders(true);
            form.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
            form.Show();
        }

        private void metroTile2_Click(object sender, System.EventArgs e)
        {
            form = new NotMetOrders(false);
            form.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
            form.Show();
        }

        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

    }
}
