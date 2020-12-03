using FinalProgramacionIII.Models;
using FinalProgramacionIII.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProgramacionIII.AccesoABaseDeDatos
{
    public class BaseDatos_computadora
    {
        public static bool nuevaComputadora(Computadora c)
        {
            bool resultado = false;

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["conexion"].ToString();

            SqlConnection conex = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand command = new SqlCommand();

                string consulta = "INSERT INTO Computadoras VALUES (@NumeroAula, @Estado, @Funcionamiento)";

                command.Parameters.Clear();
                command.Parameters.AddWithValue("@NumeroAula", c.NumeroAula);
                command.Parameters.AddWithValue("@Estado", c.Estado);
                command.Parameters.AddWithValue("@Funcionamiento", c.Funcionamiento);

                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = consulta;

                conex.Open();

                command.Connection = conex;

                command.ExecuteNonQuery();

                resultado = true;
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

        public static List<AulasItemVM> listaAulas()
        {
            List<AulasItemVM> resultado = new List<AulasItemVM>();

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["conexion"].ToString();

            SqlConnection conex = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand command = new SqlCommand();

                string consulta = "SELECT * FROM Aulas";

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
                        AulasItemVM a = new AulasItemVM();
                        a.Numero = int.Parse(lector["Numero"].ToString());
                        a.Capacidad = lector["Capacidad"].ToString();

                        resultado.Add(a);
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