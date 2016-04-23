using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    class Volunteer : Account
    {
        DBReview dbReview = new DBReview();
        DBhelprequest dbHelprequest = new DBhelprequest();
        public bool License { get; set; }
        private List<Review> reviewList = new List<Review>();

        public Volunteer(int id, bool license, string username, string password, string name, string adress, string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active) : base(id, username, password, name, adress, residence, email, phonenumber, birthdate, active, geslacht)
        {
            License = license;
        }

        public void AddReaction(string name, string message, Volunteer author, DateTime date)
        {
            string query = "INSERT INTO review(name, message, author, date) VALUES (" + name + "," + message + "," + Convert.ToString(author) + "," + Convert.ToString(date) + ")";
            dbReview.DoQueryAddReaction(query);
        }
        /// <summary>
        /// Inschrijven op hulpvraag
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
