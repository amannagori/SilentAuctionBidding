<%@ Page Language="C#" AutoEventWireup="true" 
         MasterPageFile="~/MasterPages/PublicUser.Master" 
    CodeBehind="CheckBidStatus.aspx.cs" 
    Inherits="Project_Fall2015_SilentAunctionPro.PagesPublic.CheckBidStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Bid Status</title>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/navbar-fixed-top.css" rel="stylesheet" />
  
</asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <br /> <br /> <br /> <br /> <br /> 
      <h2 style="text-align: center; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; border:groove; background:content-box">CHECK BID STATUS</h2>
 <br /><br /> 

      <asp:Panel ID="Panel1" runat="server">
            <div class="noprint jumbotron" style="text-align: center; color: red">
                <h2>
                    <asp:Label ID="itemSoldMsg" runat="server"></asp:Label></h2>
            </div>
        </asp:Panel>
    
     
     
     
     
     
     <div style="width:800px; margin:auto auto;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="table" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Item Id" HeaderText="Item Id"/>
                <asp:TemplateField HeaderText="Item Name">
                    <ItemTemplate>
                        <asp:Label ID="itemName" runat="server" Text='<%# Eval("Item Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="itemDesc" runat="server" Text='<%# Eval("Item Desc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="itemPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
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

    </div>


</asp:Content>