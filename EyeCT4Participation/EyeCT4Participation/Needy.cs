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
        DBhelprequest dbHelprequest = new DBhelprequest();
        DBReview dbReview = new DBReview();

        public bool Ov { get; set; }

        public Needy(int id, bool ov, string username, string password, string name, string adress, string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active) : base(id, username, password, name, adress, residence, email, phonenumber, birthdate, active, geslacht)
        {
            this.Ov = ov;
        }

        public bool AddHelpRequest(string question, string locatie, DateTime startdate, DateTime endatdate, bool urgency, int amountVolunteers)
        {
            //dit moet naar de database
            HelpRequest newHelpRequest = new HelpRequest(dbHelprequest.getLatestId("Hulpvraag"), question, startdate, urgency, true, this, new List<Volunteer>());
            return dbHelprequest.AddHelpRequest(newHelpRequest);
        }

        public bool AddReview(int score, string description, Volunteer reciever, HelpRequest helprequest)
        {
            //dit moet naar de database
            Review newReview = new Review(dbReview.getLatestId("Review"), score, description,"",true,DateTime.Now, this,reciever,helprequest.id);
            return dbReview.AddReview(newReview);
        }
    }
}
