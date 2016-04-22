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
        private Administration administration;
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
        //    List<Account> accountfilter = new List<Account>();
        //    foreach (string filterstring in filter)
        //    {
        //        foreach (Account account in administration.listAccounts)
        //        {
        //            if (account.Name == filterstring)
        //            {
        //                accountfilter.Add(account);
        //            }
        //        }
        //    }
        //    return accountfilter;
        //}
        
        public override string ToString()
        {
            return Date + " " + Sender.Name + ": " + Message;
        }

    }
}
