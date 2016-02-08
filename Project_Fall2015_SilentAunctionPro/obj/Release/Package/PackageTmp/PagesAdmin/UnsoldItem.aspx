<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnsoldItem.aspx.cs"
    MasterPageFile="~/MasterPages/Admin.Master"    
     Inherits="Project_Fall2015_SilentAunctionPro.PagesAdmin.UnsoldItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Silent Auction Pro</title>
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped"
        OnRowCommand="pendingGrid_RowCommand" AutoGenerateColumns="false">
          <Columns>
                                <asp:BoundField DataField="Item Id" HeaderText="Item Id" />
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="Itemdesc" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approval Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblas" runat="server" Text='<%# Eval("Approval Status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <%--<asp:Button ID="approve" runat="server" Text="Approve" CommandName="Approve"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        <asp:Button ID="deny" runat="server" Text="Deny" CommandName="Deny"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />--%>

                                        <asp:Button ID="ViewEditUser" runat="server" Text="View" CommandName="View User"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />

                                    </ItemTemplate>
                                </asp:TemplateField>
             </Columns>


    </asp:GridView>


   </asp:Content>

