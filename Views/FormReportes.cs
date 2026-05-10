using MultiSport_Manager.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace reserva_canchas.forms
{
    public partial class FormReportes : Form
    {
        private ReporteController reporteController;
        private PagoController pagoController;
        private ReservaController reservaController;

        // Constructor modificado
        public FormReportes(ReporteController pReporte, PagoController pPago, ReservaController pReserva)
        {
            InitializeComponent();
            this.reporteController = pReporte;
            this.pagoController = pPago;
            this.reservaController = pReserva;

            // Aseguramos que el Chart empiece vacío
            chartReporte.Titles.Clear();
            chartReporte.Series.Clear();
        }

        // --- BOTÓN 1: REPORTE DE INGRESOS (GRÁFICO CIRCULAR / PIE) ---
        private void btnGenerarIngresos_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtpFechaInicio.Value.Date;
            DateTime fin = dtpFechaFin.Value.Date;

            if (inicio > fin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.");
                return;
            }

            // 1. Obtenemos datos del controlador
            var listaPagos = pagoController.ListarTodo();
            var datosReporte = reporteController.GenerarReporteIngresosPorSede(listaPagos, inicio, fin);

            // 2. Llenar DataGridView
            dgvReportes.DataSource = datosReporte;

            // 3. Configurar y Llenar el Chart
            chartReporte.Series.Clear();
            chartReporte.Titles.Clear();

            chartReporte.Titles.Add("Ingresos por Sede");
            Series seriePie = chartReporte.Series.Add("Ingresos");
            seriePie.ChartType = SeriesChartType.Pie; // TIPO DE GRÁFICO CIRCULAR
            seriePie.IsValueShownAsLabel = true;      // Mostrar los valores en el gráfico

            // Llenamos los puntos (X = Nombre Sede, Y = Ingresos Totales)
            foreach (dynamic item in datosReporte)
            {
                seriePie.Points.AddXY(item.Sede, item.IngresosTotales);
            }
        }

        // --- BOTÓN 2: REPORTE DE DEPORTES (GRÁFICO DE BARRAS) ---
        private void btnGenerarDeportes_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos datos del controlador
            var listaReservas = reservaController.ListarTodo();
            var datosReporte = reporteController.GenerarReporteReservasPorDeporte(listaReservas);

            // 2. Llenar DataGridView
            dgvReportes.DataSource = datosReporte;

            // 3. Configurar y Llenar el Chart
            chartReporte.Series.Clear();
            chartReporte.Titles.Clear();

            chartReporte.Titles.Add("Cantidad de Reservas por Deporte");
            Series serieBarras = chartReporte.Series.Add("Reservas");
            serieBarras.ChartType = SeriesChartType.Column; // TIPO DE GRÁFICO DE BARRAS VERTICALES
            serieBarras.IsValueShownAsLabel = true;

            // Llenamos los puntos (X = Deporte, Y = Total Reservas)
            foreach (dynamic item in datosReporte)
            {
                serieBarras.Points.AddXY(item.Deporte, item.TotalReservas);
            }
        }

        // Botón Salir al Menú
        private void btnMenu_Click(object sender, EventArgs e) { RegresarAlMenu(); }
        private void FormReportes_FormClosed(object sender, FormClosedEventArgs e) { RegresarAlMenu(); }

        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null) principal.Show();
            this.Hide();
        }
    }
}
