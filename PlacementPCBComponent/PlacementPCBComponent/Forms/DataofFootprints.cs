using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VKR.Entities;

namespace VKR.Forms
{
    public partial class DataofFootprints : Form
    {
        public DataofFootprints()
        {
            InitializeComponent();

            Load_DataGrid();
        }

        private void Load_DataGrid()
        {
            DataTable dt = new DataTable();
            DataColumn markingComponent = new DataColumn("Маркировка компонента", Type.GetType("System.String"));
            DataColumn footprint_id = new DataColumn("Код посадочного места", Type.GetType("System.String"));
            DataColumn height = new DataColumn("Длина", Type.GetType("System.String"));
            DataColumn width = new DataColumn("Ширина", Type.GetType("System.String"));
            dt.Columns.Add(@markingComponent);
            dt.Columns.Add(@footprint_id);
            dt.Columns.Add(@height);
            dt.Columns.Add(@width);

            foreach (Entities.Component component in Project.instance.Scheme.ComponentsRef.ListComponentsRef)
            {
                if (!dt.AsEnumerable().Any(row => component.Marking == row.Field<String>("Маркировка компонента")))
                {
                    dt.Rows.Add(new object[] {
                        component.Marking,
                        component.Footprint.Name,
                        component.Footprint.Height.ToString(),
                        component.Footprint.Width.ToString()});
                }
            }

            advancedDataGridView1.DataSource = dt;
        }
    }
}
