using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class HelpRequest
    {
        public string Question { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Boolean Urgency { get; set; }

        public HelpRequest(string question, string description,DateTime date, bool urgency)
        {
            this.Question = question;
            this.Description = description;
            this.Date = date;
            this.Urgency = Urgency;
        }

        public HelpRequest()
        {

        }

        public void AddVolenteer(Account volenteer)
        {

        }
    }
}