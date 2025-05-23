using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen3
{
    public partial class Producto : Form
    {
        bool bandera = true;
        public Producto()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public Producto(string id,string nombre,string desc,string precio,string stock,
            string marca,string cod)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            bandera = false;
            txtId.Text = id;
            txtNombre.Text = nombre;
            txtDesc.Text = desc;
            txtPrecio.Text = precio;
            txtStock.Text = stock;
            txtMarca.Text = marca;
            txtCodigo.Text = cod;
            buttonAñadir.Text = "ACTUALIZAR";
            label8.Text = "ACTUALIZAR PRODUCTO";
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();
            if (bandera)
            {
                string consulta = "INSERT INTO producto(id_producto,nombre,descripcion," +
                    "precio,stock,marca,codigo_barras) VALUES(" + txtId.Text + ",'" +
                    txtNombre.Text + "','" + txtDesc.Text + "'," + txtPrecio.Text + "," +
                    txtStock.Text + ",'" + txtMarca.Text + "','" + txtCodigo.Text + "');";
                conexion.consulta(consulta);
                MessageBox.Show("Producto Agregado");
            }
            else
            {
                string consulta = "UPDATE producto \r\nSET nombre = '" + txtNombre.Text +
                    "',descripcion='" + txtDesc.Text +"',precio=" + txtPrecio.Text + 
                    ",stock=" + txtStock.Text + ",marca='" + txtMarca.Text + 
                    "',codigo_barras='"+ txtCodigo.Text + "'\r\nWHERE id_producto =" + txtId.Text +";";
                conexion.consulta(consulta);
                MessageBox.Show("Producto Actualizado");
                this.Close();
            }
        }
    }
}
