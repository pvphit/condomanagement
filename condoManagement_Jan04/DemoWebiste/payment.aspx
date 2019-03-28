<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment</title>
    <link href="css/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <div class="navbar navbar-light" style="background-color: #e3f2fd;">
        <div style="float:right;">
        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="btn btn-outline-info btn-sm"  NavigateUrl="~/userhome.aspx">Home</asp:HyperLink>
        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="btn btn-outline-info btn-sm"  NavigateUrl="~/searchusers.aspx">Search Users</asp:HyperLink>
        <asp:HyperLink ID="HyperLink6" runat="server" CssClass="btn btn-outline-info btn-sm"  NavigateUrl="~/userBooking.aspx">Booking</asp:HyperLink>
        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="btn btn-outline-info btn-sm"  NavigateUrl="~/userPayment.aspx">Payment</asp:HyperLink>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-outline-info btn-sm"  NavigateUrl="~/updateprofile.aspx">Update Profile</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-outline-info btn-sm"  NavigateUrl="~/changepassword.aspx">Change Password</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-outline-info btn-sm"  NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>
            </div></div>
         <nav class="navbar navbar-expand-lg navbar-light nav-custom">
  <a class="navbar-brand navbar-brand-custom" href="#"><h1>CONDO MANAGEMENT SYSTEM</h1></a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
     <ul class="navbar-nav mr-auto">
      
    </ul>
    <ul class="navbar-nav my-2 my-lg-0">
      <li class="nav-item active">
        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item nav-item">
        <a class="nav-link" href="#">Booking</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Payment</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Maintenance</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Contact Office</a>
      </li>
       </ul>

       

  </div>
</nav>



    <div class="container form-container mt-5" id="needs-validation" novalidate>
       <div class="form-group"> 
      <h2>Welcome to Payment Department</h2>
           <p></p>
           <p>You can pay your rent here easily without any trouble using your PayPal account.</p>
           <p>Please click the button below to pay for this month. </p>
       </div>
          <form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" target="_top">
<input type="hidden" name="cmd" value="_s-xclick">
<input type="hidden" name="hosted_button_id" value="LYJPQ8TRMDXCS">
<input type="image" src="img/Pay-now-button-copy.png" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
<img alt="" border="0" src="https://www.sandbox.paypal.com/en_US/i/scr/pixel.gif" width="1" height="1">
</form>


</div>
  

</body>
</html>
