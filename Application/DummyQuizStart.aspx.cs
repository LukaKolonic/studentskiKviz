using Application.DAL;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BC = BCrypt.Net.BCrypt;

namespace Application
{
    public partial class DummyQuizStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            //DummyData();
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
            datasource.Commit();
            Response.Redirect("ModeratorPlayQuiz.aspx");
        }

        private static void DummyData()
        {
            UnitOfWork ds = new UnitOfWork();
            ds.Users.Insert(new User
            {
                Ime = "Manuel",
                Prezime = "Plašć",
                Email = "mancek78@gmail.com",
                Password = BC.HashPassword("mancek123")

            });
            ds.Users.Insert(new User
            {
                Ime = "Roby",
                Prezime = "Rain",
                Email = "roby@gmail.com",
                Password = BC.HashPassword("mancek123")

            });
            ds.Commit();
            ds.Quizes.Insert(new Quiz
            {
                Naziv = "Testni kviz 1",
                UserID = 1
            });
            ds.Commit();
            ds.Pitanja.Insert(new Pitanje
            {
                QuizID = 1,
                Tekst = "Pitanje 1" 
            });
            ds.Pitanja.Insert(new Pitanje
            {
                QuizID = 1,
                Tekst = "Pitanje 2"
            });
            ds.Pitanja.Insert(new Pitanje
            {
                QuizID = 1,
                Tekst = "Pitanje 3"
            });
            ds.Pitanja.Insert(new Pitanje
            {
                QuizID = 1,
                Tekst = "Pitanje 4"
            });
            ds.Pitanja.Insert(new Pitanje
            {
                QuizID = 1,
                Tekst = "Pitanje 5"
            });
            ds.Commit();
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 11",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 12",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 13",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 14",
                Correct = true
            });

            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 21",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 22",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 23",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 24",
                Correct = true
            });

            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 31",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 32",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 33",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 34",
                Correct = true
            });

            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 41",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 42",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 43",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 44",
                Correct = true
            });

            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 51",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 52",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 53",
                Correct = false
            });
            ds.Odgovori.Insert(new Odgovor
            {
                PitanjeID = 1,
                Tekst = "Odgovor 54",
                Correct = true
            });

            ds.Commit();
        }

        private int GenerateCode()
        {
            Random r = new Random();
            return r.Next(100000, 999999);
        }
    }
}