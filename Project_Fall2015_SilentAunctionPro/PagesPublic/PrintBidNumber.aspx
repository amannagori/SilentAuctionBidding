<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PublicUser.Master" 
    AutoEventWireup="true"
    CodeBehind="PrintBidNumber.aspx.cs" Inherits="sub_test.PrintBidNumber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Print Bidder Number</title>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="noprint">
        <br />
        <br />
        <br />
        <br />
    </div>
    <style type="text/css">
        @media print {
            @page {
                margin: 0 auto 0 auto;
            }

            .noprint {
                display: none;
            }

            .bidNo {
                font-size: 380px;
            }
             #footerDiv {
                       display: none;
                   }
        }

        @media screen {
            #fotLogo, #fotlogo1 {
                display: none;
            }
        }

        form {
            width: 800px;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
    <br />
  
    <br />
    <p style="text-align: center" id="fotLogo">
        <asp:Image ID="Image2" runat="server" ImageUrl="../UserSpecificPages/babyFold%20logo.PNG" Height="130px" Width="800px" />
    </p>
  
   
    <div class="jumbotron" style="background-color:lightslategray;">
        <br />
        <p style="text-align: center; font-weight: bold; font-size: 40px">
            <asp:Label ID="Label2" runat="server" Text="Bidder Name : "></asp:Label>
            <asp:Label ID="bidderName" runat="server" Font-Size="40px"></asp:Label>
        </p>
        <br />
        <p style="text-align: center; font-weight: bold; font-size: 40px">
            <asp:Label ID="Label1" runat="server" Text="Bidder Number" Font-Size="40px"></asp:Label>
            <br />
            <strong>
                <asp:Label ID="bidderNumber" runat="server" class="bidNo"></asp:Label>
            </strong>
        </p>
        <p style="text-align: right" id="fotlogo1">
            <asp:Image ID="Image1" runat="server" ImageUrl="../UserSpecificPages/fotLogo.jpg" Height="130px" Width="240px" />
        </p>
    </div>
    
     <p class="noprint" style="margin:0px auto;">
        <asp:Button ID="Button1" runat="server" Text="Print" class="btn btn-lg btn-primary" OnClick="Button1_Click"  />
    </p>
    <%--<div style="clear: both" class="noprint">
        <br />
        <br />
        
    </div>--%>

    <script src="http://code.jquery.com/jquery.js"></script>
    <!-- If no online access, fallback to our hardcoded version of jQuery -->
    <script>window.jQuery || document.write('<script src="../Scripts/jquery-1.9.1.min.js"><\/script>')</script>
    <!-- Bootstrap JS -->
    <script src="Scripts/bootstrap.min.js"></script>
    <%-- <footer class="bs-docs-footer" role="contentinfo">
        <div class="container">
            <p style="text-align: center; color: white;">Copyright &copy; 2015 Silent Auction Pro</p>
        </div>
    </footer>
    --%>
</asp:Content>
