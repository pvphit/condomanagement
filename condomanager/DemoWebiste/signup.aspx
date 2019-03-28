<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
        <link rel="stylesheet" type="text/css" href="css/register.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <nav class="navbar navbar-expand-lg navbar-light nav-custom">
  <a class="navbar-brand navbar-brand-custom" href="#"><h1>CONDO MANAGEMENT SYSTEM</h1></a>
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


  </div>
</nav>
    <div class="container ">

        <div class="container form-container mt-5" id="needs-validation" novalidate>
<div class="form-group"> 
      <h2>Account Registeration</h2>
       </div>
    <table class="">
    <tr>
        <td>Username</td>
        <td>
            <asp:TextBox ID="tbusername" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbusername" ErrorMessage="Username is must"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Password</td>
        <td>
            <asp:TextBox ID="tbpassword" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is must" ControlToValidate="tbpassword"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Confirm Password</td>
        <td>
            <asp:TextBox ID="tbconfirmpassword" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbconfirmpassword" ErrorMessage="Confirm Password is must"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbpassword" ControlToValidate="tbconfirmpassword" ErrorMessage="Passwords must match"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>Full Name</td>
        <td>
            <asp:TextBox ID="tbfullname" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbfullname" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Email Id</td>
        <td>
            <asp:TextBox ID="tbemail" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="tbemail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email" ControlToValidate="tbemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>Phone No</td>
        <td>
            <asp:TextBox ID="tbphoneno" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="tbphoneno"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Mobile" ControlToValidate="tbphoneno" ValidationExpression="[246]{1}[0-9]{9}"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>Address</td>
        <td>
            <asp:TextBox ID="tbaddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="tbaddress"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Gender</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DemoConnectionString %>" DeleteCommand="DELETE FROM [Users] WHERE [username] = @username" InsertCommand="INSERT INTO [Users] ([username], [password], [fullname], [emailid], [phoneno], [address], [gender]) VALUES (@username, @password, @fullname, @emailid, @phoneno, @address, @gender)" SelectCommand="SELECT * FROM [Users]" UpdateCommand="UPDATE [Users] SET [password] = @password, [fullname] = @fullname, [emailid] = @emailid, [phoneno] = @phoneno, [address] = @address, [gender] = @gender WHERE [username] = @username">
                <DeleteParameters>
                    <asp:Parameter Name="username" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:ControlParameter ControlID="tbusername" Name="username" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="tbpassword" Name="password" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="tbfullname" Name="fullname" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="tbemail" Name="emailid" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="tbphoneno" Name="phoneno" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="tbaddress" Name="address" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="RadioButtonList1" Name="gender" PropertyName="SelectedValue" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="password" Type="String" />
                    <asp:Parameter Name="fullname" Type="String" />
                    <asp:Parameter Name="emailid" Type="String" />
                    <asp:Parameter Name="phoneno" Type="String" />
                    <asp:Parameter Name="address" Type="String" />
                    <asp:Parameter Name="gender" Type="String" />
                    <asp:Parameter Name="username" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </td>
        <td>
            <asp:Button ID="btnsubmit" runat="server" Text="Sign Up" CssClass="btn btn-primary" OnClick="btnsubmit_Click" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
    </tr>
</table>
    </div>
</div>
</asp:Content>

