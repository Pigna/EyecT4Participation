using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Volunteer : Account
    {
        public bool rijbewijs { get; set; }

        public Volunteer(bool rbws)
        {
            rijbewijs = rbws;
        }

        public void AddReaction(string description, string message, Volunteer author)
        {
            //Functie AddReaction
        }

    }
}
