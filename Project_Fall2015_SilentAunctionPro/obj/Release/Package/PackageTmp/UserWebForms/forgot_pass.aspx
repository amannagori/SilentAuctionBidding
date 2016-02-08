<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgot_pass.aspx.cs" MasterPageFile="~/MasterPages/SignUp.Master"
    Inherits="forgot_password.forgot_pass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Forgot Password</title>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />  <br />
    <br />

    <div class="jumbotron" style="width:60%; margin:0 auto;">
        <br />
        <p>Please Enter Your Email to Retrive Your Password:</p>
        <span style="text-align: center; font-weight: bold; font-size: 20px">
             Email Address:
        </span>
        <asp:TextBox ID="txtEmail" runat="server" Width = "300" />
        <br />
        <br />
        <asp:Button Text="Send" runat="server" class="btn btn-primary" OnClick="SendEmail" />
        <br />

        <asp:Label ID="lblMessage" runat="server"></asp:Label>
     
    </div>


   
 </asp:Content>
