using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room
{
    public partial class Popup : MetroForm
    {
        public Popup(String orderID)
        {
            InitializeComponent();
            timer1.Start();
            this.notificationsTile.Text = "Order number " + orderID + " is ready!";
            this.Show();
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
            this.Close();
        }
    }
}
