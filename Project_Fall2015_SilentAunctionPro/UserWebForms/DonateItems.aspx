<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/MasterPages/User.Master" CodeBehind="DonateItems.aspx.cs" Inherits="Project_Fall2015_SilentAunctionPro.UserWebForms.DonateItems" %>

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
         <br /> <br /> <br /> <br /><br />
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4">
                           <div class="page-header">
                                <h2>Donate Items</h2>
                                <p > Please Enter the following details and appropriately and 
                                     and click on <b>Donate</b> button. </p>   </div>
     
        
        Category: <asp:DropDownList ID="DropDownList1" runat="server"> </asp:DropDownList>
       <br /><br />
        Item Name: <asp:TextBox ID="item_name" runat="server"></asp:TextBox>
         <br /><br />
        Item Description: <asp:TextBox ID="item_desc" runat="server"></asp:TextBox>
         <br /><br />
        Approx. Value: <asp:TextBox ID="item_val" runat="server"></asp:TextBox>
         <br /><br />
         <asp:FileUpload ID="FileUpload1" runat="server"/>
        
        <br />
        <br />
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        <br />
        <br /><asp:Label ID="Label1" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
        
        


   
   </asp:Content>
   

