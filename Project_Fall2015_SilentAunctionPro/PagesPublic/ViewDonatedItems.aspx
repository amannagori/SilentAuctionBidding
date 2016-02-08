<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="ViewDonatedItems.aspx.cs" 
             MasterPageFile="~/MasterPages/PublicUser.Master" 
    Inherits="Project_Fall2015_SilentAunctionPro.PagesPublic.ViewDonatedItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>View Donated Item</title>
    <link href="./bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="./bootstrap/customBootstrapJS/jquery-latest.js"></script>
    <script src="./bootstrap/js/bootstrap.js"></script>
    <link href="./bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="./bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="./bootstrap/customBootstrapCSS/prettify.css" rel="stylesheet" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
    <link href="Content/Custom_StyleSheet/SchoolApprovalRatingPage.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <br />
   
    <%-- modal Testing on this page starts--%>


    <div class="modal fade" id="deleteProductModal" tabindex="-1" role="dialog" aria-labelledby="deleteProductModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="deleteProductModalLabel">Item Details- </h4>
                </div>
                <div class="modal-body">
                </div>

            </div>
        </div>
    </div>
    <%-- modal Testing on this page ends--%>
    <div>

        <asp:ScriptManager ID="manager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>


        <div class="container container-fluid">


            <%--image div ends--%>

            <div>
                <%--header div starts--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>


                        <div class="row">
                          

                            <div class="col-xs-12 col-sm12 col-md-12 col-lg-12">
                                  <%--<div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">

                                    <div class="panel panel-primary">
                                        <div class="panel-heading">Search</div>

                                        <div class="panel-body">
                                            <strong>By Price:</strong><br /><br />
                                            <asp:CheckBoxList ID="CheckBoxList2" runat="server" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="lesser than 100" Value="p1"></asp:ListItem>
                                                <asp:ListItem Text="100-200" Value="p2"></asp:ListItem>
                                                <asp:ListItem Text="200-300" Value="p3"></asp:ListItem>
                                                <asp:ListItem Text="300-400" Value="p4"></asp:ListItem>
                                                <asp:ListItem Text="greater than 400" Value="p5"></asp:ListItem>
                                            </asp:CheckBoxList><br />             
                                        </div>
                                    </div>
                                </div>--%>
                               

                                 <div class="col-xs-9 col-sm9 col-md-9 col-lg-9">
                                   
                                    <div class="tab-content">

                                        <div role="tabpanel" class="tab-pane fade in active" id="home">
                                            <%--approval navigation body panel starts--%>
                                            <div class="panel panel-primary navigationTabsBodyPanelStyling">
                                                <div class="panel-heading  refereeApprovalMainPanelHeadingStyling">My Donated Items</div>

                                                <div class="panel-body">
                                                    <div class="row" style="margin-top: 20px">
                                                        <div class="row">
                                                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1"></div>
                                                             <div class="col-xs-9 col-sm9 col-md-9 col-lg-9">
                                                               
                                                                    <%--pending referee approval list panel starts--%>

                                                                    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" BorderStyle="None" BorderWidth="" CellPadding="3" CellSpacing="2"
                                                                        Font-Names="Verdana" Font-Size="Small"  RepeatColumns="3" GridLines="Both"
                                                                        Width="600px">
                                                                        <ItemTemplate>

                                                                            <table class="table table-hover">

                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img src='<%#Eval("filePath") %>' height="120" width="200" runat="server" /><br />
                                                                                            <br />
                                                                                            <b>Item Name :
                                                                                            <asp:Label ID="itemName" runat="server" Text=' <%# Bind("itemName") %>'></asp:Label></b>
                                                                                            <br />
                                                                                            <b>Selling Price :
                                                                                            <asp:Label ID="categ" runat="server" Text=' <%# Bind("sellingPrice") %>'></asp:Label></b>
                                                                                            <br />
                                                                                            <b>Status:
                                                                                            <asp:Label ID="Label1" runat="server" Text=' <%# Bind("itemStatus") %>' ForeColor="Red"></asp:Label></b>
                                                                                            <br />
                                                                                            <b>Approval Status:
                                                                                                <asp:Label ID="apstat" runat="server" Text=' <%# Bind("approvalStatus") %>'></asp:Label></b>
                                                                                          

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
                                    </div>
                                </div>
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>

        </div>
    </div>

    <%--body div content ends--%>
    <script>
        $(document).ready(function () {
            $('#deleteProductModal').on('show.bs.modal', function (event) { // id of the modal with event
                var button = $(event.relatedTarget) // Button that triggered the modal
                var productid = button.data('productid') // Extract info from data-* attributes
                var productname = button.data('productname')

                var title = 'Item Detail'
                var content = 'Item Name ?'

                // Update the modal's content.
                var modal = $(this)
                modal.find('.modal-title').text(title)
                modal.find('.modal-body').text(content)

                // And if you wish to pass the productid to modal's 'Yes' button for further processing
                modal.find('btn btn-primary btn-lg').val(productid)
            })
        })


        $('#myTab a').click(function (e) {
            e.preventDefault();
            $(this).tab('show');
        })
    </script>

</asp:Content>