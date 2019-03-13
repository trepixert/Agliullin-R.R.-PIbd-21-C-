using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class FormCreateOrder : Form {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ICustomerService serviceC;
        private readonly IOutputService serviceP;
        private readonly IMainService serviceM;

        public FormCreateOrder(ICustomerService serviceC, IOutputService serviceP,
IMainService serviceM) {
            InitializeComponent();
            this.serviceC = serviceC;
            this.serviceP = serviceP;
            this.serviceM = serviceM;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e) {
            try {
                List<CustomerViewModel> listC = serviceC.getList();
                if (listC != null) {
                    comboBoxCustomer.DisplayMember = "CustomerFIO";
                    comboBoxCustomer.ValueMember = "ID";
                    comboBoxCustomer.DataSource = listC;
                    comboBoxCustomer.SelectedItem = null;
                }
                List<OutputViewModel> listP = serviceP.getList();
                if (listP != null) {
                    comboBoxOutput.DisplayMember = "OutputName";
                    comboBoxOutput.ValueMember = "ID";
                    comboBoxOutput.DataSource = listP;
                    comboBoxOutput.SelectedItem = null;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void CalcSum() {
            if (comboBoxOutput.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxCount.Text)) {
                try {
                    int id = Convert.ToInt32(comboBoxOutput.SelectedValue);
                    OutputViewModel product = serviceP.getElement(id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product.Price).ToString();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e) {
            CalcSum();
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e) {
            CalcSum();
        }

        private void save_Button_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBoxCount.Text)) {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCustomer.SelectedValue == null) {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxOutput.SelectedValue == null) {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try {
                serviceM.createOrder(new OrderBindingModel {
                    CustomerID = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                    OutputID = Convert.ToInt32(comboBoxOutput.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToInt32(textBoxSum.Text)
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

        private void cancel_Button_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
