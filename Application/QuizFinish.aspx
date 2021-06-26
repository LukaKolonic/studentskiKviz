<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizFinish.aspx.cs" Inherits="Application.QuizFinish" EnableSessionState="True"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body style="height:100vh">
    <form id="form1" runat="server" class="container d-flex flex-column min-vh-100 justify-content-center align-items-center">
        <div class="row" id="placediv" runat="server">
        </div>
        <div class="row mt-5" id="pointsdiv" runat="server">
        </div>
    </form>
</body>
</html>
