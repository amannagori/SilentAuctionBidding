<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/MasterPages/PublicUser.Master"
    CodeBehind="DonateItems.aspx.cs"
    Inherits="Project_Fall2015_SilentAunctionPro.PagesPublic.DonateItems" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Donate Item</title>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/navbar-fixed-top.css" rel="stylesheet" />
    <link href="../assets/css_master/form-elements.css" rel="stylesheet" />
    <link href="../assets/css_master/style.css" rel="stylesheet" />

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script type = "text/javascript">
        function uploadComplete(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "File Uploaded Successfully";
        }
        function uploadError(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "File upload failed.";
        } 
</script> 


 <asp:ScriptManager ID="ScriptManager1" runat="server"> 
    </asp:ScriptManager> 

    <br />
    <br />
    <br />
    <br />
    <br />
    <div style="margin-left: 460px;">
        <div class="row">

            <div class="col-sm-6 form-box">
                
                <div class="form-top">
                    <div class="form-top-left">
                        <h2>Donate Item</h2>
                        <p>
                            Please Enter the following details and 
                                     and click on <b>Donate</b> button.
                        </p>
                    </div>
                </div>

                
                <div class="form-bottom">

                    <div class="container text-center">
                          <div class="dropdown" style=" margin-left:68px;;width: 235px;">
                                <asp:DropDownList ID="DropDownList1" Style="height: 60px" ForeColor="White" CssClass="form-control" BackColor="#333333" runat="server">
                                </asp:DropDownList>
                          </div>

                        <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                            <asp:TextBox ID="item_name" placeholder="Item Name" ForeColor="White" runat="server"></asp:TextBox>
                        </div>

                        <div class="input-group" style="width:33%; padding-top: 0.3em;">
                             <asp:TextBox ID="item_desc" placeholder="Item Description" ForeColor="White" runat="server"></asp:TextBox>
                           
                        </div>

                        <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                           <asp:TextBox ID="item_val"  placeholder="Approximate Value" ForeColor="White" runat="server"></asp:TextBox>

                        </div>

                        <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                           
                             <asp:TextBox ID="Purchase_price" placeholder="Purchase Price" ForeColor="White" runat="server"></asp:TextBox>     

                        </div>
                        <br />
                        <%--<div class="input-group" style="width: 80px; margin-left:70px;padding-top: 0.3em;">
                              <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>--%>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <cc1:AsyncFileUpload OnClientUploadError="uploadError" OnClientUploadComplete="uploadComplete"
                                    runat="server" ID="AsyncFileUpload1" Width="400px" UploaderStyle="Modern" CompleteBackColor="White"
                                    UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" />
                                <asp:Image ID="imgLoader" runat="server" ImageUrl="progress.gif" />
                                <br />
                                <asp:Label ID="lblMesg" runat="server" Text=""></asp:Label>

                            </ContentTemplate>
                        </asp:UpdatePanel>


                        <br />
                        <div class="input-group" style="margin-left:80px;">
                       <div class="btn-group" role="group" aria-label="..." style=" padding-top: 0.3em;">
                              <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" class="btn btn-primary" /> &nbsp;&nbsp;&nbsp;
                          <a href="ttps://twitter.com/share" class="twitter-share-button"{count} data-text="I just Donated item on Silent Auction!" data-size="large" data-related="SilentAuction">Tweet</a>                
                        </div>
                       </div>
                        <div>
                            <br />
                            <asp:Label ID="lblStatus" ForeColor="Green" runat="server" Text="" />
                        </div>
                        <br />
                        <br />

                    </div>
                </div>
            </div>
        </div>

    </div>
    <script>
        !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');

    </script>

</asp:Content>
   

