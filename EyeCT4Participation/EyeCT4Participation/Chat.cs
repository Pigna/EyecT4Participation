using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
        public class Chat
    {
        public string message;
        public DateTime date;
        public Account sender;
        public Account receiver;
        public bool Active;
        public int id { get; private set; }
        public Chat(int id, string message, DateTime date, Account sender, Account receiver, bool active)
        {
            this.id = id;
            this.message = message;
            this.date = date;
            this.sender = sender;
            this.receiver = receiver;
            this.Active = active;
        }

        public override string ToString()
        {
            return Date + " " + Sender.Name + ": " + Message;
        }

    }
}
