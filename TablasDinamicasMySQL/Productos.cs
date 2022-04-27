using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablasDinamicasMySQL
{
    class Productos
    {
        private int id;
        private int codigo;
        private string nombre;
        private string descripcion;
        private double precioPublico;
        private int existencia;

        public int Id { get => id; set => id = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double PrecioPublico { get => precioPublico; set => precioPublico = value; }
        public int Existencia { get => existencia; set => existencia = value; }
    }
}
