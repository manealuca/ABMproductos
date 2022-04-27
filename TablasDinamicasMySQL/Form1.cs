using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablasDinamicasMySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cargarTabla(null);
        }

       
        private void cargarTabla(string dato) {
            List<Productos> productos = new List<Productos>();
            CtrlProductos ctrlProductos = new CtrlProductos();
            DataGrid.DataSource = ctrlProductos.consulta(dato); 

        }

        private void Buscar_Click_1(object sender, EventArgs e)
        {
            string dato = txtBuscar.Text;
            cargarTabla(dato);
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar() {
            txtCodigo.Text = "";
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecioPublico.Text = "";
            txtExistencia.Text = "";

        }
        private void Guardar_Click(object sender, EventArgs e)
        {
            bool flag = false;
            Productos _producto = new Productos();
            _producto.Codigo = int.Parse(txtCodigo.Text);
            _producto.Nombre = txtNombre.Text;
            _producto.Descripcion = txtDescripcion.Text;
            _producto.PrecioPublico = double.Parse(txtPrecioPublico.Text);
            _producto.Existencia = int.Parse(txtExistencia.Text);
            CtrlProductos Ctrl = new CtrlProductos();
            if (txtId.Text != "")
            {
                _producto.Id = int.Parse(txtId.Text);
                flag = Ctrl.Update(_producto);
            }
            else {
                 flag = Ctrl.Insert(_producto);
            }
            if (flag) {
                MessageBox.Show("Registro Guardado");
            }
            limpiar();
            cargarTabla(null);
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            txtId.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Text = DataGrid.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = DataGrid.CurrentRow.Cells[2].Value.ToString();
            txtDescripcion.Text = DataGrid.CurrentRow.Cells[3].Value.ToString();
            txtPrecioPublico.Text = DataGrid.CurrentRow.Cells[4].Value.ToString();
            txtExistencia.Text = DataGrid.CurrentRow.Cells[5].Value.ToString();
            
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            bool flag = false;
            DialogResult result = MessageBox.Show("Seguro que desea elimianr el registro?", "Salir", MessageBoxButtons.YesNoCancel);
             if(result == DialogResult.Yes) { 
                    int id = int.Parse(DataGrid.CurrentRow.Cells[0].Value.ToString());
                    CtrlProductos _Ctrl = new CtrlProductos();
                    flag = _Ctrl.Delete(id);
                if (flag) {
                    MessageBox.Show("Registro elminado correctamente");
                    limpiar();
                    cargarTabla(null);
                }
            }
             
        }
        /*  private void textBox2_TextChanged(object sender, EventArgs e)
{

}*/
    }
}
