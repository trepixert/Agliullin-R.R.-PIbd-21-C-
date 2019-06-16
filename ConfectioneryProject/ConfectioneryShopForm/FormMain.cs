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
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class ConfectioneryShopForm : Form {

        public ConfectioneryShopForm() {
            InitializeComponent();
        }

        private void ConfectioneryShopForm_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                List<OrderViewModel> list =
               APICustomer.GetRequest<List<OrderViewModel>>("api/Main/GetList");
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            } catch (Exception ex){
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new FormCustomer();
            form.ShowDialog();
        }

        private void компонентыToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new FormDetails();
            form.ShowDialog();
        }

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new FormOutputs();
            form.ShowDialog();
        }

        private void createOrder_Button_Click(object sender, EventArgs e) {
            var form = new FormCreateOrder();
            form.ShowDialog();
            LoadData();
        }

        private void orderPaid_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try {
                    APICustomer.PostRequest<OrderBindingModel, bool>("api/Main/PayOrder",
                  new OrderBindingModel
                  {
                      ID = id
                  });
                    LoadData();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void refreshList_Button_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new FormStorages();
            form.ShowDialog();
            LoadData();
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new FormFillStorage();
            form.ShowDialog();
            LoadData();
        }

        private void ценыПродуктовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    APICustomer.PostRequest<ReportBindingModel,
                   bool>("api/Report/SaveSetPrice", new ReportBindingModel
                   {
                       FileName = sfd.FileName
                   });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void загруженностьСкладовToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new FormStoragesLoad();
            form.ShowDialog();
        }

        private void заказыКлиентовToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new FormCustomerOrder();
            form.ShowDialog();
        }

        private void ЗапускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                APICustomer.PostRequest<int?, bool>("api/Main/StartWork", null);
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void СотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormImplementers();   
            form.ShowDialog();
        }
    }
}
