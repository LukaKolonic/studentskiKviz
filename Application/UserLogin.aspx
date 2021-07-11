<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Application.UserLogin" %>
    
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enter quiz</title>
    <link href="Content/ModeratorPlayQuiz.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/custom.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div class="form_wrapper">
            <div class="form_container">
                <div class="title_container">
                    <h2>Pristup kvizu</h2>
                </div>
                <div class="row clearfix">
                    <div class="">
                        <div class="input_field">
                            <span><i aria-hidden="true" class="fa fa-envelope"></i></span>
                            <asp:TextBox runat="server" class="input_control" name="code" ID="code" placeholder="Unesite kod..." />
                            <asp:RequiredFieldValidator ErrorMessage="Code field is required!" ControlToValidate="code" runat="server" Display="None" />
                        </div>
                        <div class="input_field">
                            <span><i aria-hidden="true" class="fa fa-user"></i></span>
                            <asp:TextBox runat="server" class="input_control" name="nickname" ID="nickname" placeholder="Unesite nadimak..." />
                            <asp:RequiredFieldValidator ErrorMessage="Nickname field is required!" ControlToValidate="nickname" runat="server" Display="None" />
                        </div>
                    </div>
                    <asp:Button type="submit" Text="Pristupite kvizu" runat="server" class="submit_control" ID="submit" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
