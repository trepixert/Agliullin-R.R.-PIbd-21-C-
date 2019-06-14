﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using Unity;

namespace ConfectioneryShopForm {
    public partial class FormOutput : Form {
        [Dependency] public new IUnityContainer Container { get; set; }

        public int Id {
            set { id = value; }
        }

        private readonly IOutputService service;
        private int? id;
        private List<ConnectionBetweenDetailAndOutputViewModel> productComponents;

        public FormOutput(IOutputService service) {
            InitializeComponent();
            this.service = service;
        }

        private void FormProduct_Load(object sender, EventArgs e) {
            if ( id.HasValue ) {
                try {
                    OutputViewModel view = service.GetElement(id.Value);
                    if ( view != null ) {
                        textBoxName.Text = view.OutputName;
                        textBoxPrice.Text = view.Price.ToString();
                        productComponents = view.OutputDetail;
                        LoadData();
                    }
                }
                catch ( Exception ex ) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else {
                productComponents = new List<ConnectionBetweenDetailAndOutputViewModel>();
            }
        }

        private void LoadData() {
            try {
                if ( productComponents != null ) {
                    dataGridViewOutputs.DataSource = null;
                    dataGridViewOutputs.DataSource = productComponents;
                    dataGridViewOutputs.Columns[0].Visible = false;
                    dataGridViewOutputs.Columns[1].Visible = false;
                    dataGridViewOutputs.Columns[2].Visible = false;
                    dataGridViewOutputs.Columns[3].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void add_Button_Click(object sender, EventArgs e) {
            var form = Container.Resolve<FormDetailOutput>();
            if ( form.ShowDialog() == DialogResult.OK ) {
                if ( form.Model != null ) {
                    if ( id.HasValue ) {
                        form.Model.OutputID = id.Value;
                    }

                    productComponents.Add(form.Model);
                }

                LoadData();
            }
        }

        private void change_Button_Click(object sender, EventArgs e) {
            if ( dataGridViewOutputs.SelectedRows.Count == 1 ) {
                var form = Container.Resolve<FormDetailOutput>();
                form.Model =
                    productComponents[dataGridViewOutputs.SelectedRows[0].Cells[0].RowIndex];
                if ( form.ShowDialog() == DialogResult.OK ) {
                    productComponents[dataGridViewOutputs.SelectedRows[0].Cells[0].RowIndex] =
                        form.Model;
                    LoadData();
                }
            }
        }

        private void delete_Button_Click(object sender, EventArgs e) {
            if ( dataGridViewOutputs.SelectedRows.Count == 1 ) {
                if ( MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes ) {
                    try {
                        productComponents.RemoveAt(dataGridViewOutputs.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch ( Exception ex ) {
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

        private void save_Button_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty(textBoxName.Text) ) {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            if ( string.IsNullOrEmpty(textBoxPrice.Text) ) {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            if ( productComponents == null || productComponents.Count == 0 ) {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            try {
                List<ConnectionBetweenDetailAndOutput> productComponentBM = new
                    List<ConnectionBetweenDetailAndOutput>();
                for ( int i = 0; i < productComponents.Count; ++i ) {
                    productComponentBM.Add(new ConnectionBetweenDetailAndOutput {
                        ID = productComponents[i].ID,
                        OutputID = productComponents[i].OutputID,
                        DetailID = productComponents[i].DetailID,
                        Count = productComponents[i].Count
                    });
                }

                if ( id.HasValue ) {
                    service.UpdElem(new OutputBindingModel {
                        ID = id.Value,
                        OutputName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        OutputDetail = productComponentBM
                    });
                }
                else {
                    service.AddElem(new OutputBindingModel {
                        OutputName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        OutputDetail = productComponentBM
                    });
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch ( Exception ex ) {
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