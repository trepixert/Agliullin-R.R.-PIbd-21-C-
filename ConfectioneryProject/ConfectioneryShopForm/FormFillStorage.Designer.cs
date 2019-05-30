namespace ConfectioneryShopForm {
    partial class FormFillStorage {
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
            this.labelStorage = new System.Windows.Forms.Label();
            this.comboBoxStorage = new System.Windows.Forms.ComboBox();
            this.labelDetail = new System.Windows.Forms.Label();
            this.comboBoxDetail = new System.Windows.Forms.ComboBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.save_Button = new System.Windows.Forms.Button();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStorage
            // 
            this.labelStorage.AutoSize = true;
            this.labelStorage.Location = new System.Drawing.Point(13, 13);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(41, 13);
            this.labelStorage.TabIndex = 0;
            this.labelStorage.Text = "Склад:";
            // 
            // comboBoxStorage
            // 
            this.comboBoxStorage.FormattingEnabled = true;
            this.comboBoxStorage.Location = new System.Drawing.Point(93, 10);
            this.comboBoxStorage.Name = "comboBoxStorage";
            this.comboBoxStorage.Size = new System.Drawing.Size(213, 21);
            this.comboBoxStorage.TabIndex = 1;
            // 
            // labelDetail
            // 
            this.labelDetail.AutoSize = true;
            this.labelDetail.Location = new System.Drawing.Point(13, 50);
            this.labelDetail.Name = "labelDetail";
            this.labelDetail.Size = new System.Drawing.Size(66, 13);
            this.labelDetail.TabIndex = 2;
            this.labelDetail.Text = "Компонент:";
            // 
            // comboBoxDetail
            // 
            this.comboBoxDetail.FormattingEnabled = true;
            this.comboBoxDetail.Location = new System.Drawing.Point(93, 47);
            this.comboBoxDetail.Name = "comboBoxDetail";
            this.comboBoxDetail.Size = new System.Drawing.Size(213, 21);
            this.comboBoxDetail.TabIndex = 3;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(13, 89);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "Количество:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(93, 86);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(213, 20);
            this.textBoxCount.TabIndex = 5;
            // 
            // save_Button
            // 
            this.save_Button.Location = new System.Drawing.Point(132, 127);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 6;
            this.save_Button.Text = "Сохранить";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // cancel_Button
            // 
            this.cancel_Button.Location = new System.Drawing.Point(213, 127);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 7;
            this.cancel_Button.Text = "Отмена";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormFillStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 168);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.comboBoxDetail);
            this.Controls.Add(this.labelDetail);
            this.Controls.Add(this.comboBoxStorage);
            this.Controls.Add(this.labelStorage);
            this.Name = "FormFillStorage";
            this.Text = "Пополнить склад";
            this.Load += new System.EventHandler(this.FormPutOnStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStorage;
        private System.Windows.Forms.ComboBox comboBoxStorage;
        private System.Windows.Forms.Label labelDetail;
        private System.Windows.Forms.ComboBox comboBoxDetail;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button cancel_Button;
    }
}