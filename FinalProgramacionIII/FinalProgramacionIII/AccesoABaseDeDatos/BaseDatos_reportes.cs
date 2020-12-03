using FinalProgramacionIII.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProgramacionIII.AccesoABaseDeDatos
{
    public class BaseDatos_reportes
    {
        public static int cantidadComputadorasEstadoRevision()
        {
            int cantidad = 0;

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["conexion"].ToString();

            SqlConnection conex = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand command = new SqlCommand();

                string consulta = @"SELECT COUNT(*) AS 'CantidadRevision'
                                    FROM Computadoras c
                                    WHERE estado = 2";

                command.Parameters.Clear();

                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = consulta;

                conex.Open();

                command.Connection = conex;

                SqlDataReader lector = command.ExecuteReader();

                if (lector != null)
                {
                    if (lector.Read())
                    {
                        cantidad = int.Parse(lector["CantidadRevision"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conex.Close();
            }

            return cantidad;
        }

        public static List<AulasFuncionamientoItemVM> listadoAulasFuncionamiento()
        {
            List<AulasFuncionamientoItemVM> resultado = new List<AulasFuncionamientoItemVM>();

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["conexion"].ToString();

            SqlConnection conex = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand command = new SqlCommand();

                string consulta = @"SELECT a.Numero, Capacidad, AVG(Funcionamiento) AS 'FuncionamientoComputadoras'
                                    FROM Aulas a JOIN Computadoras c ON a.Numero = c.NumeroAula
                                    GROUP BY a.Numero, Capacidad";

                command.Parameters.Clear();

                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = consulta;

                conex.Open();

                command.Connection = conex;

                SqlDataReader lector = command.ExecuteReader();

                if (lector != null)
                {
                    while (lector.Read())
                    {
                        AulasFuncionamientoItemVM af = new AulasFuncionamientoItemVM();
                        af.Numero = int.Parse(lector["Numero"].ToString());
                        af.Capacidad = lector["Capacidad"].ToString();
                        af.Funcionamiento = float.Parse(lector["FuncionamientoComputadoras"].ToString());
                        
                        resultado.Add(af);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conex.Close();
            }

            return resultado;
        }
    }
}