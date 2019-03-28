<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="setnewpassword.aspx.cs" Inherits="setnewpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <table class="nav-justified">
            <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="tbnewpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is must" ControlToValidate="tbnewpassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Confirm Password</td>
            <td>
                <asp:TextBox ID="tbconfirmpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbconfirmpassword" ErrorMessage="Confirm Password is must"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbnewpassword" ControlToValidate="tbconfirmpassword" ErrorMessage="Passwords must match"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Change Password" />
            </td>
        </tr>
        </table>

    </asp:Panel>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>

