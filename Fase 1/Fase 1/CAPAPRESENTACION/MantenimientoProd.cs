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
    public partial class MantenimientoProd : Form
    {
        public MantenimientoProd()
        {
            InitializeComponent();
        }
        ClsProductos objProducto = new ClsProductos();
        public string Operacion = "";
        public string idprod;

        public void ListarCategorias()
        {
            ClsProductos objProd = new ClsProductos();
            CmbCategoria.DataSource = objProd.ListarCategorias();
            CmbCategoria.DisplayMember = "Categoria";
            CmbCategoria.ValueMember = "Id_Categ";
        }

        public void ListarMarcas()
        {
            ClsProductos objPro = new ClsProductos();
            CmbMarca.DataSource = objPro.ListarMarcas();
            CmbMarca.DisplayMember = "Marca";
            CmbMarca.ValueMember = "Id_Marca";
        }

        private void MantenimientoProd_Load(object sender, EventArgs e)
        {
            //ListarCategorias();
            //ListarMarcas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
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
                this.Close();
            }
            else if (Operacion == "Editar")
            {
                objProducto.EditarProducto(Convert.ToInt32(idprod),
                    Convert.ToInt32(CmbCategoria.SelectedValue),
                    Convert.ToInt32(CmbMarca.SelectedValue),
                    txtDescripcion.Text,
                    Convert.ToDouble(txtPrecio.Text),
                    txtUbicacion.Text, txtResponsable.Text);
                Operacion = "Insertar";
                MessageBox.Show("Se editaron correctamente los datos");
                this.Close();
            }
        }
    }
}
