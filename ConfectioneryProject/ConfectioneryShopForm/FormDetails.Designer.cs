namespace ConfectioneryShopForm {
    partial class FormDetails {
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
            this.update_Button = new System.Windows.Forms.Button();
            this.change_Button = new System.Windows.Forms.Button();
            this.delete_Button = new System.Windows.Forms.Button();
            this.add_Button = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // update_Button
            // 
            this.update_Button.Location = new System.Drawing.Point(560, 176);
            this.update_Button.Name = "update_Button";
            this.update_Button.Size = new System.Drawing.Size(75, 23);
            this.update_Button.TabIndex = 9;
            this.update_Button.Text = "Обновить";
            this.update_Button.UseVisualStyleBackColor = true;
            this.update_Button.Click += new System.EventHandler(this.update_Button_Click);
            // 
            // change_Button
            // 
            this.change_Button.Location = new System.Drawing.Point(560, 84);
            this.change_Button.Name = "change_Button";
            this.change_Button.Size = new System.Drawing.Size(75, 23);
            this.change_Button.TabIndex = 8;
            this.change_Button.Text = "Изменить";
            this.change_Button.UseVisualStyleBackColor = true;
            this.change_Button.Click += new System.EventHandler(this.change_Button_Click);
            // 
            // delete_Button
            // 
            this.delete_Button.Location = new System.Drawing.Point(560, 130);
            this.delete_Button.Name = "delete_Button";
            this.delete_Button.Size = new System.Drawing.Size(75, 23);
            this.delete_Button.TabIndex = 7;
            this.delete_Button.Text = "Удалить";
            this.delete_Button.UseVisualStyleBackColor = true;
            this.delete_Button.Click += new System.EventHandler(this.delete_Button_Click);
            // 
            // add_Button
            // 
            this.add_Button.Location = new System.Drawing.Point(560, 35);
            this.add_Button.Name = "add_Button";
            this.add_Button.Size = new System.Drawing.Size(75, 23);
            this.add_Button.TabIndex = 6;
            this.add_Button.Text = "Добавить";
            this.add_Button.UseVisualStyleBackColor = true;
            this.add_Button.Click += new System.EventHandler(this.add_Button_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(477, 457);
            this.dataGridView.TabIndex = 5;
            // 
            // FormDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.update_Button);
            this.Controls.Add(this.change_Button);
            this.Controls.Add(this.delete_Button);
            this.Controls.Add(this.add_Button);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormDetails";
            this.Text = "Components";
            this.Load += new System.EventHandler(this.Components_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button update_Button;
        private System.Windows.Forms.Button change_Button;
        private System.Windows.Forms.Button delete_Button;
        private System.Windows.Forms.Button add_Button;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}