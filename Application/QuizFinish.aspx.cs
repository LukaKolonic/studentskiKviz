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
    public partial class QuizFinish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnitOfWork datasource = new UnitOfWork();

            int generatedQuizId = (int)Session["generated_quiz_id"];
            bool isModerator = (int)Session["user_type"] == 0;
            int quizId = datasource.PlayedQuizes.Get(q => q.GeneratedQuizID == generatedQuizId).FirstOrDefault().IDPlayedQuiz;
            List<Player> players = datasource.Players.Get(p => p.PlayedQuizID == quizId).ToList();
            players.Sort((p1, p2) => -p1.Points.CompareTo(p2.Points));

            if (!isModerator)
            {
                Player player = (Player)Session["player"];
                int place = players.FindIndex(p => p.IDPlayer == player.IDPlayer);
                SetPlayerLabels(place+1,player.Points);
            }
            else
            {
                CreateModeratorTable(players);
            }
        }

        private void CreateModeratorTable(List<Player> players)
        {
            Table table = new Table
            {
                CssClass = "table table-primary table-striped"
            };
            table.Controls.Add(AddTableHeader("Player", "Points"));
            players.Take(10).ToList().ForEach(p => table.Controls.Add(AddTableRow(p.Name, p.Points.ToString())));
            form1.Controls.Add(table);
        }

        private TableHeaderRow AddTableHeader(string text1, string text2)
        {
            TableHeaderRow tr = new TableHeaderRow();
            TableHeaderCell tc1 = new TableHeaderCell
            {
                Text = text1
            };
            TableHeaderCell tc2 = new TableHeaderCell
            {
                Text = text2,
                CssClass = "text-end"
            };
            tr.Controls.Add(tc1);
            tr.Controls.Add(tc2);
            return tr;
        }

        private TableRow AddTableRow(string text1, string text2)
        {
            TableRow tr = new TableRow();
            TableCell tc1 = new TableCell
            {
                Text = text1
            };
            TableCell tc2 = new TableCell
            {
                Text = text2,
                CssClass = "text-end"
            };
            tr.Controls.Add(tc1);
            tr.Controls.Add(tc2);
            return tr;
        }

        private void SetPlayerLabels(int place, int points)
        {
            Label lblPlace = new Label
            {
                Text = $"You finished on place: <span class='text-primary fw-bold'>{place}</span>",
                CssClass = "display-3 fw-normal"
            };
            Label lblPoints = new Label
            {
                Text = $"Points: <span class='text-warning fw-bold'>{points}</span>",
                CssClass = "display-5 fw-norma"
            };
            placediv.Controls.Add(lblPlace);
            pointsdiv.Controls.Add(lblPoints);
        }
    }
}