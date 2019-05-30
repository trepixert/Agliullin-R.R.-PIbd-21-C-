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
            this.components = new System.ComponentModel.Container();
            this.Directory = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ценыПродуктовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загруженностьСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOrder_Button = new System.Windows.Forms.Button();
            this.orderPaid = new System.Windows.Forms.Button();
            this.refreshList_Button = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.customerOrdersModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.запускToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Directory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerOrdersModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Directory
            // 
            this.Directory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.запускToolStripMenuItem});
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
            this.изделияToolStripMenuItem,
            this.складыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ценыПродуктовToolStripMenuItem,
            this.загруженностьСкладовToolStripMenuItem,
            this.заказыКлиентовToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // ценыПродуктовToolStripMenuItem
            // 
            this.ценыПродуктовToolStripMenuItem.Name = "ценыПродуктовToolStripMenuItem";
            this.ценыПродуктовToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.ценыПродуктовToolStripMenuItem.Text = "Цены продуктов";
            this.ценыПродуктовToolStripMenuItem.Click += new System.EventHandler(this.ценыПродуктовToolStripMenuItem_Click);
            // 
            // загруженностьСкладовToolStripMenuItem
            // 
            this.загруженностьСкладовToolStripMenuItem.Name = "загруженностьСкладовToolStripMenuItem";
            this.загруженностьСкладовToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.загруженностьСкладовToolStripMenuItem.Text = "Загруженность складов";
            this.загруженностьСкладовToolStripMenuItem.Click += new System.EventHandler(this.загруженностьСкладовToolStripMenuItem_Click);
            // 
            // заказыКлиентовToolStripMenuItem
            // 
            this.заказыКлиентовToolStripMenuItem.Name = "заказыКлиентовToolStripMenuItem";
            this.заказыКлиентовToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.заказыКлиентовToolStripMenuItem.Text = "Заказы клиентов";
            this.заказыКлиентовToolStripMenuItem.Click += new System.EventHandler(this.заказыКлиентовToolStripMenuItem_Click);
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
            // customerOrdersModelBindingSource
            // 
            this.customerOrdersModelBindingSource.DataSource = typeof(ConfectioneryShopModelServiceDAL.ViewModel.CustomerOrdersModel);
            // 
            // запускToolStripMenuItem
            // 
            this.запускToolStripMenuItem.Name = "запускToolStripMenuItem";
            this.запускToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.запускToolStripMenuItem.Text = "Запуск работ";
            this.запускToolStripMenuItem.Click += new System.EventHandler(this.ЗапускToolStripMenuItem_Click);
            // 
            // ConfectioneryShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 277);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.refreshList_Button);
            this.Controls.Add(this.orderPaid);
            this.Controls.Add(this.createOrder_Button);
            this.Controls.Add(this.Directory);
            this.MainMenuStrip = this.Directory;
            this.Name = "ConfectioneryShopForm";
            this.Text = "Кондитерская";
            this.Load += new System.EventHandler(this.ConfectioneryShopForm_Load);
            this.Directory.ResumeLayout(false);
            this.Directory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerOrdersModelBindingSource)).EndInit();
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
        private System.Windows.Forms.Button orderPaid;
        private System.Windows.Forms.Button refreshList_Button;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ценыПродуктовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загруженностьСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыКлиентовToolStripMenuItem;
        private System.Windows.Forms.BindingSource customerOrdersModelBindingSource;
        private System.Windows.Forms.ToolStripMenuItem запускToolStripMenuItem;
    }
}

