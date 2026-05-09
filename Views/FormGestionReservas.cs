using MultiSport_Manager.Controllers;
using MultiSport_Manager.Entities;
using MultiSport_Manager.Views;
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
    public partial class FormGestionReservas : Form
    {
        private ReservaController reservaController;
        private int idReservaSeleccionada = -1;

        public FormGestionReservas(ReservaController pReservaController)
        {
            InitializeComponent();
            this.reservaController = pReservaController;
        }


        private void FormGestionReservas_Load(object sender, EventArgs e)
        {
            // Bloqueo de auditoría
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            // Configurar los DateTimePickers de hora
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.ShowUpDown = true;

            // Llenar ComboBox de Estado (Según tu imagen y lógica)
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Confirmada");
            cmbEstado.Items.Add("Cancelada");
            cmbEstado.SelectedIndex = 0;

            CargarGrilla();
        }

        // Método que carga la grilla Y actualiza los números de arriba
        private void CargarGrilla()
        {
            var listaReservas = reservaController.ListarTodo();

            dgvReservas.DataSource = null;
            dgvReservas.DataSource = listaReservas;

            // --- LÓGICA DE ACTUALIZACIÓN DE MÉTRICAS ---
            lblTotalReservas.Text = listaReservas.Count.ToString();
            lblConfirmadas.Text = listaReservas.Count(r => r.Estado == "Confirmada").ToString();
            lblPendientes.Text = listaReservas.Count(r => r.Estado == "Pendiente").ToString();
            lblCanceladas.Text = listaReservas.Count(r => r.Estado == "Cancelada").ToString();
        }

        private void LimpiarCampos()
        {
            txtIDReserva.Clear();
            txtMontoTotal.Clear();
            txtIDCliente.Clear();
            txtIDCancha.Clear();

            dtpFecha.Value = DateTime.Now;
            dtpHoraInicio.Value = DateTime.Now;
            dtpHoraFin.Value = DateTime.Now;
            cmbEstado.SelectedIndex = 0;

            txtCreadoPor.Clear();
            txtModificadoPor.Clear();
            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaModificacion.Value = DateTime.Now;

            idReservaSeleccionada = -1;
        }

        // Botón Verde (+) -> GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Reserva nuevaReserva = new Reserva();
                nuevaReserva.IDReserva = int.Parse(txtIDReserva.Text);
                nuevaReserva.Fecha = dtpFecha.Value.Date;
                nuevaReserva.HoraInicio = dtpHoraInicio.Value.TimeOfDay;
                nuevaReserva.HoraFin = dtpHoraFin.Value.TimeOfDay;
                nuevaReserva.MontoTotal = double.Parse(txtMontoTotal.Text);
                nuevaReserva.Estado = cmbEstado.Text;

                // Asignaciones
                nuevaReserva.Cliente = new Cliente { IDCliente = int.Parse(txtIDCliente.Text) };
                nuevaReserva.Cancha = new Cancha { IDCancha = int.Parse(txtIDCancha.Text) };

                // Auditoría
                nuevaReserva.FechaCreacion = DateTime.Now;
                nuevaReserva.FechaModificacion = DateTime.Now;
                nuevaReserva.CreadoPor = 1;
                nuevaReserva.ModificadoPor = 1;

                // Tu controlador validará si hay cruce de horarios antes de registrar
                if (reservaController.RegistrarReserva(nuevaReserva))
                {
                    MessageBox.Show("Reserva registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar. Verifique que el ID no exista y que no haya cruce de horarios en esa cancha.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique los datos ingresados. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Azul -> MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una reserva de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí agregarías la lógica de actualización similar a los otros forms.
            // (Se omite el try-catch largo por brevedad, pero es idéntico a crear, solo que llamas a EditarReserva).
        }

        // Botón Rojo -> ELIMINAR (O Cancelar)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea CANCELAR esta reserva? (Esto liberará la cancha)", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    reservaController.CancelarReserva(idReservaSeleccionada);
                    CargarGrilla();
                    LimpiarCampos();
                }
            }
        }

        // Evento CellClick de la grilla
        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvReservas.Rows[e.RowIndex];

                txtIDReserva.Text = fila.Cells["IDReserva"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);

                TimeSpan inicio = (TimeSpan)fila.Cells["HoraInicio"].Value;
                dtpHoraInicio.Value = DateTime.Today.Add(inicio);

                TimeSpan fin = (TimeSpan)fila.Cells["HoraFin"].Value;
                dtpHoraFin.Value = DateTime.Today.Add(fin);

                txtMontoTotal.Text = fila.Cells["MontoTotal"].Value.ToString();
                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();

                if (fila.Cells["Cliente"].Value != null)
                {
                    txtIDCliente.Text = ((Cliente)fila.Cells["Cliente"].Value).IDCliente.ToString();
                }

                if (fila.Cells["Cancha"].Value != null)
                {
                    txtIDCancha.Text = ((Cancha)fila.Cells["Cancha"].Value).IDCancha.ToString();
                }

                idReservaSeleccionada = int.Parse(txtIDReserva.Text);
            }
        }

        // --------------------------------------------------------
        // NAVEGACIÓN A LOS OTROS FORMULARIOS (PASANDO EL ID)
        // --------------------------------------------------------

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una Reserva primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Le pasamos el controlador de pagos (que debe estar en tu FormPrincipal) y el ID de la reserva
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null)
            {
                // Abrimos FormPago enviando el controlador y el ID de la reserva seleccionada
                FormPago formPago = new FormPago(((FormPrincipal)principal).pagoController, idReservaSeleccionada);
                formPago.Show();
                this.Hide(); // Ocultamos el form de reservas temporalmente
            }
        }

        private void btnRegistrarImplemento_Click(object sender, EventArgs e)
        {

        }

        // Regresar al menú principal
        private void btnMenu_Click(object sender, EventArgs e)
        {
            RegresarAlMenu();
        }

        private void FormGestionReservas_FormClosed(object sender, FormClosedEventArgs e)
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
