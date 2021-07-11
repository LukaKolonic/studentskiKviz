<%@ Page Title="" Language="C#" MasterPageFile="~/Moderator.Master" AutoEventWireup="true" CodeBehind="ChangeAccountSettings.aspx.cs" Inherits="Application.ChangeAccountSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form_wrapper">
          <div class="form_container">
            <div class="title_container">
              <h2>Account settings</h2>
            </div>
            <div class="row clearfix">
              <div class="">
                  <div class="row clearfix">
                    <div class="col_half">
                      <div class="input_field"> <span><i aria-hidden="true" class="fa fa-user"></i></span>
                          <asp:TextBox runat="server" class="input_control" name="name" ID="name" placeholder="First Name"/>
                      </div>
                    </div>
                    <div class="col_half">
                      <div class="input_field"> <span><i aria-hidden="true" class="fa fa-user"></i></span>
                          <asp:TextBox runat="server" class="input_control" name="lastname" ID="lastname" placeholder="Last Name"/>
                      </div>
                    </div>
                  </div>
                  <div class="input_field"> <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                    <asp:TextBox runat="server" class="input_control" name="password" ID="password" placeholder="Password" type="password"/>
                  </div>
                  <div class="input_field"> <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                      <asp:TextBox runat="server" class="input_control" name="confirmpassword" ID="confirmpassword" placeholder="Confirm Password" type="password"/>
                      <asp:CompareValidator ErrorMessage="Passwords don't match." ControlToValidate="confirmpassword" ControlToCompare="password" runat="server" Display="None" />
                  </div>
                  <div class="input_field"> <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                      <asp:TextBox runat="server" class="input_control" name="oldpassword" ID="oldpassword" placeholder="Old Password" type="password"/>
                      <asp:RequiredFieldValidator ErrorMessage="Old password field is required." ControlToValidate="oldpassword" runat="server" Display="None"/>
                      <asp:CustomValidator ErrorMessage="Old password is incorrect." ControlToValidate="oldpassword" runat="server" OnServerValidate="OldPasswordServerValidate" Display="None"/>
                  </div>
                  <asp:Button type="submit" Text="Update account" runat="server" class="submit_control" ID="submit"/>
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
              </div>
            </div>
          </div>
        </div>
</asp:Content>
