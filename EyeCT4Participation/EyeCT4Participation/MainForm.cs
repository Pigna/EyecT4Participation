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
            set { tbMessage.Text = value; }
        }

        public string getTextValue
        {
            get { return tbMessage.Text; }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Chat c1 = new Chat();
            c1.AddMessage();
        }

        private void lbBeheerChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
