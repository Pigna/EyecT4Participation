using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation.Database
{
    class DBhelprequest : DB
    {
        public bool DoQueryAddHelpRequest(string query) // replace user with the data u want to add/ change to the table
        {
            try
            {
                string Query; // the query will end up in here
                Query = query;  //replace with INSERT if needed
                doQuery(Query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        public bool JoinHelprequest(HelpRequest helprequest, Volunteer volunteer)
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO GEBRUIKER_HULPVRAAG";  //replace with INSERT if needed
                query += "(GEBRUIKERID, HULPVRAAGID) VALUES ('" + volunteer.id +"', '" + helprequest + "')"; //replace 'user.X' with the data u need.
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
    }
}
