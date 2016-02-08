<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPages/Main.Master" CodeBehind="SteeringLogin.aspx.cs" Inherits="Project_Fall2015_SilentAunctionPro.SteeringLogin" %>

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
  
        <form runat="server" id="form1"> 
            
            
             <div class="jumbotron" align="center">
            <br />
                  <h2 style="color:green; font:bold status-bar;">PROTECTED: STREERING COMMITTEE</h2>
        <br />
                 <p align="center" style="color:green;" >This content is password protected. To view it please enter your password below:</p>
             <h4 style="color:green;">Password: 
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Submit" /></h4>
 </div><br /></form> 
        

    <script src="http://code.jquery.com/jquery.js"></script>
    <!-- If no online access, fallback to our hardcoded version of jQuery -->
    <script>window.jQuery || document.write('<script src="../Scripts/jquery-1.9.1.min.js"><\/script>')</script>
    <!-- Bootstrap JS -->
    <script src="Scripts/bootstrap.min.js"></script>
    </asp:Content>

