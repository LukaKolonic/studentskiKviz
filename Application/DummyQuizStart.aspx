<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DummyQuizStart.aspx.cs" Inherits="Application.DummyQuizStart" EnableSessionState="True"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="Pokreni" runat="server" ID="btnStart" OnClick="btnStart_Click"/>
        </div>
    </form>
</body>
</html>
