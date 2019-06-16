using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class FormDetailOutput : Form {

        public ConnectionBetweenDetailAndOutputViewModel Model { set { model = value; } get { return model; } }

        private ConnectionBetweenDetailAndOutputViewModel model;

        public FormDetailOutput()
        {
            InitializeComponent();
        }

        private void FormDetailOutput_Load(object sender, EventArgs e)
        {
            try
            {
                var list = APICustomer.GetRequest<List<DetailViewModel>>("api/Detail/GetList");
                if (list != null)
                {
                    comboBoxDetail.DisplayMember = "DishName";
                    comboBoxDetail.ValueMember = "Id";
                    comboBoxDetail.DataSource = list;
                    comboBoxDetail.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxDetail.Enabled = false;
                comboBoxDetail.SelectedValue = model.DetailID;
                textBoxCount.Text = model.Count.ToString();
            }
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
            try
            {
                if (model == null)

                {
                    model = new ConnectionBetweenDetailAndOutputViewModel
                    {
                        DetailID = Convert.ToInt32(comboBoxDetail.SelectedValue),
                        DetailName = comboBoxDetail.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxCount.Text);
                }
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
    }
}
