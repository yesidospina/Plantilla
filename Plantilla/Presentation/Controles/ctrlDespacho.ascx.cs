using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text;
using Business;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net;
using System.Data;



namespace Presentation.Controles
{
    public partial class ctrlDespacho : System.Web.UI.UserControl
    {
        static int _totalFinal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            _totalFinal = 0;
            
            if (!IsPostBack)
            {
                cargarClientes();
                cargaProductosList();
                if (Request.QueryString["creado"] == "created")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('DESPACHO GENERADO CON EXITO')", true);
                    
                }
            }
            
        }
        
        protected void cargaProductosList()
        {
            ddlDespachoProducto.DataSource = AccesoLogica.ObtenerProductos();
            ddlDespachoProducto.DataValueField = "codigoProducto";
            ddlDespachoProducto.DataTextField = "nombreProducto";
            ddlDespachoProducto.DataBind();
        }

        protected void cargarClientes()
        {
            ddlDespachoCliente.DataSource = AccesoLogica.obtenerDespachoCliente();
            ddlDespachoCliente.DataValueField = "codigoCliente";
            ddlDespachoCliente.DataTextField = "nombreCliente";
            ddlDespachoCliente.DataBind();
        }

        protected void ddlDespachoProducto_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDespacho();  
        }

        protected void despacho_OnPageIndexChanging(object sender, GridViewPageEventArgs e) 
        {
            gdvProductoDisponible.PageIndex = e.NewPageIndex;
        }
        
        protected void despacho_OnRowEditing(object sender, GridViewEditEventArgs e) 
        {
            gdvProductoDisponible.EditIndex = e.NewEditIndex;
            cargarDespacho();
        }

        protected void despacho_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvProductoDisponible.EditIndex = -1;
            cargarDespacho();
        }

        protected void gdvProductoDisponible_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int clienteDespacho = Convert.ToInt32(ddlDespachoCliente.SelectedValue);
            string fechaDespacho = txtFechaDespacho.Text;
            string placaVehiculo = txtVehiculoDespacho.Text;
            int productoDespacho = Convert.ToInt32(ddlDespachoProducto.SelectedValue);
            Label lblCantidadDisponible = (Label)gdvProductoDisponible.Rows[e.RowIndex].FindControl("lblCantidadDisponible");
            Label lblloteDisponible = (Label)gdvProductoDisponible.Rows[e.RowIndex].FindControl("lblloteDisponible");
            TextBox txtValorDespachar = (TextBox)gdvProductoDisponible.Rows[e.RowIndex].FindControl("txtValorDespachar");
            int cantidadDisponible = int.Parse(lblCantidadDisponible.Text);
            int cantDespacho = int.Parse(txtValorDespachar.Text);

            int codigoDespacho = AccesoLogica.obtenerConsecutivoDespacho();
            if (codigoDespacho == 0) codigoDespacho = 1; else codigoDespacho++;

            if (cantDespacho > 0)
            {
                if (AccesoLogica.ActualizaDespacho(lblloteDisponible.Text, cantidadDisponible, cantDespacho, codigoDespacho) > 0)
                {
                    gdvProductoDisponible.EditIndex = -1;
                    cargarDespacho();
                }
            }
            else 
            {
                gdvProductoDisponible.EditIndex = -1;
                cargarDespacho();
            }
                

            //if (cantidadDisponible >= cantDespacho)
            //{
            //}
            //
            //    gdvProductoDisponible.EditIndex = -1;
            //    cargarDespacho();
            //    Label lblValorDespachar = (Label)gdvProductoDisponible.Rows[e.RowIndex].FindControl("lblCantidadDisponible");
            //    lblCantidadDisponible.BackColor = System.Drawing.Color.Red;
            //}
            
            //Response.Redirect("~/InfoAnalisis/Despacho.aspx?cliente=" + clienteDespacho + "&placa=" + placaVehiculo + "&producto=" + productoDespacho + "&fecha=" + fechaDespacho + "&cantDespacho=" + txtValorDespachar.Text);
        }

        protected void gdvProductoDisponible_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                _totalFinal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "salida"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "TOTAL:";
                e.Row.Cells[5].Text = Convert.ToString(_totalFinal);
                hdfTotalDespacho.Value = Convert.ToString(_totalFinal);
            }
        }

        protected void cargarDespacho()
        {
            int codigoProducto = Convert.ToInt32(ddlDespachoProducto.SelectedValue);
            gdvProductoDisponible.DataSource = AccesoLogica.obtenerProductoDisponible(codigoProducto);
            gdvProductoDisponible.DataBind();
        }

        protected void cargarDespacho(string cantidadDespacho, string producto)
        {
            int codigoProducto = Convert.ToInt32(ddlDespachoProducto.SelectedValue);
            gdvProductoDisponible.DataSource = AccesoLogica.obtenerProductoDisponible(codigoProducto);

        }

        protected void cargaProductos(string valorSeleccionado)
        {
            ddlDespachoProducto.SelectedValue = valorSeleccionado;
        }

        protected void btnGuardaDespacho_OnClick(object sender, EventArgs e) 
        {
            int consecutivo = AccesoLogica.obtenerConsecutivoDespacho();
            if(consecutivo == null) consecutivo = 1; else consecutivo++;
            
            string fecha = txtFechaDespacho.Text;
            DateTime fechaDespacho =Convert.ToDateTime(Funciones.formatoFecha(fecha));
            string placa = txtVehiculoDespacho.Text;
            int cantidadDespacho = int.Parse(hdfTotalDespacho.Value);
            int codigoProducto = int.Parse(ddlDespachoProducto.SelectedValue);
            int codigoCliente = int.Parse(ddlDespachoCliente.SelectedValue);
            int temperatura = int.Parse(txtTemperatura.Text);
            string loginUsuario = HttpContext.Current.User.Identity.Name;
            int codigoUsuario = AccesoLogica.obtenerCodigoUsuarioLogin(loginUsuario);
            double cantidadToneladas = cantidadDespacho * 40 * 0.001;
            

            if (AccesoLogica.insertaDespacho(placa, cantidadDespacho, codigoProducto, codigoCliente, codigoUsuario, fechaDespacho, temperatura, consecutivo, cantidadToneladas) > 0)
            {
                FillPDF(consecutivo);
            }
        }

        private void FillPDF(int consecutivo)
        {
            //DateTime hoy = DateTime.Now;
            
            string pathPDF = Server.MapPath("..\\");
            string plantillaPDF = pathPDF + "\\DocsPdf\\CertificadoHarinas.pdf";
            string NewFilePDF = pathPDF + "\\DocsPdf\\CertificadoHarinas_" + consecutivo + ".pdf";
            MemoryStream _MemoryStream = new MemoryStream();
            PdfReader reader = new PdfReader(plantillaPDF);
            PdfStamper stamper = new PdfStamper(reader, _MemoryStream);
            AcroFields pdfFormFields = stamper.AcroFields;
                      

            #region "Despacho Datos"
            DataTable despachoDatos = AccesoLogica.despachoDatos(consecutivo);
            
            string txtConsecutivo = Convert.ToString(despachoDatos.Rows[0]["consecutivo"]);
            string txtFecha = Convert.ToString(despachoDatos.Rows[0]["fechaDespacho"]);
            txtFecha = txtFecha.Remove(10);
            string txtProducto = Convert.ToString(despachoDatos.Rows[0]["nombreProducto"]);
            string txtDestino = Convert.ToString(despachoDatos.Rows[0]["nombreCliente"]);
            string txtVehiculo = Convert.ToString(despachoDatos.Rows[0]["vehiculo"]);
            string txtToneladas = Convert.ToString(despachoDatos.Rows[0]["cantidadToneladas"]);
            string txtBultos = Convert.ToString(despachoDatos.Rows[0]["cantidadDespacho"]);
            string txtTemperatura = Convert.ToString(despachoDatos.Rows[0]["temperatura"]);
            string txtUsuario = Convert.ToString(despachoDatos.Rows[0]["nombreUsuario"]);


            if (txtProducto == "H. DE PLUMA HIDROLIZADA" || txtProducto == "H. DE SANGRE")
            {
                pdfFormFields.SetField("txtNumTamiz", "12:");
            }
            else {
                pdfFormFields.SetField("txtNumTamiz", "10:");
            }

            pdfFormFields.SetField("txtConsecutivo", txtConsecutivo);
            pdfFormFields.SetField("txtFecha", txtFecha);
            pdfFormFields.SetField("txtProducto", txtProducto);
            pdfFormFields.SetField("txtDestino", txtDestino);
            pdfFormFields.SetField("txtVehiculo", txtVehiculo);
            pdfFormFields.SetField("txtCantidad", txtToneladas);
            pdfFormFields.SetField("txtBultos", txtBultos);
            pdfFormFields.SetField("txtTemperatura", txtTemperatura);
            pdfFormFields.SetField("txtUsuario", txtUsuario);


            #endregion

            #region "Despacho Lote"
            DataTable despachoLote = AccesoLogica.despachoLote(consecutivo);

            int cont = 0;
            foreach (DataRow row in despachoLote.Rows)
            {
                string txtLote = Convert.ToString(row["lote"]);
                string txtsalida = Convert.ToString(row["salida"]);
                string txtFechaMovimiento = Convert.ToString(row["fechaMovimiento"]);
                txtFechaMovimiento = txtFechaMovimiento.Remove(10);
                string txtFechaVencimiento = Convert.ToString(row["fechaVencimiento"]);
                txtFechaVencimiento = txtFechaVencimiento.Remove(10);

                AccesoLogica insertaHistorial = new AccesoLogica();
                insertaHistorial.insertarHistorialDespacho(txtLote, txtFechaMovimiento, txtFechaVencimiento, "H", Convert.ToInt32(consecutivo), Convert.ToInt32(txtsalida));
                

                cont++;
                pdfFormFields.SetField("txtLote_"+ cont +"", txtLote.Substring(1));
                pdfFormFields.SetField("txtSalida_" + cont + "", txtsalida);
                pdfFormFields.SetField("txtFechaMovimiento_" + cont + "", txtFechaMovimiento);
                pdfFormFields.SetField("txtFechaVencimiento_" + cont + "", txtFechaVencimiento);

            }
            
            #endregion

            #region "Despacho Analisis"
            DataTable despachoAnalisis = AccesoLogica.despachoAnalisis(consecutivo);

            string txtProteina = Convert.ToString(despachoAnalisis.Rows[0]["proteina"]);
            string txtHumedad = Convert.ToString(despachoAnalisis.Rows[0]["humedad"]);
            string txtGrasa = Convert.ToString(despachoAnalisis.Rows[0]["grasa"]);
            string txtCeniza = Convert.ToString(despachoAnalisis.Rows[0]["ceniza"]);
            string txtTamiz = Convert.ToString(despachoAnalisis.Rows[0]["t10"]);
            string txtAcidez = Convert.ToString(despachoAnalisis.Rows[0]["acidez"]);
            string txtPeroxido = Convert.ToString(despachoAnalisis.Rows[0]["peroxido"]);

            pdfFormFields.SetField("txtProteina", txtProteina);
            pdfFormFields.SetField("txtHumedad", txtHumedad);
            pdfFormFields.SetField("txtGrasa", txtGrasa);
            pdfFormFields.SetField("txtCeniza", txtCeniza);
            pdfFormFields.SetField("txtTamiz", txtTamiz);
            pdfFormFields.SetField("txtAcidez", txtAcidez);
            pdfFormFields.SetField("txtPeroxido", txtPeroxido);

            #endregion


            stamper.FormFlattening = true;
            stamper.Close();
            reader.Close();
            
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "~/DocsPdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=CertificadoHarinas_" + txtConsecutivo + ".pdf"); 
            HttpContext.Current.Response.BinaryWrite(_MemoryStream.ToArray());
            AccesoLogica.actualizaSalidaLote(Convert.ToInt32(txtConsecutivo));
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.Expires = 0;
            //HttpContext.Current.Response.Redirect("~/InfoAnalisis/Despacho.aspx?creado=created", true);

            //Response.CacheControl = "no-cache" 
            //Response.AddHeader("Pragma", "No-Cache") 
            //Response.Expires = 0 


            //HttpContext.Current.Response.RedirectPermanent("~/InfoAnalisis/Despacho.aspx?creado=created", true);
            //HttpContext.Current.Response.Redirect("~/InfoAnalisis/Despacho.aspx?creado=created");
            //Response.Redirect("");
            
            
        }

    }
}



