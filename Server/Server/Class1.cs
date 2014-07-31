//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace hamza
//{
//    class client
//    {
//        //private System.Net.Sockets.TcpClient tcp;
//        //private System.Net.Sockets.NetworkStream ns;
//        //public client()
//        //{
//        //    tcp = new System.Net.Sockets.TcpClient("127.0.0.1", (int)1111);

//        //    ns = tcp.GetStream();
//        //}
//        public client(string ipaddress, int portnumber)
//        {
//            if (ipaddress.Trim().Length <= 0) ipaddress = "127.0.0.1";
//            tcp = new System.Net.Sockets.TcpClient(ipaddress, portnumber);

//            ns = tcp.GetStream();
//        }
//        public int send(string msg)
//        {
//            byte[] bts = System.Text.Encoding.UTF8.GetBytes(msg);
//            ns.Write(bts, 0, bts.Length);
//            return (0);
//        }
//        public string recieve()
//        {
//            byte[] btr = new byte[tcp.ReceiveBufferSize];
//            ns.Read(btr, 0, btr.Length);
//            string recieve = System.Text.Encoding.UTF8.GetString(btr);
//            return (recieve);
//            //}

//        }
//   }