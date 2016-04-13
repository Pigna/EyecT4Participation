using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeCT4Participation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string TextValue
        {
            set { tbChatMessage.Text = value; }
        }

        public string getTextValue
        {
            get { return tbChatMessage.Text; }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Chat c1 = new Chat();
            c1.AddMessage();
        }

        private void lbBeheerChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void LogIn(string username, string password)
        {
            // database.Query = "SELECT * FROM Gebruiker WHERE username = variabele.username AND password = variabele.password"
            // if("Type" = 0)
            // {
            
            tabPage4.Show();  // open hulpbehoevende scherm
            // }
            // else if ("Type" = 1)
            // {
            tabPage2.Show();  // open vrijwilliger scherm
            // }
        }

        private void btnInloggenInloggen_Click(object sender, EventArgs e)
        {
            LogIn(tbInloggenGnaam.Text, tbInloggenWW.Text);
        }

    }
}
