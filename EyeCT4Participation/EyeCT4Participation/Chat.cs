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
        public Account Sender;
        public Account Receiver;
        public bool Active;
        public Chat(string message, DateTime date, Account sender, Account receiver, bool active)
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
            lbChatConversation.Items.Add(tbChatMessage.Text);
            lbChatConversation.Refresh();
            tbChatMessage.Clear();
        }

        //public override string ToString()
        //{
        //    string info = Date + ": " + Message;
        //    return info;
        //}

    }
}
