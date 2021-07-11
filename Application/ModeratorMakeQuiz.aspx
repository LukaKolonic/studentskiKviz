<%@ Page Title="" Language="C#" MasterPageFile="~/Moderator.Master" AutoEventWireup="true" CodeBehind="ModeratorMakeQuiz.aspx.cs" Inherits="Application.ModeratorMakeQuiz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.addEventListener('DOMContentLoaded', () => {
            document.querySelector('#CustomValidator1').style.display = 'none';
            document.querySelector('#RequiredFieldValidator1').style.display = 'none';
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="input-group mb-3">
        <asp:Label CssClass="form-label col-md-2" Text="Naziv kviza: " runat="server" />
        <div class="col-md-10">
            <asp:TextBox CssClass="form-control" runat="server" ID="BoxNazivKviza" />
            <asp:RequiredFieldValidator ClientIDMode="Static" ControlToValidate="BoxNazivKviza" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obavezno morate unijeti naziv kviza!" Text="*"></asp:RequiredFieldValidator>
            <asp:CustomValidator ClientIDMode="Static" ID="CustomValidator1" runat="server" ErrorMessage="Možete unijeti najviše 25 znakova!" Text="*"></asp:CustomValidator>
        </div>
    </div>

    <div class="input-group mb-3">
        <div class="offset-2 col-md-10">
            <asp:Button CssClass="btn btn-primary" ID="btnCreateQuiz" runat="server" Text="Kreiraj Kviz" />
        </div>
    </div>
</asp:Content>
