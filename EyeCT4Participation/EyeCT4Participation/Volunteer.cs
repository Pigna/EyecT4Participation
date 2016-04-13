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

        public Volunteer(bool rijbewijs)
        {
            Rijbewijs = rijbewijs;
        }

        public void AddReaction(string description, string message, Volunteer author, DateTime date)
        {
            
        }

    }
}
