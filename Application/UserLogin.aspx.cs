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

        }

        protected void NicknameValidate(object source, ServerValidateEventArgs args)
        {
            //args.IsValid = dataSource.Players.Get(p => p.Nickname == nickname.Text).FirstOrDefault() == null;
            //UnitOfWork??
        }

        protected void CodeValidate(object source, ServerValidateEventArgs args)
        {
           
        }
    }
}