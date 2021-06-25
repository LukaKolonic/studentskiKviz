using Application.DAL;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class ModeratorPlayQuiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextCode.Text = Session["generated_quiz_id"].ToString();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account.aspx");
        }

        protected void Play_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizShow.aspx");
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            TextPlayers.Text = GetConnectedPlayers();
        }

        private string GetConnectedPlayers()
        {
            UnitOfWork datasource = new UnitOfWork();

            int generatedQuizId = (int)Session["generated_quiz_id"];
            int quizId = datasource.PlayedQuizes.Get(q => q.GeneratedQuizID == generatedQuizId).FirstOrDefault().IDPlayedQuiz;

            return datasource.Players.Get(p => p.PlayedQuizID == quizId).Count().ToString();
        }
    }
}