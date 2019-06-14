<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="ConfectionaryWeb.ReportViewer"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    С<br/>

    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    По<br/>
    <asp:Calendar ID="Calendar2" runat="server" style="margin-bottom: 0px"></asp:Calendar>

    <asp:Button ID="ButtonMake" runat="server" OnClick="ButtonMake_Click" Text="Сформировать"/>
    <asp:Button ID="ButtonToPdf" runat="server" OnClick="ButtonToPdf_Click" Text="Сохранить в PDF"/>
    <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Назад" Height="25px"/>

    <br/>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" ClientIDMode="AutoID" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" style="margin-top: 0px" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
        <LocalReport ReportPath="ReportConsumerBookings.rdlc">
            <DataSources>
                <rsweb1:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1"/>
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCustomerOrders" TypeName="ConfectionaryDataBase.Implementation.ReportServiceDB">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="model" Type="Object"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <br/>
    <br/>
    <div style="position: absolute; top: 480px; left: 21px;">

    </div>
</form>
</body>
</html>