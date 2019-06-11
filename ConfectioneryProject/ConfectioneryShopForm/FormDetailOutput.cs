using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using Unity;

namespace ConfectioneryShopForm {
    public partial class FormDetailOutput : Form {
        [Dependency] public new IUnityContainer Container { get; set; }

        public ConnectionBetweenDetailAndOutputViewModel Model {
            set { model = value; }
            get { return model; }
        }

        private readonly IDetailService service;

        private ConnectionBetweenDetailAndOutputViewModel model;

        public FormDetailOutput(IDetailService service) {
            InitializeComponent();
            this.service = service;
        }

        private void save_Button_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty(textBoxCount.Text) ) {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ( comboBoxComponent.SelectedValue == null ) {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            try {
                if ( model == null ) {
                    model = new ConnectionBetweenDetailAndOutputViewModel {
                        DetailID = Convert.ToInt32(comboBoxComponent.SelectedValue),
                        DetailName = comboBoxComponent.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else {
                    model.Count = Convert.ToInt32(textBoxCount.Text);
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

        private void FormProductComponent_Load(object sender, EventArgs e) {
            try {
                List<DetailViewModel> list = service.GetList();
                if ( list != null ) {
                    comboBoxComponent.DisplayMember = "ComponentName";
                    comboBoxComponent.ValueMember = "Id";
                    comboBoxComponent.DataSource = list;
                    comboBoxComponent.SelectedItem = null;
                }
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            if ( model != null ) {
                comboBoxComponent.Enabled = false;
                comboBoxComponent.SelectedValue = model.DetailID;
                textBoxCount.Text = model.Count.ToString();
            }
        }

        private void cancel_Button_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}