using ITUniver.TeleCalc.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITUniver.TeleCalc.Web.Models
{
    public class CalcModel
    {
        [Required(ErrorMessage = "Пропустил!")]
        public string opername { get; set; }
        [Required(ErrorMessage = "Пропустил!")]
        public double X { get; set; }
        [Required(ErrorMessage = "Пропустил!")]
        public double Y { get; set; }
        [ReadOnly(true)]
        public double Result { get; set; }

    }
}