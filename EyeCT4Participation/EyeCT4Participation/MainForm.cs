using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    public partial class MainForm : Form
    {
        
        DBaccount databaseAcc = new DBaccount();
        DBneedy databaseneedy = new DBneedy();
        DBvolunteer databaseVolunteer = new DBvolunteer();

        private Administration administration;
        public MainForm()
        {
            InitializeComponent();
            administration = new Administration();
        }

        public void btnSend_Click(object sender, EventArgs e)
        {
            //string message = tbChatMessage.Text;
            //if (message != null && message != "")
            //{
            //    Chat chat = new Chat(message, date, msgSender, active);       !!!!!! Constructor Aanpassen 
            //    lbChatConversation.Items.Add(chat);
            //}

            //else
            //{
            //    MessageBox.Show("Voer iets in, veld is nog leeg!");
            //}
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            List<string> ChatList = lbChatConversation.Items.Cast<string>().ToList();
        }

        private void btnBeheerFilter_Click(object sender, EventArgs e)
        {
            string filter = tbBeheerFilter.Text;
            if (filter != "")
            {
                List<string> filterinput = new List<string>();
                if (filter.Contains(';'))
                {
                    lbBeheerAccount.Items.Clear();
                    filterinput.AddRange(filter.Split(';'));
                    foreach (Account account in administration.ListFilterAccount(filterinput))
                    {
                        lbBeheerAccount.Items.Add(account);
                    }
                }
                else
                {
                    filterinput.Add(filter);
                }
            }

        }

        private void BeheerRefresh()
        {
            administration.ListRefresh();
            foreach (Account account in administration.listAccounts)
            {
                lbBeheerAccount.Items.Add(account);
            }
            foreach (Chat chat in administration.listChats)
            {
                lbBeheerChat.Items.Add((chat));
            }
            foreach (HelpRequest helprequest in administration.listHelprequests)
            {
                lbBeheerHulpaanvraag.Items.Add(helprequest);
            }
            foreach (Review review in administration.listReviews)
            {
                lbBeheerBeoordeling.Items.Add(review);
            }
        }

        private void btnBeheerAccountDeactiveren_Click(object sender, EventArgs e)
        {
            administration.DeactivateAccount(lbBeheerAccount.SelectedItem as Account);
        }

        private void btnBeheerHulpaanvraagDeactiveren_Click(object sender, EventArgs e)
        {
            administration.DeactivateHelpRequest(lbBeheerHulpaanvraag.SelectedItem as HelpRequest);
        }

        private void btnBeheerBeoordelingDeactiveren_Click(object sender, EventArgs e)
        {
            administration.DeactivateReview(lbBeheerBeoordeling.SelectedItem as Review);
        }

        private void btnBeheerChatDeactiveren_Click(object sender, EventArgs e)
        {
            administration.DeactivateChat(lbBeheerChat.SelectedItem as Chat);
        }

        private void btnBeheerAccountAanpassen_Click(object sender, EventArgs e)
        {
            
        }

        public void LogIn(string username, string password)
        {
            
            int retvalue = databaseAcc.GetQueryLogIn(username, password);

            if (retvalue == 0)
            {
                tabPage4.Show();        // open hulpbehoevende scherm
            }
            else if (retvalue == 1)
            {
                tabPage2.Show();        // open vrijwilliger scherm
            }
              
        }

        public void Registreer(string gebruikersnaam,string wachtwoord,string naam, string adres, string postcode, string woonplaats, string geboortedatum, int telefoonnummer,string type,int geslacht)
        {
            
            if (type == "Hulpbehoevende")
            {
                databaseneedy.DoQueryAddNeedy(gebruikersnaam, wachtwoord, naam, adres, postcode, woonplaats, geboortedatum, telefoonnummer, 1, geslacht);
            }
            else if (type == "Vrijwilliger")
            {
                
            }
        }

        private void btnInloggenInloggen_Click(object sender, EventArgs e)
        {
            LogIn(tbInloggenGnaam.Text, tbInloggenWW.Text);
        }

        private void btnRegistratieOK_Click(object sender, EventArgs e)
        {
            Registreer(tbRegistratieGnaam.Text,tbRegistratieWW.Text,tbRegistratieNaam.Text,tbRegistratieAdres.Text,tbRegistratiePcode.Text,tbRegistratieWplaats.Text,tbRegistratieGeboortedatum.Text,Convert.ToInt32(tbRegistratiePhonenumber.Text),cbRegistratieType.SelectedText,cbRegistratieGeslacht.SelectedIndex);
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab.Text == "Beheer")
            {
                BeheerRefresh();
            }
        }
    }
}
