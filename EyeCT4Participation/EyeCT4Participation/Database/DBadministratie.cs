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
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE ACTIEF != 0"); //replace your query with te example query, replace 'QueryX' with a clear name.
            foreach (Dictionary<string, object> results in QueryX) //look for all posseble results in the query result.
            {
                if ((Convert.ToInt32(results["TYPE"])) == 0)
                {
                    Account newmaManager = new Manager(Convert.ToBoolean(results["GEBRUIKERSNAAM"]), Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]), Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]),null, Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]), Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]), Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                    ret.Add(newmaManager);
                }
                else if ((Convert.ToInt32(results["type"])) == 1)
                {
                    Account newNeedy = new Needy(Convert.ToBoolean(results[""]), Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]), Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null, Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]), Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]), Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                    ret.Add(newNeedy);
                }
                else if ((Convert.ToInt32(results["type"])) == 2)
                {
                    Account newvoluenteer = new Volunteer(Convert.ToBoolean(results["AUTO"]), Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]), Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null , Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]), Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]), Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                    ret.Add((newvoluenteer));
                }

              //  ret.Add(); 
            }
            //(Convert.ToString(results["naam"]

            return ret;      //this will return the list as result from the query.
       
           
        }

        public List<Chat> ListChat()
        {
            List<Chat> ret = new List<Chat>(); //result of query will end up in here
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM CHAT WHERE ACTIEF != 0");
                //replace your query with te example query, replace 'QueryX' with a clear name.
            List<Dictionary<string, object>> QueryY = getQuery("SELECT * FROM CHAT WHERE ACTIEF != 0");
            foreach (Dictionary<string, object> results in QueryX) //look for all posseble results in the query result.
            {
                Account ontvanger = null;
                Account verzender = null;

                foreach (Dictionary<string, object> results2 in QueryY)
                    //look for all posseble results in the query result.
                {
                    if (Convert.ToInt32(results["VERZENDERID"]) == Convert.ToInt32(results2["ID"]))
                    {
                        if ((Convert.ToInt32(results["TYPE"])) == 0)
                        {
                            Account newmaManager = new Manager(Convert.ToBoolean(results["GEBRUIKERSNAAM"]),
                                Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]),
                                Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null,
                                Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]),
                                Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]),
                                Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                            verzender = newmaManager;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 1)
                        {
                            Account newNeedy = new Needy(Convert.ToBoolean(results[""]),
                                Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]),
                                Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null,
                                Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]),
                                Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]),
                                Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                            verzender = newNeedy;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 2)
                        {
                            Account newvoluenteer = new Volunteer(Convert.ToBoolean(results["AUTO"]),
                                Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]),
                                Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null,
                                Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]),
                                Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]),
                                Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                            verzender = newvoluenteer;
                        }
                    }
                    if (Convert.ToInt32(results["ONTVANGERID"]) == Convert.ToInt32(results2["ID"]))
                    {
                        if ((Convert.ToInt32(results["TYPE"])) == 0)
                        {
                            Account newmaManager = new Manager(Convert.ToBoolean(results["GEBRUIKERSNAAM"]),
                                Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]),
                                Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null,
                                Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]),
                                Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]),
                                Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                            ontvanger = newmaManager;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 1)
                        {
                            Account newNeedy = new Needy(Convert.ToBoolean(results[""]),
                                Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]),
                                Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null,
                                Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]),
                                Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]),
                                Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                            ontvanger = newNeedy;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 2)
                        {
                            Account newvoluenteer = new Volunteer(Convert.ToBoolean(results["AUTO"]),
                                Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]),
                                Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null,
                                Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]),
                                Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]),
                                Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                            ontvanger = newvoluenteer;
                        }
                    }

                }

                Chat newChat = new Chat(Convert.ToString(results["BERICHT"]), Convert.ToDateTime(results["TIJDSTIP"]),
                    verzender, ontvanger, Convert.ToBoolean(results["ACTIEF"]));
                ret.Add(newChat);
            }
            return ret;
        }

        public List<HelpRequest> ListHelpRequest()
        {
            HelpRequest newHelpRequest = null;
            return null;


        }

        public List<Review> ListReview()
        {
            return null;
        }

        public bool DeactivateAccount(Account account)
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE GEBRUIKER SET";
                query += " ACTIEF = 0 WHERE NAAM = " + account.Username;
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        public bool DeactivateChat(Chat chat)
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE CHAT SET";
                query += " ACTIEF = 0 WHERE TIJDSTIP = " + chat.Date + " AND VERZENDERID = ";
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
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
