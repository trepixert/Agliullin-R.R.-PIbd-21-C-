namespace ConfectioneryShopForm {
    partial class FormStoragesLoad {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.saveToExcel_Button = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.StorageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // saveToExcel_Button
            // 
            this.saveToExcel_Button.Location = new System.Drawing.Point(13, 13);
            this.saveToExcel_Button.Name = "saveToExcel_Button";
            this.saveToExcel_Button.Size = new System.Drawing.Size(75, 23);
            this.saveToExcel_Button.TabIndex = 0;
            this.saveToExcel_Button.Text = "Сохранить в Excel";
            this.saveToExcel_Button.UseVisualStyleBackColor = true;
            this.saveToExcel_Button.Click += new System.EventHandler(this.saveToExcel_Button_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StorageColumn,
            this.DetailColumn,
            this.CountColumn});
            this.dataGridView.Location = new System.Drawing.Point(0, 42);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(405, 385);
            this.dataGridView.TabIndex = 1;
            // 
            // StorageColumn
            // 
            this.StorageColumn.HeaderText = "Склад";
            this.StorageColumn.Name = "StorageColumn";
            // 
            // DetailColumn
            // 
            this.DetailColumn.HeaderText = "Компоненты";
            this.DetailColumn.Name = "DetailColumn";
            // 
            // CountColumn
            // 
            this.CountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CountColumn.HeaderText = "Количество";
            this.CountColumn.Name = "CountColumn";
            // 
            // FormStoragesLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 425);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.saveToExcel_Button);
            this.Name = "FormStoragesLoad";
            this.Text = "Загруженность складов";
            this.Load += new System.EventHandler(this.FormStoragesLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveToExcel_Button;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn StorageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountColumn;
    }
}