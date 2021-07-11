using Application.DAL;
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

        }

        public void ucitaj_kontrole()
        {

        }
    }
}