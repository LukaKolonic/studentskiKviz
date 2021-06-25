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
            int quizId = datasource.PlayedQuizes.Get(q => q.GeneratedQuizID == generatedQuizId).FirstOrDefault().QuizID;

            List<Pitanje> pitanja = datasource.Pitanja.Get(p => p.QuizID == quizId).ToList();
            int pitanjeID = datasource.PlayedQuizes.Get(q => q.QuizID == quizId).FirstOrDefault().BrojPitanja;
            lblPitanje.Text = pitanja[pitanjeID].ToString();

            bool isModerator = (int)Session["user_type"] == 0;
            List<Odgovor> listOdgovori = datasource.Odgovori.Get(o => o.PitanjeID == pitanja[pitanjeID].IDPitanje).ToList();
            CreateButtons(isModerator, listOdgovori);
        }

        private void CreateButtons(bool isModerator, List<Odgovor> listOdgovori)
        {
            listOdgovori.ForEach(o =>
            {
                Button btn = new Button
                {
                    Text = isModerator ? "" : o.Tekst
                };
                if(!isModerator)
                { 
                    btn.Click += Btn_Click;
                    btn.Attributes.Add("name", o.Correct.ToString());
                }
                form1.Controls.Add(btn);
            });        
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnClicked = sender as Button;
            if(btnClicked.Attributes["name"] == "True")
            {
                Player player = (Player)Session["player"];
                player.Points++;
                Session["lastQuestionCorrect"] = true;
                Response.Redirect("QuizWaiting.aspx");
            }
        }

    }
}