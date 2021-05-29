using Application.DAL;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BC = BCrypt.Net.BCrypt;

namespace Application
{
    public partial class ChangeAccountSettings : System.Web.UI.Page
    {
        UnitOfWork dataSource = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = GetUser();
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    if (name.Text.Length != 0)
                    {
                        user.Ime = name.Text;
                    }
                    if (lastname.Text.Length != 0)
                    {
                        user.Prezime = lastname.Text;
                    }
                    if (password.Text.Length != 0)
                    {
                        user.Password = BC.HashPassword(password.Text);
                    }

                    dataSource.Users.Update(user);
                    dataSource.Commit();
                    Response.Redirect("Account.aspx");
                }
            }
            else
            {
                name.Attributes.Add("placeholder", user.Ime);
                lastname.Attributes.Add("placeholder", user.Prezime);
            }
        }

        private User GetUser() => (User)Session["user"];

        protected void OldPasswordServerValidate(object source, ServerValidateEventArgs args)
        {
            User user = GetUser();
            args.IsValid = BC.Verify(oldpassword.Text, user?.Password);
        }
    }
}