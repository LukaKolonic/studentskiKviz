<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModeratorPlayQuiz.aspx.cs" Inherits="Application.ModeratorPlayQuiz" EnableSessionState="True"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PlayQuiz</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server" class="container" style="height:100%">
        <div class="row mt-5 align-items-start text-center">
                <asp:Label CssClass="display-3" ID="CodeAccess" runat="server" Text="Kod za pristup kvizu: "></asp:Label>
        </div>
        <div class="row text-center">
            <asp:Label CssClass="display-1 fw-bolder" ID="TextCode" runat="server" ></asp:Label>
        </div>
        <div class="row mt-5">
            <div class="col text-center">
                <asp:Button CssClass="fs-3 btn btn-danger" ID="Exit" runat="server" Text="Izađi iz kviza" Height="100px" Width="225px" OnClick="Exit_Click"/>
            </div>
            <div class="col text-center">
                <asp:Button CssClass="fs-3 btn btn-success" ID="Play" runat="server" Text="Pokreni kviz" Height="100px" Width="225px" OnClick="Play_Click"/>
            </div>
        </div>
        <div class="row text-center" style="margin-top:25rem">
                <asp:Label CssClass="display-3" ID="PlayersNumber" runat="server" Text="Broj igrača: "></asp:Label>
            </div>
        <div class="row text-center mt-1">
            <asp:Timer ID="Timer" OnTick="Timer_Tick" runat="server" Interval="1000" />    
            <asp:ScriptManager ID="ScriptManager" runat="server" />
            <asp:UpdatePanel ID="PlayerNumberPanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label CssClass="display-3" ID="TextPlayers" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
