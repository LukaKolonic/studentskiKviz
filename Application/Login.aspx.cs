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
    public partial class Login : System.Web.UI.Page
    {
        UnitOfWork dataSource = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    User user = dataSource.Users.Get(u => u.Email == email.Text).FirstOrDefault();
                    Response.Cookies["userID"].Value = user.IDUser.ToString();
                    Response.Redirect("Account.aspx");
                }
            }
        }

        private bool AuthenticateUser()
        {
            User user = dataSource.Users.Get(u => u.Email == email.Text).FirstOrDefault();
            return BC.Verify(password.Text, user?.Password);
        }

        protected void AccountServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = AuthenticateUser();
        }
    }
}