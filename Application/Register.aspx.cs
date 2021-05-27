using Application.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnitOfWork dataSource = new UnitOfWork();

            /*unitofWork.Users.Insert(new User
            {
                Ime = "Manuel",
                Prezime = "Plasc",
                Email = "mancek78@gmail.com",
                Password = BC.HashPassword("mancek123")
            });
            unitofWork.Commit();*/

            string email = "mancek789@gmail.com";
            bool IsUnique = dataSource.Users.Get(u => u.Email == email).FirstOrDefault() == null;
            //bool authenticated = BC.Verify("mancek12s3", user.Password);
            test.Text = IsUnique.ToString();
        }
    }
}