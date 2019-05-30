using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Exercise3.Models
{
    public class InfoModel
    {
        IPAddress ip;
        TcpClient client;
        public bool isConnected = false;
        private BinaryReader reader;
        private NetworkStream stream;


        private static InfoModel s_instace = null;

        public static InfoModel Instance
        {
            get
            {
                if (s_instace == null)
                {
                    s_instace = new InfoModel();
                }
                return s_instace;
            }
        }

        public Location location { get; private set; }
        public int time { get; set; }
       

        public InfoModel()
        {
            location = new Location();
        }


        public void close_client()
        {
            if (isConnected)
            {
                reader.Close();
                stream.Close();
                client.Close();
                isConnected = false;
            }
        }

        public void connect_client(string ipAdd, int port)
        {
            ip = IPAddress.Parse(ipAdd);
            IPEndPoint ep = new IPEndPoint(ip, port);
            client = new TcpClient();
            while (!isConnected)
            {
                try
                {
                    Console.WriteLine("Waiting for client...");
                    client.Connect(ep);
                    stream = client.GetStream();
                    reader = new BinaryReader(stream);
                    isConnected = true;
                }
                catch { }
            }
            Console.WriteLine("Connected!");

        }

        // read data and return lan & lot 
        public string Read(string request)
        {
            if (isConnected)
            {
                Byte[] write = Encoding.ASCII.GetBytes(request);
                stream.Write(write, 0, write.Length);
                // input will be stored here
                string input = "";
                char s;
                // read untill \n
                while ((s = reader.ReadChar()) != '\n') input += s;
                // split by comma
                string[] param = input.Split('\'');
                return param[1];

            }
            return null;
        }

    }
}
