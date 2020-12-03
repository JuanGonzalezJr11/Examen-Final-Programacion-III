using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProgramacionIII.ViewModels
{
    public class AulasFuncionamientoItemVM
    {
        private int numero;
        private string capacidad;
        private float funcionamiento;

        public int Numero { get => numero; set => numero = value; }
        public string Capacidad { get => capacidad; set => capacidad = value; }
        public float Funcionamiento { get => funcionamiento; set => funcionamiento = value; }
    }
}