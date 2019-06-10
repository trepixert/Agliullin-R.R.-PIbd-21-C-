using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class FormOutputs : Form {
        public FormOutputs() {
            InitializeComponent();
        }

        private void FormOutputs_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                List<OutputViewModel> list = APICustomer.GetRequest<List<OutputViewModel>>("api/Output/GetList");
                if ( list != null ) {
                    dataGridViewOutputs.DataSource = list;
                    dataGridViewOutputs.Columns[0].Visible = false;
                    dataGridViewOutputs.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            var form = new FormOutput();
            if ( form.ShowDialog() == DialogResult.OK ) {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e) {
            if ( dataGridViewOutputs.SelectedRows.Count == 1 ) {
                var form = new FormOutput();
                form.Id = Convert.ToInt32(dataGridViewOutputs.SelectedRows[0].Cells[0].Value);
                if ( form.ShowDialog() == DialogResult.OK ) {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e) {
            if ( dataGridViewOutputs.SelectedRows.Count == 1 ) {
                if ( MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                     DialogResult.Yes ) {
                    int id = Convert.ToInt32(dataGridViewOutputs.SelectedRows[0].Cells[0].Value);
                    try {
                        APICustomer.PostRequest<OutputBindingModel, bool>("api/Set/DelElement",
                        new OutputBindingModel {ID = id});
                    }
                    catch ( Exception ex ) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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