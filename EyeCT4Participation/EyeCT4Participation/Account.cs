using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    public abstract class Account
    {
        private Administration administration;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Zipcode { get; set; }
        public string Residence { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; }
        public string Geslacht { get; set; }

        public Account(string username, string password, string name, string adress, string zipcode, string residence, string email, int phonenumber, DateTime birthdate, bool active, string geslacht)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Adress = adress;
            this.Zipcode = zipcode;
            this.Residence = residence;
            this.Email = email;
            this.PhoneNumber = phonenumber;
            this.Birthdate = birthdate;
            this.Active = active;
            this.Geslacht = geslacht;
        }
        public List<Account> Conversation() //fix needed
        {
            foreach (Chat chat in administration.listChats)
            {
                if (administration.LoggedinUser == chat.Receiver)
                {
                    foreach (Chat p in administration.listChats)
                    {
                        
                    }
                }
                else
                {
                    MessageBox.Show("Verkeerde gebruiker");
                }
                return false;
            }

            /*
                foreach (Account account in administration.listAccounts)
                {

                }
            }
            return chat;*/
        }
    }
}
