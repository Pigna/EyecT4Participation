using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    class Needy : Account
    {
        DBhelprequest databaseHR = new DBhelprequest();
        DBReview databaseR = new DBReview();

        public bool Ov { get; set; }

        public Needy(int id, bool ov, string username, string password, string name, string adress, string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active) : base(id, username, password, name, adress, residence, email, phonenumber, birthdate, active, geslacht)
        {
            this.Ov = ov;
        }

        public void AddHelpRequest(string question, DateTime date, Needy author, bool urgency, bool ov)
        {
            //dit moet naar de database
            string query = "INSERT INTO hulpvraag(question, description, date, author, urgency, ov) VALUES (" + question + ", null," + Convert.ToString(date) + "," + Convert.ToString(author) + "," + Convert.ToString(urgency) + "," + Convert.ToString(ov) + ")";
            databaseHR.AddHelpRequest(null);
        }

        public void AddReview(int score, string description, Needy author)
        {
            //dit moet naar de database
            string query = "INSERT INTO review(score, description, author) VALUES (" + Convert.ToString(score) + "," + description + "," + Convert.ToString(author) + ")";
            databaseR.DoQueryAddReview(query);
        }
    }
}
