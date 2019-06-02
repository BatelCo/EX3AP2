using Exercise3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Display(string ip, int port)
        {
            InfoModel.Instance.close_client();
            InfoModel.Instance.connect_client(ip, port);
            ViewBag.lat = float.Parse(InfoModel.Instance.Read("get /position/latitude-deg\r\n"));
            ViewBag.lon = float.Parse(InfoModel.Instance.Read("get /position/longitude-deg\r\n"));
            return View();
        }
        // only with post call 
        //[HttpPost]
        //public ActionResult IndexPost() {

        // }
       
    }
}