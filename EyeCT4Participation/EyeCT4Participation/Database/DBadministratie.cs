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
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0"); //replace your query with te example query, replace 'QueryX' with a clear name.
            foreach (Dictionary<string, object> results in QueryX) //look for all posseble results in the query result.
            {
                if ((Convert.ToInt32(results["type"])) == 0)
                {
                    Account newmaManager = new Manager(Convert.ToInt32(results["id"]), Convert.ToBoolean(results["auto"]), Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]), Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),  Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]), Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]), Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                    ret.Add(newmaManager);
                }
                else if ((Convert.ToInt32(results["type"])) == 1)
                {
                    Account newNeedy = new Needy(Convert.ToInt32(results["id"]), Convert.ToBoolean(results["ovkaart"]), Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]), Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),  Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]), Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]), Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                    ret.Add(newNeedy);
                }
                else if ((Convert.ToInt32(results["type"])) == 2)
                {
                    Account newvoluenteer = new Volunteer(Convert.ToInt32(results["id"]), Convert.ToBoolean(results["auto"]), Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]), Convert.ToString(results["naam"]), Convert.ToString(results["adres"]), Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]), Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]), Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
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
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0");
            //replace your query with te example query, replace 'QueryX' with a clear name.
            List<Dictionary<string, object>> QueryY = getQuery("SELECT * FROM CHAT WHERE actief != 0");
            foreach (Dictionary<string, object> results2 in QueryY) //look for all posseble results in the query result.
            {
                Account ontvanger = null;
                Account verzender = null;

                foreach (Dictionary<string, object> results in QueryX)
                //look for all posseble results in the query result.
                {
                    if (Convert.ToInt32(results2["verzenderid"]) == Convert.ToInt32(results["ID"]))
                    {
                        if ((Convert.ToInt32(results["type"])) == 0)
                        {
                            Account newmaManager = new Manager(
                                Convert.ToInt32(results["id"]),
                                Convert.ToBoolean(results["auto"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            verzender = newmaManager;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 1)
                        {
                            Account newNeedy = new Needy(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["ovkaart"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            verzender = newNeedy;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 2)
                        {
                            Account newvoluenteer = new Volunteer(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["auto"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]), 
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            verzender = newvoluenteer;
                        }
                    }
                    if (Convert.ToInt32(results["ontvangerid"]) == Convert.ToInt32(results2["ID"]))
                    {
                        if ((Convert.ToInt32(results["type"])) == 0)
                        {
                            Account newmaManager = new Manager(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["auto"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]), 
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            ontvanger = newmaManager;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 1)
                        {
                            Account newNeedy = new Needy(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["ovkaart"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]), 
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            ontvanger = newNeedy;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 2)
                        {
                            Account newvoluenteer = new Volunteer(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["auto"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]), 
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            ontvanger = newvoluenteer;
                        }
                    }

                }

                Chat newChat = new Chat(Convert.ToInt32(results2["id"]),Convert.ToString(results2["bericht"]), Convert.ToDateTime(results2["tijdstip"]),
                    verzender, ontvanger, Convert.ToBoolean(results2["actief"]));
                ret.Add(newChat);
            }
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<HelpRequest> ListHelpRequest()
        {
            List<HelpRequest> requestslist = new List<HelpRequest>();
            Needy needyAccount = null;
            List<Volunteer> acccountList = new List<Volunteer>();
            List<Chat> ret = new List<Chat>(); //result of query will end up in here
            List<Dictionary<string, object>> Query1 = getQuery("SELECT * FROM HULPVRAAG WHERE actief != 0");
            //replace your query with te example query, replace 'QueryX' with a clear name.


            foreach (Dictionary<string, object> results in Query1) //look for all posseble results in the query result.
            {
                List<Dictionary<string, object>> Query2 = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0 AND type = 1 AND ID IN (SELECT HULPBEHOEVENDEID FROM HULPVRAAG WHERE ID = " + Convert.ToInt32(results["ID"]) + ")");
                List<Dictionary<string, object>> Query3 = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0 AND ID IN (SELECT GEBRUIKERID FROM GEBRUIKER_HULPVRAAG WHERE HULPVRAAGID = " + Convert.ToInt32(results["ID"]) + ") AND type = 2 ");
                foreach (Dictionary<string, object> volunteer in Query3)
                {
                    Volunteer newvoluenteer = new Volunteer(
                        Convert.ToInt32(volunteer["id"]), 
                        Convert.ToBoolean(volunteer["auto"]),
                        Convert.ToString(volunteer["gebruikersnaam"]), Convert.ToString(volunteer["wachtwoord"]),
                        Convert.ToString(volunteer["naam"]), Convert.ToString(volunteer["adres"]), 
                        Convert.ToString(volunteer["woonplaats"]), Convert.ToString(volunteer["email"]),
                        Convert.ToInt32(volunteer["telefoonnummer"]), Convert.ToDateTime(volunteer["geboortedatum"]),
                        Convert.ToString(volunteer["geslacht"]), Convert.ToBoolean(volunteer["actief"]));
                    acccountList.Add(newvoluenteer);
                }
                foreach (Dictionary<string, object> needyObjects in Query2)
                {
                    Needy newneedy = new Needy(
                        Convert.ToInt32(needyObjects["id"]), 
                        Convert.ToBoolean(needyObjects["ovkaart"]),
                        Convert.ToString(needyObjects["gebruikersnaam"]), Convert.ToString(needyObjects["wachtwoord"]),
                        Convert.ToString(needyObjects["naam"]), Convert.ToString(needyObjects["adres"]),
                        Convert.ToString(needyObjects["woonplaats"]), Convert.ToString(needyObjects["email"]),
                        Convert.ToInt32(needyObjects["telefoonnummer"]), Convert.ToDateTime(needyObjects["geboortedatum"]),
                        Convert.ToString(needyObjects["geslacht"]), Convert.ToBoolean(needyObjects["actief"]));
                    needyAccount = newneedy;
                }
                HelpRequest newHelpRequest = new HelpRequest(Convert.ToString(results["omschrijving"]), Convert.ToDateTime(results["startdatum"]), Convert.ToBoolean(results["urgent"]), Convert.ToBoolean(results["actief"]), needyAccount, acccountList);
                requestslist.Add((newHelpRequest));



            }


            return requestslist;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public List<Review> ListReview()
        {
            List<Review> ret = new List<Review>(); //result of query will end up in here
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0");
            //replace your query with te example query, replace 'QueryX' with a clear name.
            List<Dictionary<string, object>> QueryY = getQuery("SELECT * FROM REVIEW WHERE actief != 0");
            foreach (Dictionary<string, object> results2 in QueryY) //look for all posseble results in the query result.
            {
                Account ontvanger = null;
                Account verzender = null;
                String subreviewtxt = " ";

                foreach (Dictionary<string, object> results in QueryX)
                //look for all posseble results in the query result.
                {

                    if (Convert.ToInt32(results2["verzenderid"]) == Convert.ToInt32(results["ID"]))
                    {
                        if ((Convert.ToInt32(results["type"])) == 0)
                        {
                            Account newmaManager = new Manager(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["auto"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            verzender = newmaManager;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 1)
                        {
                            Account newNeedy = new Needy(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["ovkaart"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]), 
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            verzender = newNeedy;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 2)
                        {
                            Account newvoluenteer = new Volunteer(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["auto"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]), 
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            verzender = newvoluenteer;
                        }
                    }
                    if (Convert.ToInt32(results["ontvangerid"]) == Convert.ToInt32(results2["ID"]))
                    {
                        if ((Convert.ToInt32(results["type"])) == 0)
                        {
                            Account newmaManager = new Manager(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["auto"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]), 
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            ontvanger = newmaManager;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 1)
                        {
                            Account newNeedy = new Needy(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["ovkaart"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]), 
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            ontvanger = newNeedy;
                        }
                        else if ((Convert.ToInt32(results["type"])) == 2)
                        {
                            Account newvoluenteer = new Volunteer(
                                Convert.ToInt32(results["id"]), 
                                Convert.ToBoolean(results["auto"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]), 
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            ontvanger = newvoluenteer;
                        }
                    }

                }
                List<Dictionary<string, object>> Query8 = getQuery("SELECT * FROM REVIEW WHERE actief != 0");

                foreach (Dictionary<string, object> subreview in Query8)
                {
                    if (Convert.ToString(subreview["ID"]) == Convert.ToString(results2["reactieopid"]))
                    {
                        subreviewtxt = Convert.ToString(subreview["opmerking"]);
                    }
                }



                Review neReview = new Review(Convert.ToInt32(results2["id"]), Convert.ToInt32(results2["beoordeling"]), Convert.ToString(results2["opmerking"]), subreviewtxt, Convert.ToBoolean(results2["actief"]), Convert.ToDateTime(results2["datum"]), verzender, ontvanger);
                ret.Add(neReview);
            }
            return ret;

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
                query = "UPDATE CHAT ";
                query += "SET ACTIEF = 0 ";
                query += "WHERE TIJDSTIP = '" + chat.date + "' ";
                query += "AND VERZENDERID = (SELECT ID FROM GEBRUIKER WHERE NAAM = '" + chat.sender.Name + "') ";
                query += "AND ONTVANGERID = (SELECT ID FROM GEBRUIKER WHERE NAAM = '" + chat.receiver.Name + "') ";
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
            try
            {
                string query; // the query will end up in here
                query = "UPDATE HULPVRAAG ";
                query += "SET ACTIEF = 0 ";
                query += "WHERE STARTDATUM = '" + helprequest.Date + "' ";
                query += "AND HULPBEHOEVENDEID = (SELECT ID FROM GEBRUIKER WHERE NAAM = '" + helprequest.Needy.Name + "') ";
                query += "AND OMSCHRIJVING = '" + helprequest.Question + "' ";
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        public bool DeactivateReview(Review review)
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE REVIEW ";
                query += "SET ACTIEF = 0 ";
                query += "WHERE DATUM = '" + review.Date + "' ";
                query += "AND VERZENDERID = (SELECT ID FROM GEBRUIKER WHERE NAAM = '" + review.Volunteer.Name + "') ";
                query += "AND ONTVANGERID = (SELECT ID FROM GEBRUIKER WHERE NAAM = '" + review.Needy.Name + "') ";
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        public bool UpdateAccount(Account account)
        {
            return false;
        }
    }
}
