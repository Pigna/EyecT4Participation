using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Manager : Account
    {
        public Manager(int id, string username, string password, string name, string adress, string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active) : base(id, username, password, name, adress, residence, email, phonenumber, birthdate, active, geslacht)
        {
          
        }
    }
}
