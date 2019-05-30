namespace ConfectioneryShopForm {
    partial class FormOutput {
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dataGridViewOutputs = new System.Windows.Forms.DataGridView();
            this.NameLabel = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.save_Button = new System.Windows.Forms.Button();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutputs)).BeginInit();
            this.SuspendLayout();
            // 
            // update_Button
            // 
            this.update_Button.Location = new System.Drawing.Point(470, 192);
            this.update_Button.Name = "update_Button";
            this.update_Button.Size = new System.Drawing.Size(75, 23);
            this.update_Button.TabIndex = 14;
            this.update_Button.Text = "Обновить";
            this.update_Button.UseVisualStyleBackColor = true;
            this.update_Button.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // change_Button
            // 
            this.change_Button.Location = new System.Drawing.Point(470, 107);
            this.change_Button.Name = "change_Button";
            this.change_Button.Size = new System.Drawing.Size(75, 23);
            this.change_Button.TabIndex = 13;
            this.change_Button.Text = "Изменить";
            this.change_Button.UseVisualStyleBackColor = true;
            this.change_Button.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // delete_Button
            // 
            this.delete_Button.Location = new System.Drawing.Point(470, 150);
            this.delete_Button.Name = "delete_Button";
            this.delete_Button.Size = new System.Drawing.Size(75, 23);
            this.delete_Button.TabIndex = 12;
            this.delete_Button.Text = "Удалить";
            this.delete_Button.UseVisualStyleBackColor = true;
            this.delete_Button.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // add_Button
            // 
            this.add_Button.Location = new System.Drawing.Point(470, 65);
            this.add_Button.Name = "add_Button";
            this.add_Button.Size = new System.Drawing.Size(75, 23);
            this.add_Button.TabIndex = 11;
            this.add_Button.Text = "Добавить";
            this.add_Button.UseVisualStyleBackColor = true;
            this.add_Button.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.dataGridViewOutputs);
            this.groupBox.Controls.Add(this.add_Button);
            this.groupBox.Controls.Add(this.update_Button);
            this.groupBox.Controls.Add(this.change_Button);
            this.groupBox.Controls.Add(this.delete_Button);
            this.groupBox.Location = new System.Drawing.Point(12, 77);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(549, 277);
            this.groupBox.TabIndex = 15;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Компоненты";
            // 
            // dataGridViewOutputs
            // 
            this.dataGridViewOutputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutputs.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewOutputs.Name = "dataGridViewOutputs";
            this.dataGridViewOutputs.Size = new System.Drawing.Size(435, 251);
            this.dataGridViewOutputs.TabIndex = 15;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(19, 13);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(57, 13);
            this.NameLabel.TabIndex = 16;
            this.NameLabel.Text = "Название";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(19, 45);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(33, 13);
            this.Price.TabIndex = 17;
            this.Price.Text = "Цена";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(83, 13);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(175, 20);
            this.textBoxName.TabIndex = 18;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(83, 42);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(65, 20);
            this.textBoxPrice.TabIndex = 19;
            // 
            // save_Button
            // 
            this.save_Button.Location = new System.Drawing.Point(351, 361);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 20;
            this.save_Button.Text = "Сохранить";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // cancel_Button
            // 
            this.cancel_Button.Location = new System.Drawing.Point(454, 361);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 21;
            this.cancel_Button.Text = "Отмена";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 394);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.groupBox);
            this.Name = "FormOutput";
            this.Text = "Изделие";
            this.Load += new System.EventHandler(this.FormOutuut_Load);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutputs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button update_Button;
        private System.Windows.Forms.Button change_Button;
        private System.Windows.Forms.Button delete_Button;
        private System.Windows.Forms.Button add_Button;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.DataGridView dataGridViewOutputs;
    }
}