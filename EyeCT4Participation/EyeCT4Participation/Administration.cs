using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Administration
    {
        public List<Account> listAccounts = new List<Account>();
        public List<Chat> listChats = new List<Chat>();
        public List<HelpRequest> listHelprequests = new List<HelpRequest>();
        public List<Review> listReviews = new List<Review>();
        public void AddNeedy(bool ov, string username, string password, string name, string adress, string zipcode, string residence, string email, int phonenumber, int age, string geslacht, bool active)
        {
            Needy newNeedy = new Needy(ov, username, password, name, adress, zipcode, residence, email, phonenumber, age, geslacht, active);
            listAccounts.Add(newNeedy);
        }
        public void AddVolunteer(bool licence, string username, string password, string name, string adress, string zipcode, string residence, string email, int phonenumber, int age, string geslacht, bool active)
        {
            Volunteer newVolunteer = new Volunteer(licence, username, password, name, adress, zipcode, residence, email, phonenumber, age, geslacht, active);
            listAccounts.Add(newVolunteer);
        }

        public void DeactivateAccount(Account account)
        {
            account.Active = false;
        }

        public void DeactivateChat(Chat chat)
        {
            
        }

        public void DeactivateHelpRequest(HelpRequest helprequest)
        {
            helprequest.Active = false;
        }

        public void DeactivateReview(Review review)
        {
            
        }
    }
}
