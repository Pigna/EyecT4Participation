using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation.Database
{
    class DBReview : DB
    {
        public bool DoQueryAddReview(string query) // replace user with the data u want to add/ change to the table
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
    }
}
