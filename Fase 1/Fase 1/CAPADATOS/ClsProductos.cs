using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Fase_1.CAPADATOS
{
    class ClsProductos
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        public DataTable ListarCategorias()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarCategorias";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarMarcas()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarMarcas";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void InsertarProductos(int idCategoria, int idMarca, string descripcion, double precio, string ubicacion, string responsable)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idcategoria", idCategoria);
            Comando.Parameters.AddWithValue("@idmarca", idMarca);
            Comando.Parameters.AddWithValue("@descripcion", descripcion);
            Comando.Parameters.AddWithValue("@prec", precio);
            Comando.Parameters.AddWithValue("@ubicacion", ubicacion);
            Comando.Parameters.AddWithValue("@responsable", responsable);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public DataTable ListarProductos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void EditarProducto(int idpro, int idCategoria, int idMarca, string descripcion, double precio, string ubicacion, string responsable)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update PRODUCTOS set FkId_Categ="+idCategoria+",FkId_Marca="+idMarca+",Descripcion='"+ descripcion+"',Precio="+precio+",Ubicacion='"+ubicacion+"',Responsable='"+responsable+"' Where Id_Producto=" + idpro;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }

        public void EliminarProducto(int idpro)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete PRODUCTOS where Id_Producto=" + idpro;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }
    }
}
