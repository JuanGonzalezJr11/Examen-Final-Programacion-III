using FinalProgramacionIII.AccesoABaseDeDatos;
using FinalProgramacionIII.Models;
using FinalProgramacionIII.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProgramacionIII.Controllers
{
    public class ComputadoraController : Controller
    {
        public ActionResult NuevaComputadora()
        {
            List<AulasItemVM> listaAulas = BaseDatos_computadora.listaAulas();

            List<SelectListItem> itemsAulas = listaAulas.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Capacidad,
                    Value = a.Numero.ToString(),
                };
            });

            ViewBag.ItemsAulas = itemsAulas;

            return View();
        }

        [HttpPost]
        public ActionResult NuevaComputadora(Computadora c)
        {
            if (ModelState.IsValid)
            {
                bool resultado = BaseDatos_computadora.nuevaComputadora(c);

                if (resultado)
                {
                    return RedirectToAction("NuevaComputadora", "Computadora");
                }
                else
                {
                    return RedirectToAction("NuevaComputadora", "Computadora");
                }
            }
            else
            {
                return RedirectToAction("NuevaComputadora", "Computadora");
            }
        }
    }
}