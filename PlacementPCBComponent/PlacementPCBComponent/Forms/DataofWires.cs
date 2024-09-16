using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.Entities;

namespace VKR.Forms
{
    public partial class DataofWires : Form
    {
        public DataofWires()
        {
            InitializeComponent();

            Load_DataGrid();

            Load_ComboBox();
        }

        private void Load_ComboBox()
        {
            if (Project.instance.Scheme.WiresRef.ListWireRef.Count > 0)
            {
                List<string> designators = new List<string>();
                foreach (var components in Project.instance.Scheme.ComponentsRef.ListComponentsRef)
                {
                    designators.Add(components.Designator);
                }
                comboBox_Components.Items.AddRange(designators.ToArray());
                comboBox_Pins.Enabled = false;
            }
        }

        private void Load_DataGrid()
        {
            if (Project.instance.Scheme.WiresRef.ListWireRef.Count > 0)
            {
                DataTable dt = new DataTable();
                DataColumn wire_name = new DataColumn("Код цепи", Type.GetType("System.String"));
                DataColumn designator = new DataColumn("Позиционное обозначение компонента", Type.GetType("System.String"));
                DataColumn pin_id = new DataColumn("Номер вывода компонента", Type.GetType("System.String"));
                dt.Columns.Add(wire_name);
                dt.Columns.Add(@designator);
                dt.Columns.Add(@pin_id);

                foreach (Wire wire in Project.instance.Scheme.WiresRef.ListWireRef)
                {
                    dt.Rows.Add(new object[] {
                        wire.Id,
                        wire.Designator,
                        wire.IdPin.ToString()});
                }

                advancedDataGridView1.DataSource = dt;
            }
        }

        private void comboBox_Components_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_Components.SelectedItem != null)
            {
                comboBox_Pins.Enabled = true;

                List<string> pins_id = new List<string>();
                string designator = comboBox_Components.SelectedItem.ToString();
                foreach (var pin in Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == designator).PinsRef.ListofPinsRef)
                {
                    pins_id.Add(pin.Id.ToString());
                }
                comboBox_Pins.Items.AddRange(pins_id.ToArray());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
