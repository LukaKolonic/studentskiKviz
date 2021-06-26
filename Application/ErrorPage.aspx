<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Application.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body style="height:100vh">
    <form id="form1" runat="server" class="d-flex flex-column min-vh-100 justify-content-center align-items-center">
        <div>
            <asp:Label ID="errorMessage" Text="Oops... something went wrong" runat="server"  CssClass="display-1 mb-5"/>
        </div>
        <div>
            <a style="text-decoration:none" class="display-5 mt-5 btn btn-primary" href="UserLogin.aspx">Go back</a>
        </div>
    </form>
</body>
</html>
