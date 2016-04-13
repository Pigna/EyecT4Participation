using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeCT4Participation
{
    class Chat : MainForm
    {
        public string Message { get; set; }
        public Chat(string message)
        {
            Message = message;
        }

        public Chat()
        { 
            
        }

        public void AddMessage()
        {
            lbConversation.Items.Add(tbMessage.Text);
            tbMessage.Clear();
        }

    }
}
