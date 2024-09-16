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
    public partial class DataofComponents : Form
    {
        private bool _isFullDataofComponents = false;

        private List<Entities.Component> _listofComponents;

        private Dictionary<int, string> _selectedComponents;

        public DataofComponents()
        {
            InitializeComponent();

            ListofComponents = new List<Entities.Component>();

            _selectedComponents = new Dictionary<int, string>();

            Load_DataGrid();

            Load_DataGrid_Pins();
        }


        #region Свойства

        public bool IsFullDataofComponents
        {
            get { return _isFullDataofComponents; }
            private set { _isFullDataofComponents = value; }
        }

        public List<Entities.Component> ListofComponents
        {
            get { return _listofComponents; }
            private set 
            {
                if (value != null && value != _listofComponents)
                {
                    _listofComponents = value;

                    Refresh_DataGridView();
                }
            }
        }

        #endregion

        private void AddList(string selectedComponent_marking)
        {
            if (!_listofComponents.Exists(x => x.Marking == selectedComponent_marking))
            {

                List<string>[] selectedComponent = Database.SelectCommand("Component", $"Component.Component_Marking = \'{selectedComponent_marking}\'");

                if (selectedComponent != null)
                {
                    string selectedComponent_name = selectedComponent[1][0];
                    string selectedComponent_footprint_id = selectedComponent[2][0];
                    double selectedComponent_power_dissipation = Double.Parse(selectedComponent[3][0]);

                    List<string>[] selectedComponent_footprint = Database.SelectCommand("Footprint", $"Footprint.Footprint_ID = \'{selectedComponent_footprint_id}\'");

                    if (selectedComponent_footprint != null)
                    {
                        double footprint_height = Double.Parse(selectedComponent_footprint[1][0]);
                        double footprint_width = Double.Parse(selectedComponent_footprint[2][0]);

                        Footprint footprint = new Footprint();
                        footprint.Name = selectedComponent_footprint_id;
                        footprint.Height = footprint_height;
                        footprint.Width = footprint_width;

                        Entities.Component component = new Entities.Component();
                        component.Marking = selectedComponent_marking;
                        component.Designator = selectedComponent_name;
                        component.Footprint = footprint;
                        component.PowerDissipation = selectedComponent_power_dissipation;

                        _listofComponents.Add(component);
                    }
                }
            }
        }

        private void Refresh_DataGridView()
        {
            advancedDataGridView_Components.Rows.Clear();

            if (_listofComponents.Count > 0)
            {
                DataTable dt = new DataTable();
                DataColumn markingComponent = new DataColumn("Маркировка компонента", Type.GetType("System.String"));
                DataColumn designator = new DataColumn("Позиционное обозначение", Type.GetType("System.String"));
                DataColumn footprint_id = new DataColumn("Код посадочного места", Type.GetType("System.String"));
                DataColumn code_zone = new DataColumn("Код зоны размещения", Type.GetType("System.String"));
                DataColumn power = new DataColumn("Мощность рассеивания", Type.GetType("System.String"));
                dt.Columns.Add(@markingComponent);
                dt.Columns.Add(@designator);
                dt.Columns.Add(@footprint_id);
                dt.Columns.Add(@code_zone);
                dt.Columns.Add(@power);

                foreach (Entities.Component component in _listofComponents)
                {
                    dt.Rows.Add(new object[] {
                        component.Marking,
                        component.Designator,
                        component.Footprint.Name,
                        component.CodeZone,
                        component.PowerDissipation});
                }

                advancedDataGridView_Components.DataSource = dt;
            }
        }

        #region Кнопки

        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (Database.GetInfoConnection())
            {
                TablesComponents form = new TablesComponents();

                form.chooseButton.Click += ChooseButtonComponents_Click;

                form.Show();
            }
        }

        private void ChooseButtonComponents_Click(object sender, EventArgs e)
        {
            List<string> listofMarkingComponents = TablesComponents.ListofMarkingComponents;

            TablesComponents.ListofMarkingComponents = new List<string>();

            foreach (string markingComponent in listofMarkingComponents)
            {
                AddList(markingComponent);
            }

            Refresh_DataGridView();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView_Components.SelectedCells.Count > 0)
            {
                foreach (var index in _selectedComponents.Keys)
                {
                    advancedDataGridView_Components.Rows.RemoveAt(index);
                }
                foreach (var marking in  _selectedComponents.Values)
                {
                    if (_listofComponents.Exists(x => x.Marking == marking))
                    {
                        int selected_index = _listofComponents.FindIndex(x => x.Marking == marking);

                        _listofComponents.RemoveAt(selected_index);
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ListofComponents.Count > 0)
            {
                Components _components = new Components();
                _components.ListComponentsRef = ListofComponents;

                Project.instance.Scheme.ComponentsRef = _components;

                Close();
            }
            else
            {
                MessageBox.Show(
                    "Список компонентов пуст!",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void advancedDataGridView_Components_SelectionChanged(object sender, EventArgs e)
        {
            _selectedComponents = new Dictionary<int, string>();

            if (advancedDataGridView_Components.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in advancedDataGridView_Components.SelectedCells)
                {
                    if (!_selectedComponents.ContainsKey(cell.RowIndex))
                    {
                        string selectedComponent_marking = advancedDataGridView_Components.Rows[cell.RowIndex].Cells[0].Value as string;

                        _selectedComponents.Add(cell.RowIndex, selectedComponent_marking);
                    }
                }
            }
        }

        private void Load_DataGrid()
        {
            if (Project.instance.Scheme.ComponentsRef.ListComponentsRef.Count > 0)
            {
                ListofComponents = Project.instance.Scheme.ComponentsRef.ListComponentsRef;
            }
        }

        private void Load_DataGrid_Pins()
        {
            DataTable dt = new DataTable();
            DataColumn pin_id = new DataColumn("Номер вывода компонента", Type.GetType("System.String"));
            DataColumn x = new DataColumn("Координата по оси ОХ", Type.GetType("System.String"));
            DataColumn y = new DataColumn("Координата по оси ОУ", Type.GetType("System.String"));
            dt.Columns.Add(@pin_id);
            dt.Columns.Add(@x);
            dt.Columns.Add(@y);

            advancedDataGridView_Pins.DataSource = dt;
        }
    }
}
