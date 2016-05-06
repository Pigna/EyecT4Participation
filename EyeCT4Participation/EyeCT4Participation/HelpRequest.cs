using System;
using System.Collections.Generic;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    internal class HelpRequest
    {
        private readonly DBhelprequest dbHelprequest = new DBhelprequest();
        public List<Volunteer> ListVolunteers = new List<Volunteer>();

        public HelpRequest(int id, string question, DateTime date, bool urgency, bool active, Needy needy,
            List<Volunteer> ListVolunteers)
        {
            this.id = id;
            Question = question;
            Date = date;
            Urgency = urgency;
            Active = active;
            Needy = needy;
            foreach (var volunteer in ListVolunteers)
            {
                AddVolunteer(volunteer);
            }
        }

        public HelpRequest(int id, string question, DateTime date, bool urgency, bool active, Needy needy)
        {
            this.id = id;
            Question = question;
            Date = date;
            Urgency = urgency;
            Active = active;
            Needy = needy;
        }

        public string Question { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Urgency { get; set; }

        public bool Active { get; set; }
        public Needy Needy { get; set; }
        public int id { get; private set; }
        /// <summary>
        /// Vrijwilliger toevoegen
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public bool AddVolunteer(Volunteer volunteer)
        {
            if (!ListVolunteers.Contains(volunteer))
            {
                ListVolunteers.Add(volunteer);
                if (dbHelprequest.JoinHelprequest(this, volunteer))
                {
                    return true;
                }
            }
            return false;
        }

        public void RapportHelprequest(HelpRequest helprequest, Volunteer volunteer)
        {
            //???
        }

        public override string ToString()
        {
            var volunteers = "";
            foreach (var volunteer in ListVolunteers)
            {
                volunteers += volunteer.Name + ", ";
            }
            return
                "" + Needy.Name + "; " +
                "Vraag: " + Question + "; " +
                "Datum: " + Date + "; " +
                "Vrijwilligers: " + volunteers + "; ";
        }
    }
}