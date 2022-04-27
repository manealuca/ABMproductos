using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablasDinamicasMySQL
{
    class CtrlProductos: Conexion
    {
        public List<Object>consulta(string dato) {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT idProductos,Codigo,Nombre,Descripcion,PrecioPublico,Existencia FROM Productos ORDER BY Nombre ASC ";
            }
            else {
                sql = "SELECT idProductos,Codigo,Nombre,Descripcion,PrecioPublico,Existencia FROM Productos WHERE Codigo LIKE'%" +dato+ "%' OR Nombre LIKE'%" + dato + "%' OR Descripcion LIKE'%" + dato + "%' OR PrecioPublico LIKE'%" + dato + "%' OR Existencia LIKE'%" + dato + "%'  ORDER BY Nombre ASC";
                
            }
            MySqlConnection conexionBd = conection();
            try
            {

                conexionBd.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBd);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Productos _producto = new Productos();
                    //_producto.Id = int.Parse(reader.GetString(0));
                    //_producto.Id =reader[0].ToString();
                    //3 formas distintas de caargar la informacion al reader
                    _producto.Id = int.Parse(reader.GetString("idProductos"));
                    _producto.Codigo = int.Parse(reader.GetString("Codigo"));
                    _producto.Nombre = reader.GetString("Nombre");
                    _producto.Descripcion = reader.GetString("Descripcion");
                    _producto.PrecioPublico = double.Parse(reader.GetString("PrecioPublico"));
                    _producto.Existencia = int.Parse(reader.GetString("Existencia"));
                    lista.Add(_producto);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No pudok establecerse la coneccion con la base de datos" + ex.Message);
            }
            finally {
                conexionBd.Close();
            }
            return lista;
        }

        public bool Insert(Productos datos ) {
            bool flag = false;
            string sql = "INSERT INTO Productos(Codigo,Nombre,Descripcion,PrecioPublico,Existencia)VALUES('"+datos.Codigo+"','"+datos.Nombre+"','"+datos.Descripcion+"','"+datos.PrecioPublico+"','"+datos.Existencia+"')";
            MySqlConnection connectionBd =  conection();

            try {
                connectionBd.Open();
                MySqlCommand comando = new MySqlCommand(sql, connectionBd);
                comando.ExecuteNonQuery();
                flag = true;
            }
            catch (MySqlException ex) {
                Console.WriteLine("Error al insertar" + ex.Message.ToString());
                flag = false;
            }
            finally {
                connectionBd.Close();
            }
            return flag;
        }

        public bool Update(Productos datos)
        {
            bool flag = false;
            string sql = "UPDATE Productos SET Codigo='" + datos.Codigo + "',Nombre='" + datos.Nombre + "',Descripcion='" + datos.Descripcion + "',PrecioPublico='" + datos.PrecioPublico + "',Existencia='" + datos.Existencia + "'WHERE idProductos='" +datos.Id + "'";
            MySqlConnection connectionBd = conection();
            try{
                connectionBd.Open();
                MySqlCommand comando = new MySqlCommand(sql,connectionBd);
                comando.ExecuteNonQuery();
                flag = true;
            }catch (MySqlException ex) {
                Console.WriteLine("Error al modificar el registro"+ex.Message.ToString());
            }
            finally {
                connectionBd.Close();
                flag = false;
            }
            return flag;
        }

        public bool Delete(int id)
        {
            bool flag = false;
            string sql ="DELETE FROM Productos WHERE idProductos='"+id+"'";

            MySqlConnection connectionBd = conection();
            
            try {
                connectionBd.Open();
                MySqlCommand command = new MySqlCommand(sql, connectionBd);
                command.ExecuteNonQuery();
                flag = true;
            }
            catch (MySqlException ex) {
               MessageBox.Show("Error al eliminar el registro "+ ex.Message.ToString());
                flag = false;
            }
            {
                connectionBd.Close();
            }
            return flag;
        }

    }





}
