using System;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    internal class Review
    {
        private readonly DBReview dbReview = new DBReview();

        public Review(int id, int score, string description, string reaction, bool active, DateTime date, Account needy,
            Account volunteer, int hulpvraagid)
        {
            this.id = id;
            Score = score;
            Description = description;
            Reaction = reaction;
            Active = active;
            Date = date;
            Needy = needy;
            Volunteer = volunteer;
            this.hulpvraagid = hulpvraagid;
        }

        public int Score { get; set; }
        public string Description { get; set; }
        public string Reaction { get; set; }
        public bool Active { get; set; }
        public DateTime Date { get; set; }
        public Account Needy { get; set; }
        public Account Volunteer { get; set; }
        public int id { get; private set; }
        public int hulpvraagid { get; private set; }


        public bool AddReaction(string message)
        {
            return dbReview.AddReaction(this, message);
        }

        public override string ToString()
        {
            return
                "" + Date + "; " +
                "Hulpbehoevende: " + Needy.Name + "; " +
                "Score: " + Score + "; " +
                "Beschrijving: " + Description + "; " +
                "Score: " + Score + "; ";
        }
    }
}