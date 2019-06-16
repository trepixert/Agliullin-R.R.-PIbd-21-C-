using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;
using Microsoft.Reporting.WinForms;

namespace ConfectioneryShopForm {
    public partial class FormCustomerOrder : Form {
        public FormCustomerOrder() {
            InitializeComponent();
        }

        private void FormCustomerOrder_Load(object sender, EventArgs e) {
            this.reportViewer.RefreshReport();
        }

        private void format_Button_Click(object sender, EventArgs e) {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date) {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod",
                "c " +
                dateTimePickerFrom.Value.ToShortDateString() +
                " по " +
                dateTimePickerTo.Value.ToShortDateString());
                reportViewer.LocalReport.SetParameters(parameter);
                List<CustomerOrdersModel> response =
                    APICustomer.PostRequest<ReportBindingModel,
                        List<CustomerOrdersModel>>("api/Report/GetCustomerOrders", new ReportBindingModel {
                        DateFrom = dateTimePickerFrom.Value,
                        DateTo = dateTimePickerTo.Value
                    });
                ReportDataSource source = new ReportDataSource("DataSetOrders",
                response);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonToPdf_Click(object sender, EventArgs e) {
            if ( dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date ) {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog {
                Filter = "pdf|*.pdf"
            };

            if ( sfd.ShowDialog() == DialogResult.OK ) {
                try {
                    APICustomer.PostRequest<ReportBindingModel,
                        bool>("api/Report/SaveCustomerOrders", new ReportBindingModel {
                        FileName = sfd.FileName,
                        DateFrom = dateTimePickerFrom.Value,
                        DateTo = dateTimePickerTo.Value
                    });

                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch ( Exception ex ) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
    }
}