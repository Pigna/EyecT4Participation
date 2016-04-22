namespace EyeCT4Participation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabpageLogin = new System.Windows.Forms.TabPage();
            this.cbRegistratieType = new System.Windows.Forms.ComboBox();
            this.lblRegistratieType = new System.Windows.Forms.Label();
            this.cbRegistratieGeslacht = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRegistratiePhonenumber = new System.Windows.Forms.TextBox();
            this.lblRegistratiePhonenumber = new System.Windows.Forms.Label();
            this.btnInloggenInloggen = new System.Windows.Forms.Button();
            this.tbInloggenWW = new System.Windows.Forms.TextBox();
            this.tbInloggenGnaam = new System.Windows.Forms.TextBox();
            this.lblInloggenWW = new System.Windows.Forms.Label();
            this.lblInloggenGebruikersnaam = new System.Windows.Forms.Label();
            this.lblRegistratieRegistratie = new System.Windows.Forms.Label();
            this.lblInloggenInloggen = new System.Windows.Forms.Label();
            this.btnRegistratieOK = new System.Windows.Forms.Button();
            this.btnRegistratieAnnuleren = new System.Windows.Forms.Button();
            this.tbRegistratieGeboortedatum = new System.Windows.Forms.TextBox();
            this.tbRegistratieWplaats = new System.Windows.Forms.TextBox();
            this.tbRegistratieAdres = new System.Windows.Forms.TextBox();
            this.tbRegistratieNaam = new System.Windows.Forms.TextBox();
            this.tbRegistratieWW = new System.Windows.Forms.TextBox();
            this.tbRegistratieGnaam = new System.Windows.Forms.TextBox();
            this.lblRegistratieGeboortedatum = new System.Windows.Forms.Label();
            this.lblRegistratieWoonplaats = new System.Windows.Forms.Label();
            this.lblRegistratieAdres = new System.Windows.Forms.Label();
            this.lblRegistratieNaam = new System.Windows.Forms.Label();
            this.lblRegistratieWW = new System.Windows.Forms.Label();
            this.lblRegistratieGebruikersnaam = new System.Windows.Forms.Label();
            this.tabpageVrijwilliger = new System.Windows.Forms.TabPage();
            this.tabpageHulpbehoevende = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabpageChat = new System.Windows.Forms.TabPage();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbChatMessage = new System.Windows.Forms.RichTextBox();
            this.lbChatConversation = new System.Windows.Forms.ListBox();
            this.lblActiveConversation = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lbActiveConversations = new System.Windows.Forms.ListBox();
            this.tabpageBeheer = new System.Windows.Forms.TabPage();
            this.btnBeheerFilter = new System.Windows.Forms.Button();
            this.lblBeheerFilter = new System.Windows.Forms.Label();
            this.tbBeheerFilter = new System.Windows.Forms.TextBox();
            this.btnBeheerChatDeactiveren = new System.Windows.Forms.Button();
            this.lblBeheerBeoordeling = new System.Windows.Forms.Label();
            this.lblBeheerChat = new System.Windows.Forms.Label();
            this.lblBeheerHulpaanvraag = new System.Windows.Forms.Label();
            this.lblBeheerAccount = new System.Windows.Forms.Label();
            this.btnBeheerBeoordelingDeactiveren = new System.Windows.Forms.Button();
            this.btnBeheerHulpaanvraagDeactiveren = new System.Windows.Forms.Button();
            this.lbBeheerBeoordeling = new System.Windows.Forms.ListBox();
            this.lbBeheerChat = new System.Windows.Forms.ListBox();
            this.lbBeheerHulpaanvraag = new System.Windows.Forms.ListBox();
            this.btnBeheerAccountDeactiveren = new System.Windows.Forms.Button();
            this.btnBeheerAccountAanpassen = new System.Windows.Forms.Button();
            this.lbBeheerAccount = new System.Windows.Forms.ListBox();
            this.lblRegistratieGelukt = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.tabpageLogin.SuspendLayout();
            this.tabpageHulpbehoevende.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabpageChat.SuspendLayout();
            this.tabpageBeheer.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabpageLogin);
            this.TabControl.Controls.Add(this.tabpageVrijwilliger);
            this.TabControl.Controls.Add(this.tabpageHulpbehoevende);
            this.TabControl.Controls.Add(this.tabpageChat);
            this.TabControl.Controls.Add(this.tabpageBeheer);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(950, 657);
            this.TabControl.TabIndex = 0;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabpageLogin
            // 
            this.tabpageLogin.Controls.Add(this.cbRegistratieType);
            this.tabpageLogin.Controls.Add(this.lblRegistratieType);
            this.tabpageLogin.Controls.Add(this.cbRegistratieGeslacht);
            this.tabpageLogin.Controls.Add(this.label1);
            this.tabpageLogin.Controls.Add(this.tbRegistratiePhonenumber);
            this.tabpageLogin.Controls.Add(this.lblRegistratiePhonenumber);
            this.tabpageLogin.Controls.Add(this.btnInloggenInloggen);
            this.tabpageLogin.Controls.Add(this.tbInloggenWW);
            this.tabpageLogin.Controls.Add(this.tbInloggenGnaam);
            this.tabpageLogin.Controls.Add(this.lblInloggenWW);
            this.tabpageLogin.Controls.Add(this.lblInloggenGebruikersnaam);
            this.tabpageLogin.Controls.Add(this.lblRegistratieRegistratie);
            this.tabpageLogin.Controls.Add(this.lblInloggenInloggen);
            this.tabpageLogin.Controls.Add(this.btnRegistratieOK);
            this.tabpageLogin.Controls.Add(this.btnRegistratieAnnuleren);
            this.tabpageLogin.Controls.Add(this.tbRegistratieGeboortedatum);
            this.tabpageLogin.Controls.Add(this.tbRegistratieWplaats);
            this.tabpageLogin.Controls.Add(this.tbRegistratieAdres);
            this.tabpageLogin.Controls.Add(this.tbRegistratieNaam);
            this.tabpageLogin.Controls.Add(this.tbRegistratieWW);
            this.tabpageLogin.Controls.Add(this.tbRegistratieGnaam);
            this.tabpageLogin.Controls.Add(this.lblRegistratieGeboortedatum);
            this.tabpageLogin.Controls.Add(this.lblRegistratieWoonplaats);
            this.tabpageLogin.Controls.Add(this.lblRegistratieAdres);
            this.tabpageLogin.Controls.Add(this.lblRegistratieNaam);
            this.tabpageLogin.Controls.Add(this.lblRegistratieWW);
            this.tabpageLogin.Controls.Add(this.lblRegistratieGebruikersnaam);
            this.tabpageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabpageLogin.Name = "tabpageLogin";
            this.tabpageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageLogin.Size = new System.Drawing.Size(942, 631);
            this.tabpageLogin.TabIndex = 0;
            this.tabpageLogin.Text = "Inloggen/Registreren";
            this.tabpageLogin.UseVisualStyleBackColor = true;
            // 
            // cbRegistratieType
            // 
            this.cbRegistratieType.FormattingEnabled = true;
            this.cbRegistratieType.Items.AddRange(new object[] {
            "Hulpbehoevende",
            "Vrijwilliger"});
            this.cbRegistratieType.Location = new System.Drawing.Point(548, 303);
            this.cbRegistratieType.Margin = new System.Windows.Forms.Padding(2);
            this.cbRegistratieType.Name = "cbRegistratieType";
            this.cbRegistratieType.Size = new System.Drawing.Size(96, 21);
            this.cbRegistratieType.TabIndex = 53;
            // 
            // lblRegistratieType
            // 
            this.lblRegistratieType.AutoSize = true;
            this.lblRegistratieType.Location = new System.Drawing.Point(435, 306);
            this.lblRegistratieType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistratieType.Name = "lblRegistratieType";
            this.lblRegistratieType.Size = new System.Drawing.Size(31, 13);
            this.lblRegistratieType.TabIndex = 52;
            this.lblRegistratieType.Text = "Type";
            // 
            // cbRegistratieGeslacht
            // 
            this.cbRegistratieGeslacht.FormattingEnabled = true;
            this.cbRegistratieGeslacht.Items.AddRange(new object[] {
            "Man",
            "Vrouw"});
            this.cbRegistratieGeslacht.Location = new System.Drawing.Point(548, 334);
            this.cbRegistratieGeslacht.Margin = new System.Windows.Forms.Padding(2);
            this.cbRegistratieGeslacht.Name = "cbRegistratieGeslacht";
            this.cbRegistratieGeslacht.Size = new System.Drawing.Size(96, 21);
            this.cbRegistratieGeslacht.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Geslacht";
            // 
            // tbRegistratiePhonenumber
            // 
            this.tbRegistratiePhonenumber.Location = new System.Drawing.Point(548, 272);
            this.tbRegistratiePhonenumber.Name = "tbRegistratiePhonenumber";
            this.tbRegistratiePhonenumber.Size = new System.Drawing.Size(96, 20);
            this.tbRegistratiePhonenumber.TabIndex = 49;
            // 
            // lblRegistratiePhonenumber
            // 
            this.lblRegistratiePhonenumber.AutoSize = true;
            this.lblRegistratiePhonenumber.Location = new System.Drawing.Point(435, 275);
            this.lblRegistratiePhonenumber.Name = "lblRegistratiePhonenumber";
            this.lblRegistratiePhonenumber.Size = new System.Drawing.Size(86, 13);
            this.lblRegistratiePhonenumber.TabIndex = 48;
            this.lblRegistratiePhonenumber.Text = "Telefoonnummer";
            // 
            // btnInloggenInloggen
            // 
            this.btnInloggenInloggen.Location = new System.Drawing.Point(175, 142);
            this.btnInloggenInloggen.Margin = new System.Windows.Forms.Padding(2);
            this.btnInloggenInloggen.Name = "btnInloggenInloggen";
            this.btnInloggenInloggen.Size = new System.Drawing.Size(67, 29);
            this.btnInloggenInloggen.TabIndex = 47;
            this.btnInloggenInloggen.Text = "Inloggen";
            this.btnInloggenInloggen.UseVisualStyleBackColor = true;
            this.btnInloggenInloggen.Click += new System.EventHandler(this.btnInloggenInloggen_Click);
            // 
            // tbInloggenWW
            // 
            this.tbInloggenWW.Location = new System.Drawing.Point(166, 108);
            this.tbInloggenWW.Margin = new System.Windows.Forms.Padding(2);
            this.tbInloggenWW.Name = "tbInloggenWW";
            this.tbInloggenWW.Size = new System.Drawing.Size(76, 20);
            this.tbInloggenWW.TabIndex = 46;
            // 
            // tbInloggenGnaam
            // 
            this.tbInloggenGnaam.Location = new System.Drawing.Point(166, 67);
            this.tbInloggenGnaam.Margin = new System.Windows.Forms.Padding(2);
            this.tbInloggenGnaam.Name = "tbInloggenGnaam";
            this.tbInloggenGnaam.Size = new System.Drawing.Size(76, 20);
            this.tbInloggenGnaam.TabIndex = 45;
            // 
            // lblInloggenWW
            // 
            this.lblInloggenWW.AutoSize = true;
            this.lblInloggenWW.Location = new System.Drawing.Point(53, 110);
            this.lblInloggenWW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInloggenWW.Name = "lblInloggenWW";
            this.lblInloggenWW.Size = new System.Drawing.Size(68, 13);
            this.lblInloggenWW.TabIndex = 44;
            this.lblInloggenWW.Text = "Wachtwoord";
            // 
            // lblInloggenGebruikersnaam
            // 
            this.lblInloggenGebruikersnaam.AutoSize = true;
            this.lblInloggenGebruikersnaam.Location = new System.Drawing.Point(53, 69);
            this.lblInloggenGebruikersnaam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInloggenGebruikersnaam.Name = "lblInloggenGebruikersnaam";
            this.lblInloggenGebruikersnaam.Size = new System.Drawing.Size(84, 13);
            this.lblInloggenGebruikersnaam.TabIndex = 43;
            this.lblInloggenGebruikersnaam.Text = "Gebruikersnaam";
            // 
            // lblRegistratieRegistratie
            // 
            this.lblRegistratieRegistratie.AutoSize = true;
            this.lblRegistratieRegistratie.Location = new System.Drawing.Point(436, 29);
            this.lblRegistratieRegistratie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistratieRegistratie.Name = "lblRegistratieRegistratie";
            this.lblRegistratieRegistratie.Size = new System.Drawing.Size(57, 13);
            this.lblRegistratieRegistratie.TabIndex = 42;
            this.lblRegistratieRegistratie.Text = "Registratie";
            // 
            // lblInloggenInloggen
            // 
            this.lblInloggenInloggen.AutoSize = true;
            this.lblInloggenInloggen.Location = new System.Drawing.Point(53, 29);
            this.lblInloggenInloggen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInloggenInloggen.Name = "lblInloggenInloggen";
            this.lblInloggenInloggen.Size = new System.Drawing.Size(48, 13);
            this.lblInloggenInloggen.TabIndex = 41;
            this.lblInloggenInloggen.Text = "Inloggen";
            // 
            // btnRegistratieOK
            // 
            this.btnRegistratieOK.Location = new System.Drawing.Point(568, 383);
            this.btnRegistratieOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistratieOK.Name = "btnRegistratieOK";
            this.btnRegistratieOK.Size = new System.Drawing.Size(56, 19);
            this.btnRegistratieOK.TabIndex = 40;
            this.btnRegistratieOK.Text = "OK";
            this.btnRegistratieOK.UseVisualStyleBackColor = true;
            this.btnRegistratieOK.Click += new System.EventHandler(this.btnRegistratieOK_Click);
            // 
            // btnRegistratieAnnuleren
            // 
            this.btnRegistratieAnnuleren.Location = new System.Drawing.Point(439, 383);
            this.btnRegistratieAnnuleren.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistratieAnnuleren.Name = "btnRegistratieAnnuleren";
            this.btnRegistratieAnnuleren.Size = new System.Drawing.Size(72, 19);
            this.btnRegistratieAnnuleren.TabIndex = 39;
            this.btnRegistratieAnnuleren.Text = "Annuleren";
            this.btnRegistratieAnnuleren.UseVisualStyleBackColor = true;
            // 
            // tbRegistratieGeboortedatum
            // 
            this.tbRegistratieGeboortedatum.Location = new System.Drawing.Point(548, 240);
            this.tbRegistratieGeboortedatum.Margin = new System.Windows.Forms.Padding(2);
            this.tbRegistratieGeboortedatum.Name = "tbRegistratieGeboortedatum";
            this.tbRegistratieGeboortedatum.Size = new System.Drawing.Size(96, 20);
            this.tbRegistratieGeboortedatum.TabIndex = 37;
            // 
            // tbRegistratieWplaats
            // 
            this.tbRegistratieWplaats.Location = new System.Drawing.Point(548, 208);
            this.tbRegistratieWplaats.Margin = new System.Windows.Forms.Padding(2);
            this.tbRegistratieWplaats.Name = "tbRegistratieWplaats";
            this.tbRegistratieWplaats.Size = new System.Drawing.Size(96, 20);
            this.tbRegistratieWplaats.TabIndex = 34;
            // 
            // tbRegistratieAdres
            // 
            this.tbRegistratieAdres.Location = new System.Drawing.Point(548, 176);
            this.tbRegistratieAdres.Margin = new System.Windows.Forms.Padding(2);
            this.tbRegistratieAdres.Name = "tbRegistratieAdres";
            this.tbRegistratieAdres.Size = new System.Drawing.Size(96, 20);
            this.tbRegistratieAdres.TabIndex = 33;
            // 
            // tbRegistratieNaam
            // 
            this.tbRegistratieNaam.Location = new System.Drawing.Point(548, 142);
            this.tbRegistratieNaam.Margin = new System.Windows.Forms.Padding(2);
            this.tbRegistratieNaam.Name = "tbRegistratieNaam";
            this.tbRegistratieNaam.Size = new System.Drawing.Size(96, 20);
            this.tbRegistratieNaam.TabIndex = 32;
            // 
            // tbRegistratieWW
            // 
            this.tbRegistratieWW.Location = new System.Drawing.Point(548, 105);
            this.tbRegistratieWW.Margin = new System.Windows.Forms.Padding(2);
            this.tbRegistratieWW.Name = "tbRegistratieWW";
            this.tbRegistratieWW.Size = new System.Drawing.Size(96, 20);
            this.tbRegistratieWW.TabIndex = 31;
            // 
            // tbRegistratieGnaam
            // 
            this.tbRegistratieGnaam.Location = new System.Drawing.Point(548, 69);
            this.tbRegistratieGnaam.Margin = new System.Windows.Forms.Padding(2);
            this.tbRegistratieGnaam.Name = "tbRegistratieGnaam";
            this.tbRegistratieGnaam.Size = new System.Drawing.Size(96, 20);
            this.tbRegistratieGnaam.TabIndex = 30;
            // 
            // lblRegistratieGeboortedatum
            // 
            this.lblRegistratieGeboortedatum.AutoSize = true;
            this.lblRegistratieGeboortedatum.Location = new System.Drawing.Point(436, 243);
            this.lblRegistratieGeboortedatum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistratieGeboortedatum.Name = "lblRegistratieGeboortedatum";
            this.lblRegistratieGeboortedatum.Size = new System.Drawing.Size(80, 13);
            this.lblRegistratieGeboortedatum.TabIndex = 29;
            this.lblRegistratieGeboortedatum.Text = "Geboortedatum";
            // 
            // lblRegistratieWoonplaats
            // 
            this.lblRegistratieWoonplaats.AutoSize = true;
            this.lblRegistratieWoonplaats.Location = new System.Drawing.Point(435, 212);
            this.lblRegistratieWoonplaats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistratieWoonplaats.Name = "lblRegistratieWoonplaats";
            this.lblRegistratieWoonplaats.Size = new System.Drawing.Size(64, 13);
            this.lblRegistratieWoonplaats.TabIndex = 25;
            this.lblRegistratieWoonplaats.Text = "Woonplaats";
            // 
            // lblRegistratieAdres
            // 
            this.lblRegistratieAdres.AutoSize = true;
            this.lblRegistratieAdres.Location = new System.Drawing.Point(435, 179);
            this.lblRegistratieAdres.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistratieAdres.Name = "lblRegistratieAdres";
            this.lblRegistratieAdres.Size = new System.Drawing.Size(34, 13);
            this.lblRegistratieAdres.TabIndex = 24;
            this.lblRegistratieAdres.Text = "Adres";
            // 
            // lblRegistratieNaam
            // 
            this.lblRegistratieNaam.AutoSize = true;
            this.lblRegistratieNaam.Location = new System.Drawing.Point(435, 145);
            this.lblRegistratieNaam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistratieNaam.Name = "lblRegistratieNaam";
            this.lblRegistratieNaam.Size = new System.Drawing.Size(35, 13);
            this.lblRegistratieNaam.TabIndex = 23;
            this.lblRegistratieNaam.Text = "Naam";
            // 
            // lblRegistratieWW
            // 
            this.lblRegistratieWW.AutoSize = true;
            this.lblRegistratieWW.Location = new System.Drawing.Point(435, 107);
            this.lblRegistratieWW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistratieWW.Name = "lblRegistratieWW";
            this.lblRegistratieWW.Size = new System.Drawing.Size(68, 13);
            this.lblRegistratieWW.TabIndex = 22;
            this.lblRegistratieWW.Text = "Wachtwoord";
            // 
            // lblRegistratieGebruikersnaam
            // 
            this.lblRegistratieGebruikersnaam.AutoSize = true;
            this.lblRegistratieGebruikersnaam.Location = new System.Drawing.Point(436, 72);
            this.lblRegistratieGebruikersnaam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistratieGebruikersnaam.Name = "lblRegistratieGebruikersnaam";
            this.lblRegistratieGebruikersnaam.Size = new System.Drawing.Size(84, 13);
            this.lblRegistratieGebruikersnaam.TabIndex = 21;
            this.lblRegistratieGebruikersnaam.Text = "Gebruikersnaam";
            // 
            // tabpageVrijwilliger
            // 
            this.tabpageVrijwilliger.Location = new System.Drawing.Point(4, 22);
            this.tabpageVrijwilliger.Name = "tabpageVrijwilliger";
            this.tabpageVrijwilliger.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageVrijwilliger.Size = new System.Drawing.Size(942, 631);
            this.tabpageVrijwilliger.TabIndex = 1;
            this.tabpageVrijwilliger.Text = "Vrijwilliger";
            this.tabpageVrijwilliger.UseVisualStyleBackColor = true;
            // 
            // tabpageHulpbehoevende
            // 
            this.tabpageHulpbehoevende.Controls.Add(this.button1);
            this.tabpageHulpbehoevende.Controls.Add(this.numericUpDown1);
            this.tabpageHulpbehoevende.Controls.Add(this.listBox1);
            this.tabpageHulpbehoevende.Controls.Add(this.button2);
            this.tabpageHulpbehoevende.Controls.Add(this.richTextBox1);
            this.tabpageHulpbehoevende.Location = new System.Drawing.Point(4, 22);
            this.tabpageHulpbehoevende.Name = "tabpageHulpbehoevende";
            this.tabpageHulpbehoevende.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageHulpbehoevende.Size = new System.Drawing.Size(942, 631);
            this.tabpageHulpbehoevende.TabIndex = 3;
            this.tabpageHulpbehoevende.Text = "Hulpbehoevende";
            this.tabpageHulpbehoevende.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(609, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Beoordeel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(609, 35);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 14;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(399, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(204, 290);
            this.listBox1.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(308, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Verstuur";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(296, 289);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "Help mij met..";
            // 
            // tabpageChat
            // 
            this.tabpageChat.Controls.Add(this.btnOpen);
            this.tabpageChat.Controls.Add(this.tbChatMessage);
            this.tabpageChat.Controls.Add(this.lbChatConversation);
            this.tabpageChat.Controls.Add(this.lblActiveConversation);
            this.tabpageChat.Controls.Add(this.btnSend);
            this.tabpageChat.Controls.Add(this.lbActiveConversations);
            this.tabpageChat.Location = new System.Drawing.Point(4, 22);
            this.tabpageChat.Name = "tabpageChat";
            this.tabpageChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageChat.Size = new System.Drawing.Size(942, 631);
            this.tabpageChat.TabIndex = 4;
            this.tabpageChat.Text = "Chat";
            this.tabpageChat.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(8, 592);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(56, 19);
            this.btnOpen.TabIndex = 18;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbChatMessage
            // 
            this.tbChatMessage.Location = new System.Drawing.Point(262, 434);
            this.tbChatMessage.Margin = new System.Windows.Forms.Padding(2);
            this.tbChatMessage.Name = "tbChatMessage";
            this.tbChatMessage.Size = new System.Drawing.Size(674, 159);
            this.tbChatMessage.TabIndex = 17;
            this.tbChatMessage.Text = "";
            // 
            // lbChatConversation
            // 
            this.lbChatConversation.FormattingEnabled = true;
            this.lbChatConversation.Location = new System.Drawing.Point(262, 23);
            this.lbChatConversation.Margin = new System.Windows.Forms.Padding(2);
            this.lbChatConversation.Name = "lbChatConversation";
            this.lbChatConversation.Size = new System.Drawing.Size(674, 407);
            this.lbChatConversation.TabIndex = 16;
            // 
            // lblActiveConversation
            // 
            this.lblActiveConversation.AutoSize = true;
            this.lblActiveConversation.Location = new System.Drawing.Point(314, 3);
            this.lblActiveConversation.Name = "lblActiveConversation";
            this.lblActiveConversation.Size = new System.Drawing.Size(83, 13);
            this.lblActiveConversation.TabIndex = 15;
            this.lblActiveConversation.Text = "[HuidigGesprek]";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(861, 598);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Verstuur";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lbActiveConversations
            // 
            this.lbActiveConversations.FormattingEnabled = true;
            this.lbActiveConversations.Location = new System.Drawing.Point(8, 23);
            this.lbActiveConversations.Margin = new System.Windows.Forms.Padding(4);
            this.lbActiveConversations.Name = "lbActiveConversations";
            this.lbActiveConversations.Size = new System.Drawing.Size(249, 563);
            this.lbActiveConversations.TabIndex = 8;
            // 
            // tabpageBeheer
            // 
            this.tabpageBeheer.Controls.Add(this.btnBeheerFilter);
            this.tabpageBeheer.Controls.Add(this.lblBeheerFilter);
            this.tabpageBeheer.Controls.Add(this.tbBeheerFilter);
            this.tabpageBeheer.Controls.Add(this.btnBeheerChatDeactiveren);
            this.tabpageBeheer.Controls.Add(this.lblBeheerBeoordeling);
            this.tabpageBeheer.Controls.Add(this.lblBeheerChat);
            this.tabpageBeheer.Controls.Add(this.lblBeheerHulpaanvraag);
            this.tabpageBeheer.Controls.Add(this.lblBeheerAccount);
            this.tabpageBeheer.Controls.Add(this.btnBeheerBeoordelingDeactiveren);
            this.tabpageBeheer.Controls.Add(this.btnBeheerHulpaanvraagDeactiveren);
            this.tabpageBeheer.Controls.Add(this.lbBeheerBeoordeling);
            this.tabpageBeheer.Controls.Add(this.lbBeheerChat);
            this.tabpageBeheer.Controls.Add(this.lbBeheerHulpaanvraag);
            this.tabpageBeheer.Controls.Add(this.btnBeheerAccountDeactiveren);
            this.tabpageBeheer.Controls.Add(this.btnBeheerAccountAanpassen);
            this.tabpageBeheer.Controls.Add(this.lbBeheerAccount);
            this.tabpageBeheer.Location = new System.Drawing.Point(4, 22);
            this.tabpageBeheer.Margin = new System.Windows.Forms.Padding(2);
            this.tabpageBeheer.Name = "tabpageBeheer";
            this.tabpageBeheer.Padding = new System.Windows.Forms.Padding(2);
            this.tabpageBeheer.Size = new System.Drawing.Size(942, 631);
            this.tabpageBeheer.TabIndex = 2;
            this.tabpageBeheer.Text = "Beheer";
            this.tabpageBeheer.UseVisualStyleBackColor = true;
            // 
            // btnBeheerFilter
            // 
            this.btnBeheerFilter.Location = new System.Drawing.Point(234, 40);
            this.btnBeheerFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnBeheerFilter.Name = "btnBeheerFilter";
            this.btnBeheerFilter.Size = new System.Drawing.Size(77, 19);
            this.btnBeheerFilter.TabIndex = 59;
            this.btnBeheerFilter.Text = "Filter";
            this.btnBeheerFilter.UseVisualStyleBackColor = true;
            this.btnBeheerFilter.Click += new System.EventHandler(this.btnBeheerFilter_Click);
            // 
            // lblBeheerFilter
            // 
            this.lblBeheerFilter.AutoSize = true;
            this.lblBeheerFilter.Location = new System.Drawing.Point(3, 2);
            this.lblBeheerFilter.Name = "lblBeheerFilter";
            this.lblBeheerFilter.Size = new System.Drawing.Size(29, 13);
            this.lblBeheerFilter.TabIndex = 58;
            this.lblBeheerFilter.Text = "Filter";
            // 
            // tbBeheerFilter
            // 
            this.tbBeheerFilter.Location = new System.Drawing.Point(6, 16);
            this.tbBeheerFilter.Margin = new System.Windows.Forms.Padding(2);
            this.tbBeheerFilter.Name = "tbBeheerFilter";
            this.tbBeheerFilter.Size = new System.Drawing.Size(305, 20);
            this.tbBeheerFilter.TabIndex = 57;
            this.tbBeheerFilter.Text = "naam (Scheiden met \';\')";
            // 
            // btnBeheerChatDeactiveren
            // 
            this.btnBeheerChatDeactiveren.Location = new System.Drawing.Point(860, 608);
            this.btnBeheerChatDeactiveren.Margin = new System.Windows.Forms.Padding(2);
            this.btnBeheerChatDeactiveren.Name = "btnBeheerChatDeactiveren";
            this.btnBeheerChatDeactiveren.Size = new System.Drawing.Size(77, 19);
            this.btnBeheerChatDeactiveren.TabIndex = 56;
            this.btnBeheerChatDeactiveren.Text = "Deactiveren";
            this.btnBeheerChatDeactiveren.UseVisualStyleBackColor = true;
            this.btnBeheerChatDeactiveren.Click += new System.EventHandler(this.btnBeheerChatDeactiveren_Click);
            // 
            // lblBeheerBeoordeling
            // 
            this.lblBeheerBeoordeling.AutoSize = true;
            this.lblBeheerBeoordeling.Location = new System.Drawing.Point(1, 395);
            this.lblBeheerBeoordeling.Name = "lblBeheerBeoordeling";
            this.lblBeheerBeoordeling.Size = new System.Drawing.Size(63, 13);
            this.lblBeheerBeoordeling.TabIndex = 54;
            this.lblBeheerBeoordeling.Text = "Beoordeling";
            // 
            // lblBeheerChat
            // 
            this.lblBeheerChat.AutoSize = true;
            this.lblBeheerChat.Location = new System.Drawing.Point(631, 65);
            this.lblBeheerChat.Name = "lblBeheerChat";
            this.lblBeheerChat.Size = new System.Drawing.Size(29, 13);
            this.lblBeheerChat.TabIndex = 53;
            this.lblBeheerChat.Text = "Chat";
            // 
            // lblBeheerHulpaanvraag
            // 
            this.lblBeheerHulpaanvraag.AutoSize = true;
            this.lblBeheerHulpaanvraag.Location = new System.Drawing.Point(317, 65);
            this.lblBeheerHulpaanvraag.Name = "lblBeheerHulpaanvraag";
            this.lblBeheerHulpaanvraag.Size = new System.Drawing.Size(74, 13);
            this.lblBeheerHulpaanvraag.TabIndex = 52;
            this.lblBeheerHulpaanvraag.Text = "Hulpaanvraag";
            // 
            // lblBeheerAccount
            // 
            this.lblBeheerAccount.AutoSize = true;
            this.lblBeheerAccount.Location = new System.Drawing.Point(3, 65);
            this.lblBeheerAccount.Name = "lblBeheerAccount";
            this.lblBeheerAccount.Size = new System.Drawing.Size(47, 13);
            this.lblBeheerAccount.TabIndex = 51;
            this.lblBeheerAccount.Text = "Account";
            // 
            // btnBeheerBeoordelingDeactiveren
            // 
            this.btnBeheerBeoordelingDeactiveren.Location = new System.Drawing.Point(232, 600);
            this.btnBeheerBeoordelingDeactiveren.Margin = new System.Windows.Forms.Padding(2);
            this.btnBeheerBeoordelingDeactiveren.Name = "btnBeheerBeoordelingDeactiveren";
            this.btnBeheerBeoordelingDeactiveren.Size = new System.Drawing.Size(77, 19);
            this.btnBeheerBeoordelingDeactiveren.TabIndex = 50;
            this.btnBeheerBeoordelingDeactiveren.Text = "Deactiveren";
            this.btnBeheerBeoordelingDeactiveren.UseVisualStyleBackColor = true;
            this.btnBeheerBeoordelingDeactiveren.Click += new System.EventHandler(this.btnBeheerBeoordelingDeactiveren_Click);
            // 
            // btnBeheerHulpaanvraagDeactiveren
            // 
            this.btnBeheerHulpaanvraagDeactiveren.Location = new System.Drawing.Point(546, 361);
            this.btnBeheerHulpaanvraagDeactiveren.Margin = new System.Windows.Forms.Padding(2);
            this.btnBeheerHulpaanvraagDeactiveren.Name = "btnBeheerHulpaanvraagDeactiveren";
            this.btnBeheerHulpaanvraagDeactiveren.Size = new System.Drawing.Size(77, 19);
            this.btnBeheerHulpaanvraagDeactiveren.TabIndex = 48;
            this.btnBeheerHulpaanvraagDeactiveren.Text = "Deactiveren";
            this.btnBeheerHulpaanvraagDeactiveren.UseVisualStyleBackColor = true;
            this.btnBeheerHulpaanvraagDeactiveren.Click += new System.EventHandler(this.btnBeheerHulpaanvraagDeactiveren_Click);
            // 
            // lbBeheerBeoordeling
            // 
            this.lbBeheerBeoordeling.FormattingEnabled = true;
            this.lbBeheerBeoordeling.Items.AddRange(new object[] {
            "Beoordeling - [Stuuder] [Hulpaanvraag] [Bericht] [Rating]"});
            this.lbBeheerBeoordeling.Location = new System.Drawing.Point(4, 410);
            this.lbBeheerBeoordeling.Margin = new System.Windows.Forms.Padding(2);
            this.lbBeheerBeoordeling.Name = "lbBeheerBeoordeling";
            this.lbBeheerBeoordeling.Size = new System.Drawing.Size(305, 186);
            this.lbBeheerBeoordeling.TabIndex = 46;
            // 
            // lbBeheerChat
            // 
            this.lbBeheerChat.FormattingEnabled = true;
            this.lbBeheerChat.Items.AddRange(new object[] {
            "Chat - [Stuurder] [Bericht]"});
            this.lbBeheerChat.Location = new System.Drawing.Point(634, 80);
            this.lbBeheerChat.Margin = new System.Windows.Forms.Padding(2);
            this.lbBeheerChat.Name = "lbBeheerChat";
            this.lbBeheerChat.Size = new System.Drawing.Size(303, 524);
            this.lbBeheerChat.TabIndex = 45;
            // 
            // lbBeheerHulpaanvraag
            // 
            this.lbBeheerHulpaanvraag.FormattingEnabled = true;
            this.lbBeheerHulpaanvraag.Items.AddRange(new object[] {
            "Hulp - [Aanvrager] : [Bericht]"});
            this.lbBeheerHulpaanvraag.Location = new System.Drawing.Point(320, 80);
            this.lbBeheerHulpaanvraag.Margin = new System.Windows.Forms.Padding(2);
            this.lbBeheerHulpaanvraag.Name = "lbBeheerHulpaanvraag";
            this.lbBeheerHulpaanvraag.Size = new System.Drawing.Size(303, 277);
            this.lbBeheerHulpaanvraag.TabIndex = 44;
            // 
            // btnBeheerAccountDeactiveren
            // 
            this.btnBeheerAccountDeactiveren.Location = new System.Drawing.Point(153, 361);
            this.btnBeheerAccountDeactiveren.Margin = new System.Windows.Forms.Padding(2);
            this.btnBeheerAccountDeactiveren.Name = "btnBeheerAccountDeactiveren";
            this.btnBeheerAccountDeactiveren.Size = new System.Drawing.Size(77, 19);
            this.btnBeheerAccountDeactiveren.TabIndex = 43;
            this.btnBeheerAccountDeactiveren.Text = "Deactiveren";
            this.btnBeheerAccountDeactiveren.UseVisualStyleBackColor = true;
            this.btnBeheerAccountDeactiveren.Click += new System.EventHandler(this.btnBeheerAccountDeactiveren_Click);
            // 
            // btnBeheerAccountAanpassen
            // 
            this.btnBeheerAccountAanpassen.Location = new System.Drawing.Point(234, 361);
            this.btnBeheerAccountAanpassen.Margin = new System.Windows.Forms.Padding(2);
            this.btnBeheerAccountAanpassen.Name = "btnBeheerAccountAanpassen";
            this.btnBeheerAccountAanpassen.Size = new System.Drawing.Size(77, 19);
            this.btnBeheerAccountAanpassen.TabIndex = 42;
            this.btnBeheerAccountAanpassen.Text = "Aanpassen";
            this.btnBeheerAccountAanpassen.UseVisualStyleBackColor = true;
            this.btnBeheerAccountAanpassen.Click += new System.EventHandler(this.btnBeheerAccountAanpassen_Click);
            // 
            // lbBeheerAccount
            // 
            this.lbBeheerAccount.FormattingEnabled = true;
            this.lbBeheerAccount.Items.AddRange(new object[] {
            "Account - [Naam] [Adres] [Meer]"});
            this.lbBeheerAccount.Location = new System.Drawing.Point(6, 80);
            this.lbBeheerAccount.Margin = new System.Windows.Forms.Padding(2);
            this.lbBeheerAccount.Name = "lbBeheerAccount";
            this.lbBeheerAccount.Size = new System.Drawing.Size(305, 277);
            this.lbBeheerAccount.TabIndex = 41;
            // 
            // lblRegistratieGelukt
            // 
            this.lblRegistratieGelukt.AutoSize = true;
            this.lblRegistratieGelukt.Location = new System.Drawing.Point(519, 457);
            this.lblRegistratieGelukt.Name = "lblRegistratieGelukt";
            this.lblRegistratieGelukt.Size = new System.Drawing.Size(0, 13);
            this.lblRegistratieGelukt.TabIndex = 54;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 681);
            this.Controls.Add(this.TabControl);
            this.Name = "MainForm";
            this.TabControl.ResumeLayout(false);
            this.tabpageLogin.ResumeLayout(false);
            this.tabpageLogin.PerformLayout();
            this.tabpageHulpbehoevende.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabpageChat.ResumeLayout(false);
            this.tabpageChat.PerformLayout();
            this.tabpageBeheer.ResumeLayout(false);
            this.tabpageBeheer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabpageLogin;
        private System.Windows.Forms.TabPage tabpageVrijwilliger;
        private System.Windows.Forms.TabPage tabpageBeheer;
        private System.Windows.Forms.Button btnBeheerFilter;
        private System.Windows.Forms.Label lblBeheerFilter;
        private System.Windows.Forms.TextBox tbBeheerFilter;
        private System.Windows.Forms.Button btnBeheerChatDeactiveren;
        private System.Windows.Forms.Label lblBeheerBeoordeling;
        private System.Windows.Forms.Label lblBeheerChat;
        private System.Windows.Forms.Label lblBeheerHulpaanvraag;
        private System.Windows.Forms.Label lblBeheerAccount;
        private System.Windows.Forms.Button btnBeheerBeoordelingDeactiveren;
        private System.Windows.Forms.Button btnBeheerHulpaanvraagDeactiveren;
        private System.Windows.Forms.ListBox lbBeheerBeoordeling;
        private System.Windows.Forms.ListBox lbBeheerChat;
        private System.Windows.Forms.ListBox lbBeheerHulpaanvraag;
        private System.Windows.Forms.Button btnBeheerAccountDeactiveren;
        private System.Windows.Forms.Button btnBeheerAccountAanpassen;
        private System.Windows.Forms.ListBox lbBeheerAccount;
        private System.Windows.Forms.TabPage tabpageHulpbehoevende;
        private System.Windows.Forms.TabPage tabpageChat;
        private System.Windows.Forms.Button btnInloggenInloggen;
        private System.Windows.Forms.TextBox tbInloggenWW;
        private System.Windows.Forms.TextBox tbInloggenGnaam;
        private System.Windows.Forms.Label lblInloggenWW;
        private System.Windows.Forms.Label lblInloggenGebruikersnaam;
        private System.Windows.Forms.Label lblRegistratieRegistratie;
        private System.Windows.Forms.Label lblInloggenInloggen;
        private System.Windows.Forms.Button btnRegistratieOK;
        private System.Windows.Forms.Button btnRegistratieAnnuleren;
        private System.Windows.Forms.TextBox tbRegistratieGeboortedatum;
        private System.Windows.Forms.TextBox tbRegistratieWplaats;
        private System.Windows.Forms.TextBox tbRegistratieAdres;
        private System.Windows.Forms.TextBox tbRegistratieNaam;
        private System.Windows.Forms.TextBox tbRegistratieWW;
        private System.Windows.Forms.TextBox tbRegistratieGnaam;
        private System.Windows.Forms.Label lblRegistratieGeboortedatum;
        private System.Windows.Forms.Label lblRegistratieAdres;
        private System.Windows.Forms.Label lblRegistratieNaam;
        private System.Windows.Forms.Label lblRegistratieWW;
        private System.Windows.Forms.Label lblRegistratieGebruikersnaam;
        private System.Windows.Forms.Label lblActiveConversation;
        private System.Windows.Forms.ListBox lbActiveConversations;
        private System.Windows.Forms.Label lblRegistratieWoonplaats;
        public System.Windows.Forms.Button btnSend;
        public System.Windows.Forms.ListBox lbChatConversation;
        public System.Windows.Forms.RichTextBox tbChatMessage;
        private System.Windows.Forms.TextBox tbRegistratiePhonenumber;
        private System.Windows.Forms.Label lblRegistratiePhonenumber;
        private System.Windows.Forms.ComboBox cbRegistratieGeslacht;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRegistratieType;
        private System.Windows.Forms.Label lblRegistratieType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblRegistratieGelukt;
    }
}

