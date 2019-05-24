using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fase_1.CAPADATOS;

namespace Fase_1.CAPAPRESENTACION
{
    public partial class Productos : Form
    {
        ClsProductos objProducto = new ClsProductos();
        string Operacion = "Insertar";
        string idprod;

        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            ListarCategorias();
            ListarMarcas();
            ListarProductos();
        }

        private void ListarCategorias()
        {
            ClsProductos objProd = new ClsProductos();
            CmbCategoria.DataSource = objProd.ListarCategorias();
            CmbCategoria.DisplayMember = "Categoria";
            CmbCategoria.ValueMember = "Id_Categ";
        }

        private void ListarMarcas()
        {
            ClsProductos objPro = new ClsProductos();
            CmbMarca.DataSource = objPro.ListarMarcas();
            CmbMarca.DisplayMember = "Marca";
            CmbMarca.ValueMember = "Id_Marca";
        }

        private void CmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objProducto.InsertarProductos(Convert.ToInt32(CmbCategoria.SelectedValue),
                    Convert.ToInt32(CmbMarca.SelectedValue),
                    txtDescripcion.Text,
                    Convert.ToDouble(txtPrecio.Text),
                    txtUbicacion.Text,
                    txtResponsable.Text);
                MessageBox.Show("Agregado Correctamente");
                ListarProductos();
            }
            else if(Operacion == "Editar")
            {
                objProducto.EditarProducto(Convert.ToInt32(idprod),
                    Convert.ToInt32(CmbCategoria.SelectedValue),
                    Convert.ToInt32(CmbMarca.SelectedValue),
                    txtDescripcion.Text,
                    Convert.ToDouble(txtPrecio.Text),
                    txtUbicacion.Text,txtResponsable.Text);
                Operacion = "Insertar";
                MessageBox.Show("Se editaron correctamente los datos");
            }
            ListarProductos();
        }

        private void ListarProductos()
        {
            ClsProductos objPro = new ClsProductos();
            dataGridView1.DataSource = objPro.ListarProductos();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                CmbCategoria.Text = dataGridView1.CurrentRow.Cells["Categoria"].Value.ToString();
                CmbMarca.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtUbicacion.Text = dataGridView1.CurrentRow.Cells["Ubicacion"].Value.ToString();
                txtResponsable.Text = dataGridView1.CurrentRow.Cells["Responsable"].Value.ToString();
                idprod = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void btnEditarf2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MantenimientoProd frm = new MantenimientoProd();
                frm.Operacion = "Editar";
                frm.ListarCategorias();
                frm.ListarMarcas();

                frm.idprod = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                frm.CmbCategoria.Text = dataGridView1.CurrentRow.Cells["Categoria"].Value.ToString();
                frm.CmbMarca.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm.txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                frm.txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frm.txtUbicacion.Text = dataGridView1.CurrentRow.Cells["Ubicacion"].Value.ToString();
                frm.txtResponsable.Text = dataGridView1.CurrentRow.Cells["Responsable"].Value.ToString();

                frm.ShowDialog();

                ListarProductos();
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MantenimientoProd frm = new MantenimientoProd();
            frm.Operacion = "Insertar";
            frm.ListarCategorias();
            frm.ListarMarcas();

            frm.ShowDialog();
            ListarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                objProducto.EliminarProducto(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                MessageBox.Show("Se elimino correctamente");
                ListarProductos();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }
    }
   
}
