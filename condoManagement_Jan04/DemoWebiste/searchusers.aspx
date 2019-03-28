<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="searchusers.aspx.cs" Inherits="searchusers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="nav-justified">
        <tr>
            <td>Search By Name/Email</td>
            <td>
                <asp:TextBox ID="tbsearch" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True">Grid</asp:ListItem>
                    <asp:ListItem>List</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Search" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="username" HeaderText="Username" />
                        <asp:BoundField DataField="fullname" HeaderText="Full Name" />
                        <asp:BoundField DataField="emailid" HeaderText="Email ID" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("username") %>' OnCommand="Button1_Command" Text="Chat" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:DataList ID="DataList1" runat="server">
                    <ItemTemplate>
                        <div style="border: 1px solid black">
                            <table class="nav-justified">
                                <tr>
                                    <td>Username</td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Full Name</td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("fullname") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Email Id</td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("emailid") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("username") %>' OnCommand="Button2_Command" Text="Chat" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

