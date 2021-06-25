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
            int pitanjeID = quizId.BrojPitanja -1;
            lblPitanje.Text = pitanja[pitanjeID].ToString();

            bool isModerator = (int)Session["user_type"] == 0;
            int pitanje = pitanja[pitanjeID].IDPitanje;
            List<Odgovor> listOdgovori = datasource.Odgovori.Get(o => o.PitanjeID == pitanje).ToList();
            CreateButtons(isModerator, listOdgovori);
        }

        private void CreateButtons(bool isModerator, List<Odgovor> listOdgovori)
        {
            int itterate = 0;
            listOdgovori.ForEach(o =>
            {
                Button btn = new Button
                {
                    Text = isModerator ? o.Tekst : ""
                };
                if(!isModerator)
                { 
                    btn.Click += Btn_Click;
                    btn.Attributes.Add("Tag", o.Correct.ToString());
                }
                string css = "col";
                if(itterate == 0)
                {
                    css = "col m-1 btn btn-primary";
                }
                else if(itterate == 1)
                {
                    css = "col m-1 btn btn-success";
                }
                else if(itterate == 2)
                {
                    css = "col m-1 btn btn-danger";
                }
                else if(itterate == 3)
                {
                    css = "col m-1 btn btn-warning";
                }

                btn.CssClass = css;

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