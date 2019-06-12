﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using Unity;

namespace ConfectioneryShopForm {
    public partial class ConfectioneryShopForm : Form {
        [Dependency] public new IUnityContainer Container { get; set; }
        private readonly IMainService service;

        public ConfectioneryShopForm(IMainService service) {
            InitializeComponent();
            this.service = service;
        }

        private void ConfectioneryShopForm_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                List<OrderViewModel> list = service.GetList();
                if ( list != null ) {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormCustomers>();
            form.ShowDialog();
        }

        private void компонентыToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormDetails>();
            form.ShowDialog();
        }

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormOutputs>();
            form.ShowDialog();
        }

        private void createOrder_Button_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void toExecution_Button_Click(object sender, EventArgs e) {
            if ( dataGridView.SelectedRows.Count == 1 ) {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try {
                    service.TakeOrderInWork(new OrderBindingModel {ID = id});
                    LoadData();
                }
                catch ( Exception ex ) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void orderReady_Button_Click(object sender, EventArgs e) {
            if ( dataGridView.SelectedRows.Count == 1 ) {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try {
                    service.FinishOrder(new OrderBindingModel {ID = id});
                    LoadData();
                }
                catch ( Exception ex ) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void orderPaid_Click(object sender, EventArgs e) {
            if ( dataGridView.SelectedRows.Count == 1 ) {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try {
                    service.PayOrder(new OrderBindingModel {ID = id});
                    LoadData();
                }
                catch ( Exception ex ) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void refreshList_Button_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormStorages>();
            form.ShowDialog();
            LoadData();
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormFillStorage>();
            form.ShowDialog();
            LoadData();
        }
    }
}