<%@ Page Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Application.UserLogin" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">--%>
<%--<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/custom.css" rel="stylesheet" />
    <title></title>
</head>--%>

<%--OVO JE ZAKOMENTIRANO JER JE PRIJE BILA WEB FORMA BEZ MASTERA--%>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

<%--<body>--%>
     <%--<form id="form1" runat="server">--%>
       <div class="form_wrapper">
          <div class="form_container">
            <div class="title_container">
              <h2>Pristup kvizu</h2>
            </div>
            <div class="row clearfix">
              <div class="">
                  <div class="input_field"> <span><i aria-hidden="true" class="fa fa-envelope"></i></span>
                      <asp:TextBox runat="server" class="input_control" name="code" ID="code" placeholder="Unesite kod..."/>
                      <asp:RequiredFieldValidator ErrorMessage="Code field is required!" ControlToValidate="code" runat="server" Display="None"/>
                      <asp:CustomValidator ErrorMessage="Code is not valid." ControlToValidate="code" runat="server" OnServerValidate="CodeValidate" Display="None"/>
                  </div>
                  <div class="input_field"> <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                    <asp:TextBox runat="server" class="input_control" name="nickname" ID="nickname" placeholder="Unesite nadimak..."/>
                       <asp:RequiredFieldValidator ErrorMessage="Nickname field is required!" ControlToValidate="nickname" runat="server" Display="None"/>
                      <asp:CustomValidator ErrorMessage="Player with this nickname already exists." ControlToValidate="nickname" runat="server" OnServerValidate="NicknameValidate" Display="None"/>
                    </div>
                 
                 
                  </div>
                  <asp:Button type="submit" Text="Pristupite kvizu" runat="server" class="submit_control" ID="submit"/>
              
            </div>
          </div>
        </div>
   <%-- </form>
    
</body>--%>
    </asp:Content>
<%--</html>--%>
