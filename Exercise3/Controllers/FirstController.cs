using Exercise3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Exercise3.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        // return web page
        public ActionResult Index()
        {
            return View();
        }

        // the matching view - Display
        public ActionResult Display(string str, int num)
        {
                InfoModel.Instance.close_client();
                InfoModel.Instance.connect_client(str, num);
                ViewBag.lat = double.Parse(InfoModel.Instance.Read("get /position/latitude-deg\r\n"));
                ViewBag.lon = double.Parse(InfoModel.Instance.Read("get /position/longitude-deg\r\n"));
                return View();
        }

        //private ActionResult Display4(string flight, int freq)
        //{
        //    ViewBag.freq = freq;
        //    ReadFromFile(flight);
        //    return View();
        //}
       

        //public void ReadFromFile(string fileName)
        //{
        //    string line;
        //    const string SCENARIO_FILE = "~/App_Data/{0}.txt";
        //    // Read the file and display it line by line.  
        //    string path = System.Web.HttpContext.Current.Server.MapPath(String.Format(SCENARIO_FILE, fileName));
        //    System.IO.StreamReader file = new System.IO.StreamReader(path);
        //    // when we dont reach the end
        //    List<double[]> pairs = new List<double[]>();

        //    while ((line = file.ReadLine()) != null)
        //    {
        //        // split the line
        //        string[] arr = line.Split(';');
        //        double[] pair = new double[2];
        //        pair[0] = double.Parse(arr[0]);
        //        pair[1] = double.Parse(arr[1]);
        //        pairs.Add(pair);
        //    }
        //    ViewBag.Pairs = pairs;
        //    file.Close();
        //}


    }
    //                return RedirectToAction("Display4", new { str, num });
    // if (Regex.IsMatch(str, @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$"))

}