using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void mostrarDatos()
        {
            Conexion conecta = new Conexion();
            DataSet resultado = conecta.consulta("SELECT id_producto AS 'ID PRODUCTO',nombre AS 'NOMBRE',descripcion AS 'DESCRIPCION',\r\n\t   precio AS 'PRECIO',stock AS 'STOCK',marca AS 'MARCA',codigo_barras AS 'COD. BARRAS'\r\nFROM producto;");
            if (resultado != null)
            {
                dgvInventario.DataSource = resultado.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod.ShowDialog();
            mostrarDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion conecta = new Conexion();
            DataSet resultado = conecta.consulta("SELECT id_producto AS 'ID PRODUCTO',nombre AS 'NOMBRE',descripcion AS 'DESCRIPCION',\r\n\t   precio AS 'PRECIO',stock AS 'STOCK',marca AS 'MARCA',codigo_barras AS 'COD. BARRAS'\r\nFROM producto;");
            if (resultado != null)
            {
                dgvInventario.DataSource = resultado.Tables[0];
            }
        }

        

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dgvInventario.CurrentRow.Index;
            Producto producto = new Producto(dgvInventario.Rows[i].Cells[0].Value.ToString(),
                dgvInventario.Rows[i].Cells[1].Value.ToString(),
                dgvInventario.Rows[i].Cells[2].Value.ToString(),
                dgvInventario.Rows[i].Cells[3].Value.ToString(),
                dgvInventario.Rows[i].Cells[4].Value.ToString(),
                dgvInventario.Rows[i].Cells[5].Value.ToString(),
                dgvInventario.Rows[i].Cells[6].Value.ToString());
            producto.ShowDialog();
            mostrarDatos();
        }

        private void eliminarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int i = dgvInventario.CurrentRow.Index;
            
            string nombre = dgvInventario.Rows[i].Cells[1].Value.ToString();

            DialogResult resultado = MessageBox.Show("¿Seguro que deseas eliminar " +
                nombre + "?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvInventario.Rows[i].Cells[0].Value.ToString());
                    Conexion conexion = new Conexion();
                    conexion.consulta("DELETE FROM producto WHERE id_producto =" + id);
                    MessageBox.Show("Registro Eliminado Con Exito", "REGISTRO",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo Salio Mal" + ex.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            mostrarDatos();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.ShowDialog();
        }
    }
}
