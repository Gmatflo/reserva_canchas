using MultiSport_Manager.Controllers;
using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace reserva_canchas
{
    public partial class FormPago : Form
    {
        private PagoController pagoController;
        private ReservaController reservaController; // Necesitamos esto para saber el Monto Total

        private int idPagoSeleccionado = -1;
        private int idReservaActual = -1;
        private Reserva reservaActual;

        // Constructor actualizado
        public FormPago(PagoController pPagoController, ReservaController pReservaController, int pIdReserva)
        {
            InitializeComponent();
            this.pagoController = pPagoController;
            this.reservaController = pReservaController;
            this.idReservaActual = pIdReserva;

            // Buscamos la reserva en memoria
            this.reservaActual = reservaController.ListarTodo().Find(r => r.IDReserva == pIdReserva);

            // Conectamos los eventos MANUALMENTE para que no falle como antes
            this.Load += FormPago_Load;
            this.dgvPagos.SelectionChanged += dgvPagos_SelectionChanged;
        }

        private void FormPago_Load(object sender, EventArgs e)
        {
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            // Opciones del ComboBox
            cmbEstadoPago.Items.Clear();
            cmbEstadoPago.Items.Add("Parcial");
            cmbEstadoPago.Items.Add("Completado");
            cmbEstadoPago.Items.Add("Reembolsado");
            cmbEstadoPago.SelectedIndex = 0;

            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Online");
            cmbMetodoPago.SelectedIndex = 0;

            if (reservaActual == null)
            {
                MessageBox.Show("Error de memoria: Reserva no encontrada.");
                return;
            }

            MostrarEnDataGrid();
            LimpiarCampos();
        }

        private void MostrarEnDataGrid()
        {
            dgvPagos.DataSource = null;
            var lista = pagoController.ListarPorReserva(idReservaActual);

            if (lista.Count > 0)
            {
                // Mostramos DataGrid limpio usando LINQ
                var source = lista.Select(p => new {
                    IDPago = p.IDPago,
                    MontoPagado = p.MontoPagado,
                    FechaPago = p.FechaPago,
                    MetodoPago = p.MetodoPago,
                    Estado = p.EstadoPago,
                    CreadoPor = p.CreadoPor,
                    ModificadoPor = p.ModificadoPor
                }).ToList();

                dgvPagos.DataSource = source;
            }

            // Actualizamos la etiqueta superior para que el usuario vea cómo va la deuda
            double sumaActivos = pagoController.SumaPagosActivos(idReservaActual);
            lblIDReservaValue.Text = idReservaActual.ToString();
            lblMontoTotalReserva.Text = reservaActual.MontoTotal.ToString();
            lblPagado.Text = sumaActivos.ToString();
            lblFaltante.Text = (reservaActual.MontoTotal - sumaActivos).ToString();
        }

        private void LimpiarCampos()
        {
            txtIDPago.Clear();
            txtIDPago.Enabled = true;
            txtMontoPagado.Clear();
            dtpFechaPago.Value = DateTime.Now;
            cmbEstadoPago.SelectedIndex = 0;
            idPagoSeleccionado = -1;
            dgvPagos.ClearSelection();
        }

        private void dgvPagos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPagos.SelectedRows.Count > 0)
            {
                var fila = dgvPagos.SelectedRows[0];
                if (fila.Cells["IDPago"].Value == null) return;

                txtIDPago.Text = fila.Cells["IDPago"].Value.ToString();
                txtMontoPagado.Text = fila.Cells["MontoPagado"].Value.ToString();
                dtpFechaPago.Value = Convert.ToDateTime(fila.Cells["FechaPago"].Value);
                cmbMetodoPago.Text = fila.Cells["MetodoPago"].Value.ToString();
                cmbEstadoPago.Text = fila.Cells["Estado"].Value.ToString();

                idPagoSeleccionado = Convert.ToInt32(fila.Cells["IDPago"].Value);
                txtIDPago.Enabled = false; // Evitar que modifiquen el ID
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtIDPago.Text == "" || txtMontoPagado.Text == "" || cmbMetodoPago.Text == "" || cmbEstadoPago.Text == "")
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            try
            {
                double nuevoMonto = double.Parse(txtMontoPagado.Text);
                double sumaActual = pagoController.SumaPagosActivos(idReservaActual);

                if (sumaActual + nuevoMonto > reservaActual.MontoTotal)
                {
                    MessageBox.Show($"Operación denegada. El pago superaría el Monto Total.\nFalta pagar: S/{reservaActual.MontoTotal - sumaActual}");
                    return;
                }

                string estadoDefinitivo = cmbEstadoPago.Text;

                // LOGICA: Si con este pago se completa el total, forzamos Completado para todos
                if (sumaActual + nuevoMonto == reservaActual.MontoTotal)
                {
                    estadoDefinitivo = "Completado";
                    pagoController.SincronizarEstados(idReservaActual, "Completado");
                }
                else
                {
                    estadoDefinitivo = "Parcial"; // Si falta dinero, siempre será parcial
                }

                Pago nuevoPago = new Pago
                {
                    IDPago = int.Parse(txtIDPago.Text),
                    MontoPagado = nuevoMonto,
                    FechaPago = dtpFechaPago.Value,
                    MetodoPago = cmbMetodoPago.Text,
                    EstadoPago = estadoDefinitivo,
                    Reserva = reservaActual,
                    CreadoPor = 1,
                    ModificadoPor = 1
                };

                if (!pagoController.RegistrarPago(nuevoPago))
                {
                    MessageBox.Show("Error: El ID del pago ya existe o el monto es cero.");
                    return;
                }

                MostrarEnDataGrid();
                LimpiarCampos();
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique que el ID y el Monto sean numéricos.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idPagoSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un pago para modificar.");
                return;
            }

            try
            {
                double nuevoMonto = double.Parse(txtMontoPagado.Text);
                // OJO: Al modificar, no contamos el pago viejo en la suma
                double sumaSinEstePago = pagoController.SumaPagosActivos(idReservaActual, idPagoSeleccionado);

                if (sumaSinEstePago + nuevoMonto > reservaActual.MontoTotal)
                {
                    MessageBox.Show($"Operación denegada. Supera el Monto Total.\nMáximo permitido para este pago: S/{reservaActual.MontoTotal - sumaSinEstePago}");
                    return;
                }

                string estadoDefinitivo = cmbEstadoPago.Text;

                if (sumaSinEstePago + nuevoMonto == reservaActual.MontoTotal)
                {
                    estadoDefinitivo = "Completado";
                }
                else
                {
                    estadoDefinitivo = "Parcial";
                }

                Pago pagoModificado = new Pago
                {
                    IDPago = idPagoSeleccionado,
                    MontoPagado = nuevoMonto,
                    FechaPago = dtpFechaPago.Value,
                    MetodoPago = cmbMetodoPago.Text,
                    EstadoPago = estadoDefinitivo,
                    Reserva = reservaActual,
                    CreadoPor = 1,
                    FechaModificacion = DateTime.Now,
                    ModificadoPor = 1
                };

                if (pagoController.EditarPago(pagoModificado))
                {
                    // Sincronizamos el resto de los pagos de la reserva
                    pagoController.SincronizarEstados(idReservaActual, estadoDefinitivo);
                }

                MostrarEnDataGrid();
                LimpiarCampos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error numérico.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idPagoSeleccionado != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de REEMBOLSAR (Anular) este pago?", "Confirmar Reembolso", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (pagoController.ReembolsarPago(idPagoSeleccionado))
                    {
                        // Si se reembolsó un pago, la suma baja. Todos los que estaban en "Completado" vuelven a "Parcial"
                        double sumaRestante = pagoController.SumaPagosActivos(idReservaActual);
                        if (sumaRestante < reservaActual.MontoTotal)
                        {
                            pagoController.SincronizarEstados(idReservaActual, "Parcial");
                        }
                    }
                    MostrarEnDataGrid();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione el pago a reembolsar.");
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) { RegresarAlMenu(); }
        private void FormPago_FormClosed(object sender, FormClosedEventArgs e) { RegresarAlMenu(); }

        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormGestionReservas"];
            if (principal != null) principal.Show();
            this.Close();
        }
    }
}
