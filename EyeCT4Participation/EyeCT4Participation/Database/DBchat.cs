using System;
using System.Collections.Generic;

namespace EyeCT4Participation.Database
{
    internal class DBchat : DB
    {
        public List<Chat> Conversation(Account x, Account y) //name of ur query
        {
            
            var QueryY =
                getQuery("SELECT * FROM CHAT WHERE (verzenderid = " + x.id + " AND ontvangerid = " + y.id +
                         ") OR (verzenderid =  " + y.id + " AND ontvangerid =  " + x.id + ") AND actief = 1 ORDER BY id");
                //replace your query with te example query, replace 'QueryX' with a clear name.
            var ret = new List<Chat>(); //result of query will end up in here
            var QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0");
            foreach (var results2 in QueryY) //look for all posseble results in the query result.
            {
                Account ontvanger = null;
                Account verzender = null;

                foreach (var results in QueryX)
                    //look for all posseble results in the query result.
                {
                    if (Convert.ToInt32(results2["verzenderid"]) == Convert.ToInt32(results["id"]))
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

        public List<Account> ListConversationVolunteers(Needy needy)
        {
            var QueryY =
                getQuery(
                    "SELECT * FROM Gebruiker gb WHERE gb.id IN (SELECT gebruikerid FROM gebruiker_hulpvraag gh JOIN hulpvraag ON gh.hulpvraagid = hulpvraag.id WHERE hulpbehoevendeid = " +
                    needy.id + ")"); //replace your query with te example query, replace 'QueryX' with a clear name.
            var ret = new List<Account>(); //result of query will end up in here
            foreach (var results in QueryY) //look for all posseble results in the query result.
            {
                Account account = null;
                if (Convert.ToInt32(results["type"]) == 0)
                {
                    Account newmaManager = new Manager(
                        Convert.ToInt32(results["id"]),
                        Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                        Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                        Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                        Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                        Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                    account = newmaManager;
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
                    account = newNeedy;
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
                    account = newvoluenteer;
                }
                ret.Add(account);
            }
            return ret;
        }

        public List<Account> ListConversationNeedys(Volunteer volunteer)
        {
            var QueryY =
                getQuery(
                    "SELECT * FROM Gebruiker gb WHERE gb.id IN ( SELECT hulpbehoevendeid FROM gebruiker_hulpvraag gh JOIN hulpvraag ON gh.hulpvraagid = hulpvraag.id WHERE gebruikerid = " +
                    volunteer.id + ")"); //replace your query with te example query, replace 'QueryX' with a clear name.
            var ret = new List<Account>(); //result of query will end up in here
            foreach (var results in QueryY) //look for all posseble results in the query result.
            {
                Account account = null;
                if (Convert.ToInt32(results["type"]) == 0)
                {
                    Account newmaManager = new Manager(
                        Convert.ToInt32(results["id"]),
                        Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                        Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                        Convert.ToString(results["woonplaats"]), Convert.ToString(results["email"]),
                        Convert.ToInt32(results["telefoonnummer"]), Convert.ToDateTime(results["geboortedatum"]),
                        Convert.ToString(results["geslacht"]), Convert.ToBoolean(results["actief"]));
                    account = newmaManager;
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
                    account = newNeedy;
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
                    account = newvoluenteer;
                }
                ret.Add(account);
            }
            return ret;
        }

        public bool SendMessage(Chat chat)
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO CHAT (ID, BERICHT, TIJDSTIP, VERZENDERID, ONTVANGERID, ACTIEF) VALUES ";
                query += "(" + chat.id + ", '" + chat.message + "', TO_DATE('" + chat.date.ToString("MM-dd-yyyy") +
                         "', 'MM-DD-YYYY'), '" + chat.sender.id + "', '" + chat.receiver.id + "', 1)";
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false; // if query fails, return a false.
            }
        }

        public void ReportChat(Account selAccount, Account curAccount)
        {
            throw new NotImplementedException();
        }
    }
}