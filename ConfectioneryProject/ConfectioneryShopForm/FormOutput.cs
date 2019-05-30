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
    public partial class FormOutput : Form {

        public int Id { set { id = value; } }

        private int? id;

        private List<ConnectionBetweenDetailAndOutputViewModel> detailOutput;

        public FormOutput()
        {
            InitializeComponent();
        }

        private void FormOutuut_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    OutputViewModel set =
                    APICustomer.GetRequest<OutputViewModel>("api/Output/Get/" + id.Value);
                    textBoxName.Text = set.OutputName;
                    textBoxPrice.Text = set.Price.ToString();
                    detailOutput = set.OutputDetail;
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                detailOutput = new List<ConnectionBetweenDetailAndOutputViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (detailOutput != null)
                {
                    dataGridViewOutputs.DataSource = null;
                    dataGridViewOutputs.DataSource = detailOutput;
                    dataGridViewOutputs.Columns[1].Visible = false;
                    dataGridViewOutputs.Columns[2].Visible = false;
                    dataGridViewOutputs.Columns[3].Visible = false;
                    dataGridViewOutputs.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewOutputs.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataGridViewOutputs.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        APICustomer.PostRequest<CustomerBindingModel, bool>("api/Customer/DelElement", new CustomerBindingModel { ID = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewOutputs.SelectedRows.Count == 1)
            {
                var form = new FormCustomer
                {
                    Id = Convert.ToInt32(dataGridViewOutputs.SelectedRows[0].Cells[0].Value)
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormDetailOutput();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.OutputID = id.Value;
                    }
                    detailOutput.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (detailOutput == null || detailOutput.Count == 0)
            {
                MessageBox.Show("Заполните блюда", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<ConnectionBetweenDetailAndOutput> outputDetailBM = new List<ConnectionBetweenDetailAndOutput>();
                for (int i = 0; i < detailOutput.Count; ++i)
                {
                    outputDetailBM.Add(new ConnectionBetweenDetailAndOutput
                    {
                        ID = detailOutput[i].ID,
                        OutputID = detailOutput[i].OutputID,
                        DetailID = detailOutput[i].DetailID,
                        Count = detailOutput[i].Count
                    });
                }
                if (id.HasValue)
                {
                    APICustomer.PostRequest<OutputBindingModel, bool>("api/Output/UpdElement", new OutputBindingModel
                    {
                        ID = id.Value,
                        OutputName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        OutputDetail = outputDetailBM
                    });
                }
                else
                {
                    APICustomer.PostRequest<OutputBindingModel, bool>("api/Set/AddElement", new OutputBindingModel
                    {
                        OutputName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        OutputDetail = outputDetailBM
                    });
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