//select desp.consecutivo, desp.fechaDespacho, cli.nombreCliente, desp.vehiculo, pr.nombreProducto, 
//       desp.cantidadDespacho, desp.cantidadToneladas, desp.temperatura, us.nombreUsuario    
//from tblDespacho desp, tblCliente cli, tblProducto pr, tblUsuario us
//where desp.codigoProducto = pr.codigoProducto and cli.codigoCliente = desp.codigoCliente
//      and us.codigoUsuario = desp.codigoUsuario and desp.consecutivo = 1 
      
//select lo.lote, lo.salida, lo.fechaMovimiento, lo.fechaVencimiento    
//from tblLote lo, tblDespacho desp   
//where lo.codigoDespacho = desp.consecutivo and lo.codigoDespacho = 1


//select an.proteina, an.humedad, an.grasa, an.ceniza, an.t10 
//from tblResultadoAnalisis an, tblLote lo where an.codigoLote = lo.codigoLote and lo.codigoDespacho = 1

//--------------------------------------------

//protected void imprimirDespacho(string fecha, string placa)
//        {
//            var doc = new Document(new Rectangle(100f, 300f));
//            var titlefont = FontFactory.GetFont("Arial", 5, Font.NORMAL);

//            string path = Server.MapPath("~/DocsPdf");
//            PdfWriter.GetInstance(doc, new FileStream(path + "/Despacho.pdf", FileMode.Create));
//            doc.Open();
//            doc.Add(new Paragraph(fecha, titlefont));
//            doc.Add(new Paragraph(placa, titlefont));
//            doc.Close();
//        }



//string pathPDF = Server.MapPath("..\\");
//            pathPDF = pathPDF + "\\DocsPdf\\Despacho.pdf";


//            //MemoryStream _MemoryStream = new MemoryStream();
//            PdfReader reader = new PdfReader(pathPDF);
//            PdfStamper stamper = new PdfStamper(reader, _MemoryStream);

//            stamper.Writer.Add(despacho);

            
//            stamper.FormFlattening = true;
//            stamper.Close();

//            HttpContext.Current.Response.ClearContent();
//            HttpContext.Current.Response.ClearHeaders();
//            HttpContext.Current.Response.ContentType = "~/DocsPdf";
//            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=recibo.pdf");
//            //HttpContext.Current.Response.BinaryWrite(_MemoryStream.ToArray());
//            HttpContext.Current.Response.End();
// http://www.codeproject.com/Articles/23112/Fill-in-PDF-Form-Fields-using-the-Open-Source-iTex