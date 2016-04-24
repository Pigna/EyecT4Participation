using System;

namespace EyeCT4Participation
{
    public class Chat
    {
        public bool active;
        public DateTime date;
        public string message;
        public Account receiver;
        public Account sender;

        public Chat(int id, string message, DateTime date, Account sender, Account receiver, bool active)
        {
            this.id = id;
            this.message = message;
            this.date = date;
            this.sender = sender;
            this.receiver = receiver;
            this.active = active;
        }

        public int id { get; private set; }

        public override string ToString()
        {
            return date.ToString("d") + " " + sender.Name + ": " + message;
        }
    }
}