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
    public partial class QuizShow : System.Web.UI.Page
    {
        UnitOfWork datasource = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            int generatedQuizId = (int)Session["generated_quiz_id"];
            PlayedQuiz quizId = datasource.PlayedQuizes.Get(q => q.GeneratedQuizID == generatedQuizId).FirstOrDefault();

            List<Pitanje> pitanja = datasource.Pitanja.Get(p => p.QuizID == quizId.QuizID).ToList();
            int pitanjeID = quizId.BrojPitanja - 1;
            if(pitanjeID == pitanja.Count)
            {
                Response.Redirect("QuizFinish.aspx");
            }
            lblPitanje.Text = pitanja[pitanjeID].ToString();

            bool isModerator = (int)Session["user_type"] == 0;
            int pitanje = pitanja[pitanjeID].IDPitanje;
            List<Odgovor> listOdgovori = datasource.Odgovori.Get(o => o.PitanjeID == pitanje).ToList();
            CreateButtons(isModerator, listOdgovori);
        }

        private void CreateButtons(bool isModerator, List<Odgovor> listOdgovori)
        {
            int itterate = 0;
            List<string> styles = new List<string> { "col m-1 btn btn-primary", "col m-1 btn btn-success", "col m-1 btn btn-danger", "col m-1 btn btn-warning" };
            listOdgovori.ForEach(o =>
            {
                Button btn = new Button
                {
                    Text = isModerator ? o.Tekst : "",
                    CssClass = styles[itterate]
                };
                if(!isModerator)
                { 
                    btn.Click += Btn_Click;
                    btn.Attributes.Add("Tag", o.Correct.ToString());
                }

                if (itterate < 2)
                {
                    colone.Controls.Add(btn);
                }
                else
                {
                    coltwo.Controls.Add(btn);
                }
                itterate++;
            });
            if (isModerator)
            {
                Button button = new Button
                {
                    Text = "NEXT"
                };
                button.CssClass = "m-2 btn btn-secondary";
                button.Click += Button_Click;
                form1.Controls.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int generatedQuizId = (int)Session["generated_quiz_id"];
            PlayedQuiz quiz = datasource.PlayedQuizes.Get(q => q.GeneratedQuizID == generatedQuizId).FirstOrDefault();
            quiz.BrojPitanja++;
            datasource.PlayedQuizes.Update(quiz);
            datasource.Commit();
            Response.Redirect("QuizShow.aspx");
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnClicked = sender as Button;
            if(btnClicked.Attributes["Tag"] == "True")
            {
                Player player = (Player)Session["player"];
                player.Points++;
                datasource.Players.Update(player);
                datasource.Commit();
                Session["player"] = player;
                Session["lastQuestionCorrect"] = true;
            }
            else
            {
                Session["lastQuestionCorrect"] = false;
            }
            Response.Redirect("QuizWaiting.aspx");
        }

    }
}