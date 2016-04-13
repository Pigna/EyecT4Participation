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

        public void btnSend_Click(object sender, EventArgs e)
        {
            Chat c1 = new Chat(tbChatMessage.Text);
            c1.TextValue = tbChatMessage.Text;
            c1.AddMessage();
            tbChatMessage.Clear();
        }

        private void lbBeheerChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
