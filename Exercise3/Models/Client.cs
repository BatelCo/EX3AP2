using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace Exercise3.Models
{
    public class Client
    {
        static Client instance = null;
        private string clientIp = "127.0.0.1";
        private int clientPort = 5400;
        Int32 port = 5402;
        IPAddress ip;
        TcpClient client;
        public bool isConnected = false;
        private BinaryReader reader;
        private TcpListener listener;

        public int ClientPort
        {
            get { return clientPort; }
            set
            {
                clientPort = value;
            }
        }

        public string Ip
        {
            get { return clientIp; }
            set { clientIp = value; }
        }

        static public Client getInstance()
        {
            if (instance == null)
            {
                instance = new Client();
                return instance;
            }
            else return instance;
        }

        public void connect_client()
        {
            port = 5400;
            ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, port);
            listener = new TcpListener(ep);
            listener.Start();
        }

        // read data and return lan & lot 
        public string[] Read()
        {
            if (!isConnected)
            {
                client = listener.AcceptTcpClient();
                isConnected = true;
                reader = new BinaryReader(client.GetStream());
            }
            // input will be stored here
            string input = "";
            char s;
            // read untill \n
            while ((s = reader.ReadChar()) != '\n') input += s;
            // split by comma
            string[] param = input.Split(',');
            // lan nad lat values
            string[] ret = { param[0], param[1] };
            return ret;
        }

        public void close()
        {
            client.Close();
        }


    }
}