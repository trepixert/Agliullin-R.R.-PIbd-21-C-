using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class FormCreateOrder : Form {
        public FormCreateOrder() {
            InitializeComponent();
        }

        private void FormCreateOrder_Load(object sender, EventArgs e) {
            try {
                var listC = APICustomer.GetRequest<List<CustomerViewModel>>("api/Customer/GetList");
                if ( listC != null ) {
                    comboBoxCustomer.DisplayMember = "CustomerFIO";
                    comboBoxCustomer.ValueMember = "Id";
                    comboBoxCustomer.DataSource = listC;
                    comboBoxCustomer.SelectedItem = null;
                }

                var listP = APICustomer.GetRequest<List<OutputViewModel>>("api/Output/GetList");
                if ( listP != null ) {
                    comboBoxOutput.DisplayMember = "OutputName";
                    comboBoxOutput.ValueMember = "Id";
                    comboBoxOutput.DataSource = listP;
                    comboBoxOutput.SelectedItem = null;
                }
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum() {
            if ( comboBoxOutput.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text) ) {
                try {
                    int id = Convert.ToInt32(comboBoxOutput.SelectedValue);

                    OutputViewModel product = APICustomer.GetRequest<OutputViewModel>("api/Output/Get/" + id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product.Price).ToString();
                }
                catch ( Exception ex ) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e) {
            CalcSum();
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e) {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty(textBoxCount.Text) ) {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ( comboBoxCustomer.SelectedValue == null ) {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ( comboBoxOutput.SelectedValue == null ) {
                MessageBox.Show("Выберите набор", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            try {
                APICustomer.PostRequest<OrderBindingModel, bool>("api/Main/CreateOrder", new OrderBindingModel {
                    CustomerID = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                    OutputID = Convert.ToInt32(comboBoxOutput.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}