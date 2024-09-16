using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VKR.Entities;
using VKR.Tools;

namespace VKR.Forms
{
    public partial class DataofPCB : Form
    {
        private double grid = 0;

        public DataofPCB()
        {
            InitializeComponent();
        }

        public double Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        private void textBox_Grid_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(textBox_Grid.Text, out var result))
            {
                grid = 0;
                errorProvider1.SetError(textBox_Grid, "Только тип данных double разрешен!");
            }
            else
            {
                if (result <= 0)
                {
                    grid = 0;
                    errorProvider1.SetError(textBox_Grid, "Значение должно быть выше 0!");
                }
                else
                {
                    grid = result;
                    errorProvider1.Clear();
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (textBox_MarkingPCB.Text != String.Empty
                && textBox_HeightPCB.Text != String.Empty
                && textBox_WidthPCB.Text != String.Empty
                && textBox_Grid.Text != String.Empty)
            {
                Project.instance.PCB = PCB.CreatePCB(textBox_MarkingPCB.Text, textBox_HeightPCB.Text, textBox_WidthPCB.Text);

                Project.instance.PCB.Grid = Double.Parse(textBox_Grid.Text);

                Close();
            }
            else
            {
                MessageBox.Show(
                    "Все текстовые поля должны быть заполнены!",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            if (Database.GetInfoConnection())
            {
                TablesPCB form = new TablesPCB();

                form.button1.Click += SelectedPCB_Click;

                form.Show();
            }
        }

        private void SelectedPCB_Click(object sender, EventArgs e)
        {
            string markingPCB = TablesPCB.MarkingPCB;

            TablesPCB.MarkingPCB = string.Empty;

            List<string>[] data = Database.SelectCommand("PCB", where: $"PCB.PCB_Marking = \'{markingPCB}\'");

            if (data != null)
            {
                textBox_MarkingPCB.Text = data[0][0];
                textBox_HeightPCB.Text = data[1][0];
                textBox_WidthPCB.Text = data[2][0];
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            textBox_MarkingPCB.Text = String.Empty;
            textBox_HeightPCB.Text = String.Empty;
            textBox_WidthPCB.Text = String.Empty;
            textBox_Grid.Text = String.Empty;

            Project.instance.PCB = null;
        }

        private void DataofPCB_Load(object sender, EventArgs e)
        {
            if (Project.instance.PCB != null)
            {
                textBox_MarkingPCB.Text = Project.instance.PCB.Marking;
                textBox_HeightPCB.Text = Project.instance.PCB.Height.ToString();
                textBox_WidthPCB.Text = Project.instance.PCB.Width.ToString();
                textBox_Grid.Text = Project.instance.PCB.Grid.ToString();
            }
        }
    }
}
