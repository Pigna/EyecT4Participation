﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Chat
    {
        public string message { get; set; }
        public Chat(string msg)
        {
            message = msg;
        }

        public Chat()
        { 
            
        }

        public void AddMessage(Account sender, string message, DateTime time)
        {
            
        }

    }
}
