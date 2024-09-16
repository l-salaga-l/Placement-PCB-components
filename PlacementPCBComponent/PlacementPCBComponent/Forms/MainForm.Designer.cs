namespace VKR
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseProject = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.Close = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataofPCB_button = new System.Windows.Forms.ToolStripMenuItem();
            this.DataofComponents_button = new System.Windows.Forms.ToolStripMenuItem();
            this.dataofFootprints_button = new System.Windows.Forms.ToolStripMenuItem();
            this.dataofPins_button = new System.Windows.Forms.ToolStripMenuItem();
            this.dataofWires_button = new System.Windows.Forms.ToolStripMenuItem();
            this.DataofZones_button = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.AlgorithmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.Comply_button = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgramm = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.coordinate_X = new System.Windows.Forms.ToolStripStatusLabel();
            this.coordinate_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelForDraw = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelForDraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem5});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewProject,
            this.OpenProject,
            this.CloseProject,
            this.SaveProject,
            this.RemoveProject,
            this.Close});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // NewProject
            // 
            this.NewProject.Name = "NewProject";
            resources.ApplyResources(this.NewProject, "NewProject");
            this.NewProject.Click += new System.EventHandler(this.NewProject_Click);
            // 
            // OpenProject
            // 
            this.OpenProject.Name = "OpenProject";
            resources.ApplyResources(this.OpenProject, "OpenProject");
            this.OpenProject.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // CloseProject
            // 
            resources.ApplyResources(this.CloseProject, "CloseProject");
            this.CloseProject.Name = "CloseProject";
            this.CloseProject.Click += new System.EventHandler(this.CloseProject_Click);
            // 
            // SaveProject
            // 
            resources.ApplyResources(this.SaveProject, "SaveProject");
            this.SaveProject.Name = "SaveProject";
            this.SaveProject.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // RemoveProject
            // 
            resources.ApplyResources(this.RemoveProject, "RemoveProject");
            this.RemoveProject.Name = "RemoveProject";
            this.RemoveProject.Click += new System.EventHandler(this.RemoveProject_Click);
            // 
            // Close
            // 
            this.Close.Name = "Close";
            resources.ApplyResources(this.Close, "Close");
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataofPCB_button,
            this.DataofComponents_button,
            this.dataofFootprints_button,
            this.dataofPins_button,
            this.dataofWires_button,
            this.DataofZones_button});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // DataofPCB_button
            // 
            resources.ApplyResources(this.DataofPCB_button, "DataofPCB_button");
            this.DataofPCB_button.Name = "DataofPCB_button";
            this.DataofPCB_button.Click += new System.EventHandler(this.DataofPCB_Click);
            // 
            // DataofComponents_button
            // 
            resources.ApplyResources(this.DataofComponents_button, "DataofComponents_button");
            this.DataofComponents_button.Name = "DataofComponents_button";
            this.DataofComponents_button.Click += new System.EventHandler(this.DataofComponents_Click);
            // 
            // dataofFootprints_button
            // 
            resources.ApplyResources(this.dataofFootprints_button, "dataofFootprints_button");
            this.dataofFootprints_button.Name = "dataofFootprints_button";
            this.dataofFootprints_button.Click += new System.EventHandler(this.DataofFootprints_Click);
            // 
            // dataofPins_button
            // 
            resources.ApplyResources(this.dataofPins_button, "dataofPins_button");
            this.dataofPins_button.Name = "dataofPins_button";
            this.dataofPins_button.Click += new System.EventHandler(this.DataofPins_Click);
            // 
            // dataofWires_button
            // 
            resources.ApplyResources(this.dataofWires_button, "dataofWires_button");
            this.dataofWires_button.Name = "dataofWires_button";
            this.dataofWires_button.Click += new System.EventHandler(this.DataofWires_Click);
            // 
            // DataofZones_button
            // 
            resources.ApplyResources(this.DataofZones_button, "DataofZones_button");
            this.DataofZones_button.Name = "DataofZones_button";
            this.DataofZones_button.Click += new System.EventHandler(this.DataofZones_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AlgorithmSettings,
            this.Comply_button});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // AlgorithmSettings
            // 
            resources.ApplyResources(this.AlgorithmSettings, "AlgorithmSettings");
            this.AlgorithmSettings.Name = "AlgorithmSettings";
            this.AlgorithmSettings.Click += new System.EventHandler(this.SettingsAlgorithm_Click);
            // 
            // Comply_button
            // 
            this.Comply_button.Name = "Comply_button";
            resources.ApplyResources(this.Comply_button, "Comply_button");
            this.Comply_button.Click += new System.EventHandler(this.Comply_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help,
            this.AboutProgramm});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // Help
            // 
            this.Help.Name = "Help";
            resources.ApplyResources(this.Help, "Help");
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // AboutProgramm
            // 
            this.AboutProgramm.Name = "AboutProgramm";
            resources.ApplyResources(this.AboutProgramm, "AboutProgramm");
            this.AboutProgramm.Click += new System.EventHandler(this.AboutProgramm_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordinate_X,
            this.coordinate_Y});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // coordinate_X
            // 
            this.coordinate_X.Name = "coordinate_X";
            resources.ApplyResources(this.coordinate_X, "coordinate_X");
            // 
            // coordinate_Y
            // 
            this.coordinate_Y.Name = "coordinate_Y";
            resources.ApplyResources(this.coordinate_Y, "coordinate_Y");
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // panelForDraw
            // 
            resources.ApplyResources(this.panelForDraw, "panelForDraw");
            this.panelForDraw.Controls.Add(this.pictureBox1);
            this.panelForDraw.Name = "panelForDraw";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelForDraw);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelForDraw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem NewProject;
        private System.Windows.Forms.ToolStripMenuItem OpenProject;
        private System.Windows.Forms.ToolStripMenuItem CloseProject;
        private System.Windows.Forms.ToolStripMenuItem SaveProject;
        private System.Windows.Forms.ToolStripMenuItem RemoveProject;
        private System.Windows.Forms.ToolStripMenuItem Close;
        private System.Windows.Forms.ToolStripMenuItem DataofComponents_button;
        private System.Windows.Forms.ToolStripMenuItem DataofPCB_button;
        private System.Windows.Forms.ToolStripMenuItem dataofWires_button;
        private System.Windows.Forms.ToolStripMenuItem AlgorithmSettings;
        private System.Windows.Forms.ToolStripMenuItem Comply_button;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.ToolStripMenuItem AboutProgramm;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel coordinate_X;
        private System.Windows.Forms.ToolStripStatusLabel coordinate_Y;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelForDraw;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolStripMenuItem dataofFootprints_button;
        private System.Windows.Forms.ToolStripMenuItem dataofPins_button;
        private System.Windows.Forms.ToolStripMenuItem DataofZones_button;
    }
}

