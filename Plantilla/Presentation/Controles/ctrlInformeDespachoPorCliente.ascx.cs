using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace Presentation.Controles
{
    public partial class ctrlInformeDespachoPorCliente : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarClientes();
            }
            
        }

        protected void cargarClientes()
        {
            ddlDespachoCliente.DataSource = AccesoLogica.obtenerDespachoCliente();
            ddlDespachoCliente.DataValueField = "codigoCliente";
            ddlDespachoCliente.DataTextField = "nombreCliente";
            ddlDespachoCliente.DataBind();
        }

        protected void DespachoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigoCliente = int.Parse(ddlDespachoCliente.SelectedValue);
            informeDespachoCliente(codigoCliente);
        }

        protected void informeDespachoCliente(int codigoCliente)
        {
            gdvDespachoCliente.DataSource = AccesoLogica.informeDespachoPorCliente(codigoCliente);
            gdvDespachoCliente.DataBind();
        }

        protected void gdvDespachoCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvDespachoCliente.PageIndex = e.NewPageIndex;
            int codigoCliente = int.Parse(ddlDespachoCliente.SelectedValue);
            informeDespachoCliente(codigoCliente);
        }

    }
}