﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class FormImplementers : Form {
        public FormImplementers() {
            InitializeComponent();
        }

        private void FormImplementers_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                List<ImplementerViewModel> list =
                    APICustomer.GetRequest<List<ImplementerViewModel>>("api/Implementer/GetList");
                if ( list != null ) {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            var form = new FormImplementer();
            if ( form.ShowDialog() == DialogResult.OK ) {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e) {
            if ( dataGridView.SelectedRows.Count == 1 ) {
                var form = new FormImplementer {
                    Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value)
                };

                if ( form.ShowDialog() == DialogResult.OK ) {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e) {
            if ( dataGridView.SelectedRows.Count == 1 ) {
                if ( MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes ) {
                    int id =
                        Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try {
                        APICustomer.PostRequest<ImplementerBindingModel, bool>("api/Implementer/DelElement",
                        new ImplementerBindingModel {Id = id});
                    }
                    catch ( Exception ex ) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e) {
            LoadData();
        }
    }
}