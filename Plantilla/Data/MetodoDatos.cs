using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class MetodoDatos
    {
        #region CrearComando
        /*Este metodo nos servira para crear un comando sql estandard como un select 
         * el cual sera regresado por su metodo return */

        public static SqlCommand CrearComando()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand _comando = new SqlCommand();
            _comando = _conexion.CreateCommand();
            _comando.CommandType = CommandType.Text;
            return _comando;
        }
        #endregion

        #region CrearComandoProcedure
        /*Este metodo al igual que el anterior nos crea un comando sql, 
         *pero con la diferencia que este metodo nos creara nuestro comando
         *de manera que pueda ejecutar los procedimientos almacenados. */

        public static SqlCommand CrearProcedureInsertLote()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_dataInsertLote", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand CrearProcedureInsertarAnalisis()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_insertarAnalisis", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand CrearProcedureUptadeAnalisis()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_updateAnalisis", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand CrearProcedureUpdate()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_dataUpdate", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand CrearProcedureObtenerPrefijoProducto()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_obtenerPrefijoProducto", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand CrearProcedure_ingresoBultos() 
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_ingresoBultos", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand CrearProcedureObtenerConsecutivo()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_obtenerConsecutivoLote", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand CrearProcedureActualizarConsecutivoProducto()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_updateConsecutivoProducto", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand CrearProcedureObtenerCodigoLote() 
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_obtenerCodigoLote", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand CrearProcedureIngresoUsuario()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_ingresoUsuario", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand ActualizaDespacho()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_actualizarDespacho", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand obtenerAnteriorSalidaLote()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_obtenerAnteriorSalidaLote", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand obtenerSaldoDisponible()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_obtenerSaldoDisponible", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand insertarDespacho()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_insertarDespacho", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand obtenerCodigoUsuarioLogin()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_obtenerCodigoUsuarioLogin", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand obtenerConsecutivoDespacho()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_consecutivoDespacho", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand contarDespacho()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_contarDespacho", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand contarCertificadoCebo()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_contarCertificadoCebo", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }
        
        public static SqlCommand actualizarFechaLote()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_actualizarFechaLote", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand actualizaSalidaLote()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_actualizaSalidaLote", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand memorandoLote()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_memorandoLote", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand updateSalidaMemorando()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_updateSalidaMemorando", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand insertarDespachoSebos()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_insertarDespachoSebo", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand insertarLoteSebos()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_insertarLoteSebo", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand insertarHistorialDespacho()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_ingresarHistorialDespacho", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static SqlCommand informeAnalisisRangoFechas()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);

            SqlCommand _comando = new SqlCommand("sp_informeAnalisisRangoFecha", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }



        
        #endregion

        #region EjecutarComando

        /*Este metodo obtiene como parametro un comando sql que proviene
         * de el metodo anterior CrearComandoProc, este metodo ejecuta el
         * procedimineto almacenado que se le ha asignado al comando. */

        public static int EjecutarComando(SqlCommand comando)
        {
            try
            {
                comando.Connection.Open();
                return comando.ExecuteNonQuery();
            }
            catch { throw; }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
        }

       
        public static string EjecutarComandoString(SqlCommand comando)
        {
            try
            {
                comando.Connection.Open(); 
                string codigoProducto = (string)comando.ExecuteScalar();
                return codigoProducto;
            }
            catch { throw; }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
        }

        public static int EjecutarComandoInt(SqlCommand comando)
        {
            try
            {
                comando.Connection.Open();
                int consecutivo= (int)comando.ExecuteScalar();
                return consecutivo;
            }
            catch { throw; }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
        }

        
        #endregion

        #region EjecutarComandoSelect

        /*Este metodo ejecutara un comando select el cual nos regresara un datatable
         *con todos los registros que se encuentren en alguna tabla dada, toma como
         *parametro el comando que contiene la sentencia sql select. */

        public static DataTable EjecutarComandoSelect(SqlCommand comando)
        {
            DataTable _tabla = new DataTable();
            try
            {

                comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(_tabla);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            { comando.Connection.Close(); }
            return _tabla;

        }
        #endregion

    }
}
