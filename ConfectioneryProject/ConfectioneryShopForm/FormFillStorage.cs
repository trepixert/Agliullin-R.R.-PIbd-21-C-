using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using Unity;

namespace ConfectioneryShopForm {
    public partial class FormFillStorage : Form {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IStorageService serviceS;
        private readonly IDetailService serviceC;
        private readonly IMainService serviceM;

        public FormFillStorage(IStorageService serviceS, IDetailService serviceC, 
                               IMainService serviceM) {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceC = serviceC;
            this.serviceM = serviceM;
        }

        private void save_Button_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBoxCount.Text)) {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDetail.SelectedValue == null) {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStorage.SelectedValue == null) {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try {
                serviceM.putDetailOnStorage(new StorageDetailBindingModel {
                    DetailID = Convert.ToInt32(comboBoxDetail.SelectedValue),
                    StorageID = Convert.ToInt32(comboBoxStorage.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void FormFillStorage_Load(object sender, EventArgs e) {
            try {
                List<DetailViewModel> listC = serviceC.getList();
                if (listC != null) {
                    comboBoxDetail.DisplayMember = "DetailName";
                    comboBoxDetail.ValueMember = "ID";
                    comboBoxDetail.DataSource = listC;
                    comboBoxDetail.SelectedItem = null;
                }
                List<StorageViewModel> listS = serviceS.getList();
                if (listS != null) {
                    comboBoxStorage.DisplayMember = "StorageName";
                    comboBoxStorage.ValueMember = "ID";
                    comboBoxStorage.DataSource = listS;
                    comboBoxStorage.SelectedItem = null;
                }
            } catch (Exception ex) {
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
