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
        private int idReservaActual = -1;

        public FormPago(PagoController pPagoController, int pIdReserva = -1)
        {
            InitializeComponent();
            this.pagoController = pPagoController;
            this.idReservaActual = pIdReserva;
        }

        private void MostrarEnDataGrid(List<Pago> lista)
        {
            dgvPagos.DataSource = null;
            if (lista.Count > 0)
            {
                dgvPagos.DataSource = lista;
            }
        }

        private void FormPago_Load(object sender, EventArgs e)
        {
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            cmbMetodoPago.Items.Add("Yape / Plin");
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta (Visa/Mastercard)");
            cmbMetodoPago.Items.Add("Transferencia BCP/Interbank");
            cmbMetodoPago.SelectedIndex = 0;

            cmbEstadoPago.Items.Add("Adelanto");
            cmbEstadoPago.Items.Add("Completado");
            cmbEstadoPago.Items.Add("Retenido");
            cmbEstadoPago.Items.Add("Reembolsado");
            cmbEstadoPago.SelectedIndex = 0;

            ActualizarEtiquetaReserva();

            // Si hay reserva, mostramos sus pagos,    si no, todos los pagos del sistema
            if (idReservaActual != -1)
                MostrarEnDataGrid(pagoController.ListarPorReserva(idReservaActual));
            else
                MostrarEnDataGrid(pagoController.ListarTodo());
        }

        private void ActualizarEtiquetaReserva()
        {
            lblIDReservaValue.Text = (idReservaActual != -1) ? idReservaActual.ToString() : "N/A";
        }

        private void LimpiarCampos()
        {
            txtIDPago.Clear();
            txtMontoPagado.Clear();
            dtpFechaPago.Value = DateTime.Now;
            cmbMetodoPago.SelectedIndex = 0;
            cmbEstadoPago.SelectedIndex = 0;
            idPagoSeleccionado = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idReservaActual == -1)
            {
                MessageBox.Show("No hay una Reserva seleccionada. Por favor, ingrese desde la ventana de Reservas.");
                return;
            }

            if (txtIDPago.Text == "" || txtMontoPagado.Text == "")
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
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

                nuevoPago.Reserva = new Reserva { IDReserva = idReservaActual };

                nuevoPago.CreadoPor = 1;
                nuevoPago.ModificadoPor = 1;

                if (pagoController.RegistrarPago(nuevoPago, idReservaActual))
                {
                    MessageBox.Show("Pago registrado correctamente.");
                    MostrarEnDataGrid(pagoController.ListarPorReserva(idReservaActual));
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El ID del pago ya existe o el monto es 0.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Verifique que el ID y el Monto sean valores numéricos.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idPagoSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un pago de la lista.");
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

                pagoModificado.FechaCreacion = dtpFechaCreacion.Value;
                pagoModificado.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);
                pagoModificado.ModificadoPor = 1;

                if (pagoController.EditarPago(pagoModificado))
                {
                    MessageBox.Show("Pago modificado correctamente.");
                    MostrarEnDataGrid(pagoController.ListarPorReserva(idReservaActual));
                    LimpiarCampos();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar. Compruebe los datos ingresados.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idPagoSeleccionado != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de anular este pago?", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    pagoController.EliminarPago(idPagoSeleccionado);
                    MostrarEnDataGrid(pagoController.ListarPorReserva(idReservaActual));
                    LimpiarCampos();
                }
            }
        }

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

                if (fila.Cells["Reserva"].Value != null)
                {
                    idReservaActual = ((Reserva)fila.Cells["Reserva"].Value).IDReserva;
                    ActualizarEtiquetaReserva();
                }

                idPagoSeleccionado = int.Parse(txtIDPago.Text);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) { RegresarAlMenu(); }
        private void FormPago_FormClosed(object sender, FormClosedEventArgs e) { RegresarAlMenu(); }
        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null) principal.Show();
            this.Hide();
        }
    }
}
