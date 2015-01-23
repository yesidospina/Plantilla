using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Business;
using System.Data;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net;



namespace Presentation.Controles
{
    public partial class ctrlCertificadoCebos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProductos();
                cargarClientes();
            }
        }

        protected void cargarProductos()
        {

            ddlSebosProducto.DataSource = AccesoLogica.ObtenerProductosSebos();
            ddlSebosProducto.DataValueField = "codigoProducto";
            ddlSebosProducto.DataTextField = "nombreProducto";
            ddlSebosProducto.DataBind();
        }

        protected void cargarClientes()
        {
            ddlSebosCliente.DataSource = AccesoLogica.obtenerDespachoCliente();
            ddlSebosCliente.DataValueField = "nombreCliente";
            ddlSebosCliente.DataTextField = "nombreCliente";
            ddlSebosCliente.DataBind();
        }

        protected void btnGuardaSebo_Click(object sender, EventArgs e)
        {
            AccesoLogica insertaSebos = new AccesoLogica();
            
            string fecha = txtFechaSebos.Text;
            DateTime fechaCertificado = Convert.ToDateTime(Funciones.formatoFecha(fecha));
            string destino = ddlSebosCliente.SelectedValue;
            Int32 cantidad = Convert.ToInt32(txtCantidadSebos.Text);
            string vehiculo = txtVehiculoSebos.Text;
            DataTable datatableProducto = AccesoLogica.obtenerNombreProducto(Convert.ToInt32(ddlSebosProducto.SelectedValue));
            string producto = Convert.ToString(datatableProducto.Rows[0]["nombreProducto"]);
            string observaciones = txaObservaciones.Text;
            string humedad = txtHumedad.Text;
            string peroxido = txtPeroxido.Text;
            string acidez = txtAcidez.Text;
            string solidos = txtSolidos.Text;
            int consecutivo = AccesoLogica.obtenerConsecutivoSebos();
            DataTable datatable = AccesoLogica.obtenerNombreUsuario(HttpContext.Current.User.Identity.Name);
            string controlCalidad = Convert.ToString(datatable.Rows[0]["nombreUsuario"]);
            

            if (consecutivo == 0){ consecutivo = 1; }else { consecutivo++; }
            int consecutivoLote = consecutivo;
            

            if (insertaSebos.insertarDespachoSebos(fechaCertificado, destino, cantidad, vehiculo, humedad, peroxido, acidez, controlCalidad, observaciones, consecutivo, consecutivoLote, producto, solidos) > 0)
            {

                if (txtLote1.Text != "" && txtFechaFab_1.Text != "" && txtFechaVence_1.Text != "")
                {
                    DateTime fechaFabricacion1 = Convert.ToDateTime(Funciones.formatoFecha(txtFechaFab_1.Text));
                    DateTime fechaVence1 = Convert.ToDateTime(Funciones.formatoFecha(txtFechaVence_1.Text));
                    insertaSebos.insertarLoteSebos(txtLote1.Text, fechaFabricacion1, fechaVence1, consecutivo);
                }

                if (txtLote2.Text != "" && txtFechaFab_2.Text != "" && txtFechaVence_2.Text != "")
                {
                    DateTime fechaFabricacion2 = Convert.ToDateTime(Funciones.formatoFecha(txtFechaFab_2.Text));
                    DateTime fechaVence2 = Convert.ToDateTime(Funciones.formatoFecha(txtFechaVence_2.Text));
                    insertaSebos.insertarLoteSebos(txtLote2.Text, fechaFabricacion2, fechaVence2, consecutivo);
                }

                if (txtLote3.Text != "" && txtFechaFab_2.Text != "" && txtFechaVence_2.Text != "")
                {
                    DateTime fechaFabricacion3 = Convert.ToDateTime(Funciones.formatoFecha(txtFechaFab_3.Text));
                    DateTime fechaVence3 = Convert.ToDateTime(Funciones.formatoFecha(txtFechaVence_3.Text));
                    insertaSebos.insertarLoteSebos(txtLote3.Text, fechaFabricacion3, fechaVence3, consecutivo);
                }

                if (txtLote4.Text != "" && txtFechaFab_4.Text != "" && txtFechaVence_4.Text != "")
                {
                    DateTime fechaFabricacion4 = Convert.ToDateTime(Funciones.formatoFecha(txtFechaFab_4.Text));
                    DateTime fechaVence4 = Convert.ToDateTime(Funciones.formatoFecha(txtFechaVence_4.Text));
                    insertaSebos.insertarLoteSebos(txtLote4.Text, fechaFabricacion4, fechaVence4, consecutivo);
                }

                if (txtLote5.Text != "" && txtFechaFab_5.Text != "" && txtFechaVence_5.Text != "")
                {
                    DateTime fechaFabricacion5 = Convert.ToDateTime(Funciones.formatoFecha(txtFechaFab_5.Text));
                    DateTime fechaVence5 = Convert.ToDateTime(Funciones.formatoFecha(txtFechaVence_5.Text));
                    insertaSebos.insertarLoteSebos(txtLote5.Text, fechaFabricacion5, fechaVence5, consecutivo);
                }
                FillPDF(consecutivo);
                
            }
        }

        private void FillPDF(int consecutivo)
        {
            
            string pathPDF = Server.MapPath("..\\");
            string plantillaPDF = pathPDF + "\\DocsPdf\\CertificadoSebos.pdf";
            string NewFilePDF = pathPDF + "\\DocsPdf\\CertificadoSebos_" + consecutivo + ".pdf";
            MemoryStream _MemoryStream = new MemoryStream();
            PdfReader reader = new PdfReader(plantillaPDF);
            
            PdfStamper stamper = new PdfStamper(reader, _MemoryStream);
            
            AcroFields pdfFormFields = stamper.AcroFields;

            DataTable datatable = AccesoLogica.obtenerDespachoSebos(consecutivo);
            string fecha = Convert.ToString(datatable.Rows[0]["fechaCertificado"]);
            fecha = fecha.Remove(10);
            string cliente = Convert.ToString(datatable.Rows[0]["destino"]);
            string cantidad = Convert.ToString(datatable.Rows[0]["cantidad"]);
            string placa = Convert.ToString(datatable.Rows[0]["vehiculo"]);
            string humedad = Convert.ToString(datatable.Rows[0]["humedad"]);
            string peroxido = Convert.ToString(datatable.Rows[0]["peroxido"]);
            string acidez = Convert.ToString(datatable.Rows[0]["acidez"]);
            string controlCalidad = Convert.ToString(datatable.Rows[0]["controlCalidad"]);
            string observaciones = Convert.ToString(datatable.Rows[0]["observaciones"]);
            string consec = Convert.ToString(datatable.Rows[0]["consecutivo"]);
            string producto = Convert.ToString(datatable.Rows[0]["producto"]);
            string solidos = Convert.ToString(datatable.Rows[0]["solidos"]);
            

            pdfFormFields.SetField("txtFecha",  fecha);
            pdfFormFields.SetField("txtProducto", producto);
            pdfFormFields.SetField("txtDestino", cliente);
            pdfFormFields.SetField("txtVehiculo", placa);
            pdfFormFields.SetField("txtCantidad", cantidad);
            pdfFormFields.SetField("txtUsuario", controlCalidad);
            pdfFormFields.SetField("txtConsecutivo", consec);
            pdfFormFields.SetField("txtObservaciones", observaciones);
            pdfFormFields.SetField("txtHumedad", humedad);
            pdfFormFields.SetField("txtPeroxido", peroxido);
            pdfFormFields.SetField("txtAcidez", acidez);
            pdfFormFields.SetField("txtSolidos", solidos);


            DataTable datatableLote = AccesoLogica.obtenerLoteSebos(consecutivo);
            
            int cont = 0;
            foreach (DataRow row in datatableLote.Rows)
            {
                int consBD = Convert.ToInt32(datatableLote.Rows[cont]["consecutivo"]);
                string lote = Convert.ToString(datatableLote.Rows[cont]["lote"]);
                string fechaFabrica = Convert.ToString(datatableLote.Rows[cont]["fechaFabricacion"]);
                fechaFabrica = fechaFabrica.Remove(10);
                string fechaVence = Convert.ToString(datatableLote.Rows[cont]["fechaVence"]);
                fechaVence = fechaVence.Remove(10);

                if(consBD == consecutivo)
                {
                    cont++;

                    AccesoLogica insertaHistorial = new AccesoLogica();
                    insertaHistorial.insertarHistorialDespacho(lote, fechaFabrica, fechaVence, "C", consBD, 0);

                    pdfFormFields.SetField("txtLote_" + cont + "", lote);
                    pdfFormFields.SetField("txtFechaFabrica_" + cont + "", fechaFabrica);
                    pdfFormFields.SetField("txtFechaVence_" + cont + "", fechaVence);
                }
            }
            
            stamper.FormFlattening = true;
            stamper.Close();
            reader.Close();
            string certificado = "CertificadoSebos_" + consecutivo + ".pdf";
            AccesoLogica.updateSalidaMemorando();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "~/DocsPdf";
            Response.AddHeader("Content-Disposition", "inline;filename=" + certificado);
            Response.BinaryWrite(_MemoryStream.ToArray());
            Response.Flush();
            Response.Close();
            
         
        }

        protected void btnCalFecha1_Click(object sender, EventArgs e)
        {
            string calcFechaVence = txtFechaFab_1.Text;
            txtFechaVence_1.Text = Convert.ToString(Funciones.calculoFechaVencimientoSebos(calcFechaVence));
            
        }

        protected void btnCalFecha2_Click(object sender, EventArgs e)
        {
            string calcFechaVence = txtFechaFab_2.Text;
            txtFechaVence_2.Text = Convert.ToString(Funciones.calculoFechaVencimientoSebos(calcFechaVence));
        }

        protected void btnCalfecha3_Click(object sender, EventArgs e)
        {
            string calcFechaVence = txtFechaFab_3.Text;
            txtFechaVence_3.Text = Convert.ToString(Funciones.calculoFechaVencimientoSebos(calcFechaVence));
        }

        protected void btnCalfecha4_Click(object sender, EventArgs e)
        {
            string calcFechaVence = txtFechaFab_4.Text;
            txtFechaVence_4.Text = Convert.ToString(Funciones.calculoFechaVencimientoSebos(calcFechaVence));
        }

        protected void btnCalfecha5_Click(object sender, EventArgs e)
        {
            string calcFechaVence = txtFechaFab_5.Text;
            txtFechaVence_5.Text = Convert.ToString(Funciones.calculoFechaVencimientoSebos(calcFechaVence));
        }
    }
}