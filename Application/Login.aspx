<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Application.Login" EnableSessionState="True"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/custom.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <title>Quiz - Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form_wrapper">
          <div class="form_container">
            <div class="title_container">
              <h2>Login</h2>
            </div>
            <div class="row clearfix">
              <div class="">
                  <div class="input_field"> <span><i aria-hidden="true" class="fa fa-envelope"></i></span>
                      <asp:TextBox runat="server" class="input_control" name="email" ID="email" placeholder="Email"/>
                      <asp:RegularExpressionValidator ErrorMessage="Wrong Email format." ControlToValidate="email" runat="server" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                      <asp:RequiredFieldValidator ErrorMessage="Email field is required." ControlToValidate="email" runat="server" Display="None"/>
                  </div>
                  <div class="input_field"> <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                    <asp:TextBox runat="server" class="input_control" name="password" ID="password" placeholder="Password" type="password"/>
                    <asp:RequiredFieldValidator ErrorMessage="Password field is required." ControlToValidate="password" runat="server" Display="None"/>
                    <asp:CustomValidator ErrorMessage="Wrong email & password combination." runat="server" OnServerValidate="AccountServerValidate" Display="None"/>
                  </div>
                  <asp:Button type="submit" Text="Login" runat="server" class="submit_control" ID="submit"/>
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
              </div>
            </div>
          </div>
        </div>
        <p class="signin">New to Quiz? <a href="Register.aspx">Create an account</a></p>
    </form>
</body>
</html>
