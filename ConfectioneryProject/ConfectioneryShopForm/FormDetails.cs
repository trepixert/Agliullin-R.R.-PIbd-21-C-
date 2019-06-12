using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using Unity;

namespace ConfectioneryShopForm {
    public partial class FormDetails : Form {
        [Dependency] public new IUnityContainer Container { get; set; }

        private readonly IDetailService service;

        public FormDetails(IDetailService service) {
            InitializeComponent();
            this.service = service;
        }

        private void add_Button_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormDetail>();
            if ( form.ShowDialog() == DialogResult.OK ) {
                LoadData();
            }
        }

        private void change_Button_Click(object sender, EventArgs e) {
            if ( dataGridViewDetails.SelectedRows.Count == 1 ) {
                var form = Container.Resolve<FormDetail>();
                form.Id = Convert.ToInt32(dataGridViewDetails.SelectedRows[0].Cells[0].Value);
                if ( form.ShowDialog() == DialogResult.OK ) {
                    LoadData();
                }
            }
        }

        private void delete_Button_Click(object sender, EventArgs e) {
            if ( dataGridViewDetails.SelectedRows.Count == 1 ) {
                if ( MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes ) {
                    int id =
                        Convert.ToInt32(dataGridViewDetails.SelectedRows[0].Cells[0].Value);
                    try {
                        service.DelElem(id);
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

        private void Components_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                List<DetailViewModel> list = service.GetList();
                if ( list != null ) {
                    dataGridViewDetails.DataSource = list;
                    dataGridViewDetails.Columns[0].Visible = false;
                    dataGridViewDetails.Columns[1].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}