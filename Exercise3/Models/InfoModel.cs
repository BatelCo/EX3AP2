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

        // ?  public const string SCENARIO_FILE = "~/App_Data/{0}.txt";           // The Path of the Secnario

        public void ReadData(string name)
        {
            Client client = Client.getInstance();
            client.connect_client();
            if (client.isConnected)
            {
                string[] vals = client.Read();
            }
            
      /*
            string path = HttpContext.Current.Server.MapPath(String.Format(SCENARIO_FILE, name));
            if (!File.Exists(path))
            {
                Employee.FirstName = name;
                Employee.LastName = name;
 

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(Employee.FirstName);
                    file.WriteLine(Employee.LastName);
                    file.WriteLine(Employee.Salary);
                }
            }
            else
            {
                string[] lines = System.IO.File.ReadAllLines(path);        // reading all the lines of the file
                Employee.FirstName = lines[0];
                Employee.LastName = lines[1];
                Employee.Salary = int.Parse(lines[2]);
            }
        */
        

        }
    }
}
