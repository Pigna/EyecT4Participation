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
        public string Datetime;
        public string Sender;
        public string Receiver;
        public bool Active;
        public Chat(string message, string datetime, string sender, string receiver, bool active)
        {
            Message = message;
            Datetime = datetime;
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
            lbChatConversation.Items.Add(TextValue);
        }

    }
}
