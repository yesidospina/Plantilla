using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using System.Web.Security;
using System.Security.Principal;

namespace Presentation.Controles
{
    public partial class ctrlCreacionLote : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarProductos();
            if (!IsPostBack)
            {
                obtenerUltimoLoteCreado();
            }
            
            //si se autentica mostramos mensaje y nombre de usuario
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Session.Add
                //Response.Write("Bienvenido : " + HttpContext.Current.User.Identity.Name + ".");

            }
        }
        
        protected void cargarProductos() 
        {

            ddlProducto.DataSource = AccesoLogica.ObtenerProductos();
            ddlProducto.DataValueField = "codigoProducto";
            ddlProducto.DataTextField = "nombreProducto";
            ddlProducto.DataBind();
        }

        protected void guardarLote_OnClick(object sender, EventArgs e)
        {
            AccesoLogica insertaLote = new AccesoLogica();

            string fecha = txtFecha.Text;
            int codigoProducto = Convert.ToInt32(ddlProducto.SelectedValue);
            string prefijoProducto = AccesoLogica.ObtenerPrefijoProducto(codigoProducto);
            int consecutivo = AccesoLogica.ObtenerConsecutivoLote(prefijoProducto);
            

            string lote = prefijoProducto + fecha.Replace("-", "") + consecutivo.ToString("D3");
            string fechaMovimiento = Funciones.formatoFecha(fecha);
            DateTime fechaVencimiento = Funciones.sumarDiasFecha(fechaMovimiento);
            DateTime fechaMov = Convert.ToDateTime(fechaMovimiento);
            string loginUser = HttpContext.Current.User.Identity.Name;
            int codigoUsuario = AccesoLogica.obtenerCodigoUsuarioLogin(loginUser);
            
            switch (prefijoProducto) 
            {
                case "B": if (insertaLote.insertLote(lote, fechaMov, fechaVencimiento, codigoUsuario, codigoProducto) > 0)
                             {
                                 insertaAnalisis(lote);
                                 consecutivo++;
                                 AccesoLogica.actualizarConsecutivoProducto(prefijoProducto, consecutivo);
                                 Response.Redirect("~/InfoAnalisis/NuevoLote.aspx");    
                             }
                             break;
                case "N": if (insertaLote.insertLote(lote, fechaMov, fechaVencimiento, codigoUsuario, codigoProducto) > 0)
                             {
                                insertaAnalisis(lote);
                                consecutivo++;
                                AccesoLogica.actualizarConsecutivoProducto(prefijoProducto, consecutivo);
                                Response.Redirect("~/InfoAnalisis/NuevoLote.aspx");    
                             }
                             break;
                case "P": if (insertaLote.insertLote(lote, fechaMov, fechaVencimiento, codigoUsuario, codigoProducto) > 0)
                             {
                                insertaAnalisis(lote);
                                consecutivo++;
                                AccesoLogica.actualizarConsecutivoProducto(prefijoProducto, consecutivo);
                                Response.Redirect("~/InfoAnalisis/NuevoLote.aspx");    
                             }
                             break;
                case "D": if (insertaLote.insertLote(lote, fechaMov, fechaVencimiento, codigoUsuario, codigoProducto) > 0)
                             {
                                insertaAnalisis(lote);
                                consecutivo++;
                                AccesoLogica.actualizarConsecutivoProducto(prefijoProducto, consecutivo);
                                Response.Redirect("~/InfoAnalisis/NuevoLote.aspx");    
                             }
                             break;
                case "C": if (insertaLote.insertLote(lote, fechaMov, fechaVencimiento, codigoUsuario, codigoProducto) > 0)
                             {
                                insertaAnalisis(lote);
                                consecutivo++;
                                AccesoLogica.actualizarConsecutivoProducto(prefijoProducto, consecutivo);
                                Response.Redirect("~/InfoAnalisis/NuevoLote.aspx");    
                             }
                             break;
                case "O": if (insertaLote.insertLote(lote, fechaMov, fechaVencimiento, codigoUsuario, codigoProducto) > 0)
                             {
                                insertaAnalisis(lote);  
                                consecutivo++;
                                AccesoLogica.actualizarConsecutivoProducto(prefijoProducto, consecutivo);
                                Response.Redirect("~/InfoAnalisis/NuevoLote.aspx");    
                             }
                             break;
                }

                
            }

        protected void insertaAnalisis(string lote)
            {
                AccesoLogica insertaAnalisis = new AccesoLogica();
                int codigoLote = AccesoLogica.obtenerCodigoLote(lote.Trim());
                insertaAnalisis.insertAnalisis(0, 0, 0, 0, 0, 0, 0, 0, 0, codigoLote, 2, "", "NA", 0);
            }

        protected void obtenerUltimoLoteCreado()
        {
            gdvUltimoLote.DataSource = AccesoLogica.ObtenerUltimoLoteCreado();
            gdvUltimoLote.DataBind();
        }

    }
}