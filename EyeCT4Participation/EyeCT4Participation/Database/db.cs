using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4Participation.Database
{
    internal class DB
    {
        //fields
        private OracleConnection con;

        /// <summary>
        ///     doQuery
        /// </summary>
        /// <param name="query">here u need to insert your query </param>
        /// <returns></returns>
        protected int doQuery(string query)
        {
            try
            {
                Connect();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                var transact = cmd.Connection.BeginTransaction();
                cmd.Transaction = transact;
                var ret = cmd.ExecuteNonQuery();
                transact.Commit();
                Disconnect();
                return ret;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            finally
            {
                Disconnect();
            }
        }

        #region GetQuery

        /// <summary>
        ///     GetQuery
        /// </summary>
        /// <param name="query">here u need to insert your query</param>
        /// <returns></returns>
        protected List<Dictionary<string, object>> getQuery(string query)
        {
            var ret = new List<Dictionary<string, object>>();

            try
            {
                Connect();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                var read = true;

                var data = cmd.ExecuteReader();


                while (data.Read())
                {
                    read = true;
                    var d = new Dictionary<string, object>();
                    for (var c = 0; c < data.FieldCount; c++)
                        d.Add(data.GetName(c).ToLower(), data.GetValue(c));


                    ret.Add(d);
                }

                if (!read)
                {
                    throw new Exception("An open connection is already active");
                }

                Disconnect();
                return ret;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<Dictionary<string, object>>();
            }
            finally
            {
                Disconnect();
            }
        }

        #endregion

        /// <summary>
        ///     Connect
        /// </summary>
        private void Connect()
        {
            con = new OracleConnection();
            con.ConnectionString =
                "Data Source=fhictora01.fhict.local/fhictora;Persist Security Info=True;User ID=dbi331842;Password=CZSKUvxUUs";
            //con.ConnectionString = "Data Source=172.21.136.11:1521/xe;Persist Security Info=True;User ID=system;Password=vbNEA73jMt";
            con.Open();
        }

        /// <summary>
        ///     Disconnect
        /// </summary>
        private void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        public List<string> QueryName() //name of ur query
        {
            var ret = new List<string>(); //result of query will end up in here
            var QueryX = getQuery("SELECT naam FROM gebruiker WHERE GebruikerID = 1");
                //replace your query with te example query, replace 'QueryX' with a clear name.
            foreach (var results in QueryX) //look for all posseble results in the query result.
            {
                ret.Add(Convert.ToString(results["naam"]));
                    //add each result to the created list, if the list if for a class, u need to add 'new class_name' infront of the convert
            }

            return ret; //this will return the list as result from the query.
        }

        public int getLatestId(string table)
        {
            var data = getQuery("SELECT MAX(Id) + 1 AS ID FROM " + table);

            if (data == null)
                return 0;

            if (data.Count > 0 && data[0]["id"] != DBNull.Value)
                return Convert.ToInt32(data[0]["id"]);
            return 1;
        }
    }
}