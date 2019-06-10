using System;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class FormImplementer : Form {
        public int Id {
            set { id = value; }
        }

        private int? id;

        public FormImplementer() {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty(textBoxFIO.Text) ) {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                if ( id.HasValue ) {
                    APICustomer.PostRequest<ImplementerBindingModel, bool>("api/Customer/UpdElement",
                    new ImplementerBindingModel {
                        Id = id.Value,
                        ImplementerFIO = textBoxFIO.Text
                    });
                }
                else {
                    APICustomer.PostRequest<ImplementerBindingModel,
                        bool>("api/Implementer/AddElement", new ImplementerBindingModel {
                        ImplementerFIO = textBoxFIO.Text
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

        private void FormImplementer_Load(object sender, EventArgs e) {
            if ( id.HasValue ) {
                try {
                    ImplementerViewModel implementer =
                        APICustomer.GetRequest<ImplementerViewModel>("api/Implementer/Get/" + id.Value);
                    textBoxFIO.Text = implementer.ImplementerFIO;
                }
                catch ( Exception ex ) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}