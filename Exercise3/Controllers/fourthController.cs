using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Display4()
        {
            //        InfoModel.Instance.close_client();
            //        InfoModel.Instance.connect_client(ip, port);
            //        ViewBag.lat = float.Parse(InfoModel.Instance.Read("get /position/latitude-deg\r\n"));
            //        ViewBag.lon = float.Parse(InfoModel.Instance.Read("get /position/longitude-deg\r\n"));
            return View();
        }
    }
}