using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace Presentation.Controles
{
    public partial class ctrModificaLote : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                obtenerUltimoLoteCreado();
            }
        }

        protected void obtenerUltimoLoteCreado()
        {
            gdvLotes.DataSource = AccesoLogica.obtenerLotes();
            gdvLotes.DataBind();
        }

        #region"------------------- GridView Ultimo Lotes Creados -------------------------"

        protected void gdvLotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvLotes.PageIndex = e.NewPageIndex;
        }

        protected void gdvLotes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvLotes.EditIndex = e.NewEditIndex;
            obtenerUltimoLoteCreado();

        }

        protected void gdvLotes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvLotes.EditIndex = -1;
            obtenerUltimoLoteCreado();
        }

        protected void gdvLotes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string loginUser = HttpContext.Current.User.Identity.Name;
            int codigoUsuario = AccesoLogica.obtenerCodigoUsuarioLogin(loginUser);
            string loteAnterior = ((Label)gdvLotes.Rows[e.RowIndex].FindControl("lblLote")).Text;
            string txtFechaMov = ((TextBox)gdvLotes.Rows[e.RowIndex].FindControl("txtFechaMovimiento")).Text;
            string letraLote = loteAnterior.Remove(1, 9);

            string fechaLote = txtFechaMov;
            int countFecha = fechaLote.Length - 10;
            fechaLote = fechaLote.Remove(10, countFecha);
            fechaLote = fechaLote.Replace("/", "");
            fechaLote = fechaLote.Remove(4, 2);

            string loteNuevo = loteAnterior.Remove(0, 7);
            loteNuevo = letraLote + fechaLote + loteNuevo;

            DateTime fechaVencimiento = Funciones.sumarDiasFecha(txtFechaMov);
            DateTime fechaMov = Convert.ToDateTime(txtFechaMov);

            if (AccesoLogica.actualizarFechaLote(fechaMov, fechaVencimiento, loteNuevo, loteAnterior, codigoUsuario) > 0)
            {
                gdvLotes.EditIndex = -1;
                obtenerUltimoLoteCreado();
            }

        }

        #endregion







    }
}