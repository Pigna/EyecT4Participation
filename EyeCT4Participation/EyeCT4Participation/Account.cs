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
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Residence { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; }
        public string Geslacht { get; set; }
        public int id { get; private set; }

        public Account(int id, string username, string password, string name, string adress, string residence, string email, int phonenumber, DateTime birthdate, bool active, string geslacht)
        {
            this.id = id;
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Adress = adress;
            this.Residence = residence;
            this.Email = email;
            this.PhoneNumber = phonenumber;
            this.Birthdate = birthdate;
            this.Active = active;
            this.Geslacht = geslacht;
        }
        public List<Account> Conversation() //fix needed
        {/*
            foreach (Chat chat in administration.listChats)
            {
                if (administration.LoggedinUser == chat)
                {
                    foreach (Chat p in administration.listChats)
                    {
                        
                    }
                }
                else
                {
                    MessageBox.Show("Verkeerde gebruiker");
                }
                return null;
            }
            return null;*/
            /*
                foreach (Account account in administration.listAccounts)
                {

                }
            }
            return chat;*/
            return null;
        }

            public override string ToString()
            {
                if (!Active)
                {
                    return id + " [D] " + Name + " ";
                }
                return id + " " + Name + " ";
            }
    }
}
