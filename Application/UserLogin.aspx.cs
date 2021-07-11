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
    public partial class UserLogin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack)
            {
                UnitOfWork dataSource = new UnitOfWork();
              
                Session["quiz_pitanja"] = 0;
                Session["user_type"] = 1;
                int codeID = int.Parse(code.Text);
                Session["generated_quiz_id"] = codeID;
                
                PlayedQuiz playedQuiz = dataSource.PlayedQuizes.Get(q => q.GeneratedQuizID == codeID).FirstOrDefault();
                if(playedQuiz == null)
                {
                    Response.Redirect("UserLogin.aspx");
                }

                Player player = new Player{
                    Name = nickname.Text,
                    PlayedQuizID = playedQuiz.IDPlayedQuiz,
                    Points = 0
                };
                dataSource.Players.Insert(player);
                dataSource.Commit();
                Session["player"] = player;
                Response.Redirect("QuizWaiting.aspx");
            }
        }
    }
}