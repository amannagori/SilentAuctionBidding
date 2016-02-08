<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellItems.aspx.cs"
    MasterPageFile="~/MasterPages/Admin.Master"
    Inherits="Project_Fall2015_SilentAunctionPro.PagesAdmin.SellItems" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Sell Items</title>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <h2 style="text-align: center; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; border:groove; background:content-box">SELL ITEMS</h2>

    <br />
    <asp:MultiView ID="tabContents" ActiveViewIndex="0" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="container" style="width:60%; margin:auto auto;">

            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped"
                OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White"/>
                <Columns>
                    <asp:BoundField DataField="Item Id" HeaderText="Item Id" />

                    <asp:TemplateField HeaderText="Item Name">
                        <ItemTemplate>
                            <asp:Label ID="lName" runat="server" Text='<%# Eval("Item Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lDesc" runat="server" Text='<%# Eval("Item Desc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="sellItemBtn" runat="server" Text="Sell Item" CommandName="sell" CssClass="btn btn-primary"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
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
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="container-fluid" style="width:40%; ">
                                <div class="row" style="background-color:darkgray;">
                                   
                                    <div class="col-lg-4" style="margin-left:160px;">
                                        <div class="page-header">
                                            <h2 style="font:900">Sell Items</h2>
                                        </div>

             <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right:120px;">
                    <asp:TextBox ID="category1" runat="server" ReadOnly="True" class="form-control" placeholder="Category" aria-describedby="basic-addon1"></asp:TextBox></div>
            <br />
           
           <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right:120px;">
                        <asp:TextBox ID="item_name1" runat="server" ReadOnly="True" class="form-control" placeholder="Item Name" aria-describedby="basic-addon1"></asp:TextBox>
           </div> <br />
            
            <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right:120px;">
                        <asp:TextBox ID="item_desc1" runat="server" ReadOnly="True" class="form-control" aria-describedby="basic-addon1"></asp:TextBox>
          </div>  <br />
           
             <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right:120px;">
                     <asp:TextBox ID="item_val1" runat="server" ReadOnly="True" class="form-control" aria-describedby="basic-addon1" >

                     </asp:TextBox></div>
            <br />
          

            <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right:120px;">
                         <asp:TextBox ID="sellingPrice" runat="server" class="form-control" placeholder="Enter Selling Price.." aria-describedby="basic-addon1" ></asp:TextBox></div>
            <br />
           
            <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right:120px;">
                         <asp:DropDownList ID="buyerIdList" runat="server" class="form-control" aria-describedby="basic-addon1"></asp:DropDownList></div>
            <br />
           
            <b style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">Buyer has paid?</b>
                         <asp:DropDownList ID="status" runat="server">
                             <asp:ListItem Value="YES">Yes</asp:ListItem>
                             <asp:ListItem Value="NO">No</asp:ListItem>
                         </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="sell_item" runat="server" Text="Sell Item" OnClick="sell_item_Click" class="btn btn-primary" />
                                        <br />
            <br />

                                        <asp:Label ID="sell_display" runat="server" Text=""></asp:Label>
 <br />
            <br />
            <br /><br /><br /><br />
                                        </div></div></div>
        </asp:View>
    </asp:MultiView>


</asp:Content>
