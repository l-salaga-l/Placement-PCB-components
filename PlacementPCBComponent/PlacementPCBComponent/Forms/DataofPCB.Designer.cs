namespace VKR.Forms
{
    partial class DataofPCB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataofPCB));
            this.Choose = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.textBox_MarkingPCB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_HeightPCB = new System.Windows.Forms.TextBox();
            this.textBox_WidthPCB = new System.Windows.Forms.TextBox();
            this.textBox_Grid = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Choose
            // 
            this.Choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Choose.Location = new System.Drawing.Point(240, 146);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(101, 34);
            this.Choose.TabIndex = 0;
            this.Choose.Text = "Выбрать";
            this.Choose.UseVisualStyleBackColor = true;
            this.Choose.Click += new System.EventHandler(this.Choose_Click);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete.Location = new System.Drawing.Point(454, 146);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(101, 34);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(347, 146);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 34);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // textBox_MarkingPCB
            // 
            this.textBox_MarkingPCB.Location = new System.Drawing.Point(240, 15);
            this.textBox_MarkingPCB.Name = "textBox_MarkingPCB";
            this.textBox_MarkingPCB.Size = new System.Drawing.Size(314, 24);
            this.textBox_MarkingPCB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Маркировка печатной платы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Длина";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ширина";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Размер сетки";
            // 
            // textBox_HeightPCB
            // 
            this.textBox_HeightPCB.Location = new System.Drawing.Point(240, 45);
            this.textBox_HeightPCB.Name = "textBox_HeightPCB";
            this.textBox_HeightPCB.Size = new System.Drawing.Size(314, 24);
            this.textBox_HeightPCB.TabIndex = 8;
            // 
            // textBox_WidthPCB
            // 
            this.textBox_WidthPCB.Location = new System.Drawing.Point(240, 75);
            this.textBox_WidthPCB.Name = "textBox_WidthPCB";
            this.textBox_WidthPCB.Size = new System.Drawing.Size(314, 24);
            this.textBox_WidthPCB.TabIndex = 9;
            // 
            // textBox_Grid
            // 
            this.textBox_Grid.Location = new System.Drawing.Point(240, 105);
            this.textBox_Grid.Name = "textBox_Grid";
            this.textBox_Grid.Size = new System.Drawing.Size(314, 24);
            this.textBox_Grid.TabIndex = 10;
            this.textBox_Grid.TextChanged += new System.EventHandler(this.textBox_Grid_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DataofPCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 196);
            this.Controls.Add(this.textBox_Grid);
            this.Controls.Add(this.textBox_WidthPCB);
            this.Controls.Add(this.textBox_HeightPCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_MarkingPCB);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Choose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataofPCB";
            this.Text = "Данные о печатной плате";
            this.Load += new System.EventHandler(this.DataofPCB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Choose;
        private System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox textBox_MarkingPCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_HeightPCB;
        private System.Windows.Forms.TextBox textBox_WidthPCB;
        private System.Windows.Forms.TextBox textBox_Grid;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}