using System;
using System.Collections.Generic;
using System.Linq;

namespace EyeCT4Participation.Database
{
    internal class DBaccount : DB
    {
        public Account GetQueryLogIn(string username, string password) //name of ur query
        {
            Account retAccount = null;
            var ret = new List<string>(); //result of query will end up in here
            var LogInQuery =
                getQuery("SELECT * FROM Gebruiker WHERE Gebruikersnaam = '" + username + "' AND Wachtwoord ='" + password + "' AND actief = 1");
                //replace your query with te example query, replace 'QueryX' with a clear name.
            if (LogInQuery.Any())
            {
                foreach (var results in LogInQuery)
                    //look for all posseble results in the query result.
                {
                    //add each result to the created list, if the list if for a class, u need to add 'new class_name' 
                    var returnvalue = Convert.ToInt32(results["type"]);

                    if (returnvalue == 0)
                    {
                        retAccount = new Manager(
                            Convert.ToInt32(results["id"]),
                            Convert.ToString(results["gebruikersnaam"]),
                            Convert.ToString(results["wachtwoord"]),
                            Convert.ToString(results["naam"]),
                            Convert.ToString(results["adres"]),
                            Convert.ToString(results["woonplaats"]),
                            Convert.ToString(results["email"]),
                            Convert.ToInt32(results["telefoonnummer"]),
                            Convert.ToDateTime(results["geboortedatum"]),
                            Convert.ToString(results["geslacht"]),
                            Convert.ToBoolean(results["actief"]));
                    }
                    else if (returnvalue == 1)
                    {
                        retAccount = new Needy(
                            Convert.ToInt32(results["id"]),
                            Convert.ToBoolean(results["ovkaart"]),
                            Convert.ToString(results["gebruikersnaam"]),
                            Convert.ToString(results["wachtwoord"]),
                            Convert.ToString(results["naam"]),
                            Convert.ToString(results["adres"]),
                            Convert.ToString(results["woonplaats"]),
                            Convert.ToString(results["email"]),
                            Convert.ToInt32(results["telefoonnummer"]),
                            Convert.ToDateTime(results["geboortedatum"]),
                            Convert.ToString(results["geslacht"]),
                            Convert.ToBoolean(results["actief"]));
                    }
                    else if (returnvalue == 2)
                    {
                        retAccount = new Volunteer(
                            Convert.ToInt32(results["id"]),
                            Convert.ToBoolean(results["auto"]),
                            Convert.ToString(results["gebruikersnaam"]),
                            Convert.ToString(results["wachtwoord"]),
                            Convert.ToString(results["naam"]),
                            Convert.ToString(results["adres"]),
                            Convert.ToString(results["woonplaats"]),
                            Convert.ToString(results["email"]),
                            Convert.ToInt32(results["telefoonnummer"]),
                            Convert.ToDateTime(results["geboortedatum"]),
                            Convert.ToString(results["geslacht"]),
                            Convert.ToBoolean(results["actief"]));
                    }
                }

                return retAccount; //this will return the list as result from the query.
            }
            return null;
        }

        public bool NewAccount(string gebruikersnaam, string wachtwoord, string naam, string adres, string woonplaats,
            string email, DateTime geboortedatum, int telefoonnummer, int type, int geslacht, int auto, int actief,
            int ov) // replace user with the data u want to add/ change to the table
        {
            var returnID = getLatestId("gebruiker");

            try
            {
                string query; // the query will end up in here

                query =
                    "INSERT INTO GEBRUIKER (ID, NAAM, GEBRUIKERSNAAM, WACHTWOORD, EMAIL, GEBOORTEDATUM, ADRES, WOONPLAATS, TELEFOONNUMMER, AUTO, ACTIEF, TYPE, FOTO, OVKAART, GESLACHT) VALUES ";
                query += "(" + returnID + ",'" + naam + "','" + gebruikersnaam + "','" + wachtwoord + "','" + email +
                         "',to_date('" + geboortedatum.ToString("MM-dd-yyyy hh:mm") + "','MM-DD-YYYY hh24:MI'),'" +
                         adres + "','" + woonplaats + "'," + telefoonnummer + "," + auto + "," + actief + "," + type +
                         ", NULL ," + ov + ", " + geslacht + ")"; //replace with INSERT if needed
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false; // if query fails, return a false.
            }
        }
    }
}