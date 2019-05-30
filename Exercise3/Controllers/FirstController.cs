using Exercise3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ActionResult actionResult = display("127.0.0.1", 5400);
            Location location = new Location();
            ViewBag.lon = location.Xcordinate;
            ViewBag.lat = location.Ycordinate;
            return actionResult;

        }
        // only with post call 
        //[HttpPost]
        //public ActionResult IndexPost() {

        // }
       
   
        [HttpGet]
        public ActionResult display(string ip, int port)
        {
            InfoModel.Instance.ip = ip;
            InfoModel.Instance.port = port.ToString();


            InfoModel.Instance.ReadData("Dor");


            return View();
        }

    }
}