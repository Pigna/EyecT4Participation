using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeCT4Participation
{
        public class Chat
    {
        public string Message;
        public DateTime Date;
        public Account MsgSender;
        public bool Active;
        public Chat(string message, DateTime date, Account msgSender, bool active)
        {
            Message = message;
            Date = date;
            MsgSender = msgSender;
            Active = active;
        }


        public override string ToString()
        {
            return Date + " " + MsgSender.Name + ": " + Message;
        }

    }
}
