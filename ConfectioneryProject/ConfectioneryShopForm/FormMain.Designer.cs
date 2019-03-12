namespace ConfectioneryShopForm {
    partial class ConfectioneryShopForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.Directory = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOrder_Button = new System.Windows.Forms.Button();
            this.toExecution_Button = new System.Windows.Forms.Button();
            this.orderReady_Button = new System.Windows.Forms.Button();
            this.orderPaid = new System.Windows.Forms.Button();
            this.refreshList_Button = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Directory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Directory
            // 
            this.Directory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem});
            this.Directory.Location = new System.Drawing.Point(0, 0);
            this.Directory.Name = "Directory";
            this.Directory.Size = new System.Drawing.Size(800, 24);
            this.Directory.TabIndex = 0;
            this.Directory.Text = "Справочники";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // createOrder_Button
            // 
            this.createOrder_Button.Location = new System.Drawing.Point(648, 49);
            this.createOrder_Button.Name = "createOrder_Button";
            this.createOrder_Button.Size = new System.Drawing.Size(133, 23);
            this.createOrder_Button.TabIndex = 1;
            this.createOrder_Button.Text = "Создать заказ";
            this.createOrder_Button.UseVisualStyleBackColor = true;
            this.createOrder_Button.Click += new System.EventHandler(this.createOrder_Button_Click);
            // 
            // toExecution_Button
            // 
            this.toExecution_Button.Location = new System.Drawing.Point(648, 92);
            this.toExecution_Button.Name = "toExecution_Button";
            this.toExecution_Button.Size = new System.Drawing.Size(133, 23);
            this.toExecution_Button.TabIndex = 2;
            this.toExecution_Button.Text = "Отдать на выполнение";
            this.toExecution_Button.UseVisualStyleBackColor = true;
            this.toExecution_Button.Click += new System.EventHandler(this.toExecution_Button_Click);
            // 
            // orderReady_Button
            // 
            this.orderReady_Button.Location = new System.Drawing.Point(648, 140);
            this.orderReady_Button.Name = "orderReady_Button";
            this.orderReady_Button.Size = new System.Drawing.Size(133, 23);
            this.orderReady_Button.TabIndex = 3;
            this.orderReady_Button.Text = "Заказ готов";
            this.orderReady_Button.UseVisualStyleBackColor = true;
            this.orderReady_Button.Click += new System.EventHandler(this.orderReady_Button_Click);
            // 
            // orderPaid
            // 
            this.orderPaid.Location = new System.Drawing.Point(648, 185);
            this.orderPaid.Name = "orderPaid";
            this.orderPaid.Size = new System.Drawing.Size(133, 23);
            this.orderPaid.TabIndex = 4;
            this.orderPaid.Text = "Заказ оплачен";
            this.orderPaid.UseVisualStyleBackColor = true;
            this.orderPaid.Click += new System.EventHandler(this.orderPaid_Click);
            // 
            // refreshList_Button
            // 
            this.refreshList_Button.Location = new System.Drawing.Point(648, 231);
            this.refreshList_Button.Name = "refreshList_Button";
            this.refreshList_Button.Size = new System.Drawing.Size(133, 23);
            this.refreshList_Button.TabIndex = 5;
            this.refreshList_Button.Text = "Обновить список";
            this.refreshList_Button.UseVisualStyleBackColor = true;
            this.refreshList_Button.Click += new System.EventHandler(this.refreshList_Button_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(642, 248);
            this.dataGridView.TabIndex = 6;
            // 
            // ConfectioneryShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 277);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.refreshList_Button);
            this.Controls.Add(this.orderPaid);
            this.Controls.Add(this.orderReady_Button);
            this.Controls.Add(this.toExecution_Button);
            this.Controls.Add(this.createOrder_Button);
            this.Controls.Add(this.Directory);
            this.MainMenuStrip = this.Directory;
            this.Name = "ConfectioneryShopForm";
            this.Text = "ConfectioneryShopForm";
            this.Load += new System.EventHandler(this.ConfectioneryShopForm_Load);
            this.Directory.ResumeLayout(false);
            this.Directory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Directory;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.Button createOrder_Button;
        private System.Windows.Forms.Button toExecution_Button;
        private System.Windows.Forms.Button orderReady_Button;
        private System.Windows.Forms.Button orderPaid;
        private System.Windows.Forms.Button refreshList_Button;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

