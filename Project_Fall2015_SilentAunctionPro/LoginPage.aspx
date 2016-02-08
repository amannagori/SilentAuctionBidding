<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs"
    MasterPageFile="~/MasterPages/SignUp.Master"
    Inherits="Project_Fall2015_SilentAunctionPro.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <%--    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />--%>
    <title>Login Page</title>

    <link href="../assets/css_master/form-elements.css" rel="stylesheet" />
    <link href="../assets/css_master/style.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <br />
                <br />
                <br />
                <br />
                <asp:TextBox placeholder="User ID"
                    AutoPostBack="true" OnTextChanged="ajax_userid"
                    runat="server" ID="userid"> 
                </asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ForeColor="Red" ControlToValidate="userid" ErrorMessage="UserId is Required"></asp:RequiredFieldValidator>

                <asp:Label ID="Label1" ForeColor="IndianRed" Text="" runat="server"> </asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div>
        <br />
        <asp:TextBox TextMode="Password" placeholder="Password"
            runat="server" ID="pass"></asp:TextBox>
    </div>

    <div style="padding-bottom: 0.3em;">
        <div class="checkbox">

            <label style="color: white;">
                <asp:CheckBox ID="CheckBox1" runat="server" />
                Remember Me
            </label>
        </div>
    </div>
    <div style="padding-bottom: 0.3em;">
        <asp:Button ID="Button1" class="btn btn-lg btn-primary" runat="server"
            Text="Sign in" OnClick="Button1_Click" />

        <a href="./UserWebForms/forgot_pass.aspx" data-toggle="modal"><span class="glyphicon glyphicon-user"></span>&nbsp;Forgot Password</a>


    </div>
    <asp:Label runat="server" ID="loginResult" ForeColor="IndianRed" Text=""></asp:Label>

</asp:Content>

<%--class="form-first-name form-control"  aria-describedby="basic-addon1"--%>