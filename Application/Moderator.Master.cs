using Application.DAL;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class Moderator : System.Web.UI.MasterPage
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            UnitOfWork dataSource = new UnitOfWork();
            int id;
            string value;
            HttpCookie kuki = Request.Cookies["moderatorID"];
            value = kuki.Value;
            if (Request.Cookies["moderatorID"] == null || int.TryParse(value, out id) == false)
            {
                Response.Redirect("login.aspx");

            }
            int.TryParse(value, out id);
            User user = dataSource.Users.GetByID(id);
            LblEmail.Text = user.Email;
            LblIme.Text = $"{user.Ime} {user.Prezime}";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}