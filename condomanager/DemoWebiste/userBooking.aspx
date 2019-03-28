<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="userBooking.aspx.cs" Inherits="userBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container ">
  
 <div class="container form-container mt-5" id="needs-validation" novalidate>
       <div class="form-group"> 
      <h2>Welcome to Booking Department</h2>
       </div>
  <div class="row">
    <div class="col-md-6 mb-3">
      <label for="validationCustom01">What do you wish to Book?</label>
        <br />
<asp:DropDownList ID="CategoryList" CssClass="form-control" runat="server" required>
    <asp:ListItem>Parking</asp:ListItem>
    <asp:ListItem>Party Hall</asp:ListItem>
    <asp:ListItem>Library</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>
  <div class="row">
    <div class="col-md-3 mb-3">
      <label for="validationCustom03">Date</label>
        <asp:TextBox ID="date" CssClass="form-control"  runat="server" required></asp:TextBox>
      <div class="invalid-feedback">
        Please provide a valid date.
      </div>
    </div>
     <div class="col-md-3 mb-3">
      <label for="validationCustom03">(Time) From</label>
         <asp:TextBox ID="timeFrom"  CssClass="form-control" runat="server" required></asp:TextBox>
      <div class="invalid-feedback">
        Please provide a valid time.
      </div>
    </div>
     <div class="col-md-3 mb-3">
      <label for="validationCustom03">(Time) To</label>
      <asp:TextBox ID="timeTo"  CssClass="form-control" runat="server" required></asp:TextBox>
      <div class="invalid-feedback">
        Please provide a valid time.
      </div>
    </div>
  </div>
  <div class="row">
    <div class="col-md-6 mb-3">
      <label for="validationCustom03">Please fill all other detail </label>
        <textarea class="form-control" id="bookingDetail"  runat="server"></textarea>
      
    </div>
  </div>

<%--       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DemoConnectionString %>" SelectCommand="SELECT * FROM [booking]">

           <InsertParameters>
               <asp:ControlParameter ControlID="CategoryList" Name="category" PropertyName="SelectedValue" Type="String" />
               <asp:ControlParameter ControlID="date" Name="date" PropertyName="Text" Type="String" />
               <asp:ControlParameter ControlID="timeFrom" Name="timeFrom" PropertyName="Text" Type="String" />
               <asp:ControlParameter ControlID="timeTo" Name="timeTo" PropertyName="Text" Type="String" />
               <asp:ControlParameter ControlID="bookingDetail" Name="bookingDetail" PropertyName="Text" Type="String" />
           </InsertParameters>
       </asp:SqlDataSource>--%>

   <asp:Button ID="btnsubmit" runat="server" Text="Book Now" CssClass="btn btn-primary" OnClick="btnsubmit_Click" />
</div>
</div>
</asp:Content>

