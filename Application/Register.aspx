<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Application.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/custom.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <title>Quiz - Register</title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="form_wrapper">
          <div class="form_container">
            <div class="title_container">
              <h2>Register account</h2>
            </div>
            <div class="row clearfix">
              <div class="">
                  <div class="input_field"> <span><i aria-hidden="true" class="fa fa-envelope"></i></span>
                      <asp:TextBox runat="server" class="input_control" name="email" ID="email" placeholder="Email"/>
                      <asp:RegularExpressionValidator ErrorMessage="Wrong Email format." ControlToValidate="email" runat="server" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                      <asp:RequiredFieldValidator ErrorMessage="Email field is required." ControlToValidate="email" runat="server" Display="None"/>
                      <asp:CustomValidator ErrorMessage="Account with email address already exists." ControlToValidate="email" runat="server" OnServerValidate="EmailValidate" Display="None"/>

                  </div>
                  <div class="input_field"> <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                    <asp:TextBox runat="server" class="input_control" name="password" ID="password" placeholder="Password" type="password"/>
                    <asp:RequiredFieldValidator ErrorMessage="Password field is required." ControlToValidate="password" runat="server" Display="None"/>
                  </div>
                  <div class="input_field"> <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                      <asp:TextBox runat="server" class="input_control" name="confirmpassword" ID="confirmpassword" placeholder="Confirm Password" type="password"/>
                      <asp:CompareValidator ErrorMessage="Passwords don't match." ControlToValidate="confirmpassword" ControlToCompare="password" runat="server" Display="None" />
                      <asp:RequiredFieldValidator ErrorMessage="Confirm password field is required." ControlToValidate="confirmpassword" runat="server" Display="None"/>
                  </div>
                  <div class="row clearfix">
                    <div class="col_half">
                      <div class="input_field"> <span><i aria-hidden="true" class="fa fa-user"></i></span>
                          <asp:TextBox runat="server" class="input_control" name="name" ID="name" placeholder="First Name"/>
                          <asp:RequiredFieldValidator ErrorMessage="Name field is required." ControlToValidate="name" runat="server" Display="None"/>
                      </div>
                    </div>
                    <div class="col_half">
                      <div class="input_field"> <span><i aria-hidden="true" class="fa fa-user"></i></span>
                          <asp:TextBox runat="server" class="input_control" name="lastname" ID="lastname" placeholder="Last Name"/>
                          <asp:RequiredFieldValidator ErrorMessage="Lastname field is required." ControlToValidate="lastname" runat="server" Display="None"/>
                      </div>
                    </div>
                  </div>
                  <asp:Button type="submit" Text="Register" runat="server" class="submit_control" ID="submit"/>
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
              </div>
            </div>
          </div>
        </div>
    </form>
</body>
</html>
