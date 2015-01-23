using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business;

namespace Presentation.Controles
{
    public partial class ctrlInfomeAnalisis : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                informeAnalisRangoFechaTodo();
            }
        }

        protected void informeAnalisRangoFecha(string fechaInicial, string fechaFinal)
        {
            gdvInfoAnalisisRangoFecha.DataSource = AccesoLogica.informeAnalisRangoFecha(fechaInicial, fechaFinal);
            gdvInfoAnalisisRangoFecha.DataBind();
        }

        protected void informeAnalisRangoFechaTodo()
        {
            gdvInfoAnalisisRangoFecha.DataSource = AccesoLogica.informeAnalisRangoFechaTodo();
            gdvInfoAnalisisRangoFecha.DataBind();
        }

        protected void btnConsultaFechas_Click(object sender, EventArgs e)
        {
            string fechaInicial = txtFechaInicial.Text;
            string fechaFinal = txtFechaFinal.Text;

            if (fechaInicial != "" & fechaFinal != "")
            {
                informeAnalisRangoFecha(Funciones.formatoFechaSinHora(fechaInicial), Funciones.formatoFechaSinHora(fechaFinal));
            }
            else {
                informeAnalisRangoFechaTodo();
            }
            

        }
    }
}