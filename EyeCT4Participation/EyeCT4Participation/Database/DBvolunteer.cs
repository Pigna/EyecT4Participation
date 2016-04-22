using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation.Database
{
    class DBvolunteer : DB
    {
         DB db = new DB();
         public bool DoQueryAddVolunteer(string gebruikersnaam, string wachtwoord, string naam, string adres, string woonplaats, string email, string geboortedatum, int telefoonnummer, int type, int geslacht, int auto, int actief, int ov) // replace user with the data u want to add/ change to the table
        {
            int returnID = db.getLatestId("Gebruiker");

            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO Gebruiker (Id,Gebruikersnaam, Wachtwoord, Naam, Adres, Woonplaats, Email, Geboortedatum, Telefoonnummer, Type, Geslacht, Auto, Actief) VALUES (" + returnID + ",'" + gebruikersnaam + "','" + wachtwoord + "','" + naam + "','" + adres + "','" + woonplaats + "','" + email + "','" + geboortedatum + "'," + telefoonnummer + "," + type + "," + geslacht + "," + auto + "," + actief + "," + ov + ")"; //query will be activated
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
