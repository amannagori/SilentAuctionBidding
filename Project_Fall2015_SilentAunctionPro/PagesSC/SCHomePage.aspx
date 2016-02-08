<%@ Page Title="" Language="C#"
    MasterPageFile="../MasterPages/SteeringMaster.Master"
    AutoEventWireup="true"
    CodeBehind="SCHomePage.aspx.cs"
    Inherits="Project_Fall2015_SilentAunctionPro.PagesSC.SCHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Home</title>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; margin-left:20px; margin-right:20px">

        <br />
        <br />


        <br />
        <br />





        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div style="width: 100%;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <asp:MultiView ID="userview" ActiveViewIndex="0" runat="server">
                        <asp:View ID="View2" runat="server">
                            <%--<ajaxtoolkit:confirmbuttonextender id="ConfirmButtonExtender2" runat="server"
                                displaymodalpopupid="approveP" targetcontrolid="Button3" />


                            <ajaxtoolkit:modalpopupextender id="approveP" runat="server"
                                popupcontrolid="Panel2" okcontrolid="ok2" cancelcontrolid="cancel2" targetcontrolid="Button3">
        </ajaxtoolkit:modalpopupextender>
                            <asp:Panel ID="Panel2" runat="server" BorderStyle="Groove" BackColor="WhiteSmoke" Font-Bold="true" Height="130px">
                                <div>
                                    &nbsp;&nbsp;CONFIRMATION
                                </div>
                                <br />
                                <div>
                                    &nbsp;&nbsp;&nbsp;Are you sure you want to <i style="color: green;">approve</i> all these users?
                                </div>
                                <br />
                                <div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    <asp:Button ID="ok2" class="btn btn-success" runat="server" Text="Yes" />
                                    <asp:Button ID="cancel2" class="btn btn-danger" runat="server" Text="No" />
                                </div>
                            </asp:Panel>

                            <ajaxtoolkit:confirmbuttonextender id="ConfirmButtonExtender1" runat="server"
                                displaymodalpopupid="denyP" targetcontrolid="Button4" />
                            <ajaxtoolkit:modalpopupextender id="denyP" runat="server"
                                popupcontrolid="Panel1" okcontrolid="ok1" cancelcontrolid="cancel1" targetcontrolid="Button4">
        </ajaxtoolkit:modalpopupextender>
                            <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" BackColor="WhiteSmoke" Font-Bold="true" Height="130px">
                                <div>
                                    &nbsp;&nbsp;  CONFIRMATION
                                </div>
                                <br />
                                <div>
                                    &nbsp;&nbsp;&nbsp; Are you sure you want to <i style="color: red;">deny</i> all these users?
                                </div>
                                <br />
                                <div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="ok1" runat="server" class="btn btn-success" Text="Yes" />
                                    <asp:Button ID="cancel1" runat="server" class="btn btn-danger" Text="No" />
                                </div>
                            </asp:Panel>
