namespace VKR.Forms
{
    partial class AlgorithmSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_A1 = new System.Windows.Forms.TextBox();
            this.textBox_T_max = new System.Windows.Forms.TextBox();
            this.textBox_A2 = new System.Windows.Forms.TextBox();
            this.textBox_Nu0 = new System.Windows.Forms.TextBox();
            this.textBox_A3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.save_button = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Коэффициенты, определяющие важность критериев";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "+ Критерий минимизации суммарной \r\nвзвешенной длины";
            // 
            // textBox_A1
            // 
            this.textBox_A1.Location = new System.Drawing.Point(363, 50);
            this.textBox_A1.Name = "textBox_A1";
            this.textBox_A1.Size = new System.Drawing.Size(100, 22);
            this.textBox_A1.TabIndex = 3;
            this.textBox_A1.TextChanged += new System.EventHandler(this.textBox_A1_TextChanged);
            // 
            // textBox_T_max
            // 
            this.textBox_T_max.Location = new System.Drawing.Point(363, 189);
            this.textBox_T_max.Name = "textBox_T_max";
            this.textBox_T_max.Size = new System.Drawing.Size(100, 22);
            this.textBox_T_max.TabIndex = 4;
            this.textBox_T_max.TextChanged += new System.EventHandler(this.textBox_T_max_TextChanged);
            // 
            // textBox_A2
            // 
            this.textBox_A2.Location = new System.Drawing.Point(363, 93);
            this.textBox_A2.Name = "textBox_A2";
            this.textBox_A2.Size = new System.Drawing.Size(100, 22);
            this.textBox_A2.TabIndex = 5;
            this.textBox_A2.TextChanged += new System.EventHandler(this.textBox_A2_TextChanged);
            // 
            // textBox_Nu0
            // 
            this.textBox_Nu0.Location = new System.Drawing.Point(363, 217);
            this.textBox_Nu0.Name = "textBox_Nu0";
            this.textBox_Nu0.Size = new System.Drawing.Size(100, 22);
            this.textBox_Nu0.TabIndex = 8;
            this.textBox_Nu0.TextChanged += new System.EventHandler(this.textBox_Nu0_TextChanged);
            // 
            // textBox_A3
            // 
            this.textBox_A3.Location = new System.Drawing.Point(363, 136);
            this.textBox_A3.Name = "textBox_A3";
            this.textBox_A3.Size = new System.Drawing.Size(100, 22);
            this.textBox_A3.TabIndex = 11;
            this.textBox_A3.TextChanged += new System.EventHandler(this.textBox_A3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 36);
            this.label3.TabIndex = 12;
            this.label3.Text = "+ Критерий минимизации \r\nмаксимальной длины (ЭМС)\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(10, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(304, 36);
            this.label4.TabIndex = 13;
            this.label4.Text = "+ Критерий равномерного распределения \r\nтепловыделяющих компонентов\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(321, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "a1 =\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(320, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "a2 =\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(320, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "a3 =\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(10, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(344, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "Максимальное количество итераций               t =";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(10, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(346, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "Коэффициент соседства                                 η0 =";
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_button.Location = new System.Drawing.Point(373, 246);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(90, 30);
            this.save_button.TabIndex = 19;
            this.save_button.Text = "Сохранить";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AlgorithmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 288);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_A2);
            this.Controls.Add(this.textBox_T_max);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_A3);
            this.Controls.Add(this.textBox_Nu0);
            this.Controls.Add(this.textBox_A1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlgorithmSettings";
            this.Text = "Настройка параметров алгоритма";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_A1;
        private System.Windows.Forms.TextBox textBox_T_max;
        private System.Windows.Forms.TextBox textBox_A2;
        private System.Windows.Forms.TextBox textBox_Nu0;
        private System.Windows.Forms.TextBox textBox_A3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button save_button;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}