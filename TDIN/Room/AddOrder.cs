using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Room
{

    public partial class AddOrder : MetroForm
    {
        OrderInterface listServer;
        ArrayList descriptions;
        ArrayList tableIDs;
        ArrayList tables;

        public AddOrder()
        {
            InitializeComponent();
            listServer = (OrderInterface)RemoteNew.New(typeof(OrderInterface));
            tables = listServer.GetListOfTables();

            descriptions = new ArrayList();
            descriptions.Add("Massa à bolonhesa");
            descriptions.Add("Carne à alentejana");
            descriptions.Add("Bacalhau à brás");
            metroComboBox1.DataSource = descriptions;

            tableIDs = new ArrayList();
            for(uint i = 0; i < tables.Count; i++)
            {
                tableIDs.Add(i);
            }
            metroComboBox2.DataSource = tableIDs;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            tables = listServer.GetListOfTables();
            Local localValue;
            if (metroRadioButton1.Checked)
                localValue = Local.Kitchen;
            else localValue = Local.Bar;
            if(!(isTableAvailable((uint) metroComboBox2.SelectedValue)))
            {
                MetroMessageBox.Show(this, "Chose other table", "Table is unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Order ord = new Order(listServer.GetNewID(), metroComboBox1.SelectedValue.ToString(), (uint)numericUpDown1.Value, (uint)metroComboBox2.SelectedValue, localValue, (uint)numericUpDown2.Value);
            listServer.AddOrder(ord);
        }

        private bool isTableAvailable(uint id)
        {
           foreach(Table tab in tables)
            {
                if (tab.Id == id)
                {
                    return tab.Availability;
                }
            }
            return false;
        }
    }
}

