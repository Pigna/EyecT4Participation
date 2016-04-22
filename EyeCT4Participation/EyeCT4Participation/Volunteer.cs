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
        //DBReview databaseR = new DBReview();
        public bool License { get; set; }

        public Volunteer(int id, bool license, string username, string password, string name, string adress, string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active) : base(id, username, password, name, adress, residence, email, phonenumber, birthdate, active, geslacht)
        {
            License = license;
        }

        public void AddReaction(string name, string message, Volunteer author, DateTime date)
        {
            //string query = "INSERT INTO review(name, message, author, date) VALUES (" + name + "," + message + "," + Convert.ToString(author) + "," + Convert.ToString(date) + ")";
            //databaseR.DoQueryAddReaction(query);
        }

        public void JoinHelpRequest(string name, Volunteer author, DateTime date)
        {

        }

    }
}
