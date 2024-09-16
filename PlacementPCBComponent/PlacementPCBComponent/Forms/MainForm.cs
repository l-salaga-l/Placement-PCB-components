using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using VKR.Algorihm;
using VKR.Entities;
using VKR.Forms;
using VKR.Tools;

namespace VKR
{
    public partial class MainForm : Form
    {
        #region Поля

        private Bitmap imgtmp;
        private System.Drawing.Point mouseDownPoint = new System.Drawing.Point();
        private int zoomstep = 50;
        private bool isMove = false;
        private bool isOpenProject = false;
        private bool isFullData = false;
        private bool isFullDataofComponents = false;
        private bool isFullDataofPlate = false;
        private bool isFullDataofConnections = false;
        private bool isFullSettings = false;
        private bool isCompletedPlacement = false;

        #endregion

        #region Свойства

        private bool IsOpenProject
        {
            get { return isOpenProject; }
            set
            {
                isOpenProject = value;
                if (isOpenProject)
                {
                    EnableControls();
                }
                else
                {
                    DisableControls();
                }
            }
        }

        private bool IsFullDataofComponents
        {
            get { return isFullDataofComponents; }
            set
            {
                isFullDataofComponents = value;

                if (isFullDataofComponents == true)
                {
                    dataofFootprints_button.Enabled = true;
                    dataofPins_button.Enabled = true;
                    dataofWires_button.Enabled = true;
                }
                else
                {
                    dataofFootprints_button.Enabled = false;
                    dataofPins_button.Enabled = false;
                    dataofWires_button.Enabled = false;
                }

                if (isFullDataofComponents && isFullDataofConnections && isFullDataofPlate && isFullSettings)
                {
                    IsFullData = true;
                }
                else
                {
                    IsFullData = false;
                }
            }
        }

        private bool IsFullDataofPlate
        {
            get { return isFullDataofPlate; }
            set
            {
                isFullDataofPlate = value;

                if (isFullDataofComponents && isFullDataofConnections && isFullDataofPlate && isFullSettings)
                {
                    IsFullData = true;
                }
                else
                {
                    IsFullData = false;
                }
            }
        }

        private bool IsFullSettings
        {
            get { return isFullSettings; }
            set
            {
                isFullSettings = value;

                if (isFullDataofComponents && isFullDataofPlate && isFullSettings)
                {
                    IsFullData = true;
                }
                else
                {
                    IsFullData = false;
                }
            }
        }

        private bool IsFullData
        {
            get { return isFullData; }
            set
            {
                isFullData = value;

                if (isFullData)
                {
                    EnableControls();

                    Util.GetSizeZones();

                    DrawPCB();
                }
                else
                {
                    DisableControls();
                }
            }
        }

        private bool IsCompletedPlacement
        {
            get { return isCompletedPlacement; }
            set
            {
                isCompletedPlacement = value;

                if (isCompletedPlacement)
                {
                    EnableControls();
                }
                else
                {
                    DisableControls();
                }
            }
        }

        #endregion

        public MainForm()
        {

            InitializeComponent();

            this.FormClosed += MainForm_FormClosed;

            Database.Connect();

            ControlsRefresh();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Database.Disconnect();
        }

        #region События и методы, связанные с PictureBox

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = false;
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
                pictureBox1.Focus();
            }
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            int ow = pictureBox1.Width;
            int oh = pictureBox1.Height;
            int VX, VY;
            if (e.Delta > 0)
            {
                pictureBox1.Width += zoomstep;
                pictureBox1.Height += zoomstep;

                PropertyInfo pInfo = pictureBox1.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                    BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pictureBox1, null);

