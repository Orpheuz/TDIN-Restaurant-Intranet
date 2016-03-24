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
    public partial class RoomWindow : MetroForm
    {
        MetroForm addOrderForm = new AddOrder(false);

        public RoomWindow()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(metroTile1.Style == MetroFramework.MetroColorStyle.Blue)
                metroTile1.Style = MetroFramework.MetroColorStyle.Silver;
            else metroTile1.Style = MetroFramework.MetroColorStyle.Blue;

            metroTile1.Refresh();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            metroTile1.Style = MetroFramework.MetroColorStyle.Blue;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            addOrderForm = new AddOrder(true);
            addOrderForm.Show();
        }

    }
}
