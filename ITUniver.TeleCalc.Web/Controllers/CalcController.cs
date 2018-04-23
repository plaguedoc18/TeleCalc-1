using ITUniver.TeleCalc.Core;
using ITUniver.TeleCalc.Core.Operations;
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
        private Calc action { get; set; }
        public CalcController()
        {
            action = new Calc();
        }
        [HttpGet]
        public ActionResult Exec()
        {
            var model = new CalcModel();
            model.OperationList = new SelectList(action.GetOpers());
            return View(model);
        }
        [HttpPost]
        public PartialViewResult Exec(CalcModel model)   //Эта модель заполняется
        {
            var result = double.NaN;
            if (action.GetOpers().Contains(model.opername))
            {
                result = action.Exec(model.opername, model.InputData);
            }
            return PartialView("_Result", result);
        }
        [HttpGet]
        public ActionResult Index(string opername, double? x, double? y)
        {
            if (action.GetOpers().Contains(opername))
            {
                ViewBag.OperName = opername.ToLower();
                ViewBag.x = x;
                ViewBag.y = y;
                ViewBag.result = action.Exec(opername, new [] { x ?? 0, y ?? 0 });
            }
            else
            {
                ViewBag.Error = "Что-то пошло не так!";
            }
            return View();
        }
        public ActionResult Operations()
        {
            ViewBag.opers = action.GetOpers();
            return View();
        }
    }
}