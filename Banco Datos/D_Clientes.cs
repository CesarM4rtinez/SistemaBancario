using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Entidades;

namespace Banco.Datos
{
    public class D_Clientes
    {
        public DataTable Listado_cl(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_ListadoClientes", SQLCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }
        
        public DataTable Listado_ClientesCaidos(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_ListadoClientesCaidos", SQLCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }

        public string Guardar_cl(int nOpcion, E_Clientes oCl)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_GuardarCliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nOpcion",        SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("@nId_cliente",    SqlDbType.Int).Value = oCl.ID_CLIENTE; // Añade el ID_CLIENTE para la actualización
                Comando.Parameters.Add("@nId_Tp_Persona", SqlDbType.Int).Value = oCl.ID_TP_PERSONA;
                Comando.Parameters.Add("@cNom_Cliente",   SqlDbType.VarChar).Value = oCl.NOM_CLIENTE;
                Comando.Parameters.Add("@cApe_Pate_cli",  SqlDbType.VarChar).Value = oCl.APE_PATE_CLIENTE;
                Comando.Parameters.Add("@cApe_Mate_cli",  SqlDbType.VarChar).Value = oCl.APE_MATE_CLIENTE;
                Comando.Parameters.Add("@cDireccion_cli", SqlDbType.VarChar).Value = oCl.DIRECCION_CLIENTE;
                Comando.Parameters.Add("@cTel_Movil_cli", SqlDbType.VarChar).Value = oCl.TEL_CEL_CLIENTE;
                Comando.Parameters.Add("@cTel_Fijo_cli",  SqlDbType.VarChar).Value = oCl.TEL_FIJO_CLIENTE;
                Comando.Parameters.Add("@cDNI_cli",       SqlDbType.VarChar).Value = oCl.DNI;
                Comando.Parameters.Add("@cNom_Cargo_cli", SqlDbType.VarChar).Value = oCl.NOM_CARGO_CLIENTE;
                Comando.Parameters.Add("@nSueldo_cli",    SqlDbType.Int).Value     = oCl.SUELDO;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudieron registrar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Eliminar_cl(int ID_CLIENTE)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_EliminarCliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nID_CLIENTE", SqlDbType.Int).Value = ID_CLIENTE;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar los datos";
            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Levantar_cliente(int ID_CLIENTE)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LevantarCliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nID_CLIENTE", SqlDbType.Int).Value = ID_CLIENTE;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo restablecer el registro";
            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public DataTable TIPO_PERSONA()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_ListadoTipoCliente", SQLCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }
    }
}
