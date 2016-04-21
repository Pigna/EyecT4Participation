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
          
            List<Account> ret = new List<Account>(); //result of query will end up in here
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM GEBRUIKER"); //replace your query with te example query, replace 'QueryX' with a clear name.
            foreach (Dictionary<string, object> results in QueryX) //look for all posseble results in the query result.
            {
                if ((Convert.ToInt32(results["TYPE"])) == 0)
                {
                    Account newmaManager = new Manager(Convert.ToBoolean(results["GEBRUIKERSNAAM"]), Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]), Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]),null, Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]), Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]), Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                }
                else if ((Convert.ToInt32(results["type"])) == 1)
                {
                    Account newNeedy = new Needy(Convert.ToBoolean(results[""]), Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]), Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null, Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]), Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]), Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                }
                else if ((Convert.ToInt32(results["type"])) == 2)
                {
                    Account newvoluenteer = new Volunteer(Convert.ToBoolean(results["AUTO"]), Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]), Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null , Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]), Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]), Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                }

              //  ret.Add(); 
            }
            //(Convert.ToString(results["naam"]

            return ret;      //this will return the list as result from the query.
       
           
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
