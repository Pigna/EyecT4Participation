using System;
using System.Collections.Generic;

namespace EyeCT4Participation.Database
{
    internal class DBvolunteer : DB
    {
        public bool AddBeschikbaarheid(Beschikbaarheid beschikbaarheid) // replace user with the data u want to add/ change to the table
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO beschikbaarheid (ID,Dag, Dagdeel, GebruikerID) VALUES (" + beschikbaarheid.id +", " +beschikbaarheid.Dag + ", " + beschikbaarheid.Dagdeel + ", " + beschikbaarheid.gebruikerID + ")"; //replace with INSERT if needed
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false; // if query fails, return a false.
            }
        }
        public List<Beschikbaarheid> GetBeschikbaarheidList() //name of ur query
        {

            var ret = new List<Beschikbaarheid>(); //result of query will end up in here
            var QueryX = getQuery("SELECT * FROM beschikbaarheid");
            //replace your query with te example query, replace 'QueryX' with a clear name.
            foreach (var results in QueryX) //look for all posseble results in the query result.
            {
                Beschikbaarheid beschikbaar = new Beschikbaarheid(Convert.ToInt32(results["id"]), Convert.ToInt32(results["dag"]), Convert.ToInt32(results["dagdeel"]),Convert.ToInt32(results["gebruikerid"]));

                ret.Add(beschikbaar);
                //add each result to the created list, if the list if for a class, u need to add 'new class_name' infront of the convert
            }

            return ret; //this will return the list as result from the query.
        }
    }
}