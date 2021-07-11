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
    public partial class ModeratorHome : System.Web.UI.Page
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            // služi kao kontejner privremenih pitanja
            Session["privremena_pitanja"] = null;
            // koristi kreira se u moderator homeu,
            // a koristi se u moderator make question za izmjenu kviza i u moderator start quizu za punjenje kviza;  
            Session["kviz_id"] = null;
            // kreira se u moderator startu,
            // a koristi se u moderator playu i quiz finishu kako bi se oslobodilo tablicu igriv
            Session["zaosloboditi"] = null;
            // kreira se moderator startu
            // i koristi se u moderator playu za pristupanju admin id-u
            // i user playu za generiranje tablice rezultata na kraju kviza
            Session["IgraID"] = null;
            // kreira se moderator startu
            // i briše se u moderator playu, to je 
            Session["ID_za_brisanje_u_kvizu"] = null;
            // kreira se u play user i play moderator i služi kao kontejner broja pitanja
            Session["Broj_odgovora"] = null;
            // kreira se u play user i play moderator i služi kao kontejner rezultata
            Session["rezultati"] = null;

            ucitaj_kontrole();

        }

        public void ucitaj_kontrole()
        {
            HttpCookie kuki = Request.Cookies["moderatorID"];
            if (Request.Cookies["moderatorID"] == null || int.TryParse(kuki.Value, out id) == false)
            {
                Response.Redirect("Login.aspx");
            }
            id = int.Parse(kuki.Value);
            IEnumerable<Quiz> quizes = unitOfWork.Quizes.Get(q => q.UserID == id);
            CreateQuizesTable(quizes);
        }

        private void CreateQuizesTable(IEnumerable<Quiz> quizes)
        {
            Table table = new Table
            {
                CssClass = "table"
            };
            table.Controls.Add(AddTableHeader("Name", ""));
            quizes.ToList().ForEach(q => table.Controls.Add(AddTableRow(q.Naziv, q.IDQuiz)));
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
                CssClass = "btn btn-secondary me-3",
                ID = id.ToString(),
                ClientIDMode = ClientIDMode.Static
            };
            Button btn = new Button
            {
                Text = "Pokreni",
                CssClass = "btn btn-primary btn-run",
                ID = id.ToString(),
                ClientIDMode = ClientIDMode.Static
            };
            btn.Click += Btn_Click;
            tc2.Controls.Add(btnEdit);
            tc2.Controls.Add(btn);
            tr.Controls.Add(tc1);
            tr.Controls.Add(tc2);
            return tr;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int generatedID = GenerateCode();
            Session["user_type"] = 0;
            Session["generated_quiz_id"] = generatedID;
            UnitOfWork datasource = new UnitOfWork();
            int quizId = int.Parse(btn.ID);

            Quiz quiz = unitOfWork.Quizes.GetByID(quizId);
            datasource.PlayedQuizes.Insert(new PlayedQuiz
            {
                QuizID = quiz.IDQuiz,
                BrojPitanja = 0,
                GeneratedQuizID = generatedID
            });
            datasource.Commit();
            Response.Redirect("ModeratorPlayQuiz.aspx");
        }

        private int GenerateCode()
        {
            Random r = new Random();
            return r.Next(100000, 999999);
        }
    }
}