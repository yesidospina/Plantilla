using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace Presentation.Controles
{
    public partial class ctrlReporteExistencia : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlExistenciaTotal.Attributes.Add("title", "titulo");
            //si se autentica mostramos mensaje y nombre de usuario
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Session.Add
                //Response.Write("Bienvenido : " + User.Identity.Name + ".");
                obtenerExistenciaTotal();
                obtenerExistenciaDisponible();
                obtenerExistenciaPendiente();
                obtenerExistenciaRetenida();
                obtenerExistenciaReproceso();
            }
        }

        protected void obtenerExistenciaTotal()
        {
            gdvExitenciaTotal.DataSource = AccesoLogica.obtenerExistenciaTotal();
            gdvExitenciaTotal.DataBind();
        }

        protected void obtenerExistenciaDisponible()
        {
            gdvExistenciaDisponible.DataSource = AccesoLogica.obtenerExistenciaDisponible();
            gdvExistenciaDisponible.DataBind();
        }

        protected void obtenerExistenciaPendiente()
        {
            gdvExistenciaPendiente.DataSource = AccesoLogica.obtenerExistenciaPendiente();
            gdvExistenciaPendiente.DataBind();
        }

        protected void obtenerExistenciaRetenida()
        {
            gdvExistenciaRetenida.DataSource = AccesoLogica.obtenerExistenciaRetenida();
            gdvExistenciaRetenida.DataBind();
        }

        protected void obtenerExistenciaReproceso()
        {
            gdvExistenciaReproceso.DataSource = AccesoLogica.obtenerExistenciaReproceso();
            gdvExistenciaReproceso.DataBind();
        }
    }
}