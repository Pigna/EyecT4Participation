using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using EyeCT4Participation.Database;

namespace EyeCT4Participation
{
    public partial class MainForm : Form
    {
        private static System.Timers.Timer aTimer;
        
        DBaccount dbAccount = new DBaccount();
        DBhelprequest databaseHelprequest = new DBhelprequest();
        DBchat dbChat = new DBchat();
        private Account currentConversation;
        private Administration administration;
        public MainForm()
        {
            InitializeComponent();
            administration = new Administration();
            
            aTimer = new System.Timers.Timer(10000); // refresh timer in miliseconds
            aTimer.Elapsed += OnTimeEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

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

        private void OnTimeEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            if (currentConversation != null)
            {
                this.lbChatConversation.Invoke((Action) (() =>
                {

                    lbChatConversation.Items.Clear();
                    foreach (Chat chat in dbChat.Conversation(administration.LoggedinUser, currentConversation))
                    {
                        lbChatConversation.Items.Add(chat);
                    }
                })
                    )
                    ;
            }


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
            if (administration.LoggedinUser != null)
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
        /// <summary>
        /// Refresh interface of Chat
        /// </summary>
        private void ChatRefresh()
        {
            if (administration.LoggedinUser != null)
            {
                lbChatConversations.Items.Clear();
                lbChatConversation.Items.Clear();
                if (administration.LoggedinUser.GetType() == typeof(Needy))
                {
                    foreach (Account account in dbChat.ListConversationVolunteers(administration.LoggedinUser as Needy))
                    {
                        lbChatConversations.Items.Add(account);
                    }
                }
                else if (administration.LoggedinUser.GetType() == typeof(Volunteer))
                {
                    foreach (Account account in dbChat.ListConversationNeedys(administration.LoggedinUser as Volunteer))
                    {
                        lbChatConversations.Items.Add(account);
                    }
                }
            }

            
        }
        /// <summary>
        /// Refresh interface of needy
        /// </summary>
        private void NeedyRefresh()
        {
            if (administration.LoggedinUser != null)
            {
                if (administration.LoggedinUser.GetType() == typeof (Needy))
                {
                    lbNeedyHelprequests.Items.Clear();
                    administration.ListHelpRequest();
                    foreach (HelpRequest helprequest in administration.listHelprequests)
                    {
                        if (helprequest.Needy.id == (administration.LoggedinUser.id))
                        {
                            lbNeedyHelprequests.Items.Add(helprequest);
                        }
                    }

                }
            }
        }
        /// <summary>
        /// Deactivate selected account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Deactivatie selected helprequest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Deactivate selected review
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// deactivate selected chat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Register in the application
        /// </summary>
        /// <param name="gebruikersnaam"></param>
        /// <param name="wachtwoord"></param>
        /// <param name="naam"></param>
        /// <param name="adres"></param>
        /// <param name="woonplaats"></param>
        /// <param name="email"></param>
        /// <param name="geboortedatum"></param>
        /// <param name="telefoonnummer"></param>
        /// <param name="type"></param>
        /// <param name="geslacht"></param>
        /// <param name="auto"></param>
        /// <param name="ov"></param>
        public void Registreer(string gebruikersnaam,string wachtwoord,string naam, string adres, string woonplaats, string email, DateTime geboortedatum, int telefoonnummer,string type,int geslacht, int auto, int ov)
        {

            if (type == "Hulpbehoevende")
            {
                bool doqueryNeedy = dbAccount.NewAccount(gebruikersnaam, wachtwoord, naam, adres, woonplaats,email, geboortedatum, telefoonnummer, 1, geslacht, auto, 1, ov);
                
                if (doqueryNeedy == true)
                {
                    MessageBox.Show("Registratie is gelukt");
                }
                if (doqueryNeedy == false)
                {
                    MessageBox.Show("Registratie is mislukt");
                }
            }
            else if (type == "Vrijwilliger")
            {
                bool doqueryVrijwilliger = dbAccount.NewAccount(gebruikersnaam, wachtwoord, naam, adres, woonplaats,email, geboortedatum, telefoonnummer, 1, geslacht, auto, 1, ov);
               
                if (doqueryVrijwilliger == true)
                {
                    MessageBox.Show("Registratie is gelukt");
                }
                if (doqueryVrijwilliger == false)
                {
                    MessageBox.Show("Registratie is mislukt");
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
            cbRegistratieOv.Checked = false;
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
            Account loggedinaccount = administration.LoggedinUser;
            if (loggedinaccount != null)
            {
                if (TabControl.SelectedTab.Text == "Beheer" && loggedinaccount.GetType() == typeof(Manager))
                {
                    BeheerRefresh();
                }
                if (TabControl.SelectedTab.Text == "Vrijwilliger" && loggedinaccount.GetType() == typeof(Volunteer))
                {
                    VolunteerRefresh();
                }
                if (TabControl.SelectedTab.Text == "Hulpbehoevende" && loggedinaccount.GetType() == typeof(Needy))
                {
                    NeedyRefresh();
                }
                if (TabControl.SelectedTab.Text == "Chat")
                {
                    ChatRefresh();
                }
            }

        }

        private void btnNeedyHelprequest_Click(object sender, EventArgs e)
        {
            bool urgent = cbNeedyUrgent.Checked;
            string message = tbNeedyHelprequestDesctiption.Text;
            string locatie = tbNeedyLocation.Text;
            if (message != "")
            {
                if ((administration.LoggedinUser as Needy).AddHelpRequest(message, locatie, dtpNeedyStartdate.Value, dtpNeedyEnddate.Value, cbNeedyUrgent.Checked, Convert.ToInt32(nudNeedyVolunteers.Value)))
                {
                    MessageBox.Show("Hulpvraag verzonden");
                }
                else
                {
                    MessageBox.Show("Hulpvraag niet verzonden, is alles goed ingevult?");
                }
            }
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
            string message = tbChatMessage.Text;
            if (message != "" && currentConversation != null)
            {
                Chat chat = new Chat(dbChat.getLatestId("Chat"), message, DateTime.Now, administration.LoggedinUser, currentConversation, true);
                if (dbChat.SendMessage(chat))
                {
                    lbChatConversation.Items.Add(chat);
                    tbChatMessage.Clear();
                }
            }

            //else
            //{
            //    MessageBox.Show("Voer iets in, veld is nog leeg!");
            //}
        }

        private void btnChatOpen_Click(object sender, EventArgs e)
        {
            if (lbChatConversations.SelectedItem != null)
            {
                currentConversation = lbChatConversations.SelectedItem as Account;
                lblActiveConversation.Text = Convert.ToString(currentConversation.Name);
                lbChatConversation.Items.Clear();
                foreach (Chat chat in dbChat.Conversation(administration.LoggedinUser, currentConversation))
                {
                    lbChatConversation.Items.Add(chat);
                }
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

        private void btnNeedyHelprequestsDelete_Click(object sender, EventArgs e)
        {
            if (lbNeedyHelprequests.SelectedItem != null)
            {
                if (administration.DeactivateHelpRequest(lbNeedyHelprequests.SelectedItem as HelpRequest))
                {
                    lbNeedyHelprequests.Items.Remove(lbNeedyHelprequests.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Fout bij deactiveren Hulpvraag");
                }
            }
        }

        private void btnNeedyReview_Click(object sender, EventArgs e)
        {
            string reviewdesc = tbNeedyReviewDescription.Text;
            if (administration.LoggedinUser != null && cbNeedyReviewUser.SelectedItem != null && reviewdesc != "" && lbNeedyHelprequests.SelectedItem != null)
            {
                if ((administration.LoggedinUser as Needy).AddReview(Convert.ToInt32(nudNeedyReviewScore.Value), reviewdesc,cbNeedyReviewUser .SelectedItem as Volunteer, lbNeedyHelprequests.SelectedItem as HelpRequest))
                {

                }
            }

            }

        private void btnAccountVerwijderen_Click(object sender, EventArgs e)
        {
            DialogResult verwijderaccount = MessageBox.Show("Weet u zeker dat u uw account wilt verwijderen?", "", MessageBoxButtons.YesNo);

            if (verwijderaccount == DialogResult.Yes)
            {
                if (administration.DeactivateAccount(administration.LoggedinUser))
                {
                    MessageBox.Show("Account verwijderen is gelukt");
                    TabControl.TabPages[0].Enabled = true;
                    TabControl.TabPages[1].Enabled = false;
                    TabControl.TabPages[2].Enabled = false;
                    TabControl.TabPages[3].Enabled = false;
                    TabControl.TabPages[4].Enabled = false;
                    TabControl.SelectTab(0);
                }
            }
        }
      
    }
}
