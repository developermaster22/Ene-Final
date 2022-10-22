using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Prueba_Ene
{
    internal class Conexion
    {
        //Variables locales para la conexión
        private string Base;
        private string Server;
        private string Port;
        private string User;
        private string Password;
        private static Conexion Con = null;

        //Definir método para la conexión
        private Conexion()
        {
            this.Base = "requerimientos_bd";
            this.Server = "localhost";
            this.Port = "3306";
            this.User = "root";
            this.Password = "";
        }

        public MySqlConnection CrearConexion()
        {
            MySqlConnection Cadena = new MySqlConnection();

            try
            {
                Cadena.ConnectionString = "datasource=" + this.Server +
                                          "; port=" + this.Port +
                                          "; username=" + this.User +
                                          "; password=" + this.Password +
                                          "; database=" + this.Base;
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }

    }
}
