namespace VKR.Forms
{
    partial class TablesComponents
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableComponents = new Zuby.ADGV.AdvancedDataGridView();
            this.chooseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // tableComponents
            // 
            this.tableComponents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableComponents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableComponents.FilterAndSortEnabled = true;
            this.tableComponents.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.tableComponents.Location = new System.Drawing.Point(12, 12);
            this.tableComponents.MaxFilterButtonImageHeight = 23;
            this.tableComponents.Name = "tableComponents";
            this.tableComponents.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableComponents.RowHeadersVisible = false;
            this.tableComponents.RowHeadersWidth = 51;
            this.tableComponents.RowTemplate.Height = 24;
            this.tableComponents.Size = new System.Drawing.Size(508, 393);
            this.tableComponents.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.tableComponents.TabIndex = 0;
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(430, 411);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(90, 30);
            this.chooseButton.TabIndex = 1;
            this.chooseButton.Text = "Выбрать";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // TablesComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 453);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.tableComponents);
            this.Name = "TablesComponents";
            this.Text = "Данные о компонентах в базе данных";
            ((System.ComponentModel.ISupportInitialize)(this.tableComponents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView tableComponents;
        public System.Windows.Forms.Button chooseButton;
    }
}