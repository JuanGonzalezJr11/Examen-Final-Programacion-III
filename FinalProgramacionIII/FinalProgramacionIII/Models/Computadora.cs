using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProgramacionIII.Models
{
    public class Computadora
    {
        private int numero;
        private int numeroAula;
        private int estado;
        private int funcionamiento;

        public int Numero { get => numero; set => numero = value; }
        public int NumeroAula { get => numeroAula; set => numeroAula = value; }
        public int Estado { get => estado; set => estado = value; }
        public int Funcionamiento { get => funcionamiento; set => funcionamiento = value; }
    }
}