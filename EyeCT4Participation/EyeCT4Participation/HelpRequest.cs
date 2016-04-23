﻿using System;
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
        public Needy Needy { get; set; }
        public int id { get; private set; }
        public List<Volunteer> ListVolunteers = new List<Volunteer>();

        public HelpRequest(int id, string question, DateTime date, bool urgency, bool active, Needy needy, List<Volunteer> ListVolunteers)
        {
            this.id = id;
            this.Question = question;
            this.Date = date;
            this.Urgency = urgency;
            this.Active = active;
            this.Needy = needy;
            foreach (Volunteer volunteer in ListVolunteers)
            {
                AddVolunteer(volunteer);
            }
        }
        public HelpRequest(int id, string question, DateTime date, bool urgency, bool active, Needy needy)
        {
            this.id = id;
            this.Question = question;
            this.Date = date;
            this.Urgency = urgency;
            this.Active = active;
            this.Needy = needy;
          
        }

        public void AddVolunteer(Volunteer volunteer)
        {
            ListVolunteers.Add(volunteer);
        }
    }
}