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
            try
            {
                InfoModel.Instance.close_client();
                InfoModel.Instance.connect_client(str, num);
                ViewBag.lat = double.Parse(InfoModel.Instance.Read("get /position/latitude-deg\r\n"));
                ViewBag.lon = double.Parse(InfoModel.Instance.Read("get /position/longitude-deg\r\n"));
            }
            catch (Exception) { }
            return View();
        }
    }
}