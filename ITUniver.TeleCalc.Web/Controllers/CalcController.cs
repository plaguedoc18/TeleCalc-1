using ITUniver.TeleCalc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITUniver.TeleCalc.Web.Controllers
{
    public class CalcController : Controller
    {
        [HttpGet]
        public ActionResult Index(string opername, double? x, double? y)
        {
            Calc action = new Calc();
            if (opername != null) ViewBag.OperName = opername.ToLower();
            ViewBag.x = x;
            ViewBag.y = y;
            ViewBag.result = action.Exec(ViewBag.OperName, ViewBag.x, ViewBag.y);
            return View();
        }
        public ActionResult Operations()
        {
            Calc ForOpers = new Calc();
            foreach(string elem in ForOpers.GetOpers)
            {
                ViewBag.opers += elem + "\t";
            }
            return View();
        }
    }
}