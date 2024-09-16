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
    public class D_Usuarios
    {
        public DataTable Listado_us()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_ListadoUsuarios", SQLCon);
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
        
        public DataTable Listado_tipoUsuarioCaido()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_ListadoUsuariosCaidos", SQLCon);
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
        public string Guardar_us(int nOpcion, E_Usuarios oUs)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_GuardarUsuarios", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nOpcion",     SqlDbType.Int).Value     = nOpcion;
                Comando.Parameters.Add("@cID_USER",    SqlDbType.Int).Value     = oUs.ID_USER;
                Comando.Parameters.Add("@cUSUARIO",    SqlDbType.VarChar).Value = oUs.USUARIO;
                Comando.Parameters.Add("@cCONTRASEÑA", SqlDbType.VarChar).Value = oUs.CONTRASEÑA;
                Comando.Parameters.Add("@cADMIN",      SqlDbType.Bit).Value     = oUs.ADMIN;
                Comando.Parameters.Add("@cPRESTAMOS",  SqlDbType.Bit).Value     = oUs.PRESTAMOS;
                Comando.Parameters.Add("@cCUENTAS",    SqlDbType.Bit).Value     = oUs.CUENTAS;
                Comando.Parameters.Add("@cTARJETAS",   SqlDbType.Bit).Value     = oUs.TARJETAS;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo registrar los datos";
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
        
        public string Eliminar_us(int ID_USER)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_EliminarUsuarios", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nID_USER", SqlDbType.Int).Value = ID_USER;
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
        
        public string Levantar_UsuarioCaido(int ID_USER)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LevantarUsuarios", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nID_USER", SqlDbType.Int).Value = ID_USER;
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

        public DataTable Login_us(string USUARIO, string CONTRASEÑA)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();

            using (SqlConnection SQLCon = Conexion.getInstancia().CrearConexion())
            {
                try
                {
                    SQLCon.Open();
                    SqlCommand Comando = new SqlCommand("USP_LoginUS", SQLCon);
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.Parameters.Add(new SqlParameter("@USUARIO",    SqlDbType.VarChar)).Value = USUARIO;
                    Comando.Parameters.Add(new SqlParameter("@CONTRASEÑA", SqlDbType.VarChar)).Value = CONTRASEÑA; // Debes aplicar hash a la contraseña antes de pasarla como parámetro.

                    Resultado = Comando.ExecuteReader();
                    Tabla.Load(Resultado);
                    return Tabla;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
                }
            }
        }
    }
}