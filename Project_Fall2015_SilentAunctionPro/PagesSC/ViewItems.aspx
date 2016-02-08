<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewItems.aspx.cs"  
    MasterPageFile="../MasterPages/SteeringMaster.Master"
     Inherits="Project_Fall2015_SilentAunctionPro.PagesSC.ViewItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>View Items</title>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/navbar-fixed-top.css" rel="stylesheet" />
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server"><br /><br /><br /><br /><br />

    <br />
  
    <div>

        <asp:ScriptManager ID="manager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>


        <div class="container container-fluid">


            <%--image div ends--%>

            <div>
                <%--header div starts--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>


                        <div class="row">
                            <%--body div content starts--%>

                            <div class="col-xs-12 col-sm12 col-md-12 col-lg-12">
                                <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <%--approval and review navigation panel starts--%>
                                    <strong>By Price:</strong><br />
                                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="lesser than 100" Value="p1"></asp:ListItem>
                                        <asp:ListItem Text="100-200" Value="p2"></asp:ListItem>
                                        <asp:ListItem Text="200-300" Value="p3"></asp:ListItem>
                                        <asp:ListItem Text="300-400" Value="p4"></asp:ListItem>
                                        <asp:ListItem Text="greater than 400" Value="p5"></asp:ListItem>
                                    </asp:CheckBoxList>
                                    <strong>By Category:</strong>
                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                </div>
                                <%--approval and review navigation panel ends--%>


                                <div class="col-xs-10 col-sm10 col-md-10 col-lg-10">
                                    <%--approval and review navigation body starts--%>

                                    <div class="tab-content">

                                        <div role="tabpanel" class="tab-pane fade in active" id="home">
                                            <%--approval navigation body panel starts--%>
                                            <div class="panel panel-primary navigationTabsBodyPanelStyling">
                                                <div class="panel-heading  refereeApprovalMainPanelHeadingStyling">Auction Items</div>

                                                <br />
                                                <div style="text-align: center">
                                                    <asp:TextBox ID="itemName" runat="server"></asp:TextBox>
                                                    <asp:Button ID="search" runat="server" Text="Search" class="btn btn-info " OnClick="search_Click" />
                                                </div>


                                                <div class="panel-body">
                                                    <div class="row" style="margin-top: 20px">
                                                        <div class="row">
                                                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1"></div>
                                                            <div class="col-xs-10 col-sm-10 col-md-10 col-lg-10">

                                                                <div class="panel panel-success">
                                                                    <%--pending referee approval list panel starts--%>

                                                                    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" BorderStyle="None" BorderWidth="2px" CellPadding="3" CellSpacing="2"
                                                                        Font-Names="Verdana" Font-Size="Small" GridLines="Both" RepeatColumns="3"
                                                                        Width="600px">
                                                                        <ItemTemplate>

                                                                            <table class="table table-hover">

                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img src='<%#Eval("filePath") %>' height="200" width="200" runat="server" /><br />
                                                                                            <br />
                                                                                            <b>Item Name:</b>
                                                                                            <asp:Label ID="itemName" runat="server" Text='<%# Bind("itemName") %>'></asp:Label>
                                                                                            <br />
                                                                                            <b>Value:</b>
                                                                                            <asp:Label ID="categ" runat="server" Text=' <%# Bind("itemValue") %>'></asp:Label>
                                                                                            <br />
                                                                                            <b>Min Bid</b>
                                                                                            <asp:Label ID="MinBid" runat="server" Text=' <%# Bind("minBidPrice") %>' ForeColor="Red"></asp:Label>
                                                                                            <br />
                                                                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#deleteProductModal" data-productid="1" data-productname="Product 1">
                                                                                                View Details
                                                                              
                                                                                            </button>

                                                                                        </td>



                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>

                                                                    <br />


                                                                    <br />

                                                                    <hr />
                                                                    <br />




                                                                </div>


                                                            </div>
                                                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1"></div>

                                                        </div>

                                                    </div>





                                                    <br />
                                                    <br />


                                                    <br />
                                                    <br />
                                                </div>
                                                <%--Approval navigation body ends--%>




                                                <%--Review navigation body ends--%>
                                            </div>

                                        </div>
                                        <%--approval and review navigation body ends--%>
                                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>

        </div>
    </div>


</asp:Content>
