using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Chat
    {
        public string Message { get; set; }
        public Chat(string message)
        {
            Message = message;
        }

        public Chat()
        { 
            
        }

        public void AddMessage(Account sender, string message, DateTime date)
        {
            lbText.Items.Add(tbTekst.text);
            tbTekst.tekst.Clear();
        }

    }
}
