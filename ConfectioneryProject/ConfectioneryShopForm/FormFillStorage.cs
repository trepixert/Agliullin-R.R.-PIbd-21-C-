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

namespace ConfectioneryShopForm {
    public partial class FormFillStorage : Form {

        public FormFillStorage()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDetail.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStorage.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                APICustomer.PostRequest<StorageDetailBindingModel, bool>("api/Main/putDetailOnStorage", new StorageDetailBindingModel
                {
                    DetailID = Convert.ToInt32(comboBoxDetail.SelectedValue),
                    StorageID = Convert.ToInt32(comboBoxStorage.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormPutOnStock_Load(object sender, EventArgs e)
        {
            try
            {
                var listC = APICustomer.GetRequest<List<DetailViewModel>>("api/Detail/GetList");

                if (listC != null)
                {
                    comboBoxDetail.DisplayMember = "DetailName";
                    comboBoxDetail.ValueMember = "Id";
                    comboBoxDetail.DataSource = listC;
                    comboBoxDetail.SelectedItem = null;
                }

                var listS = APICustomer.GetRequest<List<StorageViewModel>>("api/Storage/GetList");

                if (listS != null)
                {
                    comboBoxStorage.DisplayMember = "StorageName";
                    comboBoxStorage.ValueMember = "Id";
                    comboBoxStorage.DataSource = listS;
                    comboBoxStorage.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
