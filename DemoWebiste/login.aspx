<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>CONDO MANAGEMENT SYSTEM</title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="stylesheet" type="text/css" href="css/index.css">
    <link rel="stylesheet" type="text/css" href="css/register.css">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid main-content p-0">
  <!-- Navigation  Starts-->
<nav class="navbar navbar-expand-lg navbar-light nav-custom">
  <!-- <a class="navbar-brand navbar-brand-custom" href="#"><img src="img/logo.png"></a> -->
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
   <!--    <li class="nav-item active">
        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Link</a>
      </li> -->
       </ul>

       <div class="form-inline my-2 my-lg-0">
     
      </div> 
        <ul class="navbar-nav  my-2 my-lg-0">
   
      
      <li class="nav-item">

         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/signup.aspx"><span  class="btn btn-info my-2 my-sm-0" >Register</span></asp:HyperLink>
      </li>
       </ul>

  </div>
</nav>
  <!-- Navigation  Ends-->

<!-- <div class="container subContainerWithStyleFont" >
 
</div>
 -->
<div class="container subContainerWithForm">

 <h1>CONDO MANAGEMENT SYSTEM</h1>
    
<div class="form-custom" >
  <div class="form-row">
    <div class="col-5">
       <%--<input type="text" class="form-control mr-sm-2" placeholder="Email">--%>
       
      <asp:TextBox ID="tbusername" runat="server" CssClass="form-control mr-sm-2" placeholder="Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbusername" ErrorMessage="Username is must"></asp:RequiredFieldValidator>

    </div>
    <div class="col-5">
      <%--<input class="form-control mr-sm-2"  placeholder="Password" >--%>
         <asp:TextBox ID="tbpassword" runat="server" CssClass="form-control mr-sm-2" TextMode="Password" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbpassword" ErrorMessage="Password is must"></asp:RequiredFieldValidator>
    </div>
    <div class="col-1">
      <%--<button class="btn btn-outline-light my-2 my-sm-0" type="submit">Log In</button>--%>
       
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-outline-info my-2 my-sm-0" OnClick="Button1_Click" Text="Login" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
  </div>
</div>

   <%-- <table class="nav-justified">
        <tr>
            <td>Username</td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
               
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                
            </td>
        </tr>
    </table>--%>
</div>


</div>
    

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    

    
</asp:Content>

