using Application.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class UserLogin : System.Web.UI.Page
    {
        UnitOfWork dataSource = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack)
            {
                Session["user_type"] = 1;
                Response.Redirect("QuizWaiting.aspx");
            }
        }
    }
}