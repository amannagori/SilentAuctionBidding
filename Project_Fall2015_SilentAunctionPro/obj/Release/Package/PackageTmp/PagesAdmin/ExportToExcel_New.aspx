<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="ExportToExcel_New.aspx.cs" MasterPageFile="~/MasterPages/Admin.Master"
    Inherits="Project_Fall2015_SilentAunctionPro.PagesAdmin.ExportToExcel_New" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Export To Excel</title>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><br /><br />

       <h2 style="text-align: center; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; border:groove; background:content-box">EXPORT DATA</h2><br /><br />
     
    
        <div class="container" style="background-color:darkgray;">
    <h3 style="color:azure;margin-left:200px;">Please Click the button given below to export the Data.<br />
        NOTE:Data will be shown on the Web Page as well as a <i style="color:darkred">file</i> will be downloaded for backup purpose.</h3><br />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp; <asp:Button ID="ExportToExcel"  CssClass="btn-primary" runat="server" Text="Export Data" OnClick="ExportToExcel_Click"/>
            <br />
            <br />
    </div>
<br /><br />
   <div style="width:80%; margin:auto auto;">
    <asp:GridView ID="GridView1" class="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <sortedascendingcellstyle backcolor="#F5F7FB" />
        <sortedascendingheaderstyle backcolor="#6D95E1" />
        <sorteddescendingcellstyle backcolor="#E9EBEF" />
        <sorteddescendingheaderstyle backcolor="#4870BE" />
    </asp:GridView>
        </div>
    

</asp:Content>