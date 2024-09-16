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
    public partial class AlgorithmSettings : Form
    {
        private bool isFullData = false;
        private AlgorithmParameters parameters;

        public AlgorithmSettings()
        {
            InitializeComponent();

            this.parameters = new AlgorithmParameters();

            Load_Data();

            textBox_A1.Text = parameters.A1.ToString();
            textBox_A2.Text = parameters.A2.ToString();
            textBox_A3.Text = parameters.A3.ToString();
            textBox_T_max.Text = parameters.T_max.ToString();
            textBox_Nu0.Text = parameters.Nu0.ToString();
        }

        private void Load_Data()
        {
            parameters = Project.instance.AlgorithmParametersRef;
        }

        public bool IsFullData
        {
            get { return isFullData; }
            private set { isFullData = value; }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            Project.instance.AlgorithmParametersRef = parameters;
        }

        private void textBox_A1_TextChanged(object sender, EventArgs e)
        {
            parameters.A1 = textBox_Changed1(textBox_A1);
        }

        private void textBox_A2_TextChanged(object sender, EventArgs e)
        {
            parameters.A2 = textBox_Changed1(textBox_A2);
        }

        private void textBox_A3_TextChanged(object sender, EventArgs e)
        {
            parameters.A3 = textBox_Changed1(textBox_A3);
        }

        private void textBox_T_max_TextChanged(object sender, EventArgs e)
        {
            parameters.T_max = textBox_Changed2(textBox_T_max);
        }

        private void textBox_Nu0_TextChanged(object sender, EventArgs e)
        {
            parameters.Nu0 = textBox_Changed1(textBox_Nu0);
        }

        private double textBox_Changed1(TextBox textBox)
        {
            if (!Double.TryParse(textBox.Text, out var result))
            {
                errorProvider.SetError(textBox, "Только тип данных double разрешен!");
                return 0;
            }
            else
            {
                if (result < 0 && result > 1)
                {
                    errorProvider.SetError(textBox, "Значение должно находиться в пределе от 0 до 1!");
                    return 0;
                }
                else
                {
                    errorProvider.Clear();
                    return result;
                }
            }
        }

        private double textBox_Changed2(TextBox textBox)
        {
            if (!Double.TryParse(textBox.Text, out var result))
            {
                errorProvider.SetError(textBox, "Только тип данных double разрешен!");
                return 0;
            }
            else
            {
                if (result <= 0)
                {
                    errorProvider.SetError(textBox, "Значение должно быть выше 0!");
                    return 0;
                }
                else
                {
                    errorProvider.Clear();
                    return result;
                }
            }
        }
    }
}
