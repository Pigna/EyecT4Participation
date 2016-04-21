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
        public string Message;
        public DateTime Date;
        public Account Sender;
        public Account Receiver;
        public bool Active;
        DBchat databaseC = new DBchat();
        public Chat(string message, DateTime date, Account sender, Account receiver, bool active)
        {
            Message = message;
            Date = date;
            Sender = sender;
            Receiver = receiver;
            Active = active;
        }

        //public List<Chat> ListFilterChatmessage(List<string> filter)
        //{
        //    List<Chat> chat = new List<Chat>();
        //    foreach (string chatstring in filter)
        //    {
        //        foreach (Account account in chat)
        //        {
        //            if (account.Name == chatstring)
        //            {
        //                chat.Add(account);
        //            }
        //        }
        //    }
        //    return chat;
        //}
        
        public override string ToString()
        {
            return Date + " " + Sender.Name + ": " + Message;
        }

    }
}
