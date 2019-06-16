using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopForm {
    public partial class FormMails : Form {
        public FormMails() {
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e) {
            try {
                List<MessageInfoViewModel> list =
                    APICustomer.GetRequest<List<MessageInfoViewModel>>("api/MessageInfo/GetList");
                if ( list != null ) {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch ( Exception ex ) {
                while ( ex.InnerException != null ) {
                    ex = ex.InnerException;
                }

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}