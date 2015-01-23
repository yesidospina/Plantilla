using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Funciones
    {
        public static string formatoFecha(string fecha)
        {
            string fechaFormato = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(fecha));
            string horaActual = Convert.ToString(DateTime.Now);
            horaActual = horaActual.Substring(10);
            fechaFormato = fechaFormato + horaActual;

            return fechaFormato;
        }

        public static string formatoFechaSinHora(string fecha)
        {
            string fechaFormato = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(fecha));
            return fechaFormato;
        }

        public static DateTime sumarDiasFecha(string fecha)
        {
            string fechaFormato = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(fecha));
            DateTime fechaDate = Convert.ToDateTime(fechaFormato).AddDays(180);
            return fechaDate;
        }

        public static DateTime calculoFechaVencimientoSebos(string fecha)
        {
            string fechaFormato = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(fecha));
            DateTime fechaDate = Convert.ToDateTime(fechaFormato).AddDays(60);
            return fechaDate;
        }

    }
}
