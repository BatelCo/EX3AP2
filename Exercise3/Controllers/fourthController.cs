using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercise3.Models;
using System.IO;

namespace Exercise3.Controllers
{
    public class FourthController : Controller
    {
        public static int counter = 0;
        // GET: fourth
        public ActionResult Index()
        {
            return View();
        }
        // the matching view - Display4
        public ActionResult Display4(string flight, int freq)
        {
            ViewBag.freq = freq;
            ReadFromFile(flight);
            return View();
        }

        public void ReadFromFile(string fileName)
        {
            string line;
            const string SCENARIO_FILE = "~/App_Data/{0}.txt";
            // Read the file and display it line by line.  
            string path = System.Web.HttpContext.Current.Server.MapPath(String.Format(SCENARIO_FILE, fileName));
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            // when we dont reach the end
            List<double[]> pairs = new List<double[]>();
            while ((line = file.ReadLine()) != null)
            {
                // split the line
                string[] arr = line.Split(';');
                double[] pair = new double[2];
                pair[0] = double.Parse(arr[0]);
                pair[1] = double.Parse(arr[1]);
                pairs.Add(pair);
            }
            ViewBag.Pairs = pairs;
            if (counter < pairs.Count) {
                ViewBag.lat = pairs[counter][0];
                ViewBag.lon = pairs[counter][1];
            }
            counter++;
            file.Close();
        }
    }
}