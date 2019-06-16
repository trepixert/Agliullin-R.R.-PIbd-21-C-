using System;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class FormCustomer : Form {
        public int Id {
            set { id = value; }
        }

        private int? id;

        public FormCustomer() {
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, EventArgs e) {
            if ( id.HasValue ) {
                try {
                    CustomerViewModel client = APICustomer.GetRequest<CustomerViewModel>("api/Client/Get/" + id.Value);
                    textBoxFIO.Text = client.CustomerFIO;
                    textBoxMail.Text = client.Mail;
                    dataGridView.DataSource = client.Messages;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
                catch ( Exception ex ) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty(textBoxFIO.Text) ) {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            string fio = textBoxFIO.Text;
            string mail = textBoxMail.Text;


            if ( id.HasValue ) {
                APICustomer.PostRequest<CustomerBindingModel,
                    bool>("api/Customer/UpdElement", new CustomerBindingModel {
                    ID = id.Value,
                    CustomerFIO = fio,
                    Mail = mail
                });
            }
            else {
                APICustomer.PostRequest<CustomerBindingModel,
                    bool>("api/Customer/AddElement", new CustomerBindingModel {
                    CustomerFIO = fio,
                    Mail = mail
                });
            }

            MessageBox.Show("Сохранение прошло успешно", "Сообщение",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }


        private void buttonCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}