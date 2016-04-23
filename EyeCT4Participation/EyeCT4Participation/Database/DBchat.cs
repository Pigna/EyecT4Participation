﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation.Database
{
    class DBchat : DB
    {
        public List<Chat> Conversation(Account x, Account y) //name of ur query
        {
            List<Dictionary<string, object>> QueryY = getQuery("SELECT * FROM CHAT WHERE (verzenderid = " + x.id + " AND ontvangerid = " + y.id + ") OR (verzenderid =  " + y.id + " AND ontvangerid =  " + x.id + ") AND actief = 1 ORDER BY tijdstip;"); //replace your query with te example query, replace 'QueryX' with a clear name.
            List<Chat> ret = new List<Chat>(); //result of query will end up in here
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0");
            foreach (Dictionary<string, object> results2 in QueryY) //look for all posseble results in the query result.
            {
                Account ontvanger = null;
                Account verzender = null;

                foreach (Dictionary<string, object> results in QueryX)
                //look for all posseble results in the query result.
                {
                    if (Convert.ToInt32(results2["verzenderid"]) == Convert.ToInt32(results["id"]))
                    {
                        if ((Convert.ToInt32(results["type"])) == 0)
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
                    if (Convert.ToInt32(results["ontvangerid"]) == Convert.ToInt32(results2["id"]))
                    {
                        if ((Convert.ToInt32(results["type"])) == 0)
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

                Chat newChat = new Chat(Convert.ToInt32(results2["id"]), Convert.ToString(results2["bericht"]), Convert.ToDateTime(results2["tijdstip"]),
                    verzender, ontvanger, Convert.ToBoolean(results2["actief"]));
                ret.Add(newChat);
            }
            return ret;
        }
    }
}
