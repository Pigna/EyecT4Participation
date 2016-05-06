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
    public partial class EditUser : Form
    {
        public Account editAccount;
        Administration administration = new Administration();
        public EditUser(Account editAccount)
        {
            InitializeComponent();
            this.editAccount = editAccount;
            tbUpdateUsername.Text = editAccount.Username;
            tbUpdatePassword.Text = editAccount.Password;
            tbUpdateName.Text = editAccount.Name;
            tbUpdateAdres.Text = editAccount.Adress;
            tbUpdateLocation.Text = editAccount.Residence;
            dtpUpdateBirthdate.Value = editAccount.Birthdate;
            tbUpdatePhonenumber.Text = Convert.ToString(editAccount.PhoneNumber);
            cbUpdateGender.SelectedText = editAccount.Geslacht;
            tbUpdateEmail.Text = editAccount.Email;

        }

        private void btnUpdateAnnuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateOK_Click(object sender, EventArgs e)
        {
            if(tbUpdateUsername.Text != "" && tbUpdatePassword.Text != "" && tbUpdateName.Text != "" && tbUpdateAdres.Text != "" && tbUpdateLocation.Text != "" && tbUpdatePhonenumber.Text != "" && tbUpdateEmail.Text != "")
            {
                //get data from form and update account
                editAccount.Username = tbUpdateUsername.Text;
                editAccount.Password = tbUpdatePassword.Text;
                editAccount.Name = tbUpdateName.Text;
                editAccount.Adress = tbUpdateAdres.Text;
                editAccount.Residence = tbUpdateLocation.Text;
                editAccount.Birthdate = dtpUpdateBirthdate.Value;
                editAccount.PhoneNumber = Convert.ToInt32(tbUpdatePhonenumber.Text);
                editAccount.Geslacht = cbUpdateGender.SelectedText;
                editAccount.Email = tbUpdateEmail.Text;
                //Update account to database
                if (administration.UpdateAccount(editAccount))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Fout bij aanpassen gebruiker");
                }
            }
            else
            {
                MessageBox.Show("Niet alle velden zijn ingevuld.");
            }
            
        }
    }
}
