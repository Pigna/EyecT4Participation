﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation.Database
{
    class DBReview : DB
    {
        public bool AddReview(Review review) // replace user with the data u want to add/ change to the table
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO REVIEW";
                query += "(ID, BEOORDELING, OPMERKING, DATUM, VERZENDERID, ONTVANGERID, HULPVRAAGID, REACTIEOPID, ACTIEF) VALUES ";
                query += "(" + review.id + ", " + review.Score + ", '" + review.Description + "', sysdate , " + review.Needy.id + ", " + review.Volunteer.id + ", " + review.hulpvraagid + ", NULL, 1)";
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        public bool DoQueryAddReaction(string query)
        {
            try
            {
                string Query;
                Query = query;
                doQuery(Query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddReaction(Review review, string message)
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO REVIEW";
                query += "(ID, BEOORDELING, OPMERKING, DATUM, VERZENDERID, ONTVANGERID, HULPVRAAGID, REACTIEOPID, ACTIEF) VALUES ";
                query += "(" + review.id + ", 0, '" + message + "', sysdate , " + review.Volunteer.id + ", " + review.Needy.id + ", " + review.hulpvraagid + ", " + review.id + ", 1)";
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
        public List<Review> GetReview(Volunteer volunteer)
        {
            List<Review> ret = new List<Review>(); //result of query will end up in here
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM GEBRUIKER WHERE actief != 0");
            //replace your query with te example query, replace 'QueryX' with a clear name.
            List<Dictionary<string, object>> QueryY = getQuery("SELECT * FROM REVIEW WHERE actief != 0 AND ontvangerid = " + volunteer.id);
            foreach (Dictionary<string, object> results2 in QueryY) //look for all posseble results in the query result.
            {
                Account ontvanger = null;
                Account verzender = null;
                String subreviewtxt = " ";

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
                    if (Convert.ToInt32(results["id"]) == Convert.ToInt32(results2["ontvangerid"]))
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
                List<Dictionary<string, object>> Query8 = getQuery("SELECT * FROM REVIEW WHERE actief != 0");

                foreach (Dictionary<string, object> subreview in Query8)
                {
                    if (Convert.ToString(subreview["id"]) == Convert.ToString(results2["reactieopid"]))
                    {
                        subreviewtxt = Convert.ToString(subreview["opmerking"]);
                    }
                }



                Review neReview = new Review(
                    Convert.ToInt32(results2["id"]), 
                    Convert.ToInt32(results2["beoordeling"]), 
                    Convert.ToString(results2["opmerking"]), 
                    subreviewtxt, 
                    Convert.ToBoolean(results2["actief"]), 
                    Convert.ToDateTime(results2["datum"]), 
                    verzender, 
                    ontvanger,
                    Convert.ToInt32(results2["hulpvraagid"])
                    );
                ret.Add(neReview);
            }
            return ret;
        }
    }
}
