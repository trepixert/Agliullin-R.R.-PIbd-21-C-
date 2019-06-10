using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using Unity;

namespace ConfectioneryShopForm {
    public partial class FormOutputs : Form {
        [Dependency] public new IUnityContainer Container { get; set; }

        private readonly IOutputService service;

        public FormOutputs(IOutputService service) {
            InitializeComponent();
            this.service = service;
        }

        private void FormProducts_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                List<OutputViewModel> list = service.getList();
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

        private void add_Button_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormOutput>();
            if ( form.ShowDialog() == DialogResult.OK ) {
                LoadData();
            }
        }

        private void change_Button_Click(object sender, EventArgs e) {
            if ( dataGridView.SelectedRows.Count == 1 ) {
                var form = Container.Resolve<FormOutput>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if ( form.ShowDialog() == DialogResult.OK ) {
                    LoadData();
                }
            }
        }

        private void delete_Button_Click(object sender, EventArgs e) {
            if ( dataGridView.SelectedRows.Count == 1 ) {
                if ( MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes ) {
                    int id =
                        Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try {
                        service.delElem(id);
                    }
                    catch ( Exception ex ) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                    LoadData();
                }
            }
        }

        private void update_Button_Click(object sender, EventArgs e) {
            LoadData();
        }
    }
}