using FinalProgramacionIII.ViewModels.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProgramacionIII.Controllers
{
    public class ReportesController : Controller
    {
        public ActionResult Reportes()
        {
            Reportes resultado = new Reportes();
            return View(resultado);
        }
    }
}