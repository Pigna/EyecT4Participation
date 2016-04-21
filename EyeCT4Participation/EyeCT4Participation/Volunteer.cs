using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Volunteer : Account
    {
        public bool License { get; set; }

        public Volunteer(bool license, string username, string password, string name, string adress, string zipcode, string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active) : base(username, password, name, adress, zipcode, residence, email, phonenumber, birthdate, active, geslacht)
        {
            License = license;
        }

        public void AddReaction(string description, string message, Volunteer author, DateTime date)
        {
            
        }

        public void JoinHelpRequest()
        {

        }

    }
}
