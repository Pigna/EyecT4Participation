using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Manager : Account
    {
        public Manager(bool license, string username, string password, string name, string adress, string residence, string email, int phonenumber, DateTime BIRTHDATE, string geslacht, bool active) : base(username, password, name, adress, residence, email, phonenumber, BIRTHDATE, active, geslacht)
        {
          
        }
    }
}
