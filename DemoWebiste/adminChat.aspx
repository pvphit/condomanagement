<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="adminChat.aspx.cs" Inherits="adminChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
    <table border="0"  class="nav-justified">
        <tr>
            <td>You are chatting with</td>
            <td>
                <asp:label id="Label1" runat="server" text="Label"></asp:label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:updatepanel id="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:datalist id="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <div style="border: 1px solid black">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("sentby") %>'></asp:Label>
                            <div style="border: 1px dashed black">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("message") %>'></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:datalist>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                        </asp:Timer>
                    </ContentTemplate>
                </asp:updatepanel>

            </td>
        </tr>
        <tr>
            <td>Message</td>
            <td>
                <asp:textbox id="TextBox1" runat="server" cssclass="form-control" textmode="MultiLine"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:button id="Button1" runat="server" cssclass="btn btn-primary" onclick="Button1_Click" text="Send Message" />
            </td>
        </tr>
    </table>
</asp:Content>

