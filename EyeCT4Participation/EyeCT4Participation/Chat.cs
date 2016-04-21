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

        public List<Account> ListChatmessage(List<string> filter)
        {
            Administration administration = new Administration();
            List<Account> chat = new List<Account>();
            foreach (string chatstring in filter)
            {
                foreach (Account account in chat)
                {
                    if (account.Name == chatstring)
                    {
                        chat.Add(account);
                    }
                }
            }
            return chat;
        }
        
        public override string ToString()
        {
            return Date + " " + Sender.Name + ": " + Message;
        }

    }
}
