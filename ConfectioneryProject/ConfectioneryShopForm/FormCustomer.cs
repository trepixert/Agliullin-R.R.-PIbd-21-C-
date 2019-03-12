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
    public partial class FormCustomer : Form {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ICustomerService service;

        private int? id;

        public FormCustomer(ICustomerService service) {
            InitializeComponent();
            this.service = service;
        }

        private void save_Button_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBoxFIO.Text)) {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try {
                if (id.HasValue) {
                    service.updElem(new CustomerBindingModel {
                        ID = id.Value,
                        CustomerFIO = textBoxFIO.Text
                    });
                } else{
                    service.addElem(new CustomerBindingModel {
                        CustomerFIO = textBoxFIO.Text
                    });
                }
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

        private void Client_Load(object sender, EventArgs e) {
            if (id.HasValue) {
                try {
                    CustomerViewModel view = service.getElement(id.Value);
                    if (view != null) {
                        textBoxFIO.Text = view.CustomerFIO;
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
    }
}
