using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class AccesoDatos
    {


        #region "DataTable"
        public static DataTable ultimoLoteCreado()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "Select * from vs_ultimoLoteCreado";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerLotes()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "Select * from vs_obtenerLotes";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }
        
        public static DataTable obtenerProductos()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "Select * from tblProducto order by nombreProducto";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerProductosSebos()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "Select * from tblProducto where codigoProducto >= 11 and codigoProducto <= 12  order by nombreProducto";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerDespachoCliente()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "Select * from tblCliente order by nombreCliente";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerLotePorTipoLote(string lote)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "Select pr.nombreProducto, lo.* from tblLote lo, tblproducto pr where lo.codigoProducto = pr.codigoProducto and lo.lote = '" + lote + "'";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerEstadosAnalisis()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "Select * from tblEstado order by codigoEstado desc";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerDatosAnalisis(int codigoLote)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select an.proteina AS Proteina, an.Humedad AS humedad, an.grasa AS Grasa, an.Ceniza AS Ceniza, an.Digestibilidad AS Digestibilidad, an.Acidez AS Acidez, an.Peroxido AS Peroxido, an.T10 AS T10, an.Calcio AS Calcio, es.nombreEstado AS Estado, an.codigoEstado AS CodigoEstado, an.organoleptico AS Organoleptico, an.comentario AS Comentario, an.fosforo AS fosforo from tblresultadoanalisis an, tblEstado es where an.codigoEstado = es.codigoEstado and an.codigoLote = " + @codigoLote;
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerProductoDisponible(int codigoProducto)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "SELECT lo.fechaMovimiento AS Fecha, lo.lote AS Lote, lo.salida AS Salida, lo.saldo AS Cantidad_disponible, CAST(SUM(lo.saldo * 40 * 0.001) AS DECIMAL(16,0)) AS Toneladas, an.codigoEstado AS Estado, lo.salida AS salida, lo.salidaMemorando AS SalidaMemorando from tbllote lo, tblresultadoAnalisis an WHERE lo.codigoProducto = " + @codigoProducto + " and an.codigoEstado = 3 AND lo.codigoLote = an.codigoLote AND (lo.saldo >= 0) AND (lo.saldo >= 0) GROUP BY lo.lote, lo.fechaMovimiento, lo.saldo, an.codigoEstado, lo.salida, lo.salidaMemorando";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerProductoDisponible2(int codigoProducto)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "SELECT lo.fechaMovimiento AS Fecha, lo.lote AS Lote, lo.salida AS Salida, lo.saldo AS Cantidad_disponible, CAST(SUM(lo.saldo * 40 * 0.001) AS DECIMAL(16,0)) AS Toneladas, an.codigoEstado AS Estado, lo.salida AS salida, lo.salidaMemorando AS SalidaMemorando from tbllote lo, tblresultadoAnalisis an WHERE lo.codigoProducto BETWEEN " + @codigoProducto + " and 3 and an.codigoEstado = 3 AND lo.codigoLote = an.codigoLote AND (lo.saldo >= 0) AND (lo.saldo >= 0) GROUP BY lo.lote, lo.fechaMovimiento, lo.saldo, an.codigoEstado, lo.salida, lo.salidaMemorando";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }
        
        public static DataTable existenciaTotal() 
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select * from vs_existenciaTotal";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable existenciaDisponible()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select * from vs_existenciaDisponible";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable existenciaPendiente()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select * from vs_existenciaPendiente";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable existenciaRetenida()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select * from vs_existenciaRetenida";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable existenciaReproceso()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select * from vs_existenciaReproceso";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerLotePorProducto(int codigoProducto)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "Select pr.nombreProducto, est.nombreEstado, lo.* from tblLote lo, tblproducto pr, tblResultadoAnalisis ra, tblEstado est where lo.codigoProducto = pr.codigoProducto and ra.codigoEstado = est.codigoEstado and lo.codigoLote = ra.codigoLote and lo.codigoProducto = " + codigoProducto;
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable despachoDatos(int consecutivo) 
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select desp.consecutivo, desp.fechaDespacho, cli.nombreCliente, desp.vehiculo, pr.nombreProducto, desp.cantidadDespacho, desp.cantidadToneladas, desp.temperatura, us.nombreUsuario from tblDespacho desp, tblCliente cli, tblProducto pr, tblUsuario us where desp.codigoProducto = pr.codigoProducto and cli.codigoCliente = desp.codigoCliente and us.codigoUsuario = desp.codigoUsuario and desp.consecutivo = " + consecutivo;
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable despachoLote(int codigoDespacho)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select lo.lote, lo.salida, lo.fechaMovimiento, lo.fechaVencimiento from tblLote lo, tblDespacho desp where lo.codigoDespacho = desp.consecutivo and lo.codigoDespacho = " + codigoDespacho;
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable despachoAnalisis(int codigoDespacho)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select an.proteina, an.humedad, an.grasa, an.ceniza, an.t10, an.acidez, an.peroxido from tblResultadoAnalisis an, tblLote lo where an.codigoLote = lo.codigoLote and lo.codigoDespacho = " + codigoDespacho;
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerNombreUsuario(string login)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select nombreUsuario from tblUsuario where login = '" + login + "'";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerMemorandoLote()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select lote, salidaMemorando from tblLote where salidaMemorando <> 0";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerNombreProducto(int codigoProducto)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select nombreProducto from tblProducto where codigoProducto = "+ codigoProducto;
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerDespachoSebos(int consecutivo)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select * from tblCertificadoCebo where lote = " + consecutivo;
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable obtenerLoteSebos(int consecutivo)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select * from tblLoteSebo where consecutivo = " + consecutivo;
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable informeLoteDespachado(int codigoProucto)
        {
             SqlCommand _comando = MetodoDatos.CrearComando();
             _comando.CommandText = "select hd.lote, hd.fechaMovimiento, sum(hd.cantidadDespacho) AS cantidadDespacho from tblHistorialDespacho hd, tblDespacho dsp where dsp.consecutivo = hd.consecutivo and dsp.codigoProducto =  " + codigoProucto + "group by hd.lote, hd.fechaMovimiento";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable informeLoteDespachadoDetalle(string lote)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select cli.nombreCliente, hdes.cantidadDespacho, CAST((hdes.cantidadDespacho * 40 * 0.001) AS DECIMAL(16,1)) AS Toneladas, desp.fechaDespacho from tblDespacho desp, tblHistorialDespacho hdes, tblCliente cli where hdes.consecutivo = desp.consecutivo and cli.codigoCliente = desp.codigoCliente and hdes.lote = '" + lote + "'";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable informeDespachoPorCliente(int codigoCliente)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select prod.nombreProducto, hdes.lote, hdes.consecutivo, hdes.cantidadDespacho, CAST((hdes.cantidadDespacho * 40 * 0.001) AS DECIMAL(16,1)) AS cantidadToneladas, hdes.fechaMovimiento  from tblDespacho desp, tblProducto prod, tblHistorialDespacho hdes, tblCliente cli where desp.codigoProducto = prod.codigoProducto and hdes.consecutivo = desp.consecutivo and hdes.tipo = 'H' and cli.codigoCliente = desp.codigoCliente and desp.codigoCliente = " + codigoCliente;
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable informeAnalisis(int codigoCliente)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select lot.fechaMovimiento, lot.lote, lot.entrada, ran.proteina, ran.humedad, ran.grasa, ran.calcio, ran.digestibilidad, ran.acidez, ran.peroxido, ran.t10  from tblLote lot, tblResultadoAnalisis ran where lot.codigoLote = ran.codigoLote";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable informeAnalisRangoFecha(string fechaInicial, string fechaFinal)
        {
            SqlCommand _comando = MetodoDatos.informeAnalisisRangoFechas();
            _comando.Parameters.AddWithValue("@fechaInicial", fechaInicial);
            _comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable informeAnalisRangoFechaTodo()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select lot.fechaMovimiento, lot.lote, lot.entrada, (lot.entrada * 40) as Kilos, ran.proteina, ran.humedad, ran.grasa, ran.calcio, ran.ceniza, ran.digestibilidad, ran.acidez, ran.peroxido, ran.t10 from tblLote lot, tblResultadoAnalisis ran where lot.codigoLote = ran.codigoLote order by lot.fechaMovimiento";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable informeDespachoPorDiaTodo()
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select pro.nombreProducto, cli.nombreCliente, desp.cantidadDespacho, desp.consecutivo from tblDespacho desp, tblCliente cli, tblProducto pro where desp.codigoProducto = pro.codigoProducto and desp.codigoCliente = cli.codigoCliente order by pro.nombreProducto";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable informeDespachoPorDia(string fechaInicial, string fechaFinal)
        {
            SqlCommand _comando = MetodoDatos.CrearComando();
            _comando.CommandText = "select pro.nombreProducto, cli.nombreCliente, desp.cantidadDespacho, desp.consecutivo from tblDespacho desp, tblCliente cli, tblProducto pro where desp.codigoProducto = pro.codigoProducto and desp.codigoCliente = cli.codigoCliente and desp.fechaDespacho between '" + fechaInicial + "' and '" + fechaFinal + "' order by pro.nombreProducto";
            return MetodoDatos.EjecutarComandoSelect(_comando);
        }



         


        #endregion
        //-------------------------------------------------------------

        #region "Procedures"
        public int insertaDatosLote(string lote, DateTime fechaMovimiento, DateTime fechaVencimiento, int codigoUsuario, int codigoProducto)
        {
            SqlCommand _comando = MetodoDatos.CrearProcedureInsertLote();
            _comando.Parameters.AddWithValue("@lote", lote);
            _comando.Parameters.AddWithValue("@fechaMovimiento", fechaMovimiento);
            _comando.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
            _comando.Parameters.AddWithValue("@codigoUsuario", codigoUsuario);
            _comando.Parameters.AddWithValue("@codigoProducto", codigoProducto);
            return MetodoDatos.EjecutarComando(_comando);

        }

        public int insertaDatosAnalisis(decimal proteina, decimal humedad, decimal grasa, decimal ceniza, decimal digestibilidad, decimal acidez, decimal peroxido, decimal t10, decimal calcio, int codigoLote, int codigoEstado, string comentario, string organoleptico, decimal fosforo)
        {
            SqlCommand _comando = MetodoDatos.CrearProcedureInsertarAnalisis();
            _comando.Parameters.AddWithValue("@proteina", proteina);
            _comando.Parameters.AddWithValue("@humedad", humedad);
            _comando.Parameters.AddWithValue("@grasa", grasa);
            _comando.Parameters.AddWithValue("@ceniza", ceniza);
            _comando.Parameters.AddWithValue("@digestibilidad", digestibilidad);
            _comando.Parameters.AddWithValue("@acidez", acidez);
            _comando.Parameters.AddWithValue("@peroxido", peroxido);
            _comando.Parameters.AddWithValue("@t10", t10);
            _comando.Parameters.AddWithValue("@calcio", calcio);
            _comando.Parameters.AddWithValue("@codigoLote", codigoLote);
            _comando.Parameters.AddWithValue("@codigoEstado", codigoEstado);
            _comando.Parameters.AddWithValue("@comentario", comentario);
            _comando.Parameters.AddWithValue("@organoleptico", organoleptico);
            _comando.Parameters.AddWithValue("@fosforo", fosforo);

            return MetodoDatos.EjecutarComando(_comando);
        }

        public int updateDatosAnalisis(string proteina, string humedad, string grasa, string ceniza, string digestibilidad, string acidez, string peroxido, string t10, string calcio, int codigoLote, int codigoEstado, string comentario, string organoleptico, string fosforo)
        {
            SqlCommand _comando = MetodoDatos.CrearProcedureUptadeAnalisis();
            _comando.Parameters.AddWithValue("@proteina", proteina);
            _comando.Parameters.AddWithValue("@humedad", humedad);
            _comando.Parameters.AddWithValue("@grasa", grasa);
            _comando.Parameters.AddWithValue("@ceniza", ceniza);
            _comando.Parameters.AddWithValue("@digestibilidad", digestibilidad);
            _comando.Parameters.AddWithValue("@acidez", acidez);
            _comando.Parameters.AddWithValue("@peroxido", peroxido);
            _comando.Parameters.AddWithValue("@t10", t10);
            _comando.Parameters.AddWithValue("@calcio", calcio);
            _comando.Parameters.AddWithValue("@codigoLote", codigoLote);
            _comando.Parameters.AddWithValue("@codigoEstado", codigoEstado);
            _comando.Parameters.AddWithValue("@comentario", comentario);
            _comando.Parameters.AddWithValue("@organoleptico", organoleptico);
            _comando.Parameters.AddWithValue("@fosforo", fosforo);

            return MetodoDatos.EjecutarComando(_comando);
        }

        public int ingresoBultos(string lote, int bultos)
        {
            SqlCommand _comando = MetodoDatos.CrearProcedure_ingresoBultos();
            _comando.Parameters.AddWithValue("@lote", lote);
            _comando.Parameters.AddWithValue("@bultos", bultos);
            return MetodoDatos.EjecutarComando(_comando);
        }
        
        public string obtenerPrefijoProducto(int codigoProducto)
        {
            SqlCommand _comando = MetodoDatos.CrearProcedureObtenerPrefijoProducto();
            _comando.Parameters.AddWithValue("@codigoProducto", codigoProducto);
            return MetodoDatos.EjecutarComandoString(_comando);
        }

        public int obtenerConsecutivoProducto(string prefijo)
        {
            SqlCommand _comando = MetodoDatos.CrearProcedureObtenerConsecutivo();
            _comando.Parameters.AddWithValue("@prefijoProducto", prefijo);
            return MetodoDatos.EjecutarComandoInt(_comando);
        }

        public int actualizarConsecutivoProducto(string prefijo, int consecutivo)
        {
            SqlCommand _comando = MetodoDatos.CrearProcedureActualizarConsecutivoProducto();
            _comando.Parameters.AddWithValue("@prefijoProducto", prefijo);
            _comando.Parameters.AddWithValue("@consecutivo", consecutivo);
            return MetodoDatos.EjecutarComando(_comando);
        }

        public int obteneCodigoLote(string lote)
        {
            SqlCommand _comando = MetodoDatos.CrearProcedureObtenerCodigoLote();
            _comando.Parameters.AddWithValue("@lote", lote);
            return MetodoDatos.EjecutarComandoInt(_comando);
        }

        public int ActualizaDespacho(string lote, int saldo, int salida, int codigoDespacho)
        {
            SqlCommand _comando = MetodoDatos.ActualizaDespacho();
            _comando.Parameters.AddWithValue("@lote", lote);
            _comando.Parameters.AddWithValue("@saldo", saldo);
            _comando.Parameters.AddWithValue("@salida", salida);
            _comando.Parameters.AddWithValue("@codigoDespacho", codigoDespacho);
            return MetodoDatos.EjecutarComando(_comando);
        }

        public int obtenerAnteriorSalidaLote(string lote)
        {
            SqlCommand _comando = MetodoDatos.obtenerAnteriorSalidaLote();
            _comando.Parameters.AddWithValue("@lote", lote);
            return MetodoDatos.EjecutarComandoInt(_comando);
        }

        public int ingresoUsuario(string login, string claveUsuario)
        {
            SqlCommand _comando = MetodoDatos.CrearProcedureIngresoUsuario();
            _comando.Parameters.AddWithValue("@login", login);
            _comando.Parameters.AddWithValue("@claveUsuario", claveUsuario);
            return MetodoDatos.EjecutarComandoInt(_comando);
        }

        public int insertarDespacho(string placa, int cantidadDespacho, int codigoProducto, int codigoCliente, int codigoUsuario, DateTime fechaDespacho, int temperatura, int consecutivo, double cantidadToneladas)
        {
            SqlCommand _comando = MetodoDatos.insertarDespacho();
            _comando.Parameters.AddWithValue("@placa", placa);
            _comando.Parameters.AddWithValue("@cantidadDespacho", cantidadDespacho);
            _comando.Parameters.AddWithValue("@codigoProducto", codigoProducto);
            _comando.Parameters.AddWithValue("@codigoCliente", codigoCliente);
            _comando.Parameters.AddWithValue("@codigoUsuario", codigoUsuario);
            _comando.Parameters.AddWithValue("@fechaDespacho", fechaDespacho);
            _comando.Parameters.AddWithValue("@temperatura", temperatura);
            _comando.Parameters.AddWithValue("@consecutivo", consecutivo);
            _comando.Parameters.AddWithValue("@cantidadToneladas", cantidadToneladas);
            
            
            return MetodoDatos.EjecutarComando(_comando);
        }

        public int obtenerCodigoUsuarioLogin(string login) 
        {
            SqlCommand _comando = MetodoDatos.obtenerCodigoUsuarioLogin();
            _comando.Parameters.AddWithValue("@login", login);
            return MetodoDatos.EjecutarComandoInt(_comando);
        }

        public int consultarExisteDespacho()
        {
            SqlCommand _comando = MetodoDatos.contarDespacho();
            return MetodoDatos.EjecutarComandoInt(_comando);
        }

        public int obtenerConsecutivoDespacho()
        {
            SqlCommand _comando = MetodoDatos.obtenerConsecutivoDespacho();
            return MetodoDatos.EjecutarComandoInt(_comando);
        }

        public int actualizarFechaLote(DateTime fechaMovimiento, DateTime fechaVencimiento, string loteNuevo, string loteAnterior, int codigoUsuario)
        {
            SqlCommand _comando = MetodoDatos.actualizarFechaLote();
            _comando.Parameters.AddWithValue("@fechaMovimiento", fechaMovimiento);
            _comando.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
            _comando.Parameters.AddWithValue("@loteNuevo", loteNuevo);
            _comando.Parameters.AddWithValue("@loteAnterior", loteAnterior);
            _comando.Parameters.AddWithValue("@codigoUsuario", codigoUsuario);
            return MetodoDatos.EjecutarComando(_comando);
            
        }

        public int actualizaSalidaLote(int codigoDespacho)
        {
            SqlCommand _comando = MetodoDatos.actualizaSalidaLote();
            _comando.Parameters.AddWithValue("@codigoDespacho", codigoDespacho);
            return MetodoDatos.EjecutarComando(_comando);
        }

        public int memorandoLote(string lote, string bultos)
        {
            SqlCommand _comando = MetodoDatos.memorandoLote();
            _comando.Parameters.AddWithValue("@lote", lote);
            _comando.Parameters.AddWithValue("@bultos", bultos);
            return MetodoDatos.EjecutarComando(_comando);
        }

        public int updateSalidaMemorando()
        {
            SqlCommand _comando = MetodoDatos.updateSalidaMemorando();
            return MetodoDatos.EjecutarComando(_comando);
        }

        public int obtenerConsecutivoSebos()
        {
            SqlCommand _comando = MetodoDatos.contarCertificadoCebo();
            return MetodoDatos.EjecutarComandoInt(_comando);
        }

        public int insertarDespachoSebos(DateTime fecha, string destino, int cantidad, string vehiculo, string humedad, string peroxido, string acidez, string controlCalidad, string observaciones, int consecutivo, int lote, string producto, string solidos)
        {
            SqlCommand _comando = MetodoDatos.insertarDespachoSebos();
            _comando.Parameters.AddWithValue("@fecha", fecha);
            _comando.Parameters.AddWithValue("@destino", destino);
            _comando.Parameters.AddWithValue("@cantidad", cantidad);
            _comando.Parameters.AddWithValue("@vehiculo", vehiculo);
            _comando.Parameters.AddWithValue("@humedad", humedad);
            _comando.Parameters.AddWithValue("@peroxido", peroxido);
            _comando.Parameters.AddWithValue("@acidez", acidez);
            _comando.Parameters.AddWithValue("@controlCalidad", controlCalidad);
            _comando.Parameters.AddWithValue("@observaciones", observaciones);
            _comando.Parameters.AddWithValue("@consecutivo", consecutivo);
            _comando.Parameters.AddWithValue("@lote", lote);
            _comando.Parameters.AddWithValue("@producto", producto);
            _comando.Parameters.AddWithValue("@solidos", solidos);
            
            

            return MetodoDatos.EjecutarComando(_comando);
        }

        public int insertarLoteSebos(string lote, DateTime fechaFabricacion, DateTime fechaVence, int consecutivo)
        {
            SqlCommand _comando = MetodoDatos.insertarLoteSebos();
            _comando.Parameters.AddWithValue("@lote", lote);
            _comando.Parameters.AddWithValue("@fechaFabricacion", fechaFabricacion);
            _comando.Parameters.AddWithValue("@fechaVence", fechaVence);
            _comando.Parameters.AddWithValue("@consecutivo", consecutivo);
            return MetodoDatos.EjecutarComando(_comando);
        }

        public int insertarHistorialDespacho(string lote, string fechaMovimiento, string fechaVencimiento, string tipo, int consecutivo, int cantidadDespacho)
        {
            SqlCommand _comando = MetodoDatos.insertarHistorialDespacho();
            _comando.Parameters.AddWithValue("@lote", lote);
            _comando.Parameters.AddWithValue("@fechaMovimiento", fechaMovimiento);
            _comando.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
            _comando.Parameters.AddWithValue("@tipo", tipo);
            _comando.Parameters.AddWithValue("@consecutivo", consecutivo);
            _comando.Parameters.AddWithValue("@cantidadDespacho", cantidadDespacho);
            return MetodoDatos.EjecutarComando(_comando);
        }


        #endregion


    }
}
