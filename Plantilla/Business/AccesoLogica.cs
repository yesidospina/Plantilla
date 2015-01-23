using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Data;



namespace Business
{
    public class AccesoLogica
    {

        #region "DATATABLE"

        public static DataTable ObtenerUltimoLoteCreado()
        {
            return AccesoDatos.ultimoLoteCreado(); 
        }

        public static DataTable obtenerLotes()
        {
            return AccesoDatos.obtenerLotes();
        }

        public static DataTable ObtenerProductos()
        {
            return AccesoDatos.obtenerProductos();
        }

        public static DataTable ObtenerProductosSebos()
        {
            return AccesoDatos.obtenerProductosSebos();
        }

        public static DataTable obtenerDespachoCliente() 
        {
            return AccesoDatos.obtenerDespachoCliente();
        }

        public static DataTable obtenerLotePorTipoLote(string lote)
        {
            return AccesoDatos.obtenerLotePorTipoLote(lote);
        }

        public static DataTable obtenerEstadosAnalisis()
        {
            return AccesoDatos.obtenerEstadosAnalisis();
        }

        public static DataTable obtenerDatosAnalisis(int codigoLote)
        {
            return AccesoDatos.obtenerDatosAnalisis(codigoLote);
        }

        public static DataTable obtenerProductoDisponible(int codigoProducto)
        {

            DataTable disponible = null;

            if (codigoProducto != 1)
            {
                disponible = AccesoDatos.obtenerProductoDisponible(codigoProducto);
            }
            else {
                disponible = AccesoDatos.obtenerProductoDisponible2(codigoProducto);
            }

            return disponible;
        }

        public static DataTable obtenerExistenciaTotal() 
        {
            return AccesoDatos.existenciaTotal();
        }

        public static DataTable obtenerExistenciaDisponible()
        {
            return AccesoDatos.existenciaDisponible();
        }

        public static DataTable obtenerExistenciaPendiente()
        {
            return AccesoDatos.existenciaPendiente();
        }

        public static DataTable obtenerLotePorProducto(int codigoProducto)
        {
            return AccesoDatos.obtenerLotePorProducto(codigoProducto);
        }

        public static DataTable obtenerExistenciaRetenida()
        {
            return AccesoDatos.existenciaRetenida();
        }

        public static DataTable obtenerExistenciaReproceso()
        {
            return AccesoDatos.existenciaReproceso();
        }

        public static DataTable despachoDatos(int consecutivo)
        {
            return AccesoDatos.despachoDatos(consecutivo);
        }

        public static DataTable despachoLote(int codigoDespacho)
        {
            return AccesoDatos.despachoLote(codigoDespacho);
        }

        public static DataTable despachoAnalisis(int codigoDespacho)
        {
            return AccesoDatos.despachoAnalisis(codigoDespacho);
        }

        public static DataTable obtenerNombreUsuario(string login)
        {
            return AccesoDatos.obtenerNombreUsuario(login);
        }

        public static DataTable obtenerMemorandoLote()
        {
            return AccesoDatos.obtenerMemorandoLote();
        }

        public static DataTable obtenerNombreProducto(int codigoProducto)
        {
            return AccesoDatos.obtenerNombreProducto(codigoProducto);
        }

        public static DataTable obtenerDespachoSebos(int consecutivo)
        {
            return AccesoDatos.obtenerDespachoSebos(consecutivo);
        }

        public static DataTable obtenerLoteSebos(int consecutivo)
        {
            return AccesoDatos.obtenerLoteSebos(consecutivo);
        }

        public static DataTable informeLoteDespachado(int codigoProucto)
        {
            return AccesoDatos.informeLoteDespachado(codigoProucto);
        }

        public static DataTable informeLoteDespachadoDetalle(string lote)
        {
            return AccesoDatos.informeLoteDespachadoDetalle(lote);
        }

        public static DataTable informeDespachoPorCliente(int codigoCliente)
        {
            return AccesoDatos.informeDespachoPorCliente(codigoCliente);
        }

        public static DataTable informeAnalisis(int codigoCliente)
        {
            return AccesoDatos.informeDespachoPorCliente(codigoCliente);
        }

