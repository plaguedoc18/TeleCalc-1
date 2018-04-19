using ITUniver.TeleCalc.Core;
using ITUniver.TeleCalc.Web.Models;
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
        public ActionResult Exec()
        {
            Calc action = new Calc();
            SelectList opers = new SelectList(action.GetOpers);
            ViewBag.Opers = opers;
            return View();
        }
        [HttpPost]
        public ActionResult Exec(CalcModel model)   //Эта модель заполняется
        {
            Calc action = new Calc();
            if (!string.IsNullOrEmpty(model.opername))
            {
                ViewBag.OperName = model.opername.ToLower();
                ViewBag.x = model.X;
                ViewBag.y = model.Y;
                model.Result = action.Exec(ViewBag.OperName, ViewBag.x, ViewBag.y);
            }
            else
            {
                ViewBag.Error = "Что-то пошло не так!";
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Index(string opername, double? x, double? y)
        {
            Calc action = new Calc();
            if (opername != null && x != null && y != null)
            {
                ViewBag.OperName = opername.ToLower();
                ViewBag.x = x;
                ViewBag.y = y;
                ViewBag.result = action.Exec(ViewBag.OperName, ViewBag.x, ViewBag.y);
            }
            else
            {
                ViewBag.Error = "Что-то пошло не так!";
            }
            return View();
        }
        public ActionResult Operations()
        {
            Calc ForOpers = new Calc();
            ViewBag.opers = ForOpers.GetOpers;
            return View("Ops");
        }
    }
}