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
using VKR.Tools;

namespace VKR.Forms
{
    public partial class TablesComponents : Form
    {
        private static List<string> _listofMarkingComponents;
        private List<Entities.Component> _listofComponents;

        public static List<string> ListofMarkingComponents
        {
            get { return _listofMarkingComponents; }
            set { _listofMarkingComponents = value; }
        }

        public List<Entities.Component> ListofComponents
        {
            get { return _listofComponents; }
            private set { _listofComponents = value; }
        }

        public TablesComponents()
        {
            InitializeComponent();

            ListofMarkingComponents = new List<string>();

            tableComponents.DataSource = Database.GetTable("Component");
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            Dictionary<int, Entities.Component> selectedComponents = new Dictionary<int, Entities.Component>();

            foreach (DataGridViewCell cell in tableComponents.SelectedCells)
            {
                if (!selectedComponents.ContainsKey(cell.RowIndex))
                {
                    string selectedComponent_marking = tableComponents.Rows[cell.RowIndex].Cells[0].Value as string;

                    if (!_listofMarkingComponents.Contains(selectedComponent_marking)) 
                    {
                        _listofMarkingComponents.Add(selectedComponent_marking);
                    }
                }
            }
        }
    }
}
