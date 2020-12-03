using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProgramacionIII.ViewModels
{
    public class AulasItemVM
    {
        private int numero;
        private string capacidad;

        public int Numero { get => numero; set => numero = value; }
        public string Capacidad { get => capacidad; set => capacidad = value; }
    }
}