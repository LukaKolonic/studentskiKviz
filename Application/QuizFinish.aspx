<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizFinish.aspx.cs" Inherits="Application.QuizFinish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/QuizFinish.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Finish">
            <asp:Label ID="lblFinish" runat="server" Text="You finished on"></asp:Label>
            <br />
            <asp:Label ID="lblPlaceNumber" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblPlace" runat="server" Text="place"></asp:Label>
            <br />
            <asp:Label ID="lblPoints" runat="server" Text="Points"></asp:Label>
            

        </div>
    </form>
</body>
</html>
