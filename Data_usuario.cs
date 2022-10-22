using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;

namespace Prueba_Ene
{
    public class Data_usuario
    {
        public Pro_usuario Login_user(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection SqlCon = new MySqlConnection();
            SqlCon = Conexion.getInstancia().CrearConexion();
            SqlCon.Open();

            string query = "select id_usuario, password, nombre_usuario, id_tipo from usuarios where usuario like @usuario";
            MySqlCommand Comando = new MySqlCommand(query, SqlCon);
            Comando.Parameters.AddWithValue("@usuario", usuario);

            reader = Comando.ExecuteReader();

            Pro_usuario usr = null;

            while (reader.Read())
            {
                usr = new Pro_usuario();
                usr.id_usuario = int.Parse(reader["id_usuario"].ToString());
                usr.password = reader["password"].ToString();
                usr.nombre_usuario = reader["nombre_usuario"].ToString();
                usr.id_tipo= int.Parse(reader["id_tipo"].ToString());

            }
            return usr;
        }
    }
}
