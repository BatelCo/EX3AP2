using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Display3(string ip, int port)
        {
            //        InfoModel.Instance.close_client();
            //        InfoModel.Instance.connect_client(ip, port);
            //        ViewBag.lat = float.Parse(InfoModel.Instance.Read("get /position/latitude-deg\r\n"));
            //        ViewBag.lon = float.Parse(InfoModel.Instance.Read("get /position/longitude-deg\r\n"));
            return View();
        }

    }
}