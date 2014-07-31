using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
//using hamza;
namespace Server
{
    public partial class ServerForm : Form
    {
        System.Net.Sockets.TcpClient tcple=new System.Net.Sockets.TcpClient();
        public ServerForm()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            System.Net.IPEndPoint ipep = new System.Net.IPEndPoint(IPAddress.Any, (int)1111);
            System.Net.Sockets.TcpListener tcpl = new System.Net.Sockets.TcpListener(ipep);
            tcpl.Start();
            btnStartServer.BackColor = System.Drawing.Color.Red;
            while (true)
            {

                Application.DoEvents();
                while (!tcpl.Pending())
                    Application.DoEvents();
                System.Net.Sockets.TcpClient echoserver = tcpl.AcceptTcpClient();
                System.Net.Sockets.NetworkStream ns = echoserver.GetStream();

                string recivedmsg;
                byte[] recivedbytes = new byte[echoserver.ReceiveBufferSize];

                ns.Read(recivedbytes, 0, recivedbytes.Length);
                recivedmsg = System.Text.Encoding.UTF8.GetString(recivedbytes);
                txtRecieved.Text += Environment.NewLine + "Echo: " + recivedmsg + Environment.NewLine;
                string msgtosend;
                msgtosend = Environment.NewLine + "Echoserver: " + recivedmsg;

                byte[] bytestosend = System.Text.Encoding.UTF8.GetBytes(msgtosend);
                ns.Write(bytestosend, 0, bytestosend.Length);

                ns.Close();

            }

            
        }
    }
}
