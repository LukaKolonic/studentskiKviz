<%@ Page Title="" Language="C#" MasterPageFile="~/Moderator.Master" AutoEventWireup="true" CodeBehind="ModeratorHome.aspx.cs" Inherits="Application.ModeratorHome" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink CssClass="btn btn-primary" NavigateUrl="ModeratorMakeQuestion.aspx" ID="LinkButton2" runat="server">Kreiraj Kviz</asp:HyperLink>
    <div class="container bg-light rounded-3 mt-3" runat="server" id="questionsList">
    </div>
</asp:Content>
