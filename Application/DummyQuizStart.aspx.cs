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
    public partial class DummyQuizStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            int generatedID = GenerateCode();
            Session["user_type"] = 0;
            Session["generated_quiz_id"] = generatedID;
            UnitOfWork datasource = new UnitOfWork();
            datasource.PlayedQuizes.Insert(new PlayedQuiz
            {
                QuizID = 1,
                BrojPitanja = 0,
                GeneratedQuizID = generatedID
            });
            Response.Redirect("ModeratorPlayQuiz.aspx");
        }
        private int GenerateCode()
        {
            Random r = new Random();
            return r.Next(100000, 999999);
        }
    }
}