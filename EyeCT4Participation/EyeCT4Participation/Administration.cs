using System;
using System.Collections.Generic;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    internal class Administration
    {
        private readonly DBaccount databaseAcc = new DBaccount();
        private readonly DBadministratie dbadministration = new DBadministratie();
        public List<Account> listAccounts = new List<Account>();
        public List<Chat> listChats = new List<Chat>();
        public List<HelpRequest> listHelprequests = new List<HelpRequest>();
        public List<Review> listReviews = new List<Review>();
        public Account LoggedinUser;

        public void ListRefresh()
        {
            ListAccount();
            ListChat();
            ListHelpRequest();
            ListReview();
        }

        public void AddNeedy(int id, bool ov, string username, string password, string name, string adress,
            string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active)
        {
            var newNeedy = new Needy(id, ov, username, password, name, adress, residence, email, phonenumber, birthdate,
                geslacht, active);
            listAccounts.Add(newNeedy);
        }

        public void AddVolunteer(int id, bool licence, string username, string password, string name, string adress,
            string residence, string email, int phonenumber, DateTime birthdate, string geslacht, bool active)
        {
            var newVolunteer = new Volunteer(id, licence, username, password, name, adress, residence, email,
                phonenumber, birthdate, geslacht, active);
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
            var filterlist = new List<Account>();
            foreach (var filterstring in filter)
            {
                foreach (var account in listAccounts)
                {
                    if (account.Name == filterstring)
                    {
                        filterlist.Add(account);
                    }
                }
            }
            return filterlist;
        }

        public bool DeactivateAccount(Account account)
        {
            account.Active = false;
            return dbadministration.DeactivateAccount(account);
        }

        public bool DeactivateChat(Chat chat)
        {
            chat.active = false;
            return dbadministration.DeactivateChat(chat);
        }

        public bool DeactivateHelpRequest(HelpRequest helprequest)
        {
            helprequest.Active = false;
            return dbadministration.DeactivateHelpRequest(helprequest);
        }

        public bool DeactivateReview(Review review)
        {
            review.Active = false;
            return dbadministration.DeactivateReview(review);
        }

        public bool LoginUser(string username, string password)
        {
            var loginAccount = databaseAcc.GetQueryLogIn(username, password);

            if (loginAccount != null)
            {
                LoggedinUser = loginAccount;
                return true;
            }
            return false;
        }

        //return false
        //else
        //true
        //insert user in -> administration.LoggedinUser
        //db return user
        //if db rturn = user
    }
}