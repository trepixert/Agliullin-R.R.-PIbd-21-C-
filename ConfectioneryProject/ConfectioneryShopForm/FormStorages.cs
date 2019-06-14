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
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class FormStorages : Form {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IStorageService service;

        public FormStorages(IStorageService service) {
            InitializeComponent();
            this.service = service;
        }

        private void add_Button_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormStorage>();
            if (form.ShowDialog() == DialogResult.OK) {
                LoadData();
            }
        }

        private void change_Button_Click(object sender, EventArgs e) {
            if (dataGridViewStorages.SelectedRows.Count == 1) {
                var form = Container.Resolve<FormStorage>();
                form.Id = Convert.ToInt32(dataGridViewStorages.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK) {
                    LoadData();
                }
            }
        }

        private void delete_Button_Click(object sender, EventArgs e) {
            if (dataGridViewStorages.SelectedRows.Count == 1) {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes) {
                    int id =
               Convert.ToInt32(dataGridViewStorages.SelectedRows[0].Cells[0].Value);
                    try {
                        service.DelElem(id);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void update_Button_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void FormStorages_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                List<StorageViewModel> list = service.GetList();
                if (list != null) {
                    dataGridViewStorages.DataSource = list;
                    dataGridViewStorages.Columns[0].Visible = false;
                    dataGridViewStorages.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
