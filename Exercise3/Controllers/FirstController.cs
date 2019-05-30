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
            return View();
        }
        // only with post call 
        //[HttpPost]
        //public ActionResult IndexPost() {

        // }

    }
}