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
    public partial class Register : System.Web.UI.Page
    {
        UnitOfWork dataSource = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    dataSource.Users.Insert(new User
                    {
                        Ime = name.Text,
                        Prezime = lastname.Text,
                        Email = email.Text,
                        Password = BC.HashPassword(password.Text)

                    });
                    dataSource.Commit();
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void EmailValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = dataSource.Users.Get(u => u.Email == email.Text).FirstOrDefault() == null;
        }
    }
}