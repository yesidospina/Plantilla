using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace Presentation.Controles
{
    public partial class ctrlLotePorProducto : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
                cargaProductosList(); 
            }
        }


        protected void ddlProductoLote_OnSelectedIndexChanged(object sender, EventArgs e) 
        {
            int codigoProducto = int.Parse(ddlProductoLote.SelectedValue);
            listarLote(codigoProducto);
        }
        
        protected void cargaProductosList()
        {
            ddlProductoLote.DataSource = AccesoLogica.ObtenerProductos();
            ddlProductoLote.DataValueField = "codigoProducto";
            ddlProductoLote.DataTextField = "nombreProducto";
            ddlProductoLote.DataBind();
        }

        protected void listarLote(int codigoProducto)
        {
            gdvProductoLote.DataSource = AccesoLogica.obtenerLotePorProducto(codigoProducto);
            gdvProductoLote.DataBind();
        }

        protected void gdvProductoLote_PageIndexChanging(object sender, GridViewPageEventArgs e) 
        {
            gdvProductoLote.PageIndex = e.NewPageIndex;
            int codigoProducto = int.Parse(ddlProductoLote.SelectedValue);
            listarLote(codigoProducto);
        }

        protected void gdvProductoLote_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvProductoLote.EditIndex = -1;
            int codigoProducto = int.Parse(ddlProductoLote.SelectedValue);
            listarLote(codigoProducto);
        }

        protected void gdvProductoLote_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvProductoLote.EditIndex = e.NewEditIndex;
            int codigoProducto = int.Parse(ddlProductoLote.SelectedValue);
            listarLote(codigoProducto);
        }

        protected void gdvProductoLote_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AccesoLogica logica = new AccesoLogica();

            Label lbllote = (Label)gdvProductoLote.Rows[e.RowIndex].FindControl("lbllote");
            TextBox txtBultos = (TextBox)gdvProductoLote.Rows[e.RowIndex].FindControl("txtBultos");

            if (txtBultos.Text != "")
            {
                int entradaBultos = Convert.ToInt32(txtBultos.Text);
                if (logica.ingresoBultos(lbllote.Text, entradaBultos) > -1)
                {
                    gdvProductoLote.EditIndex = -1;
                    int codigoProducto = int.Parse(ddlProductoLote.SelectedValue);
                    listarLote(codigoProducto);
                    //Response.Redirect("~/InfoAnalisis/NuevoAnalisis.aspx?lote=" + lbllote.Text.Trim());
                }
            }
        }










        protected void imgBtnAnalizaLote_OnClick(object sender, EventArgs e) 
        {
            
            for (int i = 0; i < gdvProductoLote.Rows.Count; i++)
            {

                CheckBox checkboxSelected = (CheckBox)gdvProductoLote.Rows[i].Cells[i].FindControl("chkLote");
                if(checkboxSelected.Checked)
                {
                    Label lbllote = (Label)gdvProductoLote.Rows[i].Cells[i].FindControl("lbllote");
                    Label lblproducto = (Label)gdvProductoLote.Rows[i].Cells[i].FindControl("lblNombreProducto");
                    Response.Redirect("~/InfoAnalisis/NuevoAnalisis.aspx?lote=" + lbllote.Text.Trim() + "&producto="+lblproducto.Text);
                }
            }
            
        }
        
        



    }
}