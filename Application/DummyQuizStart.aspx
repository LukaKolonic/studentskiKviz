<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DummyQuizStart.aspx.cs" Inherits="Application.DummyQuizStart" EnableSessionState="True"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body style="height:100vh">
    <form id="form1" runat="server" class="d-flex flex-column min-vh-100 justify-content-center align-items-center">
        <div>
            <asp:Button style="font-size:5rem" CssClass="btn btn-primary" Text="Pokreni" runat="server" ID="btnStart" OnClick="btnStart_Click"/>
        </div>
    </form>
</body>
</html>
