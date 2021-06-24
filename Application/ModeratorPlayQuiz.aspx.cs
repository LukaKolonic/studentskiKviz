using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class ModeratorPlayQuiz : System.Web.UI.Page
    {
        User u = new User(); //ne znam kako dohvatiti trenutnog usera

        //kada player stisne gumb da ude u kviz (upise kod i nadimak prethodno) tada ga stavi u listu players
        //i onda ispisi players.count svakih 1 sekundu

        List<Player> players = new List<Player>();

        string code;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCode();
                
            }
            
        }

        //tajmer koj svaku sekundu prikazuje broj igraca
        private void ShowPlayersCount()
        {
            TextPlayers.Text = "0";
            int interval = 1000;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = interval;
            timer.Start();
            if (interval != 0)
            {
                timer.Elapsed += timer_Elapsed;
                
            } 
            
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TextPlayers.Text = players.Count().ToString();
        }

        private void GenerateCode()
        {
            Random r = new Random();
            TextCode.Text = r.Next(100000,999999).ToString();
            code = TextCode.Text;
        }

        protected void Play_Click(object sender, EventArgs e)
        {
            // napravi instancu novog kviza, id se povecava automatski, userId (user.ID) i user
            Quiz q = new Quiz(u.IDUser, u, code);
            u.Quiz.Add(q);


            //pokreni pitanje (redirect na novu stranicu)
            Response.Redirect("QuizFinish.aspx");
            

        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            //odi na pocetnu stranicu
            Response.Redirect("Account.aspx");
           
        }
    }
}