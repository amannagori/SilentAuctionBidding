<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Admin.Master"
    CodeBehind="ViewReports.aspx.cs"
    Inherits="Project_Fall2015_SilentAunctionPro.PagesAdmin.view_reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
   
           <title>View Reports</title>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <h2 class="noprint" style="text-align: center; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; border:groove; background:content-box">VIEW REPORTS</h2>

    <br />
    <br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="margin-left:45px; float:left;">
                    <h3 style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">SELECT REPORT TYPE</h3>
                    <asp:RadioButtonList ID="RadioList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioList1_SelectedIndexChanged">
                        <asp:ListItem Text="&nbsp; Paid v/s Unpaid Items Report" Value="1"></asp:ListItem>
                        <asp:ListItem Text="&nbsp; Sold v/s Unsold Items Report" Value="2"></asp:ListItem>
                        <asp:ListItem Text="&nbsp; Items By Category" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:DropDownList ID="DropDownList1"
                        runat="server" Visible="false">
                    </asp:DropDownList>
                    &nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="View Report" class="btn btn-primary"
                        OnClick="Button1_Click" />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </div>
          
              
                
                <br />
                <br />
                <div style="float:left;margin-left: 40px">
                    <asp:Panel ID="Panel1" runat="server">
                        <div style="float: left">
                            <h3>
                                <asp:Label ID="Label3" runat="server"></asp:Label></h3>
                            <asp:GridView class="table" ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                        <div style="float:right; margin-left:10px">
                            <h3>
                                <asp:Label ID="Label4" runat="server"></asp:Label></h3>
                            <asp:GridView class="table" ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                </div>

                <div style="float: right; margin-right:50px;">
                     <div> <h4 style="font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">CURRENT STATUS</h4></div>
                    <asp:GridView class="table" ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <ajaxToolkit:PieChart ID="PieChart1" runat="server" 

                        Visible="false"></ajaxToolkit:PieChart>
                    <br /><br /><br /><br /><br /><br /><br />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
          <br /><br /><br /><br /><br /><br /><br /><br />
    </div>
    <br /><br /><br /><br /><br />
</asp:Content>
