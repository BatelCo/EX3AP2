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
            while ((line = file.ReadLine()) != null)
            {
                // split the line
                string[] arr = line.Split(';');
                ViewBag.lat = arr[0];
                ViewBag.lon = arr[1];

            }
            file.Close();
        }
    }
}