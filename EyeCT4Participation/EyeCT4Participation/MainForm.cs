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
        private Chat chat;
        public MainForm()
        {
            InitializeComponent();
            administration = new Administration();
            /*
            TabControl.TabPages[1].Enabled = false;
            TabControl.TabPages[2].Enabled = false;
            TabControl.TabPages[3].Enabled = false;
            TabControl.TabPages[4].Enabled = false;

            TabControl.TabPages.Remove(tabpageBeheer);
            TabControl.TabPages.Remove(tabpageChat);
            TabControl.TabPages.Remove(tabpageHulpbehoevende);
            TabControl.TabPages.Remove(tabpageVrijwilliger);
             */
        }

        public void btnSend_Click(object sender, EventArgs e)
        {
            //string message = tbChatMessage.Text;
            //if (message != null && message != "")
            //{
            //    Chat chat = new Chat(message, date, sender, receiver, active);
            //    lbChatConversation.Items.Add(chat);
            //}

            //else
            //{
            //    MessageBox.Show("Voer iets in, veld is nog leeg!");
            //}
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //chat.ListFilterChatmessage();
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

        public void Registreer(string gebruikersnaam,string wachtwoord,string naam, string adres, string woonplaats, string email, string geboortedatum, int telefoonnummer,string type,int geslacht, int auto)
        {

            if (type == "Hulpbehoevende")
            {
                bool doqueryNeedy = databaseneedy.DoQueryAddNeedy(gebruikersnaam, wachtwoord, naam, adres, woonplaats,email, geboortedatum, telefoonnummer, 1, geslacht, auto, 1);
                
                if (doqueryNeedy == true)
                {
                   lblRegistratieGelukt.Text = "Registratie is gelukt";
                    lblRegistratieGelukt.Visible = true;
                }
                if (doqueryNeedy == false)
                {
                  lblRegistratieGelukt.Text = "Registratie is mislukt";
                    lblRegistratieGelukt.Visible = true;
                }
            }
            else if (type == "Vrijwilliger")
            {
                bool doqueryVrijwilliger = databaseVolunteer.DoQueryAddVolunteer(gebruikersnaam, wachtwoord, naam, adres, woonplaats,email, geboortedatum, telefoonnummer, 1, geslacht, auto, 1);
               
                if (doqueryVrijwilliger == true)
                {
                    lblRegistratieGelukt.Text = "Registratie is gelukt";
                    lblRegistratieGelukt.Visible = true;
                }
                if (doqueryVrijwilliger == false)
                {
                   lblRegistratieGelukt.Text = "Registratie is mislukt";
                   lblRegistratieGelukt.Visible = true;
                }
            }
            tbRegistratieGnaam.Clear();
            tbRegistratieWW.Clear();
            tbRegistratieNaam.Clear();
            tbRegistratieAdres.Clear();
            tbRegistratieWplaats.Clear();
            tbRegistratieGeboortedatum.Clear();
            tbRegistratiePhonenumber.Clear();
            cbRegistratieGeslacht.Text = "";
            cbRegistratieType.Text = "";
            tbRegistratieEmail.Clear();
            cbRegistratieAuto.Checked = false;
        }

        private void btnInloggenInloggen_Click(object sender, EventArgs e)
        {
            administration.LoginUser(tbInloggenGnaam.Text, tbInloggenWW.Text);
            if (administration.LoggedinUser != null)
            {
                if (administration.LoggedinUser.GetType() == typeof (Manager))
                {
                    TabControl.TabPages[4].Enabled = true;
                    //TabControl.TabPages.Add(tabpageBeheer);
                }
                if (administration.LoggedinUser.GetType() == typeof (Volunteer))
                {

                    TabControl.TabPages[1].Enabled = true;
                    TabControl.TabPages[3].Enabled = true;
                    //TabControl.TabPages.Remove(tabpageChat);
                    //TabControl.TabPages.Remove(tabpageVrijwilliger);
                }
                if (administration.LoggedinUser.GetType() == typeof (Needy))
                {
                    TabControl.TabPages[2].Enabled = true;
                    TabControl.TabPages[3].Enabled = true;
                    //TabControl.TabPages.Remove(tabpageChat);
                    //TabControl.TabPages.Remove(tabpageHulpbehoevende);
                }
            }
        }

        private void btnRegistratieOK_Click(object sender, EventArgs e)
        {
            int registratiegeslacht = 2;
            int auto = 0;
            if (cbRegistratieAuto.Checked)
            {
                auto = 1;
            }
            if (cbRegistratieAuto.Checked == false)
            {
                auto = 0;
            }

            if (Convert.ToString(cbRegistratieGeslacht.SelectedItem) == "Man")
            {
                registratiegeslacht = 0;
            }
            else if (Convert.ToString(cbRegistratieGeslacht.SelectedItem) == "Vrouw")
            {
                 registratiegeslacht = 1;
            }
            Registreer(tbRegistratieGnaam.Text,tbRegistratieWW.Text,tbRegistratieNaam.Text,tbRegistratieAdres.Text,tbRegistratieWplaats.Text,tbRegistratieEmail.Text,tbRegistratieGeboortedatum.Text,Convert.ToInt32(tbRegistratiePhonenumber.Text),Convert.ToString(cbRegistratieType.SelectedItem),registratiegeslacht, auto);
            
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab.Text == "Beheer")
            {
                BeheerRefresh();
            }
        }

        private void BTHelpSend_Click(object sender, EventArgs e)
        {
            if 
        }
    }
}
