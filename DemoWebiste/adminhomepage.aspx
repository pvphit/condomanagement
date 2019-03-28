<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminhomepage.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Booking Details</h1>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
            <asp:BoundField DataField="apartmentNumber" HeaderText="apartmentNumber" SortExpression="apartmentNumber" />
            <asp:BoundField DataField="userEmail" HeaderText="userEmail" SortExpression="userEmail" />
            <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            <asp:BoundField DataField="timefrom" HeaderText="timefrom" SortExpression="timefrom" />
            <asp:BoundField DataField="timeto" HeaderText="timeto" SortExpression="timeto" />
            <asp:BoundField DataField="bookingdetail" HeaderText="bookingdetail" SortExpression="bookingdetail" />
        </Columns>
    </asp:GridView>



    <div>
        <h1>User Details</h1>
        <p>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                    <asp:BoundField DataField="fullname" HeaderText="fullname" SortExpression="fullname" />
                    <asp:BoundField DataField="emailid" HeaderText="emailid" SortExpression="emailid" />
                    <asp:BoundField DataField="phoneno" HeaderText="phoneno" SortExpression="phoneno" />
                    <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                    <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                    <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DemoConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
        </p>

    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DemoConnectionString %>" SelectCommand="SELECT * FROM [booking]"></asp:SqlDataSource>
</asp:Content>

