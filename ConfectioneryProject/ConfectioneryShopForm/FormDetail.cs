using System;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class FormDetail : Form {
        public int Id {
            set { id = value; }
        }

        private int? id;

        public FormDetail() {
            InitializeComponent();
        }

        private void FormDetail_Load(object sender, EventArgs e) {
            if ( id.HasValue ) {
                try {
                    DetailViewModel detail =
                        APICustomer.GetRequest<DetailViewModel>("api/Customer/Get/" + id.Value);
                    textBoxDetail.Text = detail.DetailName;
                }
                catch ( Exception ex ) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty(textBoxDetail.Text) ) {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                if ( id.HasValue ) {
                    APICustomer.PostRequest<DetailBindingModel,
                        bool>("api/Detail/UpdElement", new DetailBindingModel {
                        ID = id.Value,
                        DetailName = textBoxDetail.Text
                    });
                }
                else {
                    APICustomer.PostRequest<DetailBindingModel,
                        bool>("api/Detail/AddElement", new DetailBindingModel {
                        DetailName = textBoxDetail.Text
                    });
                }

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