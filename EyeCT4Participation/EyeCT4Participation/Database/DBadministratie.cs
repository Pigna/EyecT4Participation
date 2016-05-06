using System;
using System.Collections.Generic;

namespace EyeCT4Participation.Database
{
    internal class DBadministratie : DB
    {
        public List<Account> ListAccount()
        {
            var ret = new List<Account>(); //result of query will end up in here
            var QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0");
                //replace your query with te example query, replace 'QueryX' with a clear name.
            foreach (var results in QueryX) //look for all posseble results in the query result.
            {
                if (Convert.ToInt32(results["type"]) == 0)
                {
                    Account newmaManager = new Manager(Convert.ToInt32(results["id"]),
                        Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                        Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                        Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                        Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                        Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                    ret.Add(newmaManager);
                }
                else if (Convert.ToInt32(results["type"]) == 1)
                {
                    Account newNeedy = new Needy(Convert.ToInt32(results["id"]), Convert.ToBoolean(results["ovkaart"]),
                        Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                        Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                        Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                        Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                        Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                    ret.Add(newNeedy);
                }
                else if (Convert.ToInt32(results["type"]) == 2)
                {
                    Account newvoluenteer = new Volunteer(Convert.ToInt32(results["id"]),
                        Convert.ToBoolean(results["auto"]), Convert.ToString(results["gebruikersnaam"]),
                        Convert.ToString(results["wachtwoord"]), Convert.ToString(results["naam"]),
                        Convert.ToString(results["adres"]), Convert.ToString(results["woonplaats"]),
                        Convert.ToString(results["email"]), Convert.ToInt32(results["telefoonnummer"]),
                        Convert.ToDateTime(results["geboortedatum"]), Convert.ToString(results["geslacht"]),
                        Convert.ToBoolean(results["actief"]));
                    ret.Add(newvoluenteer);
                }

                //  ret.Add(); 
            }
            //(Convert.ToString(results["naam"]

            return ret; //this will return the list as result from the query.
        }

        public List<Chat> ListChat()
        {
            var ret = new List<Chat>(); //result of query will end up in here
            var QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0");
            //replace your query with te example query, replace 'QueryX' with a clear name.
            var QueryY = getQuery("SELECT * FROM CHAT WHERE actief != 0");
            foreach (var results2 in QueryY) //look for all posseble results in the query result.
            {
                Account ontvanger = null;
                Account verzender = null;

                foreach (var results in QueryX)
                    //look for all posseble results in the query result.
                {
                    if (Convert.ToInt32(results2["ontvangerid"]) == Convert.ToInt32(results["id"]))
                    {
                        if (Convert.ToInt32(results["type"]) == 0)
                        {
                            Account newmaManager = new Manager(
                                Convert.ToInt32(results["id"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            verzender = newmaManager;
                        }
                        else if (Convert.ToInt32(results["type"]) == 1)
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
                        else if (Convert.ToInt32(results["type"]) == 2)
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
                    if (Convert.ToInt32(results["id"]) == Convert.ToInt32(results2["ontvangerid"]))
                    {
                        if (Convert.ToInt32(results["type"]) == 0)
                        {
                            Account newmaManager = new Manager(
                                Convert.ToInt32(results["id"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            ontvanger = newmaManager;
                        }
                        else if (Convert.ToInt32(results["type"]) == 1)
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
                        else if (Convert.ToInt32(results["type"]) == 2)
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

                var newChat = new Chat(Convert.ToInt32(results2["id"]), Convert.ToString(results2["bericht"]),
                    Convert.ToDateTime(results2["tijdstip"]),
                    verzender, ontvanger, Convert.ToBoolean(results2["actief"]));
                ret.Add(newChat);
            }
            return ret;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<HelpRequest> ListHelpRequest()
        {
            var requestslist = new List<HelpRequest>();//result of query will end up in here
            var Query1 = getQuery("SELECT * FROM HULPVRAAG WHERE actief != 0");
            //replace your query with te example query, replace 'QueryX' with a clear name.


            foreach (var results in Query1) //look for all posseble results in the query result.
            {
                Needy needyAccount = null;
                var acccountList = new List<Volunteer>();
                var Query2 =
                    getQuery(
                        "SELECT * FROM GEBRUIKER WHERE actief != 0 AND type = 1 AND ID IN (SELECT HULPBEHOEVENDEID FROM HULPVRAAG WHERE ID = " +
                        Convert.ToInt32(results["id"]) + ")");
                var Query3 =
                    getQuery(
                        "SELECT * FROM GEBRUIKER WHERE actief != 0 AND ID IN (SELECT GEBRUIKERID FROM GEBRUIKER_HULPVRAAG WHERE HULPVRAAGID = " +
                        Convert.ToInt32(results["id"]) + ") AND type = 2 ");
                foreach (var volunteer in Query3)
                {
                    var newvoluenteer = new Volunteer(
                        Convert.ToInt32(volunteer["id"]),
                        Convert.ToBoolean(volunteer["auto"]),
                        Convert.ToString(volunteer["gebruikersnaam"]), Convert.ToString(volunteer["wachtwoord"]),
                        Convert.ToString(volunteer["naam"]), Convert.ToString(volunteer["adres"]),
                        Convert.ToString(volunteer["woonplaats"]), Convert.ToString(volunteer["email"]),
                        Convert.ToInt32(volunteer["telefoonnummer"]), Convert.ToDateTime(volunteer["geboortedatum"]),
                        Convert.ToString(volunteer["geslacht"]), Convert.ToBoolean(volunteer["actief"]));
                    acccountList.Add(newvoluenteer);
                }
                foreach (var needyObjects in Query2)
                {
                    var newneedy = new Needy(
                        Convert.ToInt32(needyObjects["id"]),
                        Convert.ToBoolean(needyObjects["ovkaart"]),
                        Convert.ToString(needyObjects["gebruikersnaam"]), Convert.ToString(needyObjects["wachtwoord"]),
                        Convert.ToString(needyObjects["naam"]), Convert.ToString(needyObjects["adres"]),
                        Convert.ToString(needyObjects["woonplaats"]), Convert.ToString(needyObjects["email"]),
                        Convert.ToInt32(needyObjects["telefoonnummer"]),
                        Convert.ToDateTime(needyObjects["geboortedatum"]),
                        Convert.ToString(needyObjects["geslacht"]), Convert.ToBoolean(needyObjects["actief"]));
                    needyAccount = newneedy;
                }
                var newHelpRequest = new HelpRequest(Convert.ToInt32(results["id"]),
                    Convert.ToString(results["omschrijving"]), Convert.ToDateTime(results["startdatum"]),
                    Convert.ToBoolean(results["urgent"]), Convert.ToBoolean(results["actief"]), needyAccount,
                    acccountList);
                requestslist.Add(newHelpRequest);
            }


            return requestslist;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<Review> ListReview()
        {
            var ret = new List<Review>(); //result of query will end up in here
            var QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0");
            //replace your query with te example query, replace 'QueryX' with a clear name.
            var QueryY = getQuery("SELECT * FROM REVIEW WHERE actief != 0");
            foreach (var results2 in QueryY) //look for all posseble results in the query result.
            {
                Account ontvanger = null;
                Account verzender = null;
                var subreviewtxt = " ";

                foreach (var results in QueryX)
                    //look for all posseble results in the query result.
                {
                    if (Convert.ToInt32(results2["ontvangerid"]) == Convert.ToInt32(results["id"]))
                    {
                        if (Convert.ToInt32(results["type"]) == 0)
                        {
                            Account newmaManager = new Manager(
                                Convert.ToInt32(results["id"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            verzender = newmaManager;
                        }
                        else if (Convert.ToInt32(results["type"]) == 1)
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
                        else if (Convert.ToInt32(results["type"]) == 2)
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
                    if (Convert.ToInt32(results["id"]) == Convert.ToInt32(results2["ontvangerid"]))
                    {
                        if (Convert.ToInt32(results["type"]) == 0)
                        {
                            Account newmaManager = new Manager(
                                Convert.ToInt32(results["id"]),
                                Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                                Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                                Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                                Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                                Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                            ontvanger = newmaManager;
                        }
                        else if (Convert.ToInt32(results["type"]) == 1)
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
                        else if (Convert.ToInt32(results["type"]) == 2)
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
                var Query8 = getQuery("SELECT * FROM REVIEW WHERE actief != 0");

                foreach (var subreview in Query8)
                {
                    if (Convert.ToString(subreview["id"]) == Convert.ToString(results2["reactieopid"]))
                    {
                        subreviewtxt = Convert.ToString(subreview["opmerking"]);
                    }
                }


                var neReview = new Review(Convert.ToInt32(results2["id"]), Convert.ToInt32(results2["beoordeling"]),
                    Convert.ToString(results2["opmerking"]), subreviewtxt, Convert.ToBoolean(results2["actief"]),
                    Convert.ToDateTime(results2["datum"]), verzender, ontvanger,
                    Convert.ToInt32(results2["hulpvraagid"]));
                ret.Add(neReview);
            }
            return ret;
        }

        public bool DeactivateAccount(Account account)
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE GEBRUIKER ";
                query += "SET ACTIEF = 0 ";
                query += "WHERE id = '" + account.id + "' ";
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false; // if query fails, return a false.
            }
        }

        public bool DeactivateChat(Chat chat)
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE CHAT ";
                query += "SET ACTIEF = 0 ";
                query += "WHERE id = '" + chat.id + "' ";
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false; // if query fails, return a false.
            }
        }

        public bool DeactivateHelpRequest(HelpRequest helprequest)
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE HULPVRAAG ";
                query += "SET ACTIEF = 0 ";
                query += "WHERE ID = '" + helprequest.id + "' ";
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false; // if query fails, return a false.
            }
        }

        public bool DeactivateReview(Review review)
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE REVIEW ";
                query += "SET ACTIEF = 0 ";
                query += "WHERE ID = '" + review.id + "' ";
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false; // if query fails, return a false.
            }
        }

        public bool UpdateAccount(Account account)
        {
            return false;
        }
    }
}