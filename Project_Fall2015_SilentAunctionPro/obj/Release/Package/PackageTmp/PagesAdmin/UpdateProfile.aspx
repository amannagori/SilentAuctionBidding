<%@ Page Title="" Language="C#"           MasterPageFile="~/MasterPages/Admin.Master" 
     AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" 
    Inherits="Project_Fall2015_SilentAunctionPro.PagesAdmin.UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Update Profile</title>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><br /><br /><br /><br />
     <div  style="margin-left:430px;" >
                    <div class="row">
                        
                      <div class="col-sm-7 form-box">
                          <%--  <div class="page-header">--%>
                                <div class="form-top">
                                    <div class="form-top-left">
                                        <h2>Update Profile</h2>
                                        <p>
                                            Update the relevant fields
                                     and click on <b>Update</b> button.
                                        </p>
                                    </div>
                                </div>

                           <%-- </div>--%>
                            <div class="form-bottom" > 
                            
                             <div style="margin-left:50px;">
                                <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                            
                                <asp:TextBox class="form-control" placeholder="User ID" MaxLength="20"
                                    ForeColor="Black"  ReadOnly="true"  aria-describedby="basic-addon1" runat="server" ID="userid1">
                                    </asp:TextBox>
                                 <%--   <asp:label class="form-control" aria-describedby="basic-addon1" 
                                        runat="server" ID="userid" ReadOnly="True"> </asp:label>--%>
                               
                            </div>
                            <div class="input-group" style="width: 374px; padding-top: 0.3em; ">
                                <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                    <asp:TextBox class="form-control" placeholder="Password" MaxLength="100"
                                        TextMode="Password" aria-describedby="basic-addon1" runat="server"
                                        ID="Password1">
                                    </asp:TextBox><asp:RequiredFieldValidator ControlToValidate="Password1"
                                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="**"  ForeColor="Red"/>
                                </div>
                                <div class="input-group " style="float: right; width: 187px;">
                                    <asp:TextBox class="form-control" placeholder="Confirm Password" MaxLength="100"
                                        aria-describedby="basic-addon1" TextMode="Password" runat="server" ID="Password2" />
                                    <asp:CompareValidator ControlToValidate="Password2" ControlToCompare="Password1"
                                        ID="CompareValidator1" runat="server" ForeColor="Red" ErrorMessage="Passwords do not match" />
                                </div>
                            </div>
                          
                            <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                    <asp:TextBox class="form-control" placeholder="First Name" MaxLength="20"
                                        aria-describedby="basic-addon1" runat="server" ID="fname">
                                    </asp:TextBox>
                                    
                                </div>
                                <div class="input-group" style="float: right; width: 187px;">
                                    <asp:TextBox class="form-control" placeholder="Last Name" MaxLength="20"
                                        aria-describedby="basic-addon1" runat="server" ID="lname" />
                                 
                                </div>
                            </div>
                            <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                    <asp:TextBox class="form-control" ID="phoneNumber" placeholder="Phone Number"
                                        MaxLength="10" aria-describedby="basic-addon1" runat="server">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="phoneNumber" ID="RequiredFieldValidator4"
                                        runat="server" ErrorMessage="**"  ForeColor="Red"/>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                        ControlToValidate="phoneNumber" ErrorMessage="Only Numbers Allowed"
                                        ValidationExpression="^[0-9]\d*(\.\d+)?$" />
                                </div>
                                <div class="dropdown" style="float: right; width: 186px;">
                                    <asp:DropDownList ID="networkProvider" style="height:50px" ForeColor="White" CssClass="form-control" BackColor="#444444" runat="server">
                                        <asp:ListItem Selected="True">Choose Provider</asp:ListItem>
                                        <asp:ListItem Value="Alltel">Alltel</asp:ListItem>
                                        <asp:ListItem Value="Att cingular">Att cingular</asp:ListItem>
                                        <asp:ListItem Value="Boost mobile">Boost mobile</asp:ListItem>
                                        <asp:ListItem Value="Cingular">Cingular</asp:ListItem>
                                        <asp:ListItem Value="Metro pcs">Metro pcs</asp:ListItem>
                                        <asp:ListItem Value="Nextel">Nextel</asp:ListItem>
                                        <asp:ListItem Value="Powertel">Powertel</asp:ListItem>
                                        <asp:ListItem Value="Sprint nextel">Sprint nextel</asp:ListItem>
                                        <asp:ListItem Value="Suncom">Suncom</asp:ListItem>
                                        <asp:ListItem Value="T-mobile">T-mobile</asp:ListItem>
                                        <asp:ListItem Value="Us cellular">Us cellular</asp:ListItem>
                                        <asp:ListItem Value="Verizon">Verizon</asp:ListItem>
                                        <asp:ListItem Value="Virgin mobile">Virgin mobile</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="Choose Provider"
                                        ControlToValidate="networkProvider" ID="RequiredFieldValidator5"
                                        runat="server" ErrorMessage="**" ForeColor="Red" />
                                </div>
                            </div>
                            
                          <div class="input-group" style="width: 374px; padding-top: 0.3em; ">
                              <div class="input-group" style="float: left; width: 184px;">
                                <asp:TextBox  class="form-control"
                                     placeholder="Address Line 1" aria-describedby="basic-addon1"
                                     runat="server" ID="addressLine1"></asp:TextBox>
                             </div>
                              <div class="input-group" style="float: right; width: 184px;">
                                    <asp:TextBox class="form-control" placeholder="Apartment No." MaxLength="20"
                                        aria-describedby="basic-addon1" runat="server" ID="addressLine2" />
                                  </div>


                            </div>
                                 
                           <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                    <asp:TextBox class="form-control" placeholder="email@email.com" aria-describedby="basic-addon1" runat="server" ID="email">
                                    </asp:TextBox></div>
                            
                             <div class="input-group" style="width: 374px; padding-top: 0.3em;">
                                <div class="input-group" style="float: left; width: 187px; padding-right: 0.5em;">
                                    <asp:TextBox class="form-control" placeholder="City" 
                                        aria-describedby="basic-addon1" runat="server" ID="city">
                                    </asp:TextBox>
                                  
                                </div>
                                <div class="input-group" style="float: right; width: 187px;">
                                    <asp:TextBox class="form-control" placeholder="State" 
                                        aria-describedby="basic-addon1" runat="server" ID="state" />
                                 
                                </div>
                            </div> <br />
                           <%--  <div class="input-group" style="width: 374px; padding-top: 0.3em; ">
                                <div class="input-group"  padding-bottom: 1em;">
                                    <asp:TextBox class="form-control" placeholder="Country" 
                                        aria-describedby="basic-addon1" runat="server" ID="country">
                                    </asp:TextBox>
                                </div></div>--%>
                                
                            <div class="btn-group" role="group" aria-label="..." style="text-align: center; padding-top: 0.3em;">
                                    <asp:Button ID="update" runat="server" Text="Update" class="btn btn-primary" onClick="updateUserProfile"/>
                                </div>
                               <div>
                                <br />
                                <asp:Label ID="UpdateReply" ForeColor="Green" runat="server" Text="" />
                            </div>
                         </div>
                          </div>
                        </div>
                    </div>
                    
                </div>
 
   <br /><br /><br /><br /><br />
</asp:Content>

