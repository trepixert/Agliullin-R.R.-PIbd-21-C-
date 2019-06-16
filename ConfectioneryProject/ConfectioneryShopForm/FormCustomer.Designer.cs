namespace ConfectioneryShopForm {
    partial class FormCustomer {
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
            this.save_Button = new System.Windows.Forms.Button();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.FNS_label = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxMessages = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // save_Button
            // 
            this.save_Button.Location = new System.Drawing.Point(351, 302);
            this.save_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(88, 27);
            this.save_Button.TabIndex = 0;
            this.save_Button.Text = "Сохранить";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // cancel_Button
            // 
            this.cancel_Button.Location = new System.Drawing.Point(447, 302);
            this.cancel_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(88, 27);
            this.cancel_Button.TabIndex = 1;
            this.cancel_Button.Text = "Отмена";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FNS_label
            // 
            this.FNS_label.AutoSize = true;
            this.FNS_label.Location = new System.Drawing.Point(13, 9);
            this.FNS_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FNS_label.Name = "FNS_label";
            this.FNS_label.Size = new System.Drawing.Size(34, 15);
            this.FNS_label.TabIndex = 2;
            this.FNS_label.Text = "ФИО";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(55, 6);
            this.textBoxFIO.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(201, 23);
            this.textBoxFIO.TabIndex = 3;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(318, 6);
            this.textBoxMail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(201, 23);
            this.textBoxMail.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Почта";
            // 
            // groupBoxMessages
            // 
            this.groupBoxMessages.Controls.Add(this.dataGridView);
            this.groupBoxMessages.Location = new System.Drawing.Point(2, 44);
            this.groupBoxMessages.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMessages.Name = "groupBoxMessages";
            this.groupBoxMessages.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMessages.Size = new System.Drawing.Size(533, 252);
            this.groupBoxMessages.TabIndex = 7;
            this.groupBoxMessages.TabStop = false;
            this.groupBoxMessages.Text = "Письма:";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(4, 18);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(530, 237);
            this.dataGridView.TabIndex = 0;
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 333);
            this.Controls.Add(this.groupBoxMessages);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.FNS_label);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.save_Button);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormCustomer";
            this.Text = "Клиент";
            this.Load += new System.EventHandler(this.FormCustomer_Load);
            this.groupBoxMessages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.Label FNS_label;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxMessages;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxFIO;
    }
}