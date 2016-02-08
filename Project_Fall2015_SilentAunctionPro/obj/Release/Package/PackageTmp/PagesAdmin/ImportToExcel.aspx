<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ImportToExcel.aspx.cs"
    MasterPageFile="~/MasterPages/Admin.Master"
    Inherits="importexcel_Nov29.ImportToExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Import To Excel</title>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
   
      <h2 style="text-align: center; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; border:groove; background:content-box">IMPORT DATA</h2><br /><br /><br />
    <br />
     <h3 style="color:black;margin-left:200px;">Please upload the file and click submit button.<br />
        NOTE:<i style="color:darkred">Data</i> will be shown on the Web Page as well in the form of grid.</h3>
        <div style="margin-left:200px;">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label><br />
        <asp:FileUpload ID="FileUpload1" runat="server" class="btn btn-default btn-file" /><br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Import" class="btn btn-primary" />
        <br />
        
          
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>  <br /><br /> 
    </div>   <asp:GridView ID="GridView1" runat="server" CssClass="table" CellPadding="4" ForeColor="#333333" GridLines="None">
                 <AlternatingRowStyle BackColor="White" />
                 <EditRowStyle BackColor="#2461BF" />
                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EFF3FB" />
                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#F5F7FB" />
                 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                 <SortedDescendingCellStyle BackColor="#E9EBEF" />
                 <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
       
   
</asp:Content>
