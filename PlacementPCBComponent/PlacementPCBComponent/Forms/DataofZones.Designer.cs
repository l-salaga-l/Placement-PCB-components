namespace VKR.Forms
{
    partial class DataofZones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.advancedDataGridView_Zones = new Zuby.ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.XForbiddenZone_TextBox = new System.Windows.Forms.TextBox();
            this.advancedDataGridView_ForbiddenZones = new Zuby.ADGV.AdvancedDataGridView();
            this.SaveZone = new System.Windows.Forms.Button();
            this.SaveForbiddenZone = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.YForbiddenZone_TextBox = new System.Windows.Forms.TextBox();
            this.WidthForbiddenZone_TextBox = new System.Windows.Forms.TextBox();
            this.HeightForbiddenZone_TextBox = new System.Windows.Forms.TextBox();
            this.CodeForbiddenZone_TextBox = new System.Windows.Forms.TextBox();
            this.AddForbiddenZone = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CodeZone_TextBox = new System.Windows.Forms.TextBox();
            this.NameZone_TextBox = new System.Windows.Forms.TextBox();
            this.HeightZone_TextBox = new System.Windows.Forms.TextBox();
            this.WidthZone_TextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AddZone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_Zones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_ForbiddenZones)).BeginInit();
            this.SuspendLayout();
            // 
            // advancedDataGridView_Zones
            // 
            this.advancedDataGridView_Zones.AllowUserToAddRows = false;
            this.advancedDataGridView_Zones.AllowUserToDeleteRows = false;
            this.advancedDataGridView_Zones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridView_Zones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView_Zones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.advancedDataGridView_Zones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_Zones.FilterAndSortEnabled = true;
            this.advancedDataGridView_Zones.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView_Zones.Location = new System.Drawing.Point(12, 32);
            this.advancedDataGridView_Zones.MaxFilterButtonImageHeight = 23;
            this.advancedDataGridView_Zones.Name = "advancedDataGridView_Zones";
            this.advancedDataGridView_Zones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView_Zones.RowHeadersVisible = false;
            this.advancedDataGridView_Zones.RowHeadersWidth = 51;
            this.advancedDataGridView_Zones.RowTemplate.Height = 24;
            this.advancedDataGridView_Zones.Size = new System.Drawing.Size(404, 150);
            this.advancedDataGridView_Zones.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView_Zones.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Данные о зонах размещения компонентов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Данные о размещении запрещенных зон";
            // 
            // XForbiddenZone_TextBox
            // 
            this.XForbiddenZone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XForbiddenZone_TextBox.Location = new System.Drawing.Point(625, 360);
            this.XForbiddenZone_TextBox.Name = "XForbiddenZone_TextBox";
            this.XForbiddenZone_TextBox.Size = new System.Drawing.Size(100, 22);
            this.XForbiddenZone_TextBox.TabIndex = 3;
            // 
            // advancedDataGridView_ForbiddenZones
            // 
            this.advancedDataGridView_ForbiddenZones.AllowUserToAddRows = false;
            this.advancedDataGridView_ForbiddenZones.AllowUserToDeleteRows = false;
            this.advancedDataGridView_ForbiddenZones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridView_ForbiddenZones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView_ForbiddenZones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.advancedDataGridView_ForbiddenZones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_ForbiddenZones.FilterAndSortEnabled = true;
            this.advancedDataGridView_ForbiddenZones.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView_ForbiddenZones.Location = new System.Drawing.Point(12, 270);
            this.advancedDataGridView_ForbiddenZones.MaxFilterButtonImageHeight = 23;
            this.advancedDataGridView_ForbiddenZones.Name = "advancedDataGridView_ForbiddenZones";
            this.advancedDataGridView_ForbiddenZones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView_ForbiddenZones.RowHeadersVisible = false;
            this.advancedDataGridView_ForbiddenZones.RowHeadersWidth = 51;
            this.advancedDataGridView_ForbiddenZones.RowTemplate.Height = 24;
            this.advancedDataGridView_ForbiddenZones.Size = new System.Drawing.Size(404, 150);
            this.advancedDataGridView_ForbiddenZones.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView_ForbiddenZones.TabIndex = 4;
            // 
            // SaveZone
            // 
            this.SaveZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveZone.Location = new System.Drawing.Point(326, 188);
            this.SaveZone.Name = "SaveZone";
            this.SaveZone.Size = new System.Drawing.Size(90, 30);
            this.SaveZone.TabIndex = 5;
            this.SaveZone.Text = "Сохранить";
            this.SaveZone.UseVisualStyleBackColor = true;
            this.SaveZone.Click += new System.EventHandler(this.SaveZone_Click);
            // 
            // SaveForbiddenZone
            // 
            this.SaveForbiddenZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveForbiddenZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveForbiddenZone.Location = new System.Drawing.Point(326, 426);
            this.SaveForbiddenZone.Name = "SaveForbiddenZone";
            this.SaveForbiddenZone.Size = new System.Drawing.Size(90, 30);
            this.SaveForbiddenZone.TabIndex = 6;
            this.SaveForbiddenZone.Text = "Сохранить";
            this.SaveForbiddenZone.UseVisualStyleBackColor = true;
            this.SaveForbiddenZone.Click += new System.EventHandler(this.SaveForbiddenZone_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.No;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(439, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Код запрещенной зоны:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.No;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(439, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Длина:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.No;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(439, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ширина:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.No;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(439, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Координата по оси ОХ:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.No;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(439, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "Координата по оси ОУ:";
            // 
            // YForbiddenZone_TextBox
            // 
            this.YForbiddenZone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YForbiddenZone_TextBox.Location = new System.Drawing.Point(625, 390);
            this.YForbiddenZone_TextBox.Name = "YForbiddenZone_TextBox";
            this.YForbiddenZone_TextBox.Size = new System.Drawing.Size(100, 22);
            this.YForbiddenZone_TextBox.TabIndex = 12;
            // 
            // WidthForbiddenZone_TextBox
            // 
            this.WidthForbiddenZone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthForbiddenZone_TextBox.Location = new System.Drawing.Point(625, 330);
            this.WidthForbiddenZone_TextBox.Name = "WidthForbiddenZone_TextBox";
            this.WidthForbiddenZone_TextBox.Size = new System.Drawing.Size(100, 22);
            this.WidthForbiddenZone_TextBox.TabIndex = 13;
            // 
            // HeightForbiddenZone_TextBox
            // 
            this.HeightForbiddenZone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeightForbiddenZone_TextBox.Location = new System.Drawing.Point(625, 300);
            this.HeightForbiddenZone_TextBox.Name = "HeightForbiddenZone_TextBox";
            this.HeightForbiddenZone_TextBox.Size = new System.Drawing.Size(100, 22);
            this.HeightForbiddenZone_TextBox.TabIndex = 14;
            // 
            // CodeForbiddenZone_TextBox
            // 
            this.CodeForbiddenZone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeForbiddenZone_TextBox.Location = new System.Drawing.Point(625, 270);
            this.CodeForbiddenZone_TextBox.Name = "CodeForbiddenZone_TextBox";
            this.CodeForbiddenZone_TextBox.Size = new System.Drawing.Size(100, 22);
            this.CodeForbiddenZone_TextBox.TabIndex = 15;
            // 
            // AddForbiddenZone
            // 
            this.AddForbiddenZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddForbiddenZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddForbiddenZone.Location = new System.Drawing.Point(635, 426);
            this.AddForbiddenZone.Name = "AddForbiddenZone";
            this.AddForbiddenZone.Size = new System.Drawing.Size(90, 30);
            this.AddForbiddenZone.TabIndex = 16;
            this.AddForbiddenZone.Text = "Добавить";
            this.AddForbiddenZone.UseVisualStyleBackColor = true;
            this.AddForbiddenZone.Click += new System.EventHandler(this.AddForbiddenZone_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.No;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(439, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "Код зоны размещения:";
            // 
            // CodeZone_TextBox
            // 
            this.CodeZone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeZone_TextBox.Location = new System.Drawing.Point(625, 30);
            this.CodeZone_TextBox.Name = "CodeZone_TextBox";
            this.CodeZone_TextBox.Size = new System.Drawing.Size(100, 22);
            this.CodeZone_TextBox.TabIndex = 18;
            // 
            // NameZone_TextBox
            // 
            this.NameZone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NameZone_TextBox.Location = new System.Drawing.Point(625, 70);
            this.NameZone_TextBox.Name = "NameZone_TextBox";
            this.NameZone_TextBox.Size = new System.Drawing.Size(100, 22);
            this.NameZone_TextBox.TabIndex = 19;
            // 
            // HeightZone_TextBox
            // 
            this.HeightZone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeightZone_TextBox.Location = new System.Drawing.Point(625, 110);
            this.HeightZone_TextBox.Name = "HeightZone_TextBox";
            this.HeightZone_TextBox.Size = new System.Drawing.Size(100, 22);
            this.HeightZone_TextBox.TabIndex = 20;
            // 
            // WidthZone_TextBox
            // 
            this.WidthZone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthZone_TextBox.Location = new System.Drawing.Point(625, 150);
            this.WidthZone_TextBox.Name = "WidthZone_TextBox";
            this.WidthZone_TextBox.Size = new System.Drawing.Size(100, 22);
            this.WidthZone_TextBox.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.No;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(439, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "Наименование:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.No;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(439, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "Длина:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.No;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(439, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 18);
            this.label11.TabIndex = 24;
            this.label11.Text = "Ширина:";
            // 
            // AddZone
            // 
            this.AddZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddZone.Location = new System.Drawing.Point(635, 188);
            this.AddZone.Name = "AddZone";
            this.AddZone.Size = new System.Drawing.Size(90, 30);
            this.AddZone.TabIndex = 25;
            this.AddZone.Text = "Добавить";
            this.AddZone.UseVisualStyleBackColor = true;
            this.AddZone.Click += new System.EventHandler(this.AddZone_Click);
            // 
            // DataofZones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 466);
            this.Controls.Add(this.AddZone);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.WidthZone_TextBox);
            this.Controls.Add(this.HeightZone_TextBox);
            this.Controls.Add(this.NameZone_TextBox);
            this.Controls.Add(this.CodeZone_TextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AddForbiddenZone);
            this.Controls.Add(this.CodeForbiddenZone_TextBox);
            this.Controls.Add(this.HeightForbiddenZone_TextBox);
            this.Controls.Add(this.WidthForbiddenZone_TextBox);
            this.Controls.Add(this.YForbiddenZone_TextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SaveForbiddenZone);
            this.Controls.Add(this.SaveZone);
            this.Controls.Add(this.advancedDataGridView_ForbiddenZones);
            this.Controls.Add(this.XForbiddenZone_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.advancedDataGridView_Zones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataofZones";
            this.Text = "Данные о зонах";
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_Zones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_ForbiddenZones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_Zones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox XForbiddenZone_TextBox;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_ForbiddenZones;
        private System.Windows.Forms.Button SaveZone;
        private System.Windows.Forms.Button SaveForbiddenZone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox YForbiddenZone_TextBox;
        private System.Windows.Forms.TextBox WidthForbiddenZone_TextBox;
        private System.Windows.Forms.TextBox HeightForbiddenZone_TextBox;
        private System.Windows.Forms.TextBox CodeForbiddenZone_TextBox;
        private System.Windows.Forms.Button AddForbiddenZone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CodeZone_TextBox;
        private System.Windows.Forms.TextBox NameZone_TextBox;
        private System.Windows.Forms.TextBox HeightZone_TextBox;
        private System.Windows.Forms.TextBox WidthZone_TextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button AddZone;
    }
}