using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Volunteer : Account
    {
        public bool Rijbewijs { get; set; }

        public Volunteer(bool rijbewijs,string username, string password, string name, string adress, string zipcode, string residence, string email, int phonenumber, int age, bool active, string geslacht) : base(username, password, name, adress, zipcode, residence, email, phonenumber, age,active, geslacht)
        {
            Rijbewijs = rijbewijs;
        }

        public void AddReaction(string description, string message, Volunteer author, DateTime date)
        {
            
        }

    }
}
