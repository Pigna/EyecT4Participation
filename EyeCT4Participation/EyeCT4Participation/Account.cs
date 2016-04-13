using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    abstract class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Zipcode { get; set; }
        public string Residence { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }
        public string Geslacht { get; set; }

        public Account(string username, string password, string name, string adress, string zipcode, string residence, string email, int phonenumber, int age, bool active, string geslacht)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Adress = adress;
            this.Zipcode = zipcode;
            this.Residence = residence;
            this.Email = email;
            this.PhoneNumber = phonenumber;
            this.Age = age;
            this.Active = active;
            this.Geslacht = geslacht;
        }

        public void LogIn(string username, string password)
        {
          // database.Query = "SELECT * Gebruiker WHERE username = variabele.username AND password = variabele.password"
          // if("Type" = 0)
          // {
          //   open hulpbehoevende scherm
          // }
          // else if ("Type" = 1)
          // {
          //   open vrijwilliger scherm
          // }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
