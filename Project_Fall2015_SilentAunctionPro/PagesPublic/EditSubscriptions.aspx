<%@ Page Title="" Language="C#" AutoEventWireup="true"
    CodeBehind="EditSubscriptions.aspx.cs" MasterPageFile="~/MasterPages/PublicUser.Master"
    Inherits="Project_Fall2015_SilentAunctionPro.PagesPublic.EditSubscriptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Mail Subscriptions</title>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
    <br />
    <br />
    <br />
    <br /> <br />
    <br />
    <br /> <br />
    <br />
    

<div class="container">
    
    <div class="jumbotron" style="background-color:lightslategray">
     <h3 style="margin-left:400px;font-family:Calibri;">  <strong> SUBSCRIBE NOW! </strong></h3>

    </div>
     
  <div class="jumbotron" style="background-color:darkgrey; margin-top:-30px;">

  
        <div class="row">
            <div class="col-sm-3">
            </div>
            <div class="col-sm-3" style="border-right:1px solid black; margin-left:-40px;">
                <p style="color:green;">
                <strong>    Subscribe to category</strong>
                </p>
                <p>
                 <asp:CheckBoxList ID="subList" runat="server"
                        RepeatDirection="Vertical">
                    </asp:CheckBoxList> 
                </p>
                <p>
                    <asp:Button ID="subscribeBtn" class="btn btn-success" runat="server" OnClick="subscribeBtnClick" Text="Subscribe" />
                </p>
                <p>
                    <asp:Label ID="subscribeMsg" runat="server" ForeColor="Green"></asp:Label>
                </p>

            </div>
            <div class="col-sm-4"  style="margin-left:40px;">

                <p style="color:brown;">
                <strong>   Unsubscribe from categories</strong> 
                </p>
                <p>
                    <asp:CheckBoxList ID="unsubList" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList>
                </p>
                <p>
                    <asp:Button ID="unsubscribeBtn" class="btn btn-danger" runat="server" OnClick="unsubscribeBtnClick" Text="Unsubscribe" />
                </p>
                <p>
                    <asp:Label ID="unsubscribeMsg" runat="server" ForeColor="Green"></asp:Label>
                </p>
            </div>
        </div>
    </div>
</div>

</asp:Content>

