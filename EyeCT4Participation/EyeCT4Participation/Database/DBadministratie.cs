using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation.Database
{
    class DBadministratie : DB
    {
        public List<Account> ListAccount()
        {
            return null;
        }

        public List<Chat> ListChat()
        {
            return null;
        }

        public List<HelpRequest> ListHelpRequest()
        {
            return null;
        }

        public List<Review> ListReview()
        {
            return null;
        }

        public bool DeactivateAccount(Account account)
        {
            return false;
        }

        public bool DeactivateChat(Chat chat)
        {
            return false;
        }

        public bool DeactivateHelpRequest(HelpRequest helprequest)
        {
            return false;
        }

        public bool DeactivateReview(Review review)
        {
            return false;
        }

        public bool UpdateAccount(Account account)
        {
            return false;
        }
    }
}
