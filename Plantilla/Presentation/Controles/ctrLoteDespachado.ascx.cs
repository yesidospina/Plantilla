using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace Presentation.Controles
{
    public partial class ctrLoteDespachado : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaProductosList();
            }
        }

        protected void ddlProductoDespachado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigoProducto = int.Parse(ddlProductoDespachado.SelectedValue);
            informeLoteDespachado(codigoProducto);
            informeLoteDespachadoDetalle(null);
        }

        protected void cargaProductosList()
        {
            ddlProductoDespachado.DataSource = AccesoLogica.ObtenerProductos();
            ddlProductoDespachado.DataValueField = "codigoProducto";
            ddlProductoDespachado.DataTextField = "nombreProducto";
            ddlProductoDespachado.DataBind();
        }

        protected void informeLoteDespachado(int codigoProducto)
        {
            gdvLoteDespachado.DataSource = AccesoLogica.informeLoteDespachado(codigoProducto);
            gdvLoteDespachado.DataBind();
        }

        protected void gdvLoteDespachado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvLoteDespachado.PageIndex = e.NewPageIndex;
            int codigoProducto = int.Parse(ddlProductoDespachado.SelectedValue);
            informeLoteDespachado(codigoProducto);
        }

        //protected void imgBtnLoteDespacho_Click(object sender, ImageClickEventArgs e)
        //{
        //    int count = 0; 

        //        for (int i = 0; i < gdvLoteDespachado.Rows.Count; i++)
        //        {
        //            Label lbllote = (Label)gdvLoteDespachado.Rows[i].Cells[i].FindControl("lblLote");

        //            if(count == i)
        //            {
        //                informeLoteDespachadoDetalle(lbllote.Text);
        //            }
        //        }
        //}

        protected void informeLoteDespachadoDetalle(string lote)
        {
            gdvLoteDespachadoDetalle.DataSource = AccesoLogica.informeLoteDespachadoDetalle(lote);
            gdvLoteDespachadoDetalle.DataBind();
        }

        protected void imgBtnLoteDespacho_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "verDetalle")
            {
                //String lbllote = gdvLoteDespachado.SelectedRow.FindControl("lote");
                String lote = ((string)e.CommandArgument);
                informeLoteDespachadoDetalle(lote);
            }
        }

        

        
    }
}
