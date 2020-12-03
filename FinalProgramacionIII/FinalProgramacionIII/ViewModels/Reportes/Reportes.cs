using FinalProgramacionIII.AccesoABaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProgramacionIII.ViewModels.Reportes
{
    public class Reportes
    {
        private int cantidad;
        private List<AulasFuncionamientoItemVM> listadoAulasFuncionamiento;

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public List<AulasFuncionamientoItemVM> ListadoAulasFuncionamiento { get => listadoAulasFuncionamiento; set => listadoAulasFuncionamiento = value; }

        public Reportes()
        {
            cantidad = BaseDatos_reportes.cantidadComputadorasEstadoRevision();
            listadoAulasFuncionamiento = new List<AulasFuncionamientoItemVM>();

            cargarLista();
        }

        public void cargarLista()
        {
            listadoAulasFuncionamiento = BaseDatos_reportes.listadoAulasFuncionamiento();
        }
    }
}