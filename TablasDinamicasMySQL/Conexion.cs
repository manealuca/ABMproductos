using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablasDinamicasMySQL
{
    public class Conexion
    {
        public static MySqlConnection conection()
        {
            string server = "localhost";
            string bd = "Tienda";
            string user = "root";
            string password = "********";
            string cadenaConexion = "Database=" + bd + ";Data Source=" + server + ";User Id=" + user + ";Password=" + password + "";
            try
            {
                MySqlConnection conexionBd = new MySqlConnection(cadenaConexion);
                return conexionBd;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error No se pudo establecer la conexion");
                return null;
            }
        }
    }
    
    }

