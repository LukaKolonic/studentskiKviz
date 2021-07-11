<%@ Page Title="" Language="C#" MasterPageFile="~/Moderator.Master" AutoEventWireup="true" CodeBehind="ModeratorMakeQuestion.aspx.cs" Inherits="Application.ModeratorMakeQuestion" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.addEventListener('DOMContentLoaded', () => {
            document.querySelector('#Validacija_obvezno_pitanje').style.display = 'none';
            document.querySelector('#provjera_znakova_pitanja').style.display = 'none';
            document.querySelector('#razlicit').style.display = 'none';
            document.querySelector('#Validacija_obvezni_tocan_odg').style.display = 'none';
            document.querySelector('#provjera_znakova_tocnog_odgovora').style.display = 'none';
            document.querySelector('#provjera_znakova_1_krivog').style.display = 'none';
            document.querySelector('#provjera_znakova_2_krivog').style.display = 'none';
            document.querySelector('#provjera_znakova_3_krivog').style.display = 'none';
            document.querySelector('#Validacija_obvezni_krivi_odg').style.display = 'none';

        })
        $(() => {
            $("#Create_Quiz").click(() => {
                window.location.replace("/ModeratorMakeQuiz.aspx");
            });
        });
    </script>
    <link href="Content/ModeratorMakeQuestion.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="uliniji" id="popis">
        <div id="IzradaPitanja">
            <div class="input-group mb-3">
                <asp:Label CssClass="form-label col-md-2" Text="Pitanje: " runat="server" />
                <div class="col-md-10">
                    <asp:TextBox CssClass="form-control" runat="server" ID="BoxPitanje" />
                    <asp:RequiredFieldValidator ID="Validacija_obvezno_pitanje" runat="server"
                        Text="*" ErrorMessage="Morate upisati pitanje!" ClientIDMode="Static" ControlToValidate="BoxPitanje"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="provjera_znakova_pitanja" runat="server"
                        Text="*" ErrorMessage="pitanje mora imati manje od 200 znakova"
                        ClientIDMode="Static" ControlToValidate="BoxPitanje" OnServerValidate="provjera_znakova_pitanja_ServerValidate"></asp:CustomValidator>
                </div>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="form-label col-md-2" Text="Točan odgovor: " runat="server" />
                <div class="col-md-10">
                    <asp:TextBox CssClass="form-control" runat="server" ID="BoxTocanOdgovor" />
                    <asp:CustomValidator ID="razlicit" runat="server" ControlToValidate="BoxTocanOdgovor" Text="*" ErrorMessage="Krivi odgovori moraju biti različiti od točnog!" ClientIDMode="Static" OnServerValidate="razlicit_ServerValidate"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="Validacija_obvezni_tocan_odg" runat="server" Text="*" ErrorMessage="Morate upisati točan odgovor!" ClientIDMode="Static" ControlToValidate="BoxTocanOdgovor"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="provjera_znakova_tocnog_odgovora" runat="server" Text="*" ErrorMessage="odgovor mora imati manje od 25 znakova" ClientIDMode="Static" ControlToValidate="BoxTocanOdgovor" OnServerValidate="provjera_znakova_tocnog_odgovora_ServerValidate"></asp:CustomValidator>
                </div>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="form-label col-md-2" Text="1. krivi odgovor: " runat="server" />
                <div class="col-md-10">
                    <asp:TextBox CssClass="form-control" runat="server" ID="BoxPrviKriviOdgovor" />
                    <asp:CustomValidator ID="provjera_znakova_1_krivog" runat="server" Text="*" ErrorMessage="odgovor mora imati manje od 25 znakova" ClientIDMode="Static" ControlToValidate="BoxPrviKriviOdgovor" OnServerValidate="provjera_znakova_1_krivog_ServerValidate"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ClientIDMode="Static" ID="Validacija_obvezni_krivi_odg" runat="server" Text="*" ErrorMessage="Morate unijeti barem 1. krivi odgovor" ControlToValidate="BoxPrviKriviOdgovor"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="form-label col-md-2" Text="2. krivi odgovor: " runat="server" />
                <div class="col-md-10">
                    <asp:TextBox CssClass="form-control" runat="server" ID="BoxDrugiKriviOdgovor" />
                    <asp:CustomValidator ID="provjera_znakova_2_krivog" runat="server" Text="*" ErrorMessage="odgovor mora imati manje od 25 znakova" ClientIDMode="Static" ControlToValidate="BoxDrugiKriviOdgovor" OnServerValidate="provjera_znakova_2_krivog_ServerValidate"></asp:CustomValidator>
                </div>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="form-label col-md-2" Text="3. krivi odgovor: " runat="server" />
                <div class="col-md-10">
                    <asp:TextBox CssClass="form-control" runat="server" ID="BoxTreciKriviOdgovor" />
                    <asp:CustomValidator ID="provjera_znakova_3_krivog" runat="server" Text="*" ErrorMessage="odgovor mora imati manje od 25 znakova" ClientIDMode="Static" ControlToValidate="BoxTreciKriviOdgovor" OnServerValidate="provjera_znakova_3_krivog_ServerValidate"></asp:CustomValidator>
                </div>
            </div>


            <div class="input-group mb-3">
                <div class="offset-2 col-md-10">
                    <asp:Button CssClass="btn btn-primary" ID="Prihvat_ipitanje" runat="server" Text="Spremi pitanje" />
                    <a id="Create_Quiz" class="btn btn-secondary">Kreiraj kviz</a>
                </div>
            </div>
            <br />
            <asp:ValidationSummary CssClass="alert-danger" ID="ValidationSummary1" runat="server" />
        </div>
        </div>
</asp:Content>
