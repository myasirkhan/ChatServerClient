using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ClientHelper rb;
            if (String.IsNullOrEmpty(txtIpOfServer.Text) || String.IsNullOrEmpty(txtPortOfServer.Text))
            {
                rb = new ClientHelper();
            }
            else
            {
                rb = new ClientHelper(txtIpOfServer.Text, Int32.Parse(txtPortOfServer.Text));
            }
            rb.send(txtToSend.Text);
            txtChatHistory.Text += Environment.NewLine + "You: " + txtToSend.Text;
            txtToSend.Text = "";
            txtChatHistory.Text +=  rb.recieve();
        }
    }
}
