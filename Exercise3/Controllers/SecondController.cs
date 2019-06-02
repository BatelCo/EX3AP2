using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercise3.Models;

namespace Exercise3.Controllers
{
    public class SecondController : Controller
    {
        // GET: Second
        // return web page
        public ActionResult Index()
        {
            return View();
        }

        // the matching view - Display2
        public ActionResult Display2(string ip, int port)
        {

         
            InfoModel.Instance.close_client();
            InfoModel.Instance.connect_client(ip, port);
            ViewBag.lat = float.Parse(InfoModel.Instance.Read("get /position/latitude-deg\r\n"));
            ViewBag.lon = float.Parse(InfoModel.Instance.Read("get /position/longitude-deg\r\n"));

            
            // ViewBag.lat = float.Parse(InfoModel.Instance.Read("get /position/latitude-deg\r\n"));
            // ViewBag.lon = float.Parse(InfoModel.Instance.Read("get /position/longitude-deg\r\n"));
            return View();
        }

    }
}