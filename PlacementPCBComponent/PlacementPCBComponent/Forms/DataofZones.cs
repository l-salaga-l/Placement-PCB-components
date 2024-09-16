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
    public partial class DataofZones : Form
    {
        private Zones _listofZones;
        private ForbiddenZones _listofForbiddenZones;

        public DataofZones()
        {
            InitializeComponent();

            Load_DataGridZones();

            Load_DataGridProhibitedZones();

            _listofForbiddenZones = new ForbiddenZones();
            _listofZones = new Zones();
        }

        private void Load_DataGridProhibitedZones()
        {
            DataTable dt = new DataTable();
            DataColumn code_zone = new DataColumn("Код запрещенной зоны", Type.GetType("System.String"));
            DataColumn name = new DataColumn("Наименование запрещенной зоны", Type.GetType("System.String"));
            DataColumn height = new DataColumn("Длина", Type.GetType("System.String"));
            DataColumn width = new DataColumn("Ширина", Type.GetType("System.String"));
            DataColumn x = new DataColumn("Координата по оси ОХ", Type.GetType("System.String"));
            DataColumn y = new DataColumn("Координата по оси ОУ", Type.GetType("System.String"));
            dt.Columns.Add(@code_zone);
            dt.Columns.Add(@name);
            dt.Columns.Add(@height);
            dt.Columns.Add(@width);
            dt.Columns.Add(@x);
            dt.Columns.Add(@y);

            if (Project.instance.PCB.ForbiddenZonesRef.ListForbiddenZoneRef.Count > 0)
            {
                foreach (ForbiddenZone zone in Project.instance.PCB.ForbiddenZonesRef.ListForbiddenZoneRef)
                {
                    dt.Rows.Add(new object[] {
                        zone.Id,
                        zone.Name,
                        zone.Height,
                        zone.Width,
                        zone.X,
                        zone.Y});
                }
            }

            advancedDataGridView_ForbiddenZones.DataSource = dt;
        }

        private void Load_DataGridZones()
        {
            DataTable dt = new DataTable();
            DataColumn code_zone = new DataColumn("Код зоны размещения", Type.GetType("System.String"));
            DataColumn name = new DataColumn("Наименование зоны", Type.GetType("System.String"));
            DataColumn height = new DataColumn("Длина зоны", Type.GetType("System.String"));
            DataColumn width = new DataColumn("Ширина зоны", Type.GetType("System.String"));
            dt.Columns.Add(@code_zone);
            dt.Columns.Add(@name);
            dt.Columns.Add(@height);
            dt.Columns.Add(width);

            if (Project.instance.ZonesRef.ListofZonesRef.Count > 0) 
            {
                foreach (Zone zone in Project.instance.ZonesRef.ListofZonesRef)
                {
                    dt.Rows.Add(new object[] {
                        zone.Id,
                        zone.Name,
                        zone.Height,
                        zone.Width});
                }
            }

            advancedDataGridView_Zones.DataSource = dt;
        }

        private void SaveZone_Click(object sender, EventArgs e)
        {
            Project.instance.ZonesRef.ListofZonesRef.AddRange(_listofZones.ListofZonesRef);
        }

        private void AddZone_Click(object sender, EventArgs e)
        {
            Zone zone = new Zone();
            zone.Id = int.Parse(CodeZone_TextBox.Text);
            zone.Name = NameZone_TextBox.Text;
            zone.Width = double.Parse(WidthZone_TextBox.Text);
            zone.Height = double.Parse(HeightZone_TextBox.Text);

            if (!_listofZones.Equals(zone))
            {
                _listofZones.ListofZonesRef.Add(zone);
            }
        }

        private void SaveForbiddenZone_Click(object sender, EventArgs e)
        {
            Project.instance.PCB.ForbiddenZonesRef.ListForbiddenZoneRef.AddRange(_listofForbiddenZones.ListForbiddenZoneRef);
        }

        private void AddForbiddenZone_Click(object sender, EventArgs e)
        {
            ForbiddenZone zone = new ForbiddenZone();
            zone.Id = int.Parse(CodeForbiddenZone_TextBox.Text);
            zone.Width = double.Parse(WidthForbiddenZone_TextBox.Text);
            zone.Height = double.Parse(HeightForbiddenZone_TextBox.Text);
            zone.X = double.Parse(XForbiddenZone_TextBox.Text);
            zone.Y = double.Parse(YForbiddenZone_TextBox.Text);

            if (!_listofForbiddenZones.Equals(zone)) 
            {
                _listofForbiddenZones.ListForbiddenZoneRef.Add(zone);
            }
        }
    }
}
