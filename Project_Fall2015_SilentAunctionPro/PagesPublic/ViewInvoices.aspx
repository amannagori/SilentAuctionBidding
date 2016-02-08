<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewInvoices.aspx.cs"
    EnableEventValidation="false"
    MasterPageFile="~/MasterPages/PublicUser.Master"
    Inherits="Project_Fall2015_SilentAunctionPro.PagesPublic.MyInvoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>View Invoices</title>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        @media print {
            @page {
                margin: 0 auto 0 auto;
            }

            .noprint {
                display: none;
            }
        }

        }
    </style>
    <div class="container">
        <br />
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <div class="noprint jumbotron" style="text-align: center; color: red">
                <h2>
                    <asp:Label ID="itemSoldMsg" runat="server"></asp:Label></h2>
            </div>
        </asp:Panel>


        <div class="row noprint">
            
            <div class="col-lg-6">
                <asp:Button ID="Button1" runat="server"
                    Text="Print Invoice" class="btn btn-sm btn-primary" OnClick="Button1_Click" />
                &nbsp;&nbsp;
                    &nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server"
                        class="btn btn-sm btn-primary" OnClick="emailInvoice" Text="Email Invoice" />
                <br />
                <br />
                <asp:Label ID="emailMsg" runat="server" ForeColor="Green"></asp:Label>
            </div>
        </div>

        <br />
        <asp:Panel ID="Panel2"  runat="server" Width="600px" >

            <div class="row">
                
                <div class="col-lg-10" style="border: 1px solid black">
                    <div style="float: left">
                        <br />
                        <b>
                            <asp:Label ID="name" runat="server"></asp:Label></b>
                        <br />
                        <asp:Label ID="address" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="mobilePhone" runat="server"></asp:Label>&nbsp;<input type="checkbox" />
                        <asp:Label ID="cellPhone" runat="server"></asp:Label>&nbsp;<input type="checkbox" />

                    </div>

                    <div >
                        <br />
                        <b style="text-align: center; width: 100px; border: 1px solid green; float: right">
                            <asp:Label ID="Label1" runat="server" Text="Invoice Date"></asp:Label>
                        <asp:Label ID="currentDate" runat="server"></asp:Label></b>
                    </div>

                    <br />
                    <br />
                    <br />
                    <h1 style="text-align: center; text-decoration: underline">
                        <asp:Label ID="Label2" runat="server" Text="INVOICE"></asp:Label></h1>
                    <p style="text-align: center">
                        <i>We appreciate your support of the Festival of Trees on behalf of The Baby Fold
                            during the period from November 8 through November 11 - you purchased the following items:</i>
                    </p>
                    <br />
                    <%--<tr>
                            <td colspan="6" align="center" style="font-size: 30px">
                                <asp:Label ID="Label2" runat="server" Text="INVOICE"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">----------------------------------------------------------------------------------------------------------------</td>
                        </tr>
                        <tr align="center">
                            <td colspan="6" style="font-size: 16px">
                                <i>We appreciate your support of the Festival of Trees on behalf of The Baby Fold<br />
                                    during the period from November 8 through November 11 - you purchased the following items:</i>
                            </td>
                        </tr>--%>


                    <table>
                        <tr align="center">
                            <td><b>Item Number</b></td>
                            <td><b>Category</b></td>
                            <td><b>Description(Designer in parenthesis)</b></td>
                            <td><b>Estimated Value</b></td>
                            <td><b>Bid</b></td>
                            <td><b>Paid?</b></td>
                        </tr>
                        <tr style="border-bottom:1px solid black">
<%--                            <td colspan="6">-------------------------------------------------------------------------------------------------------</td>--%>
                        </tr>

                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr align="center">
                                    <td><%# Eval("itemId") %></td>
                                    <td><%# Eval("categoryname") %></td>
                                    <td><%# Eval("itemName") %> ( <%# Eval("firstname") %> )</td>
                                    <td><%# Eval("itemValue") %></td>
                                    <td><%# Eval("sellingPrice") %></td>
                                    <td><%# Eval("paymentStatus") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                        <tr>
                            <td colspan="6">----------------------------------------------------------------------------------------------------------------</td>
                        </tr>

                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" align="right">
                                <b>TOTAL AMOUNT OF ITEMS BID : $</b>
                            </td>
                            <td>
                                <asp:Label ID="totalBidAmt" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" align="right">
                                <b>TOTAL AMOUNT PAID : $</b>
                            </td>
                            <td>
                                <asp:Label ID="totalAmtPaid" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" align="right">
                                <b>TOTAL AMOUNT DUE : $</b>
                            </td>
                            <td>
                                <asp:Label ID="totalAmtDue" runat="server"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                            <td colspan="2" align="left" style="color: red; font-family: 'Monotype Corsiva';">
                                <asp:Label ID="thanks" runat="server" Text="Thank You For Your Generous Gift"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                            <td colspan="2" align="left" style="font-family: 'Monotype Corsiva';">
                                <i>Sincerely,</i>
                                <br />
                                Al Badel - Co - Chair
                            <br />
                                Denna Frautschi - Co - Chair
                            </td>
                        </tr>

                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6">----------------------------------------------------------------------------------------------------------------</td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: center">A portion of your purchase is tax deductible. For each item,the amount of you purchase price which
                                    is in excess of the fair market value for that item may be an allowable charitable deduction. According to federal guidelines
                                    you are able to deduct $<asp:Label ID="charitableDeduction" runat="server"></asp:Label>
                                as a charitable contribution.
                            <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
                
            </div>

        </asp:Panel>

    </div>
    <br />
    <br />
    <br />
    <br />
    <br />


</asp:Content>
