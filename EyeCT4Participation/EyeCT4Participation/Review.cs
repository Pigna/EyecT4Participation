using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Review
    {
        public int Score { get; set; }
        public string Description { get; set; }
        public string Reaction { get; set; }
        public bool Active { get; set; }
        public DateTime Date { get; set; }
        public Account Needy { get; set; }
        public Account Volunteer { get; set; }
        public int id { get; private set; }


        public Review(int id, int score, string description, string reaction, bool active, DateTime date, Account needy, Account volunteer)
        {
            this.id = id;
            this.Score = score;
            this.Description = description;
            this.Reaction = reaction;
            this.Active = active;
            this.Date = date;
            this.Needy = needy;
            this.Volunteer = volunteer;
        }


        public void AddReaction(Account sender, string message, DateTime date)
        {

        }
    }
}