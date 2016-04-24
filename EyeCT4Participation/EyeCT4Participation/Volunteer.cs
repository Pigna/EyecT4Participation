using System;
using System.Collections.Generic;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    internal class Volunteer : Account
    {
        private readonly DBhelprequest dbHelprequest = new DBhelprequest();
        private readonly DBReview dbReview = new DBReview();
        private List<Review> reviewList = new List<Review>();

        public Volunteer(int id, bool license, string username, string password, string name, string adress,
            string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active)
            : base(id, username, password, name, adress, residence, email, phonenumber, birthdate, active, geslacht)
        {
            License = license;
        }

        public bool License { get; set; }

        public void AddReaction(string name, string message, Volunteer author, DateTime date)
        {
            var query = "INSERT INTO review(name, message, author, date) VALUES (" + name + "," + message + "," +
                        Convert.ToString(author) + "," + Convert.ToString(date) + ")";
            dbReview.DoQueryAddReaction(query);
        }

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

        public List<Review> getListReview()
        {
            reviewList = dbReview.GetReview(this);
            return reviewList;
        }
    }
}