using System;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using Unity;

namespace ConfectioneryShopForm {
    public partial class FormDetail : Form {
        [Dependency] public new IUnityContainer Container { get; set; }

        public int Id {
            set { id = value; }
        }

        private readonly IDetailService service;

        private int? id;

        public FormDetail(IDetailService service) {
            InitializeComponent();
            this.service = service;
        }

        private void Component_Load(object sender, EventArgs e) {
            if ( id.HasValue ) {
                try {
                    DetailViewModel view = service.GetElement(id.Value);
                    if ( view != null ) {
                        textBoxDetail.Text = view.DetailName;
                    }
                }
                catch ( Exception ex ) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void save_Button_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty(textBoxDetail.Text) ) {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            try {
                if ( id.HasValue ) {
                    service.UpdElem(new DetailBindingModel {
                        ID = id.Value,
                        DetailName = textBoxDetail.Text
                    });
                }
                else {
                    service.AddElem(new DetailBindingModel {
                        DetailName = textBoxDetail.Text
                    });
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void cancel_Button_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}