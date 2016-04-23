﻿using System;
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
        
        DBaccount dbAccount = new DBaccount();
        DBhelprequest databaseHelprequest = new DBhelprequest();
        

        private Administration administration;
        public MainForm()
        {
            InitializeComponent();
            administration = new Administration();
            
            TabControl.TabPages[1].Enabled = false;
            TabControl.TabPages[2].Enabled = false;
            TabControl.TabPages[3].Enabled = false;
            TabControl.TabPages[4].Enabled = false;
            /*
            TabControl.TabPages.Remove(tabpageBeheer);
            TabControl.TabPages.Remove(tabpageChat);
            TabControl.TabPages.Remove(tabpageHulpbehoevende);
            TabControl.TabPages.Remove(tabpageVrijwilliger);
             */
        }
        private void btnBeheerFilter_Click(object sender, EventArgs e)
        {
            string filter = tbBeheerFilter.Text;
            if (filter != "")
            {
                lbBeheerAccount.Items.Clear();
                lbBeheerChat.Items.Clear();
                lbBeheerHulpaanvraag.Items.Clear();
                lbBeheerBeoordeling.Items.Clear();
                List<string> filterinput = new List<string>();
                if (filter.Contains(';'))
                {
                    filterinput.AddRange(filter.Split(';'));
                    List<Account> ListFiltered = administration.ListFilterAccount(filterinput);
                    foreach (Account account in ListFiltered)
                    {
                        lbBeheerAccount.Items.Add(account);
                        foreach (Chat chat in administration.listChats)
                        {
                            if (ListFiltered.Contains(chat.sender) && ListFiltered.Contains(chat.receiver))
                            {
                                lbBeheerChat.Items.Add(chat);
                            }
                        }
                        foreach (HelpRequest helprequest in administration.listHelprequests)
                        {
                            if (helprequest.Needy == account || helprequest.ListVolunteers.Contains(account))
                            {
                                lbBeheerHulpaanvraag.Items.Add(helprequest);
                            }
                        }
                        foreach (Review review in administration.listReviews)
                        {
                            if (review.Needy == account || review.Volunteer == account)
                            {
                                lbBeheerBeoordeling.Items.Add(review);
                            }
                        }
                    }
                }
                else
                {
                    filterinput.Add(filter);
                    foreach (Account account in administration.ListFilterAccount(filterinput))
                    {
                        lbBeheerAccount.Items.Add(account);
                    }
                }
            }
            else
            {
                BeheerRefresh();
            }

        }
        /// <summary>
        /// Refresh interface of Manager
        /// </summary>
        private void BeheerRefresh()
        {
            administration.ListRefresh();
            lbBeheerAccount.Items.Clear();
            lbBeheerChat.Items.Clear();
            lbBeheerHulpaanvraag.Items.Clear();
            lbBeheerBeoordeling.Items.Clear();
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
        /// <summary>
        /// Refresh interface of Volunteer
        /// </summary>
        private void VolunteerRefresh()
        {
            Account account = administration.LoggedinUser;
            if (account != null)
            {
                if (administration.LoggedinUser.GetType() == typeof (Volunteer))
                {
                    administration.ListRefresh();
                    lbVolunteerReview.Items.Clear();
                    lbVolunteerHelprequest.Items.Clear();
                    foreach (HelpRequest helprequest in administration.listHelprequests)
                    {
                        lbVolunteerHelprequest.Items.Add(helprequest);
                    }

                    foreach (Review review in ((Volunteer) administration.LoggedinUser).getListReview())
                    {
                        lbVolunteerReview.Items.Add(review);
                    }
                }
            }
        }

        private void hulpRefresh()
        {

            lbhulpvragen.Items.Clear();
            foreach (HelpRequest helprequest in administration.listHelprequests)
            {
                lbhulpvragen.Items.Add(helprequest.ToString());
            }
        }

        private void btnBeheerAccountDeactiveren_Click(object sender, EventArgs e)
        {
            if (administration.DeactivateAccount(lbBeheerAccount.SelectedItem as Account))
            {
                lbBeheerAccount.Items.Remove(lbBeheerAccount.SelectedItem);
            }
            else
            {
                MessageBox.Show("Fout bij deactiveren account");
            }
        }

        private void btnBeheerHulpaanvraagDeactiveren_Click(object sender, EventArgs e)
        {
            if (administration.DeactivateHelpRequest(lbBeheerHulpaanvraag.SelectedItem as HelpRequest))
            {
                lbBeheerHulpaanvraag.Items.Remove(lbBeheerHulpaanvraag.SelectedItem);
            }
            else
            {
                MessageBox.Show("Fout bij deactiveren hulpaanvraag");
            }
        }

        private void btnBeheerBeoordelingDeactiveren_Click(object sender, EventArgs e)
        {
            if (administration.DeactivateReview(lbBeheerBeoordeling.SelectedItem as Review))
            {
                lbBeheerBeoordeling.Items.Remove(lbBeheerBeoordeling.SelectedItem);
            }
            else
            {
                MessageBox.Show("Fout bij deactiveren beoordeling");
            }
        }

        private void btnBeheerChatDeactiveren_Click(object sender, EventArgs e)
        {
            if (administration.DeactivateChat(lbBeheerChat.SelectedItem as Chat))
            {
                lbBeheerChat.Items.Remove(lbBeheerChat.SelectedItem);
            }
            else
            {
                MessageBox.Show("Fout bij deactiveren chat");
            }
        }

        private void btnBeheerAccountAanpassen_Click(object sender, EventArgs e)
        {
            
        }

        public void Registreer(string gebruikersnaam,string wachtwoord,string naam, string adres, string woonplaats, string email, DateTime geboortedatum, int telefoonnummer,string type,int geslacht, int auto, int ov)
        {

            if (type == "Hulpbehoevende")
            {
                bool doqueryNeedy = dbAccount.NewAccount(gebruikersnaam, wachtwoord, naam, adres, woonplaats,email, geboortedatum, telefoonnummer, 1, geslacht, auto, 1, ov);
                
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
                bool doqueryVrijwilliger = dbAccount.NewAccount(gebruikersnaam, wachtwoord, naam, adres, woonplaats,email, geboortedatum, telefoonnummer, 1, geslacht, auto, 1, ov);
               
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
            tbRegistratiePhonenumber.Clear();
            cbRegistratieGeslacht.Text = "";
            cbRegistratieType.Text = "";
            tbRegistratieEmail.Clear();
            cbRegistratieAuto.Checked = false;
        }

        private void btnInloggenInloggen_Click(object sender, EventArgs e)
        {
            if (administration.LoginUser(tbInloggenGnaam.Text, tbInloggenWW.Text))
            {
            if (administration.LoggedinUser != null)
            {
                    if (administration.LoggedinUser.GetType() == typeof (Manager))
                {
                    TabControl.TabPages[0].Enabled = false;
                    TabControl.TabPages[1].Enabled = false;
                    TabControl.TabPages[2].Enabled = false;
                    TabControl.TabPages[3].Enabled = false;

                    TabControl.TabPages[4].Enabled = true;
                    TabControl.SelectTab(4);
                        MessageBox.Show("U bent ingelogd welkom");
                    //TabControl.TabPages.Add(tabpageBeheer);
                }
                    if (administration.LoggedinUser.GetType() == typeof (Volunteer))
                {
                    TabControl.TabPages[0].Enabled = false;
                    TabControl.TabPages[4].Enabled = false;
                    TabControl.TabPages[2].Enabled = false;

                    TabControl.TabPages[1].Enabled = true;
                    TabControl.TabPages[3].Enabled = true;
                    TabControl.SelectTab(1);
                        MessageBox.Show("U bent ingelogd welkom");
                    //TabControl.TabPages.Remove(tabpageChat);
                    //TabControl.TabPages.Remove(tabpageVrijwilliger);
                }
                    if (administration.LoggedinUser.GetType() == typeof (Needy))
                    {
                    TabControl.TabPages[0].Enabled = false;
                    TabControl.TabPages[1].Enabled = false;
                    TabControl.TabPages[4].Enabled = false;

                    TabControl.TabPages[2].Enabled = true;
                    TabControl.TabPages[3].Enabled = true;
                    TabControl.SelectTab(2);
                        MessageBox.Show("U bent ingelogd welkom");
                    //TabControl.TabPages.Remove(tabpageChat);
                    //TabControl.TabPages.Remove(tabpageHulpbehoevende);
                }
                tbInloggenGnaam.Clear();
                tbInloggenWW.Clear();
                }
            }
            else
            {
                MessageBox.Show("Wachtwoord of inlognaam is niet correct");
            }
        }

        private void btnRegistratieOK_Click(object sender, EventArgs e)
        {
            if
            (
                    tbRegistratieGnaam.Text != "" &&
                    tbRegistratieWW.Text != "" &&
                    tbRegistratieNaam.Text != "" &&
                    tbRegistratieAdres.Text != "" &&
                    tbRegistratieWplaats.Text != "" &&
                    tbRegistratieEmail.Text != ""
            )
            {
                int registratiegeslacht = 2;
                int auto = 0;
                int ov = 0;
                if (cbRegistratieAuto.Checked)
                {
                    auto = 1;
                }
                if (cbRegistratieOv.Checked)
                {
                    ov = 1;
                }

                if (Convert.ToString(cbRegistratieGeslacht.SelectedItem) == "Man")
                {
                    registratiegeslacht = 0;
                }
                else if (Convert.ToString(cbRegistratieGeslacht.SelectedItem) == "Vrouw")
                {
                     registratiegeslacht = 1;
                }
                Registreer(
                    tbRegistratieGnaam.Text,
                    tbRegistratieWW.Text,
                    tbRegistratieNaam.Text,
                    tbRegistratieAdres.Text,
                    tbRegistratieWplaats.Text,
                    tbRegistratieEmail.Text,
                    Convert.ToDateTime(dtpRegistratieBirthdate.Value),
                    Convert.ToInt32(tbRegistratiePhonenumber.Text),
                    Convert.ToString(cbRegistratieType.SelectedItem),
                    registratiegeslacht,
                    auto,
                    ov
                    );
            }

            
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab.Text == "Beheer")
            {
                BeheerRefresh();
            }
            if (TabControl.SelectedTab.Text == "Vrijwilliger")
            {
                VolunteerRefresh();
            }
            if (TabControl.SelectedTab.Text == "Hulpbehoevende")
            {
                hulpRefresh();
            }
        }

        private void BTHelpSend_Click(object sender, EventArgs e)
        {
            bool urgent = CBUrgent.Checked;
            string message = rtbhelpvraag.Text;
            HelpRequest newHelpRequested = new HelpRequest(0,message,dthelprequest.Value, urgent,true,(Needy)administration.LoggedinUser);


            if(databaseHelprequest.DoQueryAddHelpRequest(newHelpRequested))
            {
                MessageBox.Show("Hulpvraag verzonden");
            }
            MessageBox.Show("Hulpvraag niet verzonden, is alles goed ingevult?");



        }

        private void btnVolunteerHelprequestRegister_Click(object sender, EventArgs e)
        {
            if (lbVolunteerHelprequest.SelectedItem != null)
            {
                if(((HelpRequest)lbVolunteerHelprequest.SelectedItem).AddVolunteer((Volunteer)administration.LoggedinUser))
                {
                    MessageBox.Show("Inschrijven gelukt.");
                }
            }
        }

        private void btnVolunteerReviewReact_Click(object sender, EventArgs e)
        {
            string reaction = tbVolunteerReviewReaction.Text;
            if (lbVolunteerReview.SelectedItem != null && reaction != "")
            {
                if (((Review) lbVolunteerReview.SelectedItem).AddReaction(reaction))
                {
                    MessageBox.Show("Reactie geplaatst.");
                }
            }
        }

        private void btnChatSend_Click(object sender, EventArgs e)
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

        private void btnChatOpen_Click(object sender, EventArgs e)
        {
            foreach (Chat chat in administration.listChats)
            {
                if (administration.LoggedinUser == chat.receiver)
                {
                    foreach (Chat p in administration.listChats)
                    {
                        lbChatConversation.Items.Add(p);
                    }
                }
                else { MessageBox.Show("Verkeerde gebruiker"); }
            }
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            if (administration.LoggedinUser != null)
            {
                administration.LoggedinUser = null;
                TabControl.TabPages[0].Enabled = true;
                TabControl.TabPages[1].Enabled = false;
                TabControl.TabPages[2].Enabled = false;
                TabControl.TabPages[3].Enabled = false;
                TabControl.TabPages[4].Enabled = false;
                TabControl.SelectTab(0);
                MessageBox.Show("U bent uitgelogd");
            }
        }
    }
}
