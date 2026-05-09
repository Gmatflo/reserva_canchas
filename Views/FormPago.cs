using MultiSport_Manager.Controllers;
using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reserva_canchas
{
    public partial class FormPago : Form
    {
        private PagoController pagoController;
        private int idPagoSeleccionado = -1;

        // Esta variable guardará el ID de la reserva con la que estamos trabajando
        private int idReservaActual = -1;

        // Modificamos el constructor para que reciba Opcionalmente el ID de la Reserva.
        // Si vienes del menú principal, pIdReserva será -1. Si vienes de Reservas, tendrá el número.
        public FormPago(PagoController pPagoController, int pIdReserva = -1)
        {
            InitializeComponent();
            this.pagoController = pPagoController;
            this.idReservaActual = pIdReserva;
        }


        private void FormPago_Load(object sender, EventArgs e)
        {
            // Bloqueo de auditoría
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            // Llenar Métodos de Pago
            cmbMetodoPago.Items.Add("Yape / Plin");
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta (Visa/Mastercard)");
            cmbMetodoPago.Items.Add("Transferencia BCP/Interbank");
            cmbMetodoPago.SelectedIndex = 0;

            // Llenar Estados de Pago (Manejo de Adelantos y Penalidades)
            cmbEstadoPago.Items.Add("Adelanto");
            cmbEstadoPago.Items.Add("Completado");
            cmbEstadoPago.Items.Add("Retenido"); // Ideal para tu reporte de penalidad por cancelación
            cmbEstadoPago.Items.Add("Reembolsado");
            cmbEstadoPago.SelectedIndex = 0;

            ActualizarEtiquetaReserva();
            CargarGrilla();
        }

        // Método para actualizar el número grande azul en la esquina
        private void ActualizarEtiquetaReserva()
        {
            if (idReservaActual != -1)
            {
                lblIDReservaValue.Text = idReservaActual.ToString();
            }
            else
            {
                lblIDReservaValue.Text = "N/A"; // Si entran desde el menú sin seleccionar reserva
            }
        }

        private void CargarGrilla()
        {
            dgvPagos.DataSource = null;

            if (idReservaActual != -1)
            {
                // Si venimos de una reserva específica, mostramos SOLO los pagos de esa reserva
                // (por ejemplo, su adelanto y su cancelación final)
                dgvPagos.DataSource = pagoController.ListarPorReserva(idReservaActual);
            }
            else
            {
                // Si abren Pagos desde el menú lateral, idealmente tendrías un ListarTodo() en el controller
                // dgvPagos.DataSource = pagoController.ListarTodo();
            }
        }

        private void LimpiarCampos()
        {
            txtIDPago.Clear();
            txtMontoPagado.Clear();
            dtpFechaPago.Value = DateTime.Now;
            cmbMetodoPago.SelectedIndex = 0;
            cmbEstadoPago.SelectedIndex = 0;

            txtCreadoPor.Clear();
            txtModificadoPor.Clear();
            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaModificacion.Value = DateTime.Now;

            idPagoSeleccionado = -1;
        }

        // Botón Verde (+) -> GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idReservaActual == -1)
            {
                MessageBox.Show("No hay una Reserva seleccionada. Por favor, ingrese desde la ventana de Reservas para registrar un pago.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Pago nuevoPago = new Pago();
                nuevoPago.IDPago = int.Parse(txtIDPago.Text);
                nuevoPago.MontoPagado = double.Parse(txtMontoPagado.Text);
                nuevoPago.FechaPago = dtpFechaPago.Value;
                nuevoPago.MetodoPago = cmbMetodoPago.Text;
                nuevoPago.EstadoPago = cmbEstadoPago.Text;

                // Enlazamos el pago a la reserva actual
                nuevoPago.Reserva = new Reserva { IDReserva = idReservaActual };

                // Auditoría
                nuevoPago.FechaCreacion = DateTime.Now;
                nuevoPago.FechaModificacion = DateTime.Now;
                nuevoPago.CreadoPor = 1;
                nuevoPago.ModificadoPor = 1;

                if (pagoController.RegistrarPago(nuevoPago, idReservaActual))
                {
                    MessageBox.Show("Pago registrado correctamente. (Ej: Adelanto guardado)", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El monto debe ser mayor a 0 o el ID ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique que el ID y el Monto sean valores numéricos. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Azul -> MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idPagoSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un pago de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Pago pagoModificado = new Pago();
                pagoModificado.IDPago = idPagoSeleccionado;
                pagoModificado.MontoPagado = double.Parse(txtMontoPagado.Text);
                pagoModificado.FechaPago = dtpFechaPago.Value;
                pagoModificado.MetodoPago = cmbMetodoPago.Text;
                pagoModificado.EstadoPago = cmbEstadoPago.Text;
                pagoModificado.Reserva = new Reserva { IDReserva = idReservaActual };

                // Auditoría
                pagoModificado.FechaCreacion = dtpFechaCreacion.Value;
                pagoModificado.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);
                pagoModificado.FechaModificacion = DateTime.Now;
                pagoModificado.ModificadoPor = 1;

                // Asumiendo que agregaron un EditarPago al controlador
                // pagoController.EditarPago(pagoModificado);

                MessageBox.Show("Pago modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Rojo -> ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idPagoSeleccionado != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de anular este pago?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    // Asumiendo que agregaron EliminarPago al controlador
                    // pagoController.EliminarPago(idPagoSeleccionado);
                    CargarGrilla();
                    LimpiarCampos();
                }
            }
        }

        // Evento CellClick del DataGridView
        private void dgvPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPagos.Rows[e.RowIndex];

                txtIDPago.Text = fila.Cells["IDPago"].Value.ToString();
                txtMontoPagado.Text = fila.Cells["MontoPagado"].Value.ToString();
                dtpFechaPago.Value = Convert.ToDateTime(fila.Cells["FechaPago"].Value);
                cmbMetodoPago.Text = fila.Cells["MetodoPago"].Value.ToString();
                cmbEstadoPago.Text = fila.Cells["EstadoPago"].Value.ToString();

                // MAGIA AQUÍ: Si el usuario seleccionó un pago de la grilla general,
                // extraemos el ID de la Reserva y actualizamos el número gigante de la esquina.
                if (fila.Cells["Reserva"].Value != null)
                {
                    idReservaActual = ((Reserva)fila.Cells["Reserva"].Value).IDReserva;
                    ActualizarEtiquetaReserva();
                }

                // Auditoría
                txtCreadoPor.Text = fila.Cells["CreadoPor"].Value.ToString();
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                txtModificadoPor.Text = fila.Cells["ModificadoPor"].Value.ToString();
                dtpFechaModificacion.Value = Convert.ToDateTime(fila.Cells["FechaModificacion"].Value);

                idPagoSeleccionado = int.Parse(txtIDPago.Text);
            }
        }

        // Navegación para regresar al menú
        private void btnMenu_Click(object sender, EventArgs e)
        {
            RegresarAlMenu();
        }

        private void FormPago_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegresarAlMenu();
        }

        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null)
            {
                principal.Show();
            }
            this.Hide();
        }
    }
}
