using System;
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
            this.message = msg;
        }

        public void AddMessage(Account sender, string message, DateTime time)
        {
            //functie addmessage
        }

    }
}