        public static DataTable informeAnalisRangoFecha(string fechaInicial, string fechaFinal)
        {
            fechaInicial = fechaInicial + " 00:00";
            fechaFinal = fechaFinal + " 23:59";
            return AccesoDatos.informeAnalisRangoFecha(fechaInicial.Replace("-",""), fechaFinal.Replace("-",""));
        }

        public static DataTable informeAnalisRangoFechaTodo()
        {
            return AccesoDatos.informeAnalisRangoFechaTodo();
        }

        public static DataTable informeDespachoPorDiaTodo()
        {
            return AccesoDatos.informeDespachoPorDiaTodo();
        }

        public static DataTable informeDespachoPorDia(string fechaInicial, string fechaFinal)
        {
            fechaInicial = fechaInicial + " 00:00";
            fechaFinal = fechaFinal + " 23:59";
            return AccesoDatos.informeDespachoPorDia(fechaInicial.Replace("-", ""), fechaFinal.Replace("-", ""));
        }

        
        #endregion

        // --------------------------------------------------------------------

        #region "PRECEDURE"
        public static string ObtenerPrefijoProducto(int codigoProducto)
        {
            AccesoDatos acceso = new AccesoDatos(); 
            return acceso.obtenerPrefijoProducto(codigoProducto);
        }

        public int insertLote(string lote, DateTime fechaMovimiento, DateTime fechaVencimiento, int codigoUsuario, int codigoProducto)
        {
            AccesoDatos acceso = new AccesoDatos();
            return acceso.insertaDatosLote(lote, fechaMovimiento, fechaVencimiento, codigoUsuario, codigoProducto);
        }

        public int insertAnalisis(decimal proteina, decimal humedad, decimal grasa, decimal ceniza, decimal digestibilidad, decimal acidez, decimal peroxido, decimal t10, decimal calcio, int codigoLote, int codigoEstado, string comentario, string organoleptico, decimal fosforo)
        {
            AccesoDatos acceso = new AccesoDatos();
            return acceso.insertaDatosAnalisis(proteina, humedad, grasa, ceniza, digestibilidad, acidez, peroxido, t10, calcio, codigoLote, codigoEstado, comentario, organoleptico, fosforo);
        }

        public int updateAnalisis(string proteina, string humedad, string grasa, string ceniza, string digestibilidad, string acidez, string peroxido, string t10, string calcio, int codigoLote, int codigoEstado, string comentario, string organoleptico, string fosforo)
        {
            AccesoDatos acceso = new AccesoDatos();
            return acceso.updateDatosAnalisis(proteina, humedad, grasa, ceniza, digestibilidad, acidez, peroxido, t10, calcio, codigoLote, codigoEstado, comentario, organoleptico, fosforo);
        }

        public int ingresoBultos(string lote, int bultos)
        {
            AccesoDatos acceso = new AccesoDatos();
            return acceso.ingresoBultos(lote, bultos);
        }

        public static int ObtenerConsecutivoLote(string prefijoProducto)
        {
            AccesoDatos acceso = new AccesoDatos();
            return acceso.obtenerConsecutivoProducto(prefijoProducto); 
        }

        public static int actualizarConsecutivoProducto(string prefijoProducto, int consecutivo)
        {
            AccesoDatos acceso = new AccesoDatos();
            return acceso.actualizarConsecutivoProducto(prefijoProducto, consecutivo);
        }

        public static int obtenerCodigoLote(string lote)
        {
            AccesoDatos acceso = new AccesoDatos();
            return acceso.obteneCodigoLote(lote); 
        }

        public static int ingresoUsuario(string login, string claveUsuario)
        {
            AccesoDatos acceso = new AccesoDatos();
            return acceso.ingresoUsuario(login, claveUsuario); 
        }

