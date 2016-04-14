using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Needy : Account
    {
        public bool Ov { get; set; }

        public Needy(bool ov,string username, string password, string name, string adress, string zipcode, string residence, string email, int phonenumber, int age, bool active, string geslacht) : base(username, password, name, adress, zipcode, residence, email, phonenumber, age,active, geslacht)
        {
            this.Ov = ov;
        }

        public void AddHelpRequest(string question, string description, DateTime date, Needy author, bool urgency, bool ov)
        {
            //dit moet naar de database
            //INSERT INTO hulpvraag(question, description, date, author, urgency, ov) VALUES ( string, string, datetime, needy, bool, bool)
        }

        public void AddReview(int score, string description, Needy author)
        {
            //dit moet naar de database
            //INSERT INTO review(score, description, author) VALUES (score, string, author)
        }
    }
}
