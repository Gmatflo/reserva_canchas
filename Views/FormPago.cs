using MultiSport_Manager.Controllers;
using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
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
            if (lista.Count > 0) dgvPagos.DataSource = lista;
        }

        private void FormPago_Load(object sender, EventArgs e)
        {
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            lblIDReservaValue.Text = (idReservaActual != -1) ? idReservaActual.ToString() : "N/A";

            if (idReservaActual != -1)
            {
                MostrarEnDataGrid(pagoController.ListarPorReserva(idReservaActual));
            }
            else
            {
                MostrarEnDataGrid(pagoController.ListarTodo());
            }

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtIDPago.Clear();
            txtIDPago.Enabled = true;
            txtMontoPagado.Clear();
            dtpFechaPago.Value = DateTime.Now;
            idPagoSeleccionado = -1;
            dgvPagos.ClearSelection();
        }

        private void dgvPagos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPagos.SelectedRows.Count > 0)
            {
                var fila = dgvPagos.SelectedRows[0];
                if (fila.Cells["IDPago"].Value == null)
                {
                    return;
                }

                txtIDPago.Text = fila.Cells["IDPago"].Value.ToString();
                txtMontoPagado.Text = fila.Cells["MontoPagado"].Value.ToString();
                dtpFechaPago.Value = Convert.ToDateTime(fila.Cells["FechaPago"].Value);
                cmbMetodoPago.Text = fila.Cells["MetodoPago"].Value.ToString();
                cmbEstadoPago.Text = fila.Cells["EstadoPago"].Value.ToString();

                idPagoSeleccionado = Convert.ToInt32(fila.Cells["IDPago"].Value);
                txtIDPago.Enabled = false;
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (idReservaActual == -1)
            {
                MessageBox.Show("Debe entrar desde Reservas para asignar un pago.");
                return;
            }

            if (txtIDPago.Text == "" || txtMontoPagado.Text == "" || cmbMetodoPago.Text == "" || cmbEstadoPago.Text == "")
            {
                MessageBox.Show("Complete todos los campos.");
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

                if (!pagoController.RegistrarPago(nuevoPago, idReservaActual))
                {
                    MessageBox.Show("El ID ya existe o el monto es 0.");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en los datos numéricos.");
                return;
            }

            MostrarEnDataGrid(pagoController.ListarPorReserva(idReservaActual));
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
