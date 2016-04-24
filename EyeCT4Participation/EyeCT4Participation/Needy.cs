using System;
using System.Collections.Generic;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    internal class Needy : Account
    {
        private readonly DBhelprequest dbHelprequest = new DBhelprequest();
        private readonly DBReview dbReview = new DBReview();

        public Needy(int id, bool ov, string username, string password, string name, string adress, string residence,
            string email, int phonenumber, DateTime birthdate, string geslacht, bool active)
            : base(id, username, password, name, adress, residence, email, phonenumber, birthdate, active, geslacht)
        {
            Ov = ov;
        }

        public bool Ov { get; set; }
        /// <summary>
        /// Nieuwe hulpvraag aanmaken
        /// </summary>
        /// <param name="question"></param>
        /// <param name="locatie"></param>
        /// <param name="startdate"></param>
        /// <param name="endatdate"></param>
        /// <param name="urgency"></param>
        /// <param name="amountVolunteers"></param>
        /// <returns></returns>
        public bool AddHelpRequest(string question, string locatie, DateTime startdate, DateTime endatdate, bool urgency,
            int amountVolunteers)
        {
            //dit moet naar de database
            var newHelpRequest = new HelpRequest(dbHelprequest.getLatestId("Hulpvraag"), question, startdate, urgency,
                true, this, new List<Volunteer>());
            return dbHelprequest.AddHelpRequest(newHelpRequest);
        }
        /// <summary>
        /// Nieuwe review aanmaken
        /// </summary>
        /// <param name="score"></param>
        /// <param name="description"></param>
        /// <param name="reciever"></param>
        /// <param name="helprequest"></param>
        /// <returns></returns>
        public bool AddReview(int score, string description, Volunteer reciever, HelpRequest helprequest)
        {
            //dit moet naar de database
            var newReview = new Review(dbReview.getLatestId("Review"), score, description, "", true, DateTime.Now, this,
                reciever, helprequest.id);
            return dbReview.AddReview(newReview);
        }
    }
}