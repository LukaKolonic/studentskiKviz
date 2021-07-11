using Application.DAL;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Application.ModeratorMakeQuestion;

namespace Application
{
    public partial class ModeratorMakeQuiz : System.Web.UI.Page
    {
        UnitOfWork dataSource = new UnitOfWork();

        List<privremeno_pitanjce> lp = new List<privremeno_pitanjce>();
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (Session["privremena_pitanja"] == null)
            {
                Response.Redirect("ModeratorHome.aspx");
            }
            if (Page.IsPostBack)
            {
                if (Page.IsValid)
                {
                    HttpCookie kuki = Request.Cookies["moderatorID"];
                    if (Request.Cookies["moderatorID"] == null || int.TryParse(kuki.Value, out id) == false)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    id = int.Parse(kuki.Value);
                    dataSource.Quizes.Insert(new Quiz
                    {
                        Naziv = BoxNazivKviza.Text,
                        UserID = id
                    });
                    dataSource.Commit();

                    List<Quiz> lista_kvizova = dataSource.Quizes.Get(g => g.UserID == id).ToList();
                    lp = Session["privremena_pitanja"] as List<privremeno_pitanjce>;
                    int max = Max_kviz(lista_kvizova);
                    foreach (var p in lp)
                    {
                        dataSource.Pitanja.Insert(new Pitanje
                        {
                            QuizID = max,
                            Tekst = p.pitanje

                        });
                        dataSource.Commit();
                        List<Pitanje> lista_pitanja = dataSource.Pitanja.Get(g => g.QuizID == max).ToList();
                        int maxi = Max_pitanje(lista_pitanja);

                        dataSource.Odgovori.Insert(new Odgovor
                        {
                            PitanjeID = maxi,
                            Tekst = p.tocan_odgovor,
                            Correct = true
                        });

                        dataSource.Odgovori.Insert(new Odgovor
                        {
                            PitanjeID = maxi,
                            Tekst = p.krivi_odgovor1,
                            Correct = false
                        });

                        if (p.krivi_odgovor2 != null)
                        {
                            dataSource.Odgovori.Insert(new Odgovor
                            {
                                PitanjeID = maxi,
                                Tekst = p.krivi_odgovor2,
                                Correct = false
                            });
                        }
                        if (p.krivi_odgovor3 != null)
                        {
                            dataSource.Odgovori.Insert(new Odgovor
                            {
                                PitanjeID = maxi,
                                Tekst = p.krivi_odgovor3,
                                Correct = false
                            });
                        }


                    }

                    Session["privremena_pitanja"] = null;
                    Response.Redirect("ModeratorHome.aspx");
                }
            }



        }

        private int Max_kviz(List<Quiz> lista_kvizova)
        {
            int Max = 0;
            foreach (var kviz in lista_kvizova)
            {
                if (kviz.IDQuiz > Max)
                {
                    Max = kviz.IDQuiz;
                }
            }
            return Max;
        }
        private int Max_pitanje(List<Pitanje> lista_pitanja)
        {
            int Max = 0;
            foreach (var pitanje in lista_pitanja)
            {
                if (pitanje.IDPitanje > Max)
                {
                    Max = pitanje.IDPitanje;
                }
            }
            return Max;
        }
    }
}