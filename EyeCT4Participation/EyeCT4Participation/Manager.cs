using System;

namespace EyeCT4Participation
{
    internal class Manager : Account
    {
        public Manager(int id, string username, string password, string name, string adress, string residence,
            string email, int phonenumber, DateTime birthdate, string geslacht, bool active)
            : base(id, username, password, name, adress, residence, email, phonenumber, birthdate, active, geslacht)
        {
        }
    }
}