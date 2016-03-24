using MetroFramework.Forms;
using System;
using System.Collections;
using System.Runtime.Remoting;

namespace Room
{

    public partial class AddOrder : MetroForm
    {
        OrderInterface listServer;
        AlterEventRepeater evRepeater;
        ArrayList descriptions;
        ArrayList tableIDs;
        ArrayList orders;
        ArrayList tables;

        public AddOrder(bool remotingInitialized)
        {
            if (!remotingInitialized)
            {
                RemotingConfiguration.Configure("Room.exe.config", false);
                remotingInitialized = true;
            }
            InitializeComponent();
            listServer = (OrderInterface)RemoteNew.New(typeof(OrderInterface));
            orders = listServer.GetListOfOrders();
            tables = listServer.GetListOfTables();

            evRepeater = new AlterEventRepeater();
            listServer.alterEvent += new AlterDelegate(evRepeater.Repeater);

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
            Local localValue;
            if (metroRadioButton1.Checked)
                localValue = Local.Kitchen;
            else localValue = Local.Bar;
            Order ord = new Order(listServer.GetNewID(), metroComboBox1.SelectedValue.ToString(), (uint)numericUpDown1.Value, (uint)metroComboBox2.SelectedValue, localValue, (uint)numericUpDown2.Value);
            listServer.AddItem(ord);
        }
    }

    class RemoteNew
    {
        private static Hashtable types = null;

        private static void InitTypeTable()
        {
            types = new Hashtable();
            foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
                types.Add(entry.ObjectType, entry);
        }

        public static object New(Type type)
        {
            if (types == null)
                InitTypeTable();
            WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)types[type];
            if (entry == null)
                throw new RemotingException("Type not found!");
            return RemotingServices.Connect(type, entry.ObjectUrl);
        }
    }


}

