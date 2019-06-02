using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Exercise3.Models
{
    public class InfoModel
    {
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
        public string ip { get; set; }
        public string port { get; set; }
        public int time { get; set; }
       

        public InfoModel()
        {
            location = new Location();
        }


        public void ReadData(string name)
        {
            Client client = Client.getInstance();
            client.connect_client();
            if (client.isConnected)
            {
                string[] vals = client.Read();
            }     

        }
    }
}
