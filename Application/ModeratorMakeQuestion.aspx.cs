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
    public partial class ModeratorMakeQuestion : System.Web.UI.Page
    {
        UnitOfWork dataSource = new UnitOfWork();

        public struct privremeno_pitanjce
        {
            public string pitanje;
            public string tocan_odgovor;
            public string krivi_odgovor1;
            public string krivi_odgovor2;
            public string krivi_odgovor3;
        }
        List<privremeno_pitanjce> lp = new List<privremeno_pitanjce>();
        privremeno_pitanjce p;
        string string_pitanje_za_promjenu;
        int broj_kviza_za_promjenu;


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // ukoliko korisnik u homepageu klikne na promjenu kviza, id kviza zapiše se u session
            // i ovdje gurne u getkviz koji promijeni listu lp na način da ju
            if (Session["kviz_id"] != null)
            {
                string_pitanje_za_promjenu = Session["kviz_id"] as string;
                int.TryParse(string_pitanje_za_promjenu, out broj_kviza_za_promjenu);
                GetKviz(broj_kviza_za_promjenu);
                Session["kviz_id"] = null;
            }

            if (Page.IsPostBack)
            {
                // provjerava postoje li spremljena pitanja, i ukoliko postoje sprema ih u listu
                // u koju kasnije spremamo nova pitanja
                if (Session["privremena_pitanja"] != null)
                {
                    lp = Session["privremena_pitanja"] as List<privremeno_pitanjce>;
                }

                // kreira indeks pitanja ukoliko korisnik želi promijeniti pitanje


                // kreira pitanje 
                if (Page.IsValid)
                {
                    p.pitanje = BoxPitanje.Text;
                    p.tocan_odgovor = BoxTocanOdgovor.Text;
                    p.krivi_odgovor1 = BoxPrviKriviOdgovor.Text;

                    if (BoxTreciKriviOdgovor != null)
                    {
                        p.krivi_odgovor3 = BoxTreciKriviOdgovor.Text;
                    }
                    if (BoxDrugiKriviOdgovor != null)
                    {
                        p.krivi_odgovor2 = BoxDrugiKriviOdgovor.Text;
                    }


                    // provjerava je li mijenjamo pitanje ili samo dodaje novo


                    lp.Add(p);


                    Session["privremena_pitanja"] = lp;
                }

                BoxPitanje.Text = "";
                BoxTocanOdgovor.Text = "";
                BoxPrviKriviOdgovor.Text = "";
                BoxDrugiKriviOdgovor.Text = "";
                BoxTreciKriviOdgovor.Text = "";
            }
        }
        public void GetKviz(int broj_kviza_za_promjenu)
        {
            // iz baze vadi sva pitanja iz kviza po id-u
            var pitanja = dataSource.Pitanja.Get(p => p.QuizID == broj_kviza_za_promjenu);
            int id_pitanje;

            //prolazi po pitanjima
            foreach (var item in pitanja)
            {
                p.pitanje = item.Tekst;
                id_pitanje = item.IDPitanje;
                // iz baze vadi sve odgovore na pitanje po id-u 
                var odgovori = dataSource.Odgovori.Get(o => o.PitanjeID == id_pitanje);
                // brojač u petlji služi da se vidi koliko ima krivih odgovora jer može biti između 1 i 3
                // brojač se resetira uvijek nakon što petlja unese sve odgovore
                int brojac = 0;
                foreach (var rjesenje in odgovori)
                {
                    if (rjesenje.Correct)
                    {

                    }

                }
                brojac = 0;
                lp.Add(p);
            }
        }

        protected void provjera_znakova_pitanja_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 200)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void provjera_znakova_tocnog_odgovora_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 25)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void provjera_znakova_1_krivog_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 25)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void provjera_znakova_2_krivog_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((args.Value.Length > 25) || (args.Value == null))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void provjera_znakova_3_krivog_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((args.Value.Length > 25) || (args.Value == null))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void razlicit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value != BoxPrviKriviOdgovor.Text && args.Value != BoxDrugiKriviOdgovor.Text
                && args.Value != BoxTreciKriviOdgovor.Text)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}