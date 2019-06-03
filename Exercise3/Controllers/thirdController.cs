﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercise3.Models;

namespace Exercise3.Controllers
{
    public class ThirdController : Controller
    {
        // GET: third
        public ActionResult Index()
        {
            return View();
        }

        // the matching view - Display3
        public ActionResult Display3(string ip, int port, int freq, int time)
        {
            InfoModel.Instance.close_client();
            InfoModel.Instance.connect_client(ip, port);
            ViewBag.freq = freq;
            ViewBag.time = time;
            ViewBag.lat = double.Parse(InfoModel.Instance.Read("get /position/latitude-deg\r\n"));
            ViewBag.lon = double.Parse(InfoModel.Instance.Read("get /position/longitude-deg\r\n"));
            ViewBag.throttle = double.Parse(InfoModel.Instance.Read("get /controls/engines/current-engine/throttle\r\n"));
            ViewBag.rudder = double.Parse(InfoModel.Instance.Read("get /controls/flight/rudder\r\n"));
            WriteToFile(ViewBag.lat, ViewBag.lon, ViewBag.throttle, ViewBag.rudder);
            return View();
        }

        public void WriteToFile(double lat, double lon, double throttle, double rudder)
        {
            using (StreamWriter writetext = new StreamWriter("C:/Users/yonis/Desktop/Computer Science/Coding2/Exercise3/Exercise3/App_Data/data.txt", true))
            {
                writetext.WriteLine(lat + ";" + lon + ";" + throttle + ";" + rudder);
                writetext.AutoFlush = true;
                writetext.Close();
            }           
        }
    }
}