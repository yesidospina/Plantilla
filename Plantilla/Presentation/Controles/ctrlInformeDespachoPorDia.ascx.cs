using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace Presentation.Controles
{
    public partial class ctrlInformeDespachoPorDia : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                informeAnalisisDespachoPorDiaTodo();
            }
        }

        protected void btnConsultaFechas_Click(object sender, EventArgs e)
        {
            string fechaInicial = txtFechaInicial.Text;
            string fechaFinal = txtFechaFinal.Text;

            if (fechaInicial != "" & fechaFinal != "")
            {
                informeAnalisisDespachoPorDia(Funciones.formatoFechaSinHora(fechaInicial), Funciones.formatoFechaSinHora(fechaFinal));
            }
            else
            {
                informeAnalisisDespachoPorDiaTodo();
            }
        }

        protected void informeAnalisisDespachoPorDia(string fechaInicial, string fechaFinal)
        {
            gdvInfoAnalisisFechaPorDia.DataSource = AccesoLogica.informeDespachoPorDia(fechaInicial, fechaFinal);
            gdvInfoAnalisisFechaPorDia.DataBind();
        }

        protected void informeAnalisisDespachoPorDiaTodo()
        {
            gdvInfoAnalisisFechaPorDia.DataSource = AccesoLogica.informeDespachoPorDiaTodo();
            gdvInfoAnalisisFechaPorDia.DataBind();
        }

    }
}