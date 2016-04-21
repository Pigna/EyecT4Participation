using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation.Database
{
    class DBneedy : DB
    {
        public bool DoQueryAddNeedy(string gebruikersnaam, string wachtwoord, string naam, string adres, string postcode, string woonplaats, string geboortedatum, int telefoonnummer, int type, int geslacht) // replace user with the data u want to add/ change to the table
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO Gebruiker (Gebruikersnaam, Wachtwoord, Naam, Adres, Postcode, Woonplaats, Geboortedatum, Telefoonnummer, Type, Geslacht) VALUES ("+ gebruikersnaam + "," + wachtwoord + "," + naam + "," + adres + "," + postcode + "," + woonplaats + ","+ geboortedatum + "," + telefoonnummer + "," + type + "," + geslacht + ")";  //replace with INSERT if needed
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
