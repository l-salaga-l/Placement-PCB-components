using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.Tools;
using Zuby.ADGV;

namespace VKR.Forms
{
    public partial class TablesPCB : Form
    {
        private static string _markingPCB;

        public static string MarkingPCB
        {
            get
            {
                return _markingPCB;
            }
            set 
            {
                if (value != _markingPCB)
                {
                    _markingPCB = value;
                }
            }
        }

        public TablesPCB()
        {
            InitializeComponent();

            tablePCB.DataSource = Database.GetTable("PCB");
        }

        private void Select_Click(object sender, EventArgs e)
        {
            if (tablePCB.SelectedCells.Count == 1) 
            {
                int rowIndex = tablePCB.SelectedCells[0].RowIndex;

                MarkingPCB = (string)tablePCB.Rows[rowIndex].Cells[0].Value;

                Close();
            }
            else
            {
                MessageBox.Show(
                    "Должна быть выбрана одна строка!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tablePCB_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {

        }
    }
}
