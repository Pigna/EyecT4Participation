using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using EyeCT4Participation.Database;
using Timer = System.Timers.Timer;

namespace EyeCT4Participation
{
    public partial class MainForm : Form
    {
        private static Timer aTimer;
        private readonly Administration administration;
        private Account currentConversation;
        private DBhelprequest databaseHelprequest = new DBhelprequest();
        private Volunteer volunteer;

        private readonly DBaccount dbAccount = new DBaccount();
        private readonly DBchat dbChat = new DBchat();
        private readonly DBvolunteer dbVolunteer = new DBvolunteer();

        public MainForm()
        {
            InitializeComponent();
            administration = new Administration();

            aTimer = new Timer(1000); // refresh timer in miliseconds
            aTimer.Elapsed += OnTimeEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true; // start event

            TabControl.TabPages[1].Enabled = false;
            TabControl.TabPages[2].Enabled = false;
            TabControl.TabPages[3].Enabled = false;
            TabControl.TabPages[4].Enabled = false;
        }

        private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            if (currentConversation != null && administration.LoggedinUser != null)
            {
                lbChatConversation.Invoke((Action) (() =>
                {
                    lbChatConversation.Items.Clear();
                    foreach (var chat in dbChat.Conversation(administration.LoggedinUser, currentConversation))
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
            var filter = tbBeheerFilter.Text;
            if (filter != "")
            {
                lbBeheerAccount.Items.Clear();
                lbBeheerChat.Items.Clear();
                lbBeheerHulpaanvraag.Items.Clear();
                lbBeheerBeoordeling.Items.Clear();
                var filterinput = new List<string>();
                if (filter.Contains(';'))
                {
                    filterinput.AddRange(filter.Split(';'));
                    var ListFiltered = administration.ListFilterAccount(filterinput);
                    foreach (var account in ListFiltered)
                    {
                        lbBeheerAccount.Items.Add(account);
                        foreach (var chat in administration.listChats)
                        {
                            if (ListFiltered.Contains(chat.sender) && ListFiltered.Contains(chat.receiver))
                            {
                                lbBeheerChat.Items.Add(chat);
                            }
                        }
                        foreach (var helprequest in administration.listHelprequests)
                        {
                            if (helprequest.Needy == account || helprequest.ListVolunteers.Contains(account))
                            {
                                lbBeheerHulpaanvraag.Items.Add(helprequest);
                            }
                        }
                        foreach (var review in administration.listReviews)
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
                    foreach (var account in administration.ListFilterAccount(filterinput))
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
        ///     Refresh interface of Manager
        /// </summary>
        private void BeheerRefresh()
        {
            administration.ListRefresh();
            lbBeheerAccount.Items.Clear();
            lbBeheerChat.Items.Clear();
            lbBeheerHulpaanvraag.Items.Clear();
            lbBeheerBeoordeling.Items.Clear();
            foreach (var account in administration.listAccounts)
            {
                lbBeheerAccount.Items.Add(account);
            }
            foreach (var chat in administration.listChats)
            {
                lbBeheerChat.Items.Add(chat);
            }
            foreach (var helprequest in administration.listHelprequests)
            {
                lbBeheerHulpaanvraag.Items.Add(helprequest);
            }
            foreach (var review in administration.listReviews)
            {
                lbBeheerBeoordeling.Items.Add(review);
            }
        }

        /// <summary>
        ///     Refresh interface of Volunteer
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
                    lbVrijwilligerBeschikbaarheid.Items.Clear();
                    foreach (var helprequest in administration.listHelprequests)
                    {
                        lbVolunteerHelprequest.Items.Add(helprequest);
                    }

                    foreach (var review in ((Volunteer) administration.LoggedinUser).getListReview())
                    {
                        lbVolunteerReview.Items.Add(review);
                    }
                    foreach (var beschikbaarheid in (administration.LoggedinUser as Volunteer).getListBeschikbaarheid())
                    {
                        lbVrijwilligerBeschikbaarheid.Items.Add(beschikbaarheid);
                    }
                }
            }
        }
        /// <summary>
        ///     Refresh interface of Chat
        /// </summary>
        private void ChatRefresh()
        {
            if (administration.LoggedinUser != null)
            {
                lbChatConversations.Items.Clear();
                lbChatConversation.Items.Clear();
                if (administration.LoggedinUser.GetType() == typeof (Needy))
                {
                    foreach (var account in dbChat.ListConversationVolunteers(administration.LoggedinUser as Needy))
                    {
                        lbChatConversations.Items.Add(account);
                    }
                }
                else if (administration.LoggedinUser.GetType() == typeof (Volunteer))
                {
                    foreach (var account in dbChat.ListConversationNeedys(administration.LoggedinUser as Volunteer))
                    {
                        lbChatConversations.Items.Add(account);
                    }
                }
            }
        }

        /// <summary>
        ///     Refresh interface of needy
        /// </summary>
        private void NeedyRefresh()
        {
            if (administration.LoggedinUser != null)
            {
                if (administration.LoggedinUser.GetType() == typeof (Needy))
                {
                    lbNeedyHelprequests.Items.Clear();
                    administration.ListHelpRequest();
                    foreach (var helprequest in administration.listHelprequests)
                    {
                        if (helprequest.Needy.id == administration.LoggedinUser.id)
                        {
                            lbNeedyHelprequests.Items.Add(helprequest);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Deactivate selected account
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
        ///     Deactivatie selected helprequest
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
        ///     Deactivate selected review
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
        ///     deactivate selected chat
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
        ///     Register in the application
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
        public void Registreer(string gebruikersnaam, string wachtwoord, string naam, string adres, string woonplaats,
            string email, DateTime geboortedatum, int telefoonnummer, string type, int geslacht, int auto, int ov)
        {
            if (type == "Hulpbehoevende")
            {
                var doqueryNeedy = dbAccount.NewAccount(gebruikersnaam, wachtwoord, naam, adres, woonplaats, email,
                    geboortedatum, telefoonnummer, 1, geslacht, auto, 1, ov);

                if (doqueryNeedy)
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
                var doqueryVrijwilliger = dbAccount.NewAccount(gebruikersnaam, wachtwoord, naam, adres, woonplaats,
                    email, geboortedatum, telefoonnummer, 2, geslacht, auto, 1, ov);

                if (doqueryVrijwilliger)
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
        /// <summary>
        /// Klik event Log in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Klik event Registratie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                var registratiegeslacht = 2;
                var auto = 0;
                var ov = 0;
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
        /// <summary>
        /// Refresh wanneer je van tabpage verandert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var loggedinaccount = administration.LoggedinUser;
            if (loggedinaccount != null)
            {
                if (TabControl.SelectedTab.Text == "Beheer" && loggedinaccount.GetType() == typeof (Manager))
                {
                    BeheerRefresh();
                }
                if (TabControl.SelectedTab.Text == "Vrijwilliger" && loggedinaccount.GetType() == typeof (Volunteer))
                {
                    VolunteerRefresh();
                }
                if (TabControl.SelectedTab.Text == "Hulpbehoevende" && loggedinaccount.GetType() == typeof (Needy))
                {
                    NeedyRefresh();
                }
                if (TabControl.SelectedTab.Text == "Chat")
                {
                    ChatRefresh();
                }
            }
        }
        /// <summary>
        /// Klik event hulpaanvraag opstellen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNeedyHelprequest_Click(object sender, EventArgs e)
        {
            var urgent = cbNeedyUrgent.Checked;
            var message = tbNeedyHelprequestDesctiption.Text;
            var locatie = tbNeedyLocation.Text;
            if (message != "")
            {
                if ((administration.LoggedinUser as Needy).AddHelpRequest(message, locatie, dtpNeedyStartdate.Value,
                    dtpNeedyEnddate.Value, cbNeedyUrgent.Checked, Convert.ToInt32(nudNeedyVolunteers.Value)))
                {
                    MessageBox.Show("Hulpvraag verzonden");
                }
                else
                {
                    MessageBox.Show("Hulpvraag niet verzonden, is alles goed ingevult?");
                }
            }
        }
        /// <summary>
        /// Klik event inschrijven op een hulpvraag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolunteerHelprequestRegister_Click(object sender, EventArgs e)
        {
            if (lbVolunteerHelprequest.SelectedItem != null)
            {
                if (
                    ((HelpRequest) lbVolunteerHelprequest.SelectedItem).AddVolunteer(
                        (Volunteer) administration.LoggedinUser))
                {
                    MessageBox.Show("Inschrijven gelukt.");
                }
            }
        }
        /// <summary>
        /// Klik event reactie op review
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolunteerReviewReact_Click(object sender, EventArgs e)
        {
            var reaction = tbVolunteerReviewReaction.Text;
            if (lbVolunteerReview.SelectedItem != null && reaction != "")
            {
                if (((Review) lbVolunteerReview.SelectedItem).AddReaction(reaction))
                {
                    MessageBox.Show("Reactie geplaatst.");
                }
            }
        }
        /// <summary>
        /// Klik event chat verzenden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChatSend_Click(object sender, EventArgs e)
        {
            var message = tbChatMessage.Text;
            if (message != "" && currentConversation != null)
            {
                var chat = new Chat(dbChat.getLatestId("Chat"), message, DateTime.Now, administration.LoggedinUser,
                    currentConversation, true);
                if (dbChat.SendMessage(chat))
                {
                    lbChatConversation.Items.Add(chat);
                    tbChatMessage.Clear();
                }
            }
        }
        /// <summary>
        /// Klik event Open conversation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChatOpen_Click(object sender, EventArgs e)
        {
            if (lbChatConversations.SelectedItem != null)
            {
                currentConversation = lbChatConversations.SelectedItem as Account;
                lblActiveConversation.Text = Convert.ToString(currentConversation.Name);
                lbChatConversation.Items.Clear();
                foreach (var chat in dbChat.Conversation(administration.LoggedinUser, currentConversation))
                {
                    lbChatConversation.Items.Add(chat);
                }
            }
        }
        /// <summary>
        /// Klik event uitloggen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Klik event Hulpvraag verwijderen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Klik event review
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNeedyReview_Click(object sender, EventArgs e)
        {
            var reviewdesc = tbNeedyReviewDescription.Text;
            if (administration.LoggedinUser != null &&
                lbNeedyReviewVolunteer.SelectedItem != null &&
                reviewdesc != "" &&
                lbNeedyHelprequests.SelectedItem != null
                )
            {
                Volunteer volunteer = lbNeedyReviewVolunteer.SelectedItem as Volunteer;
                if ((administration.LoggedinUser as Needy).AddReview(Convert.ToInt32(nudNeedyReviewScore.Value),
                    reviewdesc, volunteer,
                    lbNeedyHelprequests.SelectedItem as HelpRequest))
                {
                    MessageBox.Show("review is gelukt");
                }
                else
                {
                    MessageBox.Show("vul alle velden correct in." + lbNeedyReviewVolunteer.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("vul alle velden correct in");
            }
        }
        /// <summary>
        /// Klik event account verwijderen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccountVerwijderen_Click(object sender, EventArgs e)
        {
            var verwijderaccount = MessageBox.Show("Weet u zeker dat u uw account wilt verwijderen?", "",
                MessageBoxButtons.YesNo);

            if (verwijderaccount == DialogResult.Yes)
            {
                if (administration.DeactivateAccount(administration.LoggedinUser))
                {
                    MessageBox.Show("Account verwijderen is gelukt");
                    administration.LoggedinUser = null;
                    TabControl.TabPages[0].Enabled = true;
                    TabControl.TabPages[1].Enabled = false;
                    TabControl.TabPages[2].Enabled = false;
                    TabControl.TabPages[3].Enabled = false;
                    TabControl.TabPages[4].Enabled = false;
                    TabControl.SelectTab(0);
                }
            }
        }
        /// <summary>
        /// Refresh van hulpvraaglistbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbNeedyHelprequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNeedyReviewVolunteer.Items.Clear();
            HelpRequest help = ((HelpRequest)lbNeedyHelprequests.SelectedItem);
            foreach (Volunteer volunteer in help.ListVolunteers)
            {
                lbNeedyReviewVolunteer.Items.Add(volunteer);
            }
        }

        private void btnVrijwilligerBeschikbaarheidToevoegen_Click(object sender, EventArgs e)
        {
            if (cbVrijwilligerDag.SelectedItem != null)
            {
                if (cbVrijwilligerDagdeel.SelectedItem != null)
                {
                    if ((administration.LoggedinUser as Volunteer).AddBeschikbaarheid(dbVolunteer.getLatestId("beschikbaarheid"),
                        Convert.ToString(cbVrijwilligerDag.SelectedItem), Convert.ToString(cbVrijwilligerDagdeel.SelectedItem),administration.LoggedinUser.id))
                    {
                        lbVrijwilligerBeschikbaarheid.Items.Clear();
                        foreach (Beschikbaarheid b in (administration.LoggedinUser as Volunteer).getListBeschikbaarheid())
                        {
                            lbVrijwilligerBeschikbaarheid.Items.Add(b);
                        }
                        MessageBox.Show("Beschikbaarheid is succesvol ingesteld");
                    }
                }
                else
                {
                        MessageBox.Show("U bent vergeten een dagdeel te selecteren. Selecteer een dagdeel.");
                }
            }
            else
            {
                MessageBox.Show("U bent vergeten een dag te selecteren. Selecteer een dag.");
            }
        }
    }
}