using System;
using System.Data;
using System.Windows.Forms;
using VKR.Entities;

namespace VKR.Forms
{
    public partial class DataofPins : Form
    {
        public DataofPins()
        {
            InitializeComponent();

            Load_DataGrid();
        }

        private void Load_DataGrid()
        {
            DataTable dt = new DataTable();
            DataColumn markingComponent = new DataColumn("Маркировка компонента", Type.GetType("System.String"));
            DataColumn designator = new DataColumn("Позиционное обозначение", Type.GetType("System.String"));
            DataColumn pin_id = new DataColumn("Номер вывода компонента", Type.GetType("System.String"));
            DataColumn x = new DataColumn("Координата по оси ОХ", Type.GetType("System.String"));
            DataColumn y = new DataColumn("Координата по оси ОУ", Type.GetType("System.String"));
            dt.Columns.Add(@markingComponent);
            dt.Columns.Add(@designator);
            dt.Columns.Add(@pin_id);
            dt.Columns.Add(@x);
            dt.Columns.Add(@y);

            foreach (Entities.Component component in Project.instance.Scheme.ComponentsRef.ListComponentsRef)
            {
                foreach (Pin pin in component.PinsRef.ListofPinsRef) 
                {
                    dt.Rows.Add(new object[] {
                        component.Marking,
                        component.Designator,
                        pin.Id,
                        pin.X.ToString(),
                        pin.Y.ToString()});
                }
            }

            advancedDataGridView1.DataSource = dt;
        }
    }
}