--%>

                            
                            <br />
                            <br />
                            <div style="width: 40%; clear:left; float:left;">
                                                            <h2>Pending User Requests</h2>
                                                                <asp:GridView class="table" ID="pendingGrid" runat="server" CssClass="table table-hover table-striped"
                                    OnRowCommand="pendingGrid_RowCommand" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
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

                                                <asp:Button ID="ViewEditUser" runat="server" class="btn btn-primary" Text="View" CommandName="View User"
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
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </div>


                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </asp:View>

                        <asp:View ID="View3" runat="server">
                            <div class="container-fluid" style="width: 50%; margin:auto auto">
                                <div class="row" style="background-color: darkgray;">

                                    <div class="col-lg-4" style="margin-left: 220px;">
                                        <div class="page-header">
                                            <h2 style="font: 900">User Information</h2>
                                        </div>

                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" placeholder="User ID" aria-describedby="basic-addon1" runat="server" ID="userid" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="input-group" style="width: 260px; padding-top: 0.3em;">
                                            <div class="input-group" style="float: left; width: 130px; padding-right: 0.5em;">
                                                <asp:TextBox class="form-control" placeholder="First Name" aria-describedby="basic-addon1" runat="server" ID="fname">
                                                </asp:TextBox>
                                            </div>
                                            <div class="input-group" style="float: right; width: 130px;">
                                                <asp:TextBox class="form-control" placeholder="Last Name" aria-describedby="basic-addon1" runat="server" ID="lname"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="input-group" style="width: 260px; padding-top: 0.3em;">
                                            <div class="input-group" style="float: left; width: 120px;">
                                                <asp:TextBox class="form-control" placeholder="Address" aria-describedby="basic-addon1" runat="server" ID="address1">
                                                </asp:TextBox>
                                            </div>
                                            <div class="input-group" style="float: right; width: 130px;">
                                                <asp:TextBox class="form-control" placeholder="Apartment No." aria-describedby="basic-addon1" runat="server" ID="address2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" placeholder="City" aria-describedby="basic-addon1" runat="server" ID="city"></asp:TextBox>
                                        </div>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" placeholder="State" aria-describedby="basic-addon1" runat="server" ID="state"></asp:TextBox>
                                        </div>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" placeholder="Zip" aria-describedby="basic-addon1" runat="server" ID="zip"></asp:TextBox>
                                        </div>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" placeholder="Country" aria-describedby="basic-addon1" runat="server" ID="country"></asp:TextBox>
                                        </div>
                                        <div class="input-group" style="width: 260px; padding-top: 0.3em; padding-right: 120px;">
                                            <div class="input-group" style="float: left; padding-right: 0.5em;">
                                                <asp:TextBox class="form-control" placeholder="Phone Number" MaxLength="10" aria-describedby="basic-addon1" runat="server" ID="phoneNumber">
                                                </asp:TextBox>

                                            </div>

                                        </div>

                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" placeholder="email@email.com" aria-describedby="basic-addon1" runat="server" ID="email">
                                            </asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                        <asp:Button ID="Approve_User" runat="server" Text="Approve" class="btn btn-success" OnClick="Approve_User_Click"></asp:Button>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Deny_User" runat="server" Text="Deny" class="btn btn-danger" OnClick="Deny_User_Click" />
                                        <br />
                                        <br />
                                    </div>
                                </div>


                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </asp:View>

                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <div style="width: 40%; float:left;margin-left:30px;">
            
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="tabContents" ActiveViewIndex="0" runat="server">
                        <asp:View ID="View1" runat="server">
                            <h2>Pending Item Requests</h2>
                            <asp:GridView class="table" ID="GridView1" runat="server" CssClass="table table-hover table-striped"
                                OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
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

                                            <asp:Button ID="ViewEdit" runat="server" class="btn btn-primary" Text="View/Edit" CommandName="View Edit"
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
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>


                        </asp:View>

                        <asp:View ID="itemView" runat="server">
                            <div class="container-fluid" style="margin-left:300px; width:600px">
                                <div class="row" style="background-color: darkgray;">
                                    <div class="col-lg-4"></div>
                                    <div class="col-lg-5">
                                        <div class="page-header">
                                            <h2 style="font: 900">Item Information</h2>
                                        </div>

                                        <b>Category :</b>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" aria-describedby="basic-addon1" runat="server" ID="category" ReadOnly="True"></asp:TextBox>
                                        </div>


                                        <b>Item Name :</b>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" aria-describedby="basic-addon1" runat="server" ID="item_name"></asp:TextBox>
                                        </div>
                                        <b>Item Desc :</b><div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" aria-describedby="basic-addon1" runat="server" ID="item_desc"></asp:TextBox>
                                        </div>

                                        <b>Item Price :</b>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" aria-describedby="basic-addon1" runat="server" ID="item_val"></asp:TextBox>
                                        </div>
                                        <b>Purchase Price:</b>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" aria-describedby="basic-addon1" runat="server" ID="pur_val"></asp:TextBox>
                                        </div>
                                        <b>Min Bid Price :</b>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" aria-describedby="basic-addon1" runat="server" ID="minbid_val"></asp:TextBox>
                                        </div>
                                        <b>Angel Price:</b>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:TextBox class="form-control" aria-describedby="basic-addon1" runat="server" ID="ang_val"></asp:TextBox>
                                        </div>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <asp:Literal ID="imagedisplay" runat="server"></asp:Literal>
                                            <br />
                                            <asp:Image ID="Image1" runat="server" AlternateText="image" BorderColor="Black" BorderStyle="Groove" Width="200px" Height="150px" />
                                        </div>
                                        <div class="input-group" style="width: 374px; padding-top: 0.3em; padding-right: 120px;">
                                            <br />
                                            <asp:Button ID="Approve" runat="server" Text="Approve" class="btn btn-success" OnClick="Approve_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Deny" runat="server" Text="Deny" class="btn btn-danger" OnClick="Deny_Click" />
                                            &nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;

                                        </div>
                                    </div>
                                </div>

                                <br /><br />
                            </div>
                            <%-- <asp:Label ID="Label3" runat="server"></asp:Label>--%>
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

       

    </div>
    <br /><br /><br /><br /><br /><br /><br />
</asp:Content>


