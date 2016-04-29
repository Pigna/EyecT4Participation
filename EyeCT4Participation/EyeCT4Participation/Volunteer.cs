using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    internal class Volunteer : Account
    {
        private readonly DBhelprequest dbHelprequest = new DBhelprequest();
        private readonly DBReview dbReview = new DBReview();
        private DBvolunteer dbVolunteer = new DBvolunteer();
        private List<Review> reviewList = new List<Review>();
        public List<Beschikbaarheid> beschikbaarheidList = new List<Beschikbaarheid>();

        public Volunteer(int id, bool license, string username, string password, string name, string adress,
            string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active)
            : base(id, username, password, name, adress, residence, email, phonenumber, birthdate, active, geslacht)
        {
            License = license;
        }

        public bool License { get; set; }

        /// <summary>
        ///     Inschrijven op hulpvraag
        /// </summary>
        /// <param name="name"></param>
        /// <param name="author"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool JoinHelpRequest(HelpRequest helprequest, Volunteer volunteer)
        {
            if (dbHelprequest.JoinHelprequest(helprequest, volunteer))
            {
                return true;
            }
            return false;
        }

        enum Dagen { Zondag,Maandag,Dinsdag,Woensdag,Donderdag,Vrijdag,Zaterdag}
        enum Dagdelen { Ochtend,Middag,Avond}

        /// <summary>
        /// Beschikbaarheid aangeven
        /// </summary>
        /// <returns></returns>
        public bool AddBeschikbaarheid(int id, string dag, string dagdeel,int gebruikerID)
        {
            int Dag = 10;
            int Dagdeel = 10;

            if (dag == "Maandag")
            {
               Dag =(int) Dagen.Maandag;
            }
            if (dag == "Dinsdag")
            {
               Dag = (int)Dagen.Dinsdag;
            }
            if (dag == "Woensdag")
            {
               Dag =  (int)Dagen.Woensdag;
            }
            if (dag == "Donderdag")
            {
               Dag = (int)Dagen.Donderdag;
            }
            if (dag == "Vrijdag")
            {
               Dag = (int)Dagen.Vrijdag;
            }
            if (dag == "Zaterdag")
            {
               Dag = (int)Dagen.Zaterdag;
            }
            if (dag == "Zondag")
            {
               Dag = (int)Dagen.Zondag;
            }
            if (dagdeel == "Ochtend")
            {
                Dagdeel = (int) Dagdelen.Ochtend;
            }
            if (dagdeel == "Middag")
            {
                Dagdeel = (int) Dagdelen.Middag;
            }
            if (dagdeel == "Avond")
            {
                Dagdeel = (int) Dagdelen.Avond;
            }

            Beschikbaarheid beschikbaarheid = new Beschikbaarheid(id, Dag, Dagdeel,gebruikerID);
            if (beschikbaarheidList.Contains(beschikbaarheid))
            {
                MessageBox.Show("De aangemaakte beschikbaarheid bestaat al.");
                return false;
            }
            else
            {
                if (dbVolunteer.AddBeschikbaarheid(beschikbaarheid))
                {
                    return true;
                }
                MessageBox.Show("Er is iets fout gegaan, check wat u heeft ingevult en probeer opnieuw");
                return false;
            }
        }

        public List<Beschikbaarheid> getListBeschikbaarheid()
        {
            beschikbaarheidList = dbVolunteer.GetBeschikbaarheidList();
            return beschikbaarheidList;
        }
        /// <summary>
        /// Lijst met review
        /// </summary>
        /// <returns></returns>
        public List<Review> getListReview()
        {
            reviewList = dbReview.GetReview(this);
            return reviewList;
        }
    }
}