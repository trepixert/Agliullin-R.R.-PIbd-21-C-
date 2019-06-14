using System;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using Microsoft.Reporting.WebForms;

namespace ConfectionaryWeb {
    public partial class ReportViewer : System.Web.UI.Page {
        private readonly IReportService service = Globals.ReportService;

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void ButtonMake_Click(object sender, EventArgs e) {
            if ( Calendar1.SelectedDate >= Calendar2.SelectedDate ) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllertDate",
                "<script>alert('Дата начала должна быть меньше даты окончания');</script>");
                return;
            }

            try {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod",
                "c " + Calendar1.SelectedDate.ToShortDateString() +
                " по " + Calendar2.SelectedDate.ToShortDateString());
                
                ReportViewer1.LocalReport.SetParameters(parameter);

                var dataSource = service.GetCustomerOrders(new ReportBindingModel {
                    DateFrom = Calendar1.SelectedDate,
                    DateTo = Calendar2.SelectedDate
                });
                ReportDataSource source = new ReportDataSource("DataSetBookings", dataSource);
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
            }
            catch ( Exception ex ) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert",
                "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonToPdf_Click(object sender, EventArgs e) {
            Session["DateFrom"] = Calendar1.SelectedDate.ToString();
            Session["DateTo"] = Calendar2.SelectedDate.ToString();
            Server.Transfer("FormConsumerBookingsSave.aspx");
        }

        protected void ButtonBack_Click(object sender, EventArgs e) {
            Server.Transfer("FormMain.aspx");
        }
    }
}