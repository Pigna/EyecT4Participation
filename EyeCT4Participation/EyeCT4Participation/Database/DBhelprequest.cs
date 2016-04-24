using System;

namespace EyeCT4Participation.Database
{
    internal class DBhelprequest : DB
    {
        private DB DB = new DB();

        public bool AddHelpRequest(HelpRequest newhelprequest)
            // replace user with the data u want to add/ change to the table
        {
            try
            {
                string Query = null; // the query will end up in here

                Query = "insert into hulpvraag VALUES( " + newhelprequest.id + ",'" + newhelprequest.Question +
                        "', '1', NULL, to_date('" + newhelprequest.Date.ToString("MM-dd-yyyy") +
                        "','MM-DD-YYYY'), to_date('" + newhelprequest.Date.ToString("MM-dd-yyyy") + "','MM-DD-YYYY')," +
                        Convert.ToInt32(newhelprequest.Urgency) + ", 1, " + newhelprequest.Needy.id + ", null, 1) ";
                if (doQuery(Query) != -1) //query will be activated
                    return true;
                return false;
            }
            catch
            {
                return false; // if query fails, return a false.
            }
        }

        public bool JoinHelprequest(HelpRequest helprequest, Volunteer volunteer)
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO GEBRUIKER_HULPVRAAG"; //replace with INSERT if needed
                query += "(GEBRUIKERID, HULPVRAAGID) VALUES ('" + volunteer.id + "', '" + helprequest.id + "')";
                    //replace 'user.X' with the data u need.
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