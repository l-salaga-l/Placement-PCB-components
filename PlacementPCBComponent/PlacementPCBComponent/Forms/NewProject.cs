using System;
using System.Windows.Forms;
using VKR.Entities;

namespace VKR
{
    public partial class NewProject : Form
    {
        private string nameOfProject = "New Project";

        public NewProject()
        {
            InitializeComponent();

            nameText.Text = nameOfProject;
        }

        #region Properties

        private string NameOfProject
        {
            get { return nameOfProject; }
            set
            {
                nameOfProject = value;

                if (nameOfProject != null && nameOfProject != string.Empty) 
                {
                    CreateButton.Enabled = true;
                }
                else
                {
                    CreateButton.Enabled = false;
                }
            }
        }

        #endregion

        #region Events

        private void NameText_TextChanged(object sender, EventArgs e)
        {
            NameOfProject = nameText.Text;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Project.CreateProject(NameOfProject);

            Close();
        }

        #endregion
    }
}
