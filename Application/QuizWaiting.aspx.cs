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
    public partial class QuizWaiting : System.Web.UI.Page
    {
        UnitOfWork datasource = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lastQuestionCorrect"] != null)
            {
                if((bool)Session["lastQuestionCorrect"])
                {
                    lblMessage.Text = "Correct answer!";     
                }
                else
                {
                    lblMessage.Text = "Incorrect answer!";
                }
                Player player = (Player)Session["player"];
                Label lblScore = new Label
                {
                    Text = $"Points: {player.Points}"
                };
                lblScore.CssClass = "display-3 mt-5";
                form1.Controls.Add(lblScore);
            }
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            bool isModerator = (int)Session["user_type"] == 0;
            if (!isModerator)
            {
                CheckNextQuestion();
            }
        }

        private void CheckNextQuestion()
        {
            int generatedQuizId = (int)Session["generated_quiz_id"];
            int questionID = (int)Session["quiz_pitanja"];
            int realQuestionID = datasource.PlayedQuizes.Get(q => q.GeneratedQuizID == generatedQuizId).FirstOrDefault().BrojPitanja;
            if (realQuestionID > questionID)
            {
                Session["quiz_pitanja"] = realQuestionID;
                Response.Redirect("QuizShow.aspx");
            }
        }
    }
}