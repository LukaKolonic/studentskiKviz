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
    public partial class ModeratorEditQuestion : System.Web.UI.Page
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            int questionId = (int)Session["question_id"];
            Pitanje pitanje = unitOfWork.Pitanja.GetByID(questionId);
            List<Odgovor> odgovori = unitOfWork.Odgovori.Get(o => o.PitanjeID == questionId).ToList();
            if (!IsPostBack)
            {
                BoxPitanje.Text = pitanje.Tekst;
                BoxTocanOdgovor.Text = odgovori.Where(o => o.Correct).FirstOrDefault().Tekst;
                BoxTocanOdgovor.Attributes.Add("answerID", odgovori.Where(o => o.Correct).FirstOrDefault().IDOdgovor.ToString());
                List<Odgovor> pogresniOdgovori = odgovori.Where(o => o.Correct == false).ToList();
                BoxPrviKriviOdgovor.Text = pogresniOdgovori[0].Tekst;
                BoxPrviKriviOdgovor.Attributes.Add("answerID", pogresniOdgovori[0].IDOdgovor.ToString());
                if (pogresniOdgovori[1] != null)
                {
                    BoxDrugiKriviOdgovor.Text = pogresniOdgovori[1].Tekst;
                    BoxDrugiKriviOdgovor.Attributes.Add("answerID", pogresniOdgovori[1].IDOdgovor.ToString());
                }
                if (pogresniOdgovori[2] != null)
                {
                    BoxTreciKriviOdgovor.Text = pogresniOdgovori[2].Tekst;
                    BoxTreciKriviOdgovor.Attributes.Add("answerID", pogresniOdgovori[2].IDOdgovor.ToString());
                }
            }
            else
            {
                pitanje.Tekst = BoxPitanje.Text;
                odgovori.Where(o => o.IDOdgovor == int.Parse(BoxTocanOdgovor.Attributes["answerID"])).FirstOrDefault().Tekst = BoxTocanOdgovor.Text;
                odgovori.Where(o => o.IDOdgovor == int.Parse(BoxPrviKriviOdgovor.Attributes["answerID"])).FirstOrDefault().Tekst = BoxPrviKriviOdgovor.Text;
                odgovori.Where(o => o.IDOdgovor == int.Parse(BoxDrugiKriviOdgovor.Attributes["answerID"])).FirstOrDefault().Tekst = BoxDrugiKriviOdgovor.Text;
                odgovori.Where(o => o.IDOdgovor == int.Parse(BoxTreciKriviOdgovor.Attributes["answerID"])).FirstOrDefault().Tekst = BoxTreciKriviOdgovor.Text;
                unitOfWork.Pitanja.Update(pitanje);
                odgovori.ForEach(o => unitOfWork.Odgovori.Update(o));
                unitOfWork.Commit();
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModeratorEditQuiz.aspx");
        }
    }
}