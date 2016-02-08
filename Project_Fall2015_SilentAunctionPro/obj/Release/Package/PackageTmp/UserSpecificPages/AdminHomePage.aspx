<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="~/UserSpecificPages/AdminHomePage.aspx.cs" Inherits="Project_Fall2015_SilentAunctionPro.UserSpecificPages.AdminHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Silent Auction Pro</title>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/navbar-fixed-top.css" rel="stylesheet" />

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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div style="width:60%;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <asp:MultiView ID="userview" ActiveViewIndex="0" runat="server">
                    <asp:View ID="View2" runat="server">
                        <asp:GridView ID="pendingGrid" runat="server" CssClass="table table-hover table-striped"
                             OnRowCommand="pendingGrid_RowCommand" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="User Id" HeaderText="User Id" />
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
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
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </asp:View>

                    <asp:View ID="View3" runat="server">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-4"></div>
                                <div class="col-lg-4">
                                    <div class="page-header">
                                        <h2>View User Information</h2>
                                    </div>

                                    <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                        <asp:TextBox class="form-control" placeholder="User ID" aria-describedby="basic-addon1" runat="server" ID="userid" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                        <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                            <asp:TextBox class="form-control" placeholder="First Name" aria-describedby="basic-addon1" runat="server" ID="fname">
                                            </asp:TextBox>
                                        </div>
                                        <div class="input-group" style="float: right; width: 187px;">
                                            <asp:TextBox class="form-control" placeholder="Last Name" aria-describedby="basic-addon1" runat="server" ID="lname"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                        <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                            <asp:TextBox class="form-control" placeholder="Address" aria-describedby="basic-addon1" runat="server" ID="address1">
                                            </asp:TextBox>
                                        </div>
                                        <div class="input-group" style="float: right; width: 187px;">
                                            <asp:TextBox class="form-control" placeholder="Apartment No." aria-describedby="basic-addon1" runat="server" ID="address2"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                        <asp:TextBox class="form-control" placeholder="City" aria-describedby="basic-addon1" runat="server" ID="city"></asp:TextBox>
                                    </div>
                                    <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                        <asp:TextBox class="form-control" placeholder="State" aria-describedby="basic-addon1" runat="server" ID="state"></asp:TextBox>
                                    </div>
                                    <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                        <asp:TextBox class="form-control" placeholder="Zip" aria-describedby="basic-addon1" runat="server" ID="zip"></asp:TextBox>
                                    </div>
                                    <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                        <asp:TextBox class="form-control" placeholder="Country" aria-describedby="basic-addon1" runat="server" ID="country"></asp:TextBox>
                                    </div>
                                    <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                        <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                            <asp:TextBox class="form-control" placeholder="Phone Number" MaxLength="10" aria-describedby="basic-addon1" runat="server" ID="phoneNumber">
                                            </asp:TextBox>

                                        </div>

                                    </div>

                                    <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                        <asp:TextBox class="form-control" placeholder="email@email.com" aria-describedby="basic-addon1" runat="server" ID="email">
                                        </asp:TextBox>
                                    </div>
                                    <br /><br />
                                    <asp:Button ID="Approve_User" runat="server" Text="Approve" class="btn btn-primary" OnClick="Approve_User_Click"></asp:Button>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Deny_User" runat="server" Text="Deny" class="btn btn-primary" OnClick="Deny_User_Click"/>
                                </div>
                            </div>
                     
                        <div class="col-lg-4"></div>
                        </div>
 
                    </asp:View>

                </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <hr />
    <div style="width:60%;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:MultiView ID="tabContents" ActiveViewIndex="0" runat="server">
                    <asp:View ID="View1" runat="server">

                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped"
                            OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false">
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
                                        <%-- <asp:Button ID="approve1" runat="server" Text="Approve" CommandName="Approve"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        <asp:Button ID="deny1" runat="server" Text="Deny" CommandName="Deny"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />--%>

                                        <asp:Button ID="ViewEdit" runat="server" Text="View/Edit" CommandName="View Edit"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>


                    </asp:View>

                    <asp:View ID="itemView" runat="server">
                        Category:
                       <asp:TextBox ID="category" runat="server" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />
                        Item Name:
                        <asp:TextBox ID="item_name" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        Item Description:
                        <asp:TextBox ID="item_desc" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        Approx. Value:
                        <asp:TextBox ID="item_val" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <%-- <asp:FileUpload ID="FileUpload1" runat="server" />

                        <br />
                        <br />
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>--%>
                        <asp:Literal ID="imagedisplay" runat="server"></asp:Literal>

                        <br />
                        <br />
                        <asp:Button ID="Approve" runat="server" Text="Approve" OnClick="Approve_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Deny" runat="server" Text="Deny" OnClick="Deny_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="UpdateItem" runat="server" Text="Update" OnClick="UpdateItem_Click" />
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <script src="http://code.jquery.com/jquery.js"></script>
    <!-- If no online access, fallback to our hardcoded version of jQuery -->
    <script>window.jQuery || document.write('<script src="../Scripts/jquery-1.9.1.min.js"><\/script>')</script>
    <!-- Bootstrap JS -->
    <script src="Scripts/bootstrap.min.js"></script>
    <footer class="bs-docs-footer" role="contentinfo">
        <div class="container">
            <p style="text-align: center; color: white;">Copyright &copy; 2015 Silent Auction Pro</p>
        </div>
    </footer>


</asp:Content>



