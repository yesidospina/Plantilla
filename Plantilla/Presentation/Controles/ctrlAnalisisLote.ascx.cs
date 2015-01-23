using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using System.Data;

namespace Presentation.Controles
{
    public partial class ctrlAnalisisLote : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["lote"] != null || Request.QueryString["producto"] != null)
                {
                    listarLote(Request.QueryString["lote"]);
                    txtBuscarLote.Text = Request.QueryString["lote"];
                    int codigoLote = AccesoLogica.obtenerCodigoLote(Request.QueryString["lote"]);
                    obtenerAnalisis(codigoLote);

                    if(Request.QueryString["producto"] == "H. DE PLUMA HIDROLIZADA" || Request.QueryString["producto"] == "H. DE SANGRE")
                    {
                        lblTamiz.Text = "Retiene Tamiz 12";
                        lblPestina.Text = "Digest. Pestina: 0,02";
                    }
                    else
                    {
                        lblTamiz.Text = "Retiene Tamiz 10";
                        lblPestina.Text = "Digest. Pestina: 0,002";
                    }
                    
                }
                if (Request.QueryString["creado"] == "created")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ANALISIS ALMACENADO CON EXITO')", true);    
                }
                
                obtenerEstadosAnalisis();
            }
        }

        protected void obtenerEstadosAnalisis()
        {
            
            ddlEstado.DataSource = AccesoLogica.obtenerEstadosAnalisis();
            ddlEstado.DataValueField = "codigoEstado";
            ddlEstado.DataTextField = "nombreEstado";
            ddlEstado.DataBind();
        }

        #region buscarLote
        protected void listarLote(string lote)
        {
            gdvAnalisisLote.DataSource = AccesoLogica.obtenerLotePorTipoLote(lote);
            gdvAnalisisLote.DataBind();

            for (int i = 0; i < gdvAnalisisLote.Rows.Count; i++)
            {
                Label lblproducto = (Label)gdvAnalisisLote.Rows[i].Cells[i].FindControl("lblNombreProducto");
                if (lblproducto.Text == "H. DE PLUMA HIDROLIZADA" || lblproducto.Text == "H. DE SANGRE")
                {
                    lblTamiz.Text = "Retiene Tamiz 12";
                }
                else
                {
                    lblTamiz.Text = "Retiene Tamiz 10";
                }

            }
                if (lote != "")
                {
                    int codigoLote = AccesoLogica.obtenerCodigoLote(lote);
                    obtenerAnalisis(codigoLote);
                }
            
        }

        protected void btnBuscar_OnClick(object sender, EventArgs e)
        {
            //gdvAnalisisLote.AutoGenerateEditButton = false;
            string txtLote = txtBuscarLote.Text;
            txtBuscarLote.Text = txtLote;
            listarLote(txtLote);

            if (txtLote != "")
            {
                listarLote(txtBuscarLote.Text);
                int codLote = AccesoLogica.obtenerCodigoLote(txtBuscarLote.Text);
                obtenerAnalisis(codLote);
            }

        }
        #endregion

        #region "calculoAnalisis"
        protected void guardaAnalsis_OnClick(object sender, EventArgs e)
        {

            if (txtBuscarLote.Text.Trim() != "")
            {
                int codigoLote = AccesoLogica.obtenerCodigoLote(txtBuscarLote.Text.Trim());
                string proteina = txtProteina.Text;
                string humedad = txtHumedad.Text;
                string grasa = txtGrasa.Text;
                string ceniza = txtCeniza.Text;
                string digestibilidad = txtPestina.Text;
                string acidez = txtAcidez.Text;
                string peroxido = txtPeroxido.Text;
                string t10 = txtTamiz.Text;
                string calcio = txtCalcio.Text;
                int codigoEstado = Convert.ToInt32(ddlEstado.SelectedValue);
                string organoleptico = ddlCumple.SelectedValue;
                string comentario = txaObservacion.Text;
                string fosforo = txtFosforo.Text;

                AccesoLogica accesosLogica = new AccesoLogica();
                if (codigoEstado > 0)
                {
                    if (accesosLogica.updateAnalisis(proteina, humedad, grasa, ceniza, digestibilidad, acidez, peroxido, t10, calcio, codigoLote, codigoEstado, comentario, organoleptico, fosforo) > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('REGISTROS ALMACENADO CON EXITO')", true);
                        Response.Redirect("~/InfoAnalisis/NuevoAnalisis.aspx?creado=created");
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('DEBE SELECCIONAR EL ESTADO')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('DEBE DIGITAR EL LOTE')", true);
            }
        }
        #endregion

        protected void obtenerAnalisis(int codigoLote)
        {
            DataTable datatable = AccesoLogica.obtenerDatosAnalisis(codigoLote);
            
            txtProteina.Text = Convert.ToString(datatable.Rows[0]["Proteina"]).Replace(",",".");
            txtHumedad.Text = Convert.ToString(datatable.Rows[0]["humedad"]).Replace(",", ".");
            txtGrasa.Text = Convert.ToString(datatable.Rows[0]["Grasa"]).Replace(",", ".");
            txtCeniza.Text = Convert.ToString(datatable.Rows[0]["Ceniza"]).Replace(",", ".");
            txtPestina.Text = Convert.ToString(datatable.Rows[0]["Digestibilidad"]).Replace(",", ".");
            txtAcidez.Text = Convert.ToString(datatable.Rows[0]["Acidez"]).Replace(",", ".");
            txtPeroxido.Text = Convert.ToString(datatable.Rows[0]["Peroxido"]).Replace(",", ".");
            txtTamiz.Text = Convert.ToString(datatable.Rows[0]["T10"]).Replace(",", ".");
            txtCalcio.Text = Convert.ToString(datatable.Rows[0]["Calcio"]).Replace(",", ".");
            ddlEstado.SelectedValue = Convert.ToString(datatable.Rows[0]["CodigoEstado"]).Replace(",", ".");
            txaObservacion.Text = Convert.ToString(datatable.Rows[0]["Comentario"]).Replace(",", ".");
            ddlCumple.SelectedValue = Convert.ToString(datatable.Rows[0]["organoleptico"]).Replace(",", ".");
            txtFosforo.Text = Convert.ToString(datatable.Rows[0]["fosforo"]).Replace(",", ".");
        }

    }
}