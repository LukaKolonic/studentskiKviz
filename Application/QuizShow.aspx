<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizShow.aspx.cs" Inherits="Application.QuizShow" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" class ="container text-center align-content-center">
        <div class="p-5 mb-4 bg-secondary rounded-3" style="margin-top:300px">
            <asp:Label Text="Pitanje" runat="server" ID="lblPitanje" CssClass="text-white"/>
        </div>
        <div id="colone" runat="server" class="row" style="margin-top:400px">

        </div>
        <div id="coltwo" runat="server" class="row">   

        </div>
    </form>
</body>
</html>
