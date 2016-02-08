<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPages/Main.Master" CodeBehind="SignUp.aspx.cs" Inherits="Project_Fall2015_SilentAunctionPro.SignUp" %>


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
     <asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"  > 
           <br /><br /><br /><br />
 
  <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4">
                            <div class="page-header">
                                <h2>Sign Up Form</h2>
                            </div>
                            <div><br />
                                <asp:Label ID="SignUpReply" ForeColor="DarkSeaGreen" runat="server" Text=""></asp:Label>
                            </div>
                               <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <asp:TextBox class="form-control" placeholder="User ID" aria-describedby="basic-addon1" runat="server" ID="userid"></asp:TextBox>
                               </div>
                             <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                    <asp:TextBox class="form-control" placeholder="First Name" aria-describedby="basic-addon1" runat="server" ID="fname">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="fname" ID="RequiredFieldValidator1" runat="server" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="input-group" style="float: right; width: 187px;">
                                    <asp:TextBox class="form-control" placeholder="Last Name" aria-describedby="basic-addon1" runat="server" ID="lname"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lname" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                             <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                    <asp:TextBox class="form-control" placeholder="Address" aria-describedby="basic-addon1" runat="server" ID="address1">
                                    </asp:TextBox>
                                </div>
                                <div class="input-group" style="float: right; width: 187px;">
                                    <asp:TextBox class="form-control" placeholder="Apartment No." aria-describedby="basic-addon1" runat="server" ID="address2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <asp:TextBox class="form-control" placeholder="City" aria-describedby="basic-addon1" runat="server" ID="city"></asp:TextBox>
                               </div>
                             <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <asp:TextBox class="form-control" placeholder="State" aria-describedby="basic-addon1" runat="server" ID="state"></asp:TextBox>
                               </div>
                             <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <asp:TextBox class="form-control" placeholder="Zip" aria-describedby="basic-addon1" runat="server" ID="zip"></asp:TextBox>
                               </div>
                             <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <asp:TextBox class="form-control" placeholder="Country" aria-describedby="basic-addon1" runat="server" ID="country"></asp:TextBox>
                               </div>
                             <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                    <asp:TextBox class="form-control" placeholder="Phone Number" MaxLength="10" aria-describedby="basic-addon1" runat="server" ID="phoneNumber">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="phoneNumber" ID="RequiredFieldValidator7" runat="server" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="phoneNumber" ErrorMessage="Only Numbers Allowed" ValidationExpression="^[0-9]\d*(\.\d+)?$"></asp:RegularExpressionValidator>
                                </div>
                                <div class="dropdown" style="float: right; width: 186px;">
                                    <asp:DropDownList ID="networkProvider" CssClass="form-control" runat="server">
                                        <asp:ListItem Selected="True">Choose Provider</asp:ListItem>
                                        <asp:ListItem>alltel</asp:ListItem>
                                        <asp:ListItem>att cingular</asp:ListItem>
                                        <asp:ListItem>boost mobile</asp:ListItem>
                                        <asp:ListItem>cingular</asp:ListItem>
                                        <asp:ListItem>metro pcs</asp:ListItem>
                                        <asp:ListItem>nextel</asp:ListItem>
                                        <asp:ListItem>powertel</asp:ListItem>
                                        <asp:ListItem>sprint nextel</asp:ListItem>
                                        <asp:ListItem>suncom</asp:ListItem>
                                        <asp:ListItem>t-mobile</asp:ListItem>
                                        <asp:ListItem>us cellular</asp:ListItem>
                                        <asp:ListItem>verizon</asp:ListItem>
                                        <asp:ListItem>virgin mobile</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="Choose Provider" ControlToValidate="networkProvider" ID="RequiredFieldValidator5" runat="server" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                             <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <asp:TextBox class="form-control" placeholder="Work-Phone" aria-describedby="basic-addon1" runat="server" ID="workphone"></asp:TextBox>
                               </div>
                           <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                    <asp:TextBox class="form-control" placeholder="email@email.com" aria-describedby="basic-addon1" runat="server" ID="email">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="email" ID="RequiredFieldValidator3" runat="server" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                              <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                    <asp:TextBox class="form-control" placeholder="Password" TextMode="Password" aria-describedby="basic-addon1" runat="server" ID="signUpPassword">
                                    </asp:TextBox><asp:RequiredFieldValidator ControlToValidate="signUpPassword" ID="RequiredFieldValidator4" runat="server" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="input-group " style="float: right; width: 187px;">
                                    <asp:TextBox class="form-control" placeholder="Confirm Password" aria-describedby="basic-addon1" TextMode="Password" runat="server" ID="signUpPassword2"></asp:TextBox>
                                    <asp:CompareValidator ControlToValidate="signUpPassword2" ControlToCompare="signUpPassword" ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match" ForeColor="Red"></asp:CompareValidator>
                                </div>
                            </div>
                           
                           
                            <div class="input-group" style="width: 394px; text-align: center; padding-top: 0.3em;">
                                <asp:RadioButtonList ID="role" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="role_SelectedIndexChanged">
                                     <asp:ListItem Text="Admin &nbsp;" Value="A" />
                                    <asp:ListItem Text="Public(Buyer/Donor) &nbsp;" Value="P" /> 
                                    <asp:ListItem Text="Steering Committee" Value="SC" /> 
                                   
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ControlToValidate="role" ID="RequiredFieldValidator6" runat="server" ErrorMessage="**" ForeColor="Red" ></asp:RequiredFieldValidator>
                                 </div>
                          
                           <div class="btn-group" role="group" aria-label="..." style="text-align: center; padding-top: 0.3em;">
                               
                                <asp:Button ID="signUp" runat="server" Text="Submit" class="btn btn-primary" OnClick="signUp_Click1"> </asp:Button> 
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4"></div>
                </div>
  
          

    <script src="http://code.jquery.com/jquery.js"></script>
    <!-- If no online access, fallback to our hardcoded version of jQuery -->
    <script>window.jQuery || document.write('<script src="../Scripts/jquery-1.9.1.min.js"><\/script>')</script>
    <!-- Bootstrap JS -->
    <script src="Scripts/bootstrap.min.js"></script>
   

</asp:Content>