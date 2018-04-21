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
        Calc action = new Calc();
        [HttpGet]
        public ActionResult Exec()
        {
            ViewBag.Opers = new SelectList(Calc.GetOpers);
            return View();
        }
        [HttpPost]
        public ActionResult Exec(CalcModel model)   //Эта модель заполняется
        {
            model.Result = double.NaN;
            if (!string.IsNullOrEmpty(model.opername))
            {
                ViewBag.Opers = new SelectList(Calc.GetOpers);
                model.Result = action.Exec(model.opername.ToLower(), model.X, model.Y);
            }
            else
            {
                ViewBag.Error = "Что-то пошло не так!";
                model.Result = double.NaN;
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
            ViewBag.opers = Calc.GetOpers;
            return View();
        }
    }
}