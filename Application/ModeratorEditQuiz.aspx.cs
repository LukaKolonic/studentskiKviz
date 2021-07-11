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
    public partial class ModeratorEditQuiz : System.Web.UI.Page
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            ucitaj_kontrole();
        }
        public void ucitaj_kontrole()
        {
            int quizId = (int)Session["quiz_id"];
            IEnumerable<Pitanje> pitanja = unitOfWork.Pitanja.Get(p => p.QuizID == quizId);
            CreateQuestionsTable(pitanja);
        }

        private void CreateQuestionsTable(IEnumerable<Pitanje> questions)
        {
            Table table = new Table
            {
                CssClass = "table"
            };
            table.Controls.Add(AddTableHeader("Tekst", ""));
            questions.ToList().ForEach(q => table.Controls.Add(AddTableRow(q.Tekst, q.IDPitanje)));
            questionsList.Controls.Add(table);
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
                Text = text2
            };
            tr.Controls.Add(tc1);
            tr.Controls.Add(tc2);
            return tr;
        }

        private TableRow AddTableRow(string text1, int id)
        {
            TableRow tr = new TableRow();
            TableCell tc1 = new TableCell
            {
                Text = text1
            };
            TableCell tc2 = new TableCell();
            tc2.CssClass = "text-end";
            Button btnEdit = new Button
            {
                Text = "Edit",
                CssClass = "btn btn-primary",
                ClientIDMode = ClientIDMode.Static
            };
            btnEdit.Click += BtnEdit_Click;
            btnEdit.Attributes.Add("idQuestion", id.ToString());
            tc2.Controls.Add(btnEdit);
            tr.Controls.Add(tc1);
            tr.Controls.Add(tc2);
            return tr;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int questionId = int.Parse(btn.Attributes["idQuestion"]);

            Session["question_id"] = questionId;
            Response.Redirect("ModeratorEditQuestion.aspx");
        }
    }
}