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
    public partial class ctrlMemorandoDespacho : System.Web.UI.UserControl
    {
        static int _totalFinal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            _totalFinal = 0;

            if (!IsPostBack)
            {
                cargarClientes();
                cargaProductosList();
            }

        }

        protected void cargaProductosList()
        {
            ddlMemorandoProducto.DataSource = AccesoLogica.ObtenerProductos();
            ddlMemorandoProducto.DataValueField = "codigoProducto";
            ddlMemorandoProducto.DataTextField = "nombreProducto";
            ddlMemorandoProducto.DataBind();
        }

        protected void cargarClientes()
        {
            ddlMemorandoCliente.DataSource = AccesoLogica.obtenerDespachoCliente();
            ddlMemorandoCliente.DataValueField = "nombreCliente";
            ddlMemorandoCliente.DataTextField = "nombreCliente";
            ddlMemorandoCliente.DataBind();
        }

        protected void ddlMemorandoProducto_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDespacho();
        }

        protected void gdvProductoDisponible_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvProductoDisponible.PageIndex = e.NewPageIndex;
        }

        protected void gdvProductoDisponible_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvProductoDisponible.EditIndex = e.NewEditIndex;
            cargarDespacho();
        }

        protected void gdvProductoDisponible_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvProductoDisponible.EditIndex = -1;
            cargarDespacho();
        }

        protected void gdvProductoDisponible_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblloteDisponible = (Label)gdvProductoDisponible.Rows[e.RowIndex].FindControl("lblloteDisponible");
            TextBox txtValorDespachar = (TextBox)gdvProductoDisponible.Rows[e.RowIndex].FindControl("txtValorDespachar");

            TextBox lblValorDespachar = (TextBox)gdvProductoDisponible.Rows[e.RowIndex].FindControl("txtValorDespachar");

            int cantDespacho = int.Parse(txtValorDespachar.Text);

            if (cantDespacho > 0)
            {
                if (AccesoLogica.memorandoLote(lblloteDisponible.Text, txtValorDespachar.Text) > 0)
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

        }

        protected void gdvProductoDisponible_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                _totalFinal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SalidaMemorando"));
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
            int codigoProducto = Convert.ToInt32(ddlMemorandoProducto.SelectedValue);
            gdvProductoDisponible.DataSource = AccesoLogica.obtenerProductoDisponible(codigoProducto);
            gdvProductoDisponible.DataBind();
        }

        protected void cargaProductos(string valorSeleccionado)
        {
            ddlMemorandoProducto.SelectedValue = valorSeleccionado;
        }

        protected void btnGuardaMemorando_OnClick(object sender, EventArgs e)
        {
            string fecha = txtFechaMemorando.Text;
            DateTime fechaMemorando = Convert.ToDateTime(Funciones.formatoFecha(fecha));
            string placa = txtVehiculoMemorando.Text;
            string cantidadDespacho = hdfTotalDespacho.Value;
            DataTable datatableProducto = AccesoLogica.obtenerNombreProducto(Convert.ToInt32(ddlMemorandoProducto.SelectedValue));
            string producto = Convert.ToString(datatableProducto.Rows[0]["nombreProducto"]);
            string cliente = ddlMemorandoCliente.SelectedValue;
            DataTable datatable = AccesoLogica.obtenerNombreUsuario(HttpContext.Current.User.Identity.Name);
            string nombreUsuario = Convert.ToString(datatable.Rows[0]["nombreUsuario"]);
            string observaciones = txaObservaciones.Text;

            FillPDF(Convert.ToString(fechaMemorando), placa, cantidadDespacho, producto, cliente, nombreUsuario, observaciones);
            
        }

        private void FillPDF(string fecha, string placa, string cantidadDespacho, string producto, string cliente, string nombreUsuario, string observaciones)
        {
            string pathPDF = Server.MapPath("..\\");
            string plantillaPDF = pathPDF + "\\DocsPdf\\MemorandoDespacho.pdf";
            string NewFilePDF = pathPDF + "\\DocsPdf\\MemorandoDespacho.pdf";
            MemoryStream _MemoryStream = new MemoryStream();
            PdfReader reader = new PdfReader(plantillaPDF);
            PdfStamper stamper = new PdfStamper(reader, _MemoryStream);
            AcroFields pdfFormFields = stamper.AcroFields;

            #region "Memorando Datos"
            
            string txtFecha = fecha;
            txtFecha = txtFecha.Remove(10);
            
            pdfFormFields.SetField("txtFecha", txtFecha);
            pdfFormFields.SetField("txtProducto", producto);
            pdfFormFields.SetField("txtDestino", cliente);
            pdfFormFields.SetField("txtVehiculo", placa);
            pdfFormFields.SetField("txtBultos", cantidadDespacho);
            pdfFormFields.SetField("txtUsuario", nombreUsuario);
            pdfFormFields.SetField("txtDirigido", "Produccion Calidad");
            pdfFormFields.SetField("txtObservaciones", observaciones);

            #endregion

            #region "Memorando Lote"
            DataTable memorandoLote = AccesoLogica.obtenerMemorandoLote();
            
            int cont = 0;
            foreach (DataRow row in memorandoLote.Rows)
            {
                string txtLote = Convert.ToString(row["lote"]);
                string txtsalida = Convert.ToString(row["salidaMemorando"]);
                
                cont++;
                pdfFormFields.SetField("txtLote_" + cont + "", txtLote);
                pdfFormFields.SetField("txtSalida_" + cont + "", txtsalida);
            }

            #endregion
            
            stamper.FormFlattening = true;
            stamper.Close();
            reader.Close();
            AccesoLogica.updateSalidaMemorando();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "~/DocsPdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=Memorando.pdf");
            HttpContext.Current.Response.BinaryWrite(_MemoryStream.ToArray());
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