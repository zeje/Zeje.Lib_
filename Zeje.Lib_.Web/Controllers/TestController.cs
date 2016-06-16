using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zeje.Core;

namespace Zeje.Lib_.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            int? ID = Request.GetInt_("id");
            DateTime dt = Request.GetDateTime("dt");
            return View();
        }
    }
}