<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizWaiting.aspx.cs" Inherits="Application.QuizWaiting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body style="height:100vh">
    <form id="form1" runat="server" class="d-flex flex-column min-vh-100 justify-content-center align-items-center">
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server" />
            <asp:Timer ID="Timer" OnTick="Timer_Tick" runat="server" Interval="1000" />    
            <asp:UpdatePanel ID="PlayerNumberPanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer" />
                </Triggers>
                <ContentTemplate>
                        <asp:Label Text="Waiting..." runat="server" ID="lblMessage" CssClass="display-1"/>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
