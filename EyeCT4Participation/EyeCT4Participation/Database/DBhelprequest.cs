using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation.Database
{
    class DBhelprequest : DB
    {
        DB DB = new DB();
        public bool DoQueryAddHelpRequest(HelpRequest newhelprequest) // replace user with the data u want to add/ change to the table
        {
            
            try
            {
               string Query = null; // the query will end up in here

                Query = "insert into hulpvraag VALUES( ";
                Query += DB.getLatestId("hulpvraag");
                Query += ", '";
                Query += newhelprequest.Description;
                Query += "', 'null', 0,";
                Query += "to_date('" + newhelprequest.Date.ToString("MM-dd-yyyy") + "', 'MM-DD-YYYY'),";
                Query += "0-0-0,";
                Query += Convert.ToInt32(newhelprequest.Urgency);
                Query += ",1,";
                Query += ", ";
                Query += newhelprequest.Needy.id;
                Query += ", ";
                Query += "1";
                Query += ")";
               if(doQuery(Query) != -1) //query will be activated
                return true;
               else
               {
                   return false;
               }
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
    }
}
