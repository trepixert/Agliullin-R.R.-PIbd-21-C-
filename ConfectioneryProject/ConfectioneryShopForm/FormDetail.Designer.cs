namespace ConfectioneryShopForm {
    partial class FormDetail {
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
            this.textBoxComponent = new System.Windows.Forms.TextBox();
            this.FNS_label = new System.Windows.Forms.Label();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.save_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxComponent
            // 
            this.textBoxComponent.Location = new System.Drawing.Point(73, 22);
            this.textBoxComponent.Name = "textBoxComponent";
            this.textBoxComponent.Size = new System.Drawing.Size(266, 20);
            this.textBoxComponent.TabIndex = 7;
            // 
            // FNS_label
            // 
            this.FNS_label.AutoSize = true;
            this.FNS_label.Location = new System.Drawing.Point(4, 25);
            this.FNS_label.Name = "FNS_label";
            this.FNS_label.Size = new System.Drawing.Size(63, 13);
            this.FNS_label.TabIndex = 6;
            this.FNS_label.Text = "Компонент";
            // 
            // cancel_Button
            // 
            this.cancel_Button.Location = new System.Drawing.Point(264, 65);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 5;
            this.cancel_Button.Text = "Отмена";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // save_Button
            // 
            this.save_Button.Location = new System.Drawing.Point(182, 65);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 4;
            this.save_Button.Text = "Сохранить";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // Component
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 110);
            this.Controls.Add(this.textBoxComponent);
            this.Controls.Add(this.FNS_label);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.save_Button);
            this.Name = "Component";
            this.Text = "Компонент";
            this.Load += new System.EventHandler(this.Component_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxComponent;
        private System.Windows.Forms.Label FNS_label;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.Button save_Button;
    }
}