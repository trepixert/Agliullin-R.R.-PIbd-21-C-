using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using Unity;

namespace ConfectioneryShopForm {
    public partial class FormCustomers : Form {
        [Dependency] public new IUnityContainer Container { get; set; }

        private readonly ICustomerService service;

        public FormCustomers(ICustomerService service) {
            InitializeComponent();
            this.service = service;
        }

        private void Clients_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                List<CustomerViewModel> list = service.GetList();
                if ( list != null ) {
                    dataGridViewOfClients.DataSource = list;
                    dataGridViewOfClients.Columns[0].Visible = false;
                    dataGridViewOfClients.Columns[1].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void add_Button_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormCustomer>();
            if ( form.ShowDialog() == DialogResult.OK ) {
                LoadData();
            }
        }

        private void change_Button_Click(object sender, EventArgs e) {
            if ( dataGridViewOfClients.SelectedRows.Count == 1 ) {
                var form = Container.Resolve<FormCustomer>();
                form.Id = Convert.ToInt32(dataGridViewOfClients.SelectedRows[0].Cells[0].Value);
                if ( form.ShowDialog() == DialogResult.OK ) {
                    LoadData();
                }
            }
        }

        private void delete_Button_Click(object sender, EventArgs e) {
            if ( dataGridViewOfClients.SelectedRows.Count == 1 ) {
                if ( MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes ) {
                    int id =
                        Convert.ToInt32(dataGridViewOfClients.SelectedRows[0].Cells[0].Value);
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
    }
}