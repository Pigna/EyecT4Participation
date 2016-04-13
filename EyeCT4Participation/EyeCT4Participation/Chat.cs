using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeCT4Participation
{
        public class Chat : MainForm
    {
        public string Message;
        public DateTime Date;
        public string Sender;
        public string Receiver;
        public bool Active;
        public Chat(string message, DateTime date, string sender, string receiver, bool active)
        {
            Message = message;
            Date = date;
            Sender = sender;
            Receiver = receiver;
            Active = active;
        }

        public Chat()
        { 
            
        }

        public string TextValue
        {
            get { return Message; }
            set { Message = value; }
        }

        public void AddMessage()
        {
            lbChatConversation.Items.Add(Message);
        }

    }
}
