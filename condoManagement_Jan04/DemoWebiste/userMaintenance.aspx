<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="userMaintenance.aspx.cs" Inherits="userMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container form-container mt-5" id="needs-validation" novalidate>
       <div class="form-group"> 
      <h2>Welcome to Maintenance Department</h2>
       </div>
  <div class="row">
    <div class="col-md-6 mb-3">
      <label for="validationCustom01">What kind of Maintenance do you need?</label>
        <br />
<asp:DropDownList ID="CategoryList" CssClass="form-control" runat="server" required>
    <asp:ListItem>Cleaning</asp:ListItem>
    <asp:ListItem>Repair</asp:ListItem>
    <asp:ListItem>Complaints</asp:ListItem>
    <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>
  <div class="row">
    <div class="col-md-3 mb-3">
      <label for="validationCustom03">When did the problem started ?</label><br />
        <input id="date" type="date" value="2018-01-04" runat="server" class="form-control" required/>
        <%--<asp:TextBox ID="date" CssClass="form-control"  runat="server" required></asp:TextBox>--%>
      <div class="invalid-feedback">
        Please provide a valid date.
      </div>
    </div>
  </div>
  <div class="row">
    <div class="col-md-6 mb-3">
      <label for="validationCustom03">Please fill all other detail </label>
        <textarea class="form-control" id="bookingDetail"  runat="server"></textarea>
      
    </div>
  </div>
        <div class="d-none">

        <asp:label id="lblUsername"  runat="server" text=""></asp:label>
        <asp:label id="lblAddress"  runat="server" text=""></asp:label>
        <asp:label id="lblEmail"  runat="server" text=""></asp:label>
        </div>

   <asp:Button ID="btnsubmit" runat="server" Text="Book Now" CssClass="btn btn-primary" OnClick="btnsubmit_Click" />
</div>

            <div class="container mt-5 mb-5">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="#eae5e5" BorderColor="White" BorderStyle="None" CssClass="table table-hover" Width="100%">
        <Columns>
            <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            <asp:BoundField DataField="maintenanceDetail" HeaderText="maintenanceDetail" SortExpression="maintenanceDetail" />
        </Columns>
         <HeaderStyle  CssClass="thead-dark" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DemoConnectionString %>" SelectCommand="SELECT [category], [date], [maintenanceDetail] FROM [Maintenance] WHERE ([username] = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="username" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
        </div>
</div>
    
</asp:Content>

