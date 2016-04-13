using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Administration
    {
        List<Account> listaccounts = new List<Account>();
        public void AddNeedy(string name, string adres, string zipcode, string residence, int phonenumber, int age, string email)
        {
            Needy newNeedy = new Needy(false, name, adres, zipcode, residence, phonenumber, age, email);
            listaccounts.Add(newNeedy);
        }
        public void AddNeedy(string name, string adres, string zipcode, string residence, int phonenumber, int age, string email, bool active)
        {
            Needy newNeedy = new Needy(false, name, adres, zipcode, residence, phonenumber, age, email, active);
            listaccounts.Add(newNeedy);
        }
        public void AddVolunteer(string name, string adres, string zipcode, string residence, int phonenumber, int age, string email)
        {
            Needy newNeedy = new Needy(false, name, adres, zipcode, residence, phonenumber, age, email);
            listaccounts.Add(newNeedy);
        }
        public void AddVolunteer(string name, string adres, string zipcode, string residence, int phonenumber, int age, string email, bool active)
        {
            Needy newNeedy = new Needy(false, name, adres, zipcode, residence, phonenumber, age, email, active);
            listaccounts.Add(newNeedy);
        }

        public void DeactivateAccount(Account account)
        {
            account.Active = false;
        }

        public void DeactivateChat(Chat chat)
        {
            chat.
        }

        public void DeactivateHelpRequest(HelpRequest helprequest)
        {
            
        }

        public void DeactivateReview(Review review)
        {
            
        }
    }
}
