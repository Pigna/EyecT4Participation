using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation.Database
{
    class DBaccount : DB
    {
        public Account GetQueryLogIn(string username, string password) //name of ur query
        {
            Account retAccount = null;
            List<string> ret = new List<string>(); //result of query will end up in here
            List<Dictionary<string, object>> LogInQuery = getQuery("SELECT * FROM Gebruiker WHERE Gebruikersnaam = '" + username + "' AND Wachtwoord ='" + password + "'"); //replace your query with te example query, replace 'QueryX' with a clear name.
            if (LogInQuery.Any())
            {


                foreach (Dictionary<string, object> results in LogInQuery)
                    //look for all posseble results in the query result.
                {
                    //add each result to the created list, if the list if for a class, u need to add 'new class_name' 
                    int returnvalue = Convert.ToInt32(results["type"]);

                    if (returnvalue == 0)
                    {
                        retAccount = new Manager(
                            Convert.ToInt32(results["id"]),
                            Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                            Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                            Convert.ToString(results["woonplaats"]),
                            Convert.ToString(results["email"]), Convert.ToInt32(results["telefoonnummer"]),
                            Convert.ToDateTime(results["geboortedatum"]), Convert.ToString(results["geslacht"]),
                            Convert.ToBoolean(results["actief"]));
                    }
                    else if (returnvalue == 1)
                    {
                        retAccount = new Needy(
                            Convert.ToInt32(results["id"]),
                            Convert.ToBoolean(results["ovkaart"]),
                            Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                            Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                            Convert.ToString(results["woonplaats"]),
                            Convert.ToString(results["email"]), Convert.ToInt32(results["telefoonnummer"]),
                            Convert.ToDateTime(results["geboortedatum"]), Convert.ToString(results["geslacht"]),
                            Convert.ToBoolean(results["actief"]));
                    }
                    else if (returnvalue == 2)
                    {
                        retAccount = new Volunteer(
                            Convert.ToInt32(results["id"]),
                            Convert.ToBoolean(results["auto"]),
                            Convert.ToString(results["gebruikersnaam"]), Convert.ToString(results["wachtwoord"]),
                            Convert.ToString(results["naam"]), Convert.ToString(results["adres"]),
                            Convert.ToString(results["woonplaats"]),
                            Convert.ToString(results["email"]), Convert.ToInt32(results["telefoonnummer"]),
                            Convert.ToDateTime(results["geboortedatum"]), Convert.ToString(results["geslacht"]),
                            Convert.ToBoolean(results["actief"]));
                    }
                }

                return retAccount; //this will return the list as result from the query.
            }
            else
            {
                return null;
            }
        }
    }
}
