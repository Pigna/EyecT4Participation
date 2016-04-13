using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
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

        public bool Active { get; set; }

        public HelpRequest(string question, string description, DateTime date, bool urgency, bool active)
        {
            this.Question = question;
            this.Description = description;
            this.Date = date;
            this.Urgency = urgency;
            this.Active = active;
        }

        public HelpRequest()
        {

        }

        public void AddVolunteer(Account volunteer)
        {

        }
    }
}