        public static int ActualizaDespacho(string lote, int saldo, int despachoNuevo, int codigoDespacho)
        {
            AccesoDatos acceso = new AccesoDatos();

            int despachoAnterior = acceso.obtenerAnteriorSalidaLote(lote);
            int saldoFinal = 0;
            int despachoTotal = 0;

            if (despachoNuevo > despachoAnterior)
            {
                if (despachoAnterior != 0)
                {
                    despachoTotal = despachoNuevo - despachoAnterior;
                    saldoFinal = saldo - despachoTotal;
                }
                else
                {
                    despachoTotal = despachoNuevo - despachoAnterior;
                    saldoFinal = saldo - despachoTotal;
                }
                
            }
            else
            {
                despachoTotal = despachoAnterior - despachoNuevo;
                saldoFinal = saldo + despachoTotal;
            }
            return acceso.ActualizaDespacho(lote, saldoFinal, despachoNuevo, codigoDespacho);
        }

        public static int insertaDespacho(string placa, int cantidadDespacho, int codigoProducto, int codigoCliente, int codigoUsuario, DateTime fechaDespacho, int temperatura, int consecutivo, double cantidadToneladas)
        {
           AccesoDatos insertDespacho = new AccesoDatos();
           return insertDespacho.insertarDespacho(placa, cantidadDespacho, codigoProducto, codigoCliente, codigoUsuario, fechaDespacho, temperatura, consecutivo, cantidadToneladas);     
        }

        public static int obtenerConsecutivoDespacho()
        {
            AccesoDatos acceso = new AccesoDatos();

            int numero = 0;

            if (acceso.consultarExisteDespacho() > 0)
            {
                numero = acceso.obtenerConsecutivoDespacho();
            }
            else {
                numero = 0;
            }
            return numero;
                        
        }

        public static int obtenerConsecutivoSebos()
        {
            AccesoDatos acceso = new AccesoDatos();

            int numero = 0;

            if (acceso.obtenerConsecutivoSebos() > 0)
            {
                numero = acceso.obtenerConsecutivoSebos();
            }
            else
            {
                numero = 0;
            }
            return numero;

        }

        public static int obtenerCodigoUsuarioLogin(string login) 
        {
            AccesoDatos codigoUsuario = new AccesoDatos();
            return codigoUsuario.obtenerCodigoUsuarioLogin(login);
        }

        public static int actualizarFechaLote(DateTime fechaMovimiento, DateTime fechaVencimiento, string loteNuevo, string loteAnterior, int codigoUsuario)
        {
            AccesoDatos fechaLote = new AccesoDatos();
            return fechaLote.actualizarFechaLote(fechaMovimiento, fechaVencimiento, loteNuevo, loteAnterior, codigoUsuario);
        }

        public static int actualizaSalidaLote(int codigoDespacho)
        {
            AccesoDatos salidaLote = new AccesoDatos();
            return salidaLote.actualizaSalidaLote(codigoDespacho);
        }

        public static int memorandoLote(string lote, string bultos)
        {
            AccesoDatos memorando = new AccesoDatos();
            return memorando.memorandoLote(lote, bultos);                                  
        }

        public static int updateSalidaMemorando()
        {
            AccesoDatos updateMemorando = new AccesoDatos();
            return updateMemorando.updateSalidaMemorando();
        }

        public int insertarDespachoSebos(DateTime fecha, string destino, int cantidad, string vehiculo, string humedad, string peroxido, string acidez, string controlCalidad, string observaciones, int consecutivo, int lote, string producto, string solidos)
        {
            AccesoDatos datosSebos = new AccesoDatos();
            return datosSebos.insertarDespachoSebos(fecha, destino, cantidad, vehiculo, humedad, peroxido, acidez, controlCalidad, observaciones, consecutivo, lote, producto, solidos);
        }

        public int insertarLoteSebos(string lote, DateTime fechaFabricacion, DateTime fechaVence, int consecutivo)
        {
            AccesoDatos insertaLoteSebos = new AccesoDatos();
            return insertaLoteSebos.insertarLoteSebos(lote, fechaFabricacion, fechaVence, consecutivo);
        }

        public int insertarHistorialDespacho(string lote, string fechaMovimiento, string fechaVencimiento, string tipo, int consecutivo, int cantidadDespacho)
        {
            AccesoDatos insertaHistorial = new AccesoDatos();
            return insertaHistorial.insertarHistorialDespacho(lote, fechaMovimiento, fechaVencimiento, tipo, consecutivo, cantidadDespacho);
        }


        #endregion

    }
}