                pictureBox1.Width = rect.Width;
                pictureBox1.Height = rect.Height;
            }
            if (e.Delta < 0)
            {

                if (pictureBox1.Width < imgtmp.Width / 10)
                    return;

                pictureBox1.Width -= zoomstep;
                pictureBox1.Height -= zoomstep;
                PropertyInfo pInfo = pictureBox1.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                    BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pictureBox1, null);
                pictureBox1.Width = rect.Width;
                pictureBox1.Height = rect.Height;
            }

            VX = (int)((double)x * (ow - pictureBox1.Width) / ow);
            VY = (int)((double)y * (oh - pictureBox1.Height) / oh);
            pictureBox1.Location = new System.Drawing.Point(pictureBox1.Location.X + VX, pictureBox1.Location.Y + VY);
        }

        public void DrawPCB()
        {
            Draw draw = new Draw(pictureBox1.Width, pictureBox1.Height);

            draw.DrawPCB(Project.instance.PCB);
            draw.DrawComponents(Project.instance.Scheme.ComponentsRef);
            draw.DrawZones(Project.instance.ZonesRef);
            if (Project.instance.PCB.ForbiddenZonesRef.ListForbiddenZoneRef.Count > 0)
            {
                draw.DrawForbiddenZones(Project.instance.PCB.ForbiddenZonesRef);
            }
            draw.DrawFunction();

            pictureBox1.Image = draw.Image;
            pictureBox1.Refresh();
        }

        #endregion

        #region Выпадающий список "Файл"

        #region Кнопка "Создать"

        /// <summary> Открытие формы для создания проекта </summary>
        private void NewProject_Click(object sender, EventArgs e)
        {
            NewProject form = new NewProject();

            form.CreateButton.Click += NewProject_Create_Click;

            form.Show();
        }

        /// <summary> Создание проекта </summary>
        private void NewProject_Create_Click(object sender, EventArgs e)
        {
            IsOpenProject = Project.instance.IsCreated;
        }

        #endregion

        #region Кнопка "Открыть"

        /// <summary> Открытие проекта </summary>
        private void OpenProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Project files Delta Design(*.DDC)|*.DDC|Project files (*.xml)|*.xml";

            if (openDialog.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show(
                    "Не загружен проект",
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                string filename = openDialog.FileName;

                ToolForExport tool = new ToolForExport();

                tool.Export(filename);

                Util.GetPower();

                IsOpenProject = true;
                IsFullDataofPlate = true;
                //IsFullData = true;
            }
        }
        #endregion

        #region Кнопка "Закрыть"

        /// <summary> Закрытие проекта </summary>
        private void CloseProject_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Проект закрыт",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            IsOpenProject = false;

            Project.instance = null;
        }

        #endregion

        #region Кнопка "Сохранить"

        /// <summary> Сохранение проекта </summary>
        private async void SaveProject_Click(object sender, EventArgs e)
        {
            // Создаем диалоговое окно для сохранении
            SaveFileDialog saveDialog = new SaveFileDialog();
            // Определяем расширение файла
            saveDialog.Filter = "Project files Delta Design(*.DDC)|*.DDC|Project files (*.xml)|*.xml";

            // открываем окно сохранения
            if (saveDialog.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show(
                    "Проект не сохранен",
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                // присваниваем строке путь из открытого нами окна
                string filename = saveDialog.FileName;

                ToolForSave tool = new ToolForSave();
                tool.Save(filename);
            }
        }

        #endregion

        #region Кнопка "Удалить"

        /// <summary> Удаление проекта </summary>
        private void RemoveProject_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы точно хотите удалить проект?",
                "Сообщение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1, 
                MessageBoxOptions.DefaultDesktopOnly);

            if (result.CompareTo(DialogResult.Yes) == 0)
            {
                IsOpenProject = false;

                Project.instance = null;

                MessageBox.Show(
                    "Проект удален",
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Кнопка "Выход"

        /// <summary> Закрытие программы </summary>
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #endregion

        #region Выпадающий список "Проект"

        #region Взаимодействие с таблицей "Данные о компонентах"

        private void DataofComponents_Click(object sender, EventArgs e)
        {
            DataofComponents form = new DataofComponents();

            form.save_button.Click += DataofComponents_Save_Click;

            form.Show();
        }

        private void DataofComponents_Save_Click(object sender, EventArgs e)
        {
            IsFullDataofComponents = true;
        }

        #endregion

        #region Взаимодействие с таблицей "Данные о печатной плате"

        private void DataofPCB_Click(object sender, EventArgs e)
        {
            DataofPCB form = new DataofPCB();

            form.saveButton.Click += DataofPCB_Save_Click;

            form.Show();
        }

        private void DataofPCB_Save_Click(object sender, EventArgs e)
        {
            IsFullDataofPlate = true;

            DrawPCB();
        }

        #endregion

        #region Взаимодействие с таблицей "Данные о цепях"

        private void DataofWires_Click(object sender, EventArgs e)
        {
            DataofWires form = new DataofWires();

            form.Show();
        }

        #endregion

        #region Кнопка "Данные о посадочных местах"

        private void DataofFootprints_Click(object sender, EventArgs e)
        {
            DataofFootprints form = new DataofFootprints();

            form.Show();
        }

        #endregion

        #region Кнопка "Данные о выводах компонентов"

        private void DataofPins_Click(object sender, EventArgs e)
        {
            DataofPins form = new DataofPins();

            form.Show();
        }

        #endregion

        #region Кнопка "Данные о зонах"

        private void DataofZones_Click(object sender, EventArgs e)
        {
            DataofZones form = new DataofZones();

            form.Show();
        }

        #endregion

        #endregion

        #region Выпадающий список "Выполнить"

        #region Кнопка "Настройка алгоритма"

        private void SettingsAlgorithm_Click(object sender, EventArgs e)
        {
            AlgorithmSettings form = new AlgorithmSettings();

            form.save_button.Click += Save_button_Click;

            form.Show();
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            IsFullSettings = true;
        }

        #endregion

        #region Кнопка "Выполнить проектную процедуру"

        private void Comply_Click(object sender, EventArgs e)
        {
            Placement algorithm = new Placement();
            algorithm.Start();

            IsCompletedPlacement = true;

            DrawPCB();
        }

        #endregion

        #endregion

        #region Выпадающий список "Справка"

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Документация к программе открыта",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void AboutProgramm_Click(object sender, EventArgs e)
        {
            Reference form = new Reference();
            form.ShowDialog();
        }

        #endregion

        #region Обновление блоков управления и переменных

        private void ControlsRefresh()
        {
            pictureBox1.Image = imgtmp;

            panelForDraw.BackColor = Color.White;

            pictureBox1.MouseWheel += PictureBox_MouseWheel;
        }

        private void EnableControls()
        {
            if (IsOpenProject && !IsFullData && !IsCompletedPlacement)
            {
                CloseProject.Enabled = true;
                RemoveProject.Enabled = true;
                SaveProject.Enabled = true;
                DataofComponents_button.Enabled = true;
                DataofPCB_button.Enabled = true;
                dataofWires_button.Enabled = true;
                DataofZones_button.Enabled = true;
                AlgorithmSettings.Enabled = true;
            }
            if (IsFullData && !IsCompletedPlacement)
            {
                Comply_button.Enabled = true;
            }
        }

        private void DisableControls() 
        {
            if (!IsOpenProject)
            {
                CloseProject.Enabled = false;
                RemoveProject.Enabled = false;
                SaveProject.Enabled = false;
                DataofComponents_button.Enabled = false;
                DataofPCB_button.Enabled = false;
                dataofWires_button.Enabled = false;
                DataofZones_button.Enabled = false;
                AlgorithmSettings.Enabled = false;
            }
            if (!IsFullData)
            {
                Comply_button.Enabled = false;
            }
        }

        #endregion
    }
}
