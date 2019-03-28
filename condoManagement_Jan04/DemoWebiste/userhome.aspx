<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="userhome.aspx.cs" Inherits="userhome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   <div class="container"> 
       <div class="jumbotron jumbotron-custom mt-5">
       <h1><asp:Label ID="Label1" runat="server" Text=""></asp:Label></h1>
        <p>You have successfully logged in to the Condo Management System.</p>
       </div>
       </div>
</asp:Content>

