using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace Prueba_Ene
{
    public class data_requerimiento
    {
        public string Guardar_ar(prop_requerimiento oAr)
        {
            string Rpta = "";
            string query = "";
            int diasPlazo = oAr.dias_plazo;

            MySqlConnection SqlCon = new MySqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                switch (oAr.prioridad)
                {
                    //Prioridad Alta
                    case 1:
                        diasPlazo = 3;
                        oAr.dias_plazo = diasPlazo;
                        break;
                    //Prioridad Media
                    case 2:
                        diasPlazo = 4;
                        oAr.dias_plazo = diasPlazo;
                        break;
                    //Prioridad Baja
                    default:
                        diasPlazo = 5;
                        oAr.dias_plazo = diasPlazo;
                        break;
                }
                query =
                    "INSERT INTO `requerimientos` " + "(`usuario_req`, `descripcion_req`, `prioridad`, " +
                                                                  "`dias_plazo`, `tipo_requerimiento`) " +
                    "VALUES ('"+ oAr.usuario_req        + "','" +
                                 oAr.descripcion        + "', '"+
                                 oAr.prioridad          + "', '" +
                                 oAr.dias_plazo         + "', '" +
                                 oAr.tipo_requerimiento + "');";







                MySqlCommand Comando = new MySqlCommand(query, SqlCon);
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }
    }
}