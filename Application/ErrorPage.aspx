<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Application.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body style="height:100vh">
    <form id="form1" runat="server" class="d-flex flex-column min-vh-100 justify-content-center align-items-center">
        <div class="h-100 p-5 bg-light border rounded-3">
            <div>
                <asp:Label ID="errorMessage" Text="Oops... something went wrong" runat="server"  CssClass="display-1 mb-5"/>
                <hr />
            </div>
            <div>
                <asp:Button style="text-decoration:none" CssClass="display-5 mt-5 btn btn-secondary" runat="server" ID="btnBack" OnClick="btnBack_Click" Text="Go back"/>
                <asp:Button style="text-decoration:none" CssClass="display-5 mt-5 btn btn-primary" runat="server" ID="btnHome" OnClick="btnHome_Click" Text="Home Page"/>
            </div>
        </div>
    </form>
</body>
</html>
