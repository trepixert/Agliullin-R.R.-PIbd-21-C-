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
    public partial class FormDetails : Form {

        public FormDetails()
        {
            InitializeComponent();
        }

        private void FormDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<CustomerViewModel> list =
               APICustomer.GetRequest<List<CustomerViewModel>>("api/Detail/GetList");
                if (list != null)
                {
                    dataGridViewDetails.DataSource = list;
                    dataGridViewDetails.Columns[0].Visible = false;
                    dataGridViewDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormDetail();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewDetails.SelectedRows.Count == 1)
            {
                var form = new FormDetail();
                form.Id = Convert.ToInt32(dataGridViewDetails.SelectedRows[0].Cells[0].Value);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewDetails.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewDetails.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        APICustomer.PostRequest<DetailBindingModel, bool>("api/Detail/DelElement", new DetailBindingModel { ID = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
