using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    class Administration
    {
        public List<Account> listAccounts = new List<Account>();
        public List<Chat> listChats = new List<Chat>();
        public List<HelpRequest> listHelprequests = new List<HelpRequest>();
        public List<Review> listReviews = new List<Review>();
        private DBadministratie dbadministration = new DBadministratie();
        public Account LoggedinUser;

        public void ListRefresh()
        {
            ListAccount();
            ListChat();
            ListHelpRequest();
            ListReview();
        }
        public void AddNeedy(bool ov, string username, string password, string name, string adress, string zipcode, string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active)
        {
            Needy newNeedy = new Needy(ov, username, password, name, adress, zipcode, residence, email, phonenumber, birthdate, geslacht, active);
            listAccounts.Add(newNeedy);
        }
        public void AddVolunteer(bool licence, string username, string password, string name, string adress, string zipcode, string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active)
        {
            Volunteer newVolunteer = new Volunteer(licence, username, password, name, adress, zipcode, residence, email, phonenumber, birthdate, geslacht, active);
            listAccounts.Add(newVolunteer);
        }
        public void ListAccount()
        {
            listAccounts.Clear();
            listAccounts = dbadministration.ListAccount();
        }

        public void ListChat()
        {
            listChats.Clear();
            listChats = dbadministration.ListChat();
        }
        public void ListHelpRequest()
        {
            listHelprequests.Clear();
            listHelprequests = dbadministration.ListHelpRequest();
        }

        public void ListReview()
        {
            listReviews.Clear();
            listReviews = dbadministration.ListReview();
        }

        public List<Account> ListFilterAccount(List<string> filter)
        {
            List<Account> filterlist = new List<Account>();
            foreach (string filterstring in filter)
            {
                foreach (Account account in listAccounts)
                {
                    if (account.Name == filterstring)
                    {
                        filterlist.Add(account);
                    }
                }
            }
            return filterlist;
        }
        public void DeactivateAccount(Account account)
        {
            account.Active = false;
            dbadministration.DeactivateAccount(account);
        }

        public void DeactivateChat(Chat chat)
        {
            dbadministration.DeactivateChat(chat);
        }

        public void DeactivateHelpRequest(HelpRequest helprequest)
        {
            helprequest.Active = false;
            dbadministration.DeactivateHelpRequest(helprequest);
        }

        public void DeactivateReview(Review review)
        {
            
            dbadministration.DeactivateReview(review);
        }

        public bool LoginUser(string username, string password)
        {
            //if db rturn = user
            //db return user
            //insert user in -> administration.LoggedinUser
            //true
            //else
            //return false
            return false;
        }
    }
}
