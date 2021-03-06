﻿using System;
using System.Collections.Generic;

namespace EyeCT4Participation
{
    public abstract class Account
    {
        public Account(int id, string username, string password, string name, string adress, string residence,
            string email, int phonenumber, DateTime birthdate, bool active, string geslacht)
        {
            this.id = id;
            Username = username;
            Password = password;
            Name = name;
            Adress = adress;
            Residence = residence;
            Email = email;
            PhoneNumber = phonenumber;
            Birthdate = birthdate;
            Active = active;
            Geslacht = geslacht;
        }

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

        public override string ToString()
        {
            if (!Active)
            {
                return  Name + " ";
            }
            return Name + " ";
        }
    }
}