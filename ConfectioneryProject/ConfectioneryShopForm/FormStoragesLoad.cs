using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
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

namespace ConfectioneryShopForm {
    public partial class FormStoragesLoad : Form {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IReportService service;


        public FormStoragesLoad(IReportService service) {
            InitializeComponent();
            this.service = service;
        }

        private void FormStoragesLoad_Load(object sender, EventArgs e) {
            try {
                var dict = service.GetStorageLoad();
                if (dict != null) {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict) {
                        dataGridView.Rows.Add(new object[] { elem.StorageName, "", "" });
                        foreach (var listElem in elem.Components) {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1,
                            listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount
});
                        dataGridView.Rows.Add(new object[] { });
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void saveToExcel_Button_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == DialogResult.OK) {
                try {
                    service.SaveStorageLoad(new ReportBindingModel {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
    }
}
