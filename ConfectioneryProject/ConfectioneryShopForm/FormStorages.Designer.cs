namespace ConfectioneryShopForm {
    partial class FormStorages {
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
            this.dataGridViewStorages = new System.Windows.Forms.DataGridView();
            this.add_Button = new System.Windows.Forms.Button();
            this.change_Button = new System.Windows.Forms.Button();
            this.delete_Button = new System.Windows.Forms.Button();
            this.update_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStorages
            // 
            this.dataGridViewStorages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStorages.Location = new System.Drawing.Point(1, 2);
            this.dataGridViewStorages.Name = "dataGridViewStorages";
            this.dataGridViewStorages.Size = new System.Drawing.Size(403, 367);
            this.dataGridViewStorages.TabIndex = 0;
            // 
            // add_Button
            // 
            this.add_Button.Location = new System.Drawing.Point(427, 30);
            this.add_Button.Name = "add_Button";
            this.add_Button.Size = new System.Drawing.Size(75, 23);
            this.add_Button.TabIndex = 1;
            this.add_Button.Text = "Добавить";
            this.add_Button.UseVisualStyleBackColor = true;
            this.add_Button.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // change_Button
            // 
            this.change_Button.Location = new System.Drawing.Point(427, 74);
            this.change_Button.Name = "change_Button";
            this.change_Button.Size = new System.Drawing.Size(75, 23);
            this.change_Button.TabIndex = 2;
            this.change_Button.Text = "Изменить";
            this.change_Button.UseVisualStyleBackColor = true;
            this.change_Button.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // delete_Button
            // 
            this.delete_Button.Location = new System.Drawing.Point(427, 119);
            this.delete_Button.Name = "delete_Button";
            this.delete_Button.Size = new System.Drawing.Size(75, 23);
            this.delete_Button.TabIndex = 3;
            this.delete_Button.Text = "Удалить";
            this.delete_Button.UseVisualStyleBackColor = true;
            this.delete_Button.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // update_Button
            // 
            this.update_Button.Location = new System.Drawing.Point(427, 161);
            this.update_Button.Name = "update_Button";
            this.update_Button.Size = new System.Drawing.Size(75, 23);
            this.update_Button.TabIndex = 4;
            this.update_Button.Text = "Обновить";
            this.update_Button.UseVisualStyleBackColor = true;
            this.update_Button.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // FormStorages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 369);
            this.Controls.Add(this.update_Button);
            this.Controls.Add(this.delete_Button);
            this.Controls.Add(this.change_Button);
            this.Controls.Add(this.add_Button);
            this.Controls.Add(this.dataGridViewStorages);
            this.Name = "FormStorages";
            this.Text = "Склады";
            this.Load += new System.EventHandler(this.FormStorages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStorages;
        private System.Windows.Forms.Button add_Button;
        private System.Windows.Forms.Button change_Button;
        private System.Windows.Forms.Button delete_Button;
        private System.Windows.Forms.Button update_Button;
    }
}