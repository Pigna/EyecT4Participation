using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation.Database
{
    class DBaccount : DB
    {
        private int returnvalue;
        public int GetQueryLogIn(string username, string password) //name of ur query
        {
            List<string> ret = new List<string>(); //result of query will end up in here
            List<Dictionary<string, object>> LogInQuery = getQuery("SELECT * FROM Gebruiker WHERE Gebruikersnaam = " + username + "AND Wachtwoord =" + password + ";"); //replace your query with te example query, replace 'QueryX' with a clear name.
            
            foreach (Dictionary<string, object> results in LogInQuery) //look for all posseble results in the query result.
            {
                 //add each result to the created list, if the list if for a class, u need to add 'new class_name' 
                 returnvalue = Convert.ToInt32(results["Type"]);
            }

            return returnvalue;      //this will return the list as result from the query.
        }
    }
}
