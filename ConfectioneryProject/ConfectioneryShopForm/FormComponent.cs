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
    public partial class FormComponent : Form {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { Id = value; } }

        private readonly IComponentService service;

        private int? id;

        public FormComponent(IComponentService service) {
            InitializeComponent();
            this.service = service;
        }

        private void Component_Load(object sender, EventArgs e) {
            if (id.HasValue) {
                try {
                    ComponentViewModel view = service.getElement(id.Value);
                    if (view != null) {
                        textBoxComponent.Text = view.ComponentName;
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void save_Button_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBoxComponent.Text)) {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try {
                if (id.HasValue) {
                    service.updElem(new ComponentBindingModel {
                        ID = id.Value,
                        ComponentName = textBoxComponent.Text
                    });
                } else {
                    service.addElem(new ComponentBindingModel
                    {
                     ComponentName = textBoxComponent.Text
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
    }
}
