<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="employeeMaintenance.aspx.cs" Inherits="employeeMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container mt-5">
        <h1 class="display-4">Employee Maintenance Department</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="#eae5e5" BorderColor="White" BorderStyle="None" CssClass="table table-hover" Width="100%">
        <Columns>
            <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
            <asp:BoundField DataField="apartmentNumber" HeaderText="apartmentNumber" SortExpression="apartmentNumber" />
            <asp:BoundField DataField="userEmail" HeaderText="userEmail" SortExpression="userEmail" />
            <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            <asp:BoundField DataField="maintenanceDetail" HeaderText="maintenanceDetail" SortExpression="maintenanceDetail" />
        </Columns>
        <HeaderStyle  CssClass="thead-dark" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DemoConnectionString %>" SelectCommand="SELECT * FROM [Maintenance]"></asp:SqlDataSource>
         </div>
</asp:Content>

