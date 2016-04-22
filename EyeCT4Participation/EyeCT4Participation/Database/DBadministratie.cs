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
                    Account newmaManager = new Manager(Convert.ToBoolean(results["GEBRUIKERSNAAM"]), Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]), Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null, Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]), Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]), Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                    ret.Add(newmaManager);
                }
                else if ((Convert.ToInt32(results["type"])) == 1)
                {
                    Account newNeedy = new Needy(Convert.ToBoolean(results[""]), Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]), Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null, Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]), Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]), Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
                    ret.Add(newNeedy);
                }
                else if ((Convert.ToInt32(results["type"])) == 2)
                {
                    Account newvoluenteer = new Volunteer(Convert.ToBoolean(results["AUTO"]), Convert.ToString(results["GEBRUIKERSNAAM"]), Convert.ToString(results["WACHTWOORD"]), Convert.ToString(results["NAAM"]), Convert.ToString(results["ADRES"]), null, Convert.ToString(results["WOONPLAATS"]), Convert.ToString(results["EMAIL"]), Convert.ToInt32(results["TELEFOONNUMMER"]), Convert.ToDateTime(results["GEBOORTEDATUM"]), Convert.ToString(results["GESLACHT"]), Convert.ToBoolean(results["ACTIEF"]));
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
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE ACTIEF != 0");
            //replace your query with te example query, replace 'QueryX' with a clear name.
            List<Dictionary<string, object>> QueryY = getQuery("SELECT * FROM CHAT WHERE ACTIEF != 0");
            foreach (Dictionary<string, object> results2 in QueryY) //look for all posseble results in the query result.
            {
                Account ontvanger = null;
                Account verzender = null;

                foreach (Dictionary<string, object> results in QueryX)
                //look for all posseble results in the query result.
                {
                    if (Convert.ToInt32(results2["VERZENDERID"]) == Convert.ToInt32(results["ID"]))
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

                Chat newChat = new Chat(Convert.ToString(results2["BERICHT"]), Convert.ToDateTime(results2["TIJDSTIP"]),
                    verzender, ontvanger, Convert.ToBoolean(results2["ACTIEF"]));
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
            List<HelpRequest> requestslist = null;
            Needy needyAccount = null;
            List<Volunteer> acccountList = new List<Volunteer>();
            List<Chat> ret = new List<Chat>(); //result of query will end up in here
            List<Dictionary<string, object>> Query1 = getQuery("SELECT * FROM HULPVRAAG WHERE ACTIEF != 0");
            //replace your query with te example query, replace 'QueryX' with a clear name.


            foreach (Dictionary<string, object> results in Query1) //look for all posseble results in the query result.
            {
                List<Dictionary<string, object>> Query2 = getQuery("SELECT * FROM GEBRUIKER WHERE ACTIEF != 0 AND TYPE = 1 AND ID IN (SELECT HULPBEHOEVENDEID FROM HULPVRAAG WHERE ID = " + Convert.ToInt32(results["ID"]) + ")");
                List<Dictionary<string, object>> Query3 = getQuery("SELECT * FROM GEBRUIKER WHERE ACTIEF != 0 AND ID IN (SELECT GEBRUIKERID FROM GEBRUIKER_HULPVRAAG WHERE HULPVRAAGID = " + Convert.ToInt32(results["ID"]) + ") AND TYPE = 2 ");
                foreach (Dictionary<string, object> volunteer in Query3)
                {
                    Volunteer newvoluenteer = new Volunteer(Convert.ToBoolean(volunteer["AUTO"]),
                                Convert.ToString(volunteer["GEBRUIKERSNAAM"]), Convert.ToString(volunteer["WACHTWOORD"]),
                                Convert.ToString(volunteer["NAAM"]), Convert.ToString(volunteer["ADRES"]), null,
                                Convert.ToString(volunteer["WOONPLAATS"]), Convert.ToString(volunteer["EMAIL"]),
                                Convert.ToInt32(volunteer["TELEFOONNUMMER"]), Convert.ToDateTime(volunteer["GEBOORTEDATUM"]),
                                Convert.ToString(volunteer["GESLACHT"]), Convert.ToBoolean(volunteer["ACTIEF"]));
                    acccountList.Add(newvoluenteer);
                }
                foreach (Dictionary<string, object> needyObjects in Query2)
                {
                    Needy newneedy = new Needy(Convert.ToBoolean(needyObjects["OVKAART"]),
                                  Convert.ToString(needyObjects["GEBRUIKERSNAAM"]), Convert.ToString(needyObjects["WACHTWOORD"]),
                                  Convert.ToString(needyObjects["NAAM"]), Convert.ToString(needyObjects["ADRES"]), null,
                                  Convert.ToString(needyObjects["WOONPLAATS"]), Convert.ToString(needyObjects["EMAIL"]),
                                  Convert.ToInt32(needyObjects["TELEFOONNUMMER"]), Convert.ToDateTime(needyObjects["GEBOORTEDATUM"]),
                                  Convert.ToString(needyObjects["GESLACHT"]), Convert.ToBoolean(needyObjects["ACTIEF"]));
                    needyAccount = newneedy;
                }
                HelpRequest newHelpRequest = new HelpRequest(Convert.ToString(results["OMSCHRIJVING"]), null, Convert.ToDateTime(results["STARTDATUM"]), Convert.ToBoolean(results["urgent"]), Convert.ToBoolean(results["ACTIEF"]), needyAccount, acccountList);
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
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE ACTIEF != 0");
            //replace your query with te example query, replace 'QueryX' with a clear name.
            List<Dictionary<string, object>> QueryY = getQuery("SELECT * FROM REVIEW WHERE ACTIEF != 0");
            foreach (Dictionary<string, object> results2 in QueryY) //look for all posseble results in the query result.
            {
                Account ontvanger = null;
                Account verzender = null;
                String subreviewtxt = " ";

                foreach (Dictionary<string, object> results in QueryX)
                //look for all posseble results in the query result.
                {

                    if (Convert.ToInt32(results2["VERZENDERID"]) == Convert.ToInt32(results["ID"]))
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
                List<Dictionary<string, object>> Query8 = getQuery("SELECT * FROM REVIEW WHERE ACTIEF != 0");

                foreach (Dictionary<string, object> subreview in Query8)
                {
                    if (Convert.ToString(subreview["ID"]) == Convert.ToString(results2["REACTIEOPID"]))
                    {
                        subreviewtxt = Convert.ToString(subreview["OPMERKING"]);
                    }
                }



                Review neReview = new Review(Convert.ToInt32(results2["BEOORDELING"]), Convert.ToString(results2["OPMERKING"]), subreviewtxt, Convert.ToBoolean(results2["ACTIEF"]));
                ret.Add(neReview);
            }
            return ret;

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
