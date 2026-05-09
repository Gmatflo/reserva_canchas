using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    public class ReporteController
    {
        // Los métodos devuelven List<object> para que sean flexibles al llenar gráficos o DataGridViews
        public List<object> GenerarReportePenalidadCancelacion()
        {
            List<object> reporte = new List<object>();

            // Aquí irá la lógica que recorre las reservas canceladas y suma los montos retenidos
            // Ejemplo de objeto anónimo a devolver:
            // reporte.Add(new { Cliente = "Juan", MontoRetenido = 50.00, Fecha = DateTime.Now });

            return reporte;
        }

        public List<object> GenerarReporteIngresosPorComplejo(DateTime pFechaInicio, DateTime pFechaFin)
        {
            List<object> reporte = new List<object>();
            // Lógica agrupando pagos por sede
            return reporte;
        }
    }
}
