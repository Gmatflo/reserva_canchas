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
        private ClienteController clienteController; 
        private CanchaController canchaController; 

        private int idReservaSeleccionada = -1;

        public FormGestionReservas(ReservaController pReservaController, ClienteController pClienteController, CanchaController pCanchaController)
        {
            InitializeComponent();
            this.reservaController = pReservaController;
            this.clienteController = pClienteController;
            this.canchaController = pCanchaController;
        }

        private void MostrarEnDataGrid(List<Reserva> lista)
        {
            dgvReservas.DataSource = null;
            if (lista.Count > 0)
            {
                dgvReservas.DataSource = lista;
            }

            lblTotalReservas.Text = lista.Count.ToString();
            lblConfirmadas.Text = lista.Count(r => r.Estado == "Confirmada").ToString();
            lblPendientes.Text = lista.Count(r => r.Estado == "Pendiente").ToString();
            lblCanceladas.Text = lista.Count(r => r.Estado == "Cancelada").ToString();
        }

        private void FormGestionReservas_Load(object sender, EventArgs e)
        {
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.ShowUpDown = true;

            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Confirmada");
            cmbEstado.Items.Add("Cancelada");
            cmbEstado.SelectedIndex = 0;

            MostrarEnDataGrid(reservaController.ListarTodo());
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
            idReservaSeleccionada = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIDReserva.Text == "" || txtIDCliente.Text == "" || txtIDCancha.Text == "" || txtMontoTotal.Text == "")
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            try
            {
                int idCliente = int.Parse(txtIDCliente.Text);
                int idCancha = int.Parse(txtIDCancha.Text);

                // --- VALIDACIÓN 1: INTEGRIDAD REFERENCIAL (¿Existen?) ---
                Cliente clienteReal = clienteController.BuscarClientePorID(idCliente);
                if (clienteReal == null)
                {
                    MessageBox.Show("El ID de Cliente ingresado no se encuentra registrado en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cancha canchaReal = canchaController.BuscarCancha(idCancha);
                if (canchaReal == null)
                {
                    MessageBox.Show("El ID de Cancha ingresado no existe en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- VALIDACIÓN 2: LÓGICA DE TIEMPO (Múltiplos de hora exacta) ---
                TimeSpan inicio = dtpHoraInicio.Value.TimeOfDay;
                TimeSpan fin = dtpHoraFin.Value.TimeOfDay;

                if (inicio >= fin)
                {
                    MessageBox.Show("La hora de inicio debe ser estrictamente antes que la hora de fin.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TimeSpan diferencia = fin - inicio;
                // Verificamos si los minutos totales son divisibles exactamente entre 60
                if (diferencia.TotalMinutes % 60 != 0)
                {
                    MessageBox.Show("Las reservas deben ser por bloques de horas exactas (Ej: 1 hora, 2 horas). No se permiten fracciones.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Reserva nuevaReserva = new Reserva();
                nuevaReserva.IDReserva = int.Parse(txtIDReserva.Text);
                nuevaReserva.Fecha = dtpFecha.Value.Date;
                nuevaReserva.HoraInicio = inicio;
                nuevaReserva.HoraFin = fin;
                nuevaReserva.MontoTotal = double.Parse(txtMontoTotal.Text);
                nuevaReserva.Estado = cmbEstado.Text;

                // Asignamos los objetos reales que encontramos
                nuevaReserva.Cliente = clienteReal;
                nuevaReserva.Cancha = canchaReal;

                nuevaReserva.CreadoPor = 1;
                nuevaReserva.ModificadoPor = 1;

                if (reservaController.RegistrarReserva(nuevaReserva))
                {
                    MostrarEnDataGrid(reservaController.ListarTodo());
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error: ID duplicado o existe CRUCE DE HORARIOS en esa Cancha y Fecha.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique que los IDs y el Monto sean solo números.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una reserva de la tabla.");
                return;
            }

            try
            {
                int idCliente = int.Parse(txtIDCliente.Text);
                int idCancha = int.Parse(txtIDCancha.Text);

                // --- VALIDACIÓN 1: INTEGRIDAD REFERENCIAL ---
                Cliente clienteReal = clienteController.BuscarClientePorID(idCliente);
                if (clienteReal == null)
                {
                    MessageBox.Show("El ID de Cliente ingresado no se encuentra registrado.");
                    return;
                }

                Cancha canchaReal = canchaController.BuscarCancha(idCancha);
                if (canchaReal == null)
                {
                    MessageBox.Show("El ID de Cancha ingresado no existe.");
                    return;
                }

                // --- VALIDACIÓN 2: LÓGICA DE TIEMPO ---
                TimeSpan inicio = dtpHoraInicio.Value.TimeOfDay;
                TimeSpan fin = dtpHoraFin.Value.TimeOfDay;

                if (inicio >= fin)
                {
                    MessageBox.Show("La hora de inicio debe ser antes que la hora de fin.");
                    return;
                }

                TimeSpan diferencia = fin - inicio;
                if (diferencia.TotalMinutes % 60 != 0)
                {
                    MessageBox.Show("Las reservas deben ser por bloques de horas exactas.");
                    return;
                }

                Reserva reservaModificada = new Reserva();
                reservaModificada.IDReserva = idReservaSeleccionada;
                reservaModificada.Fecha = dtpFecha.Value.Date;
                reservaModificada.HoraInicio = inicio;
                reservaModificada.HoraFin = fin;
                reservaModificada.MontoTotal = double.Parse(txtMontoTotal.Text);
                reservaModificada.Estado = cmbEstado.Text;

                reservaModificada.Cliente = clienteReal;
                reservaModificada.Cancha = canchaReal;

                reservaModificada.FechaCreacion = dtpFechaCreacion.Value;
                reservaModificada.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);
                reservaModificada.ModificadoPor = 1;

                if (reservaController.EditarReserva(reservaModificada))
                {
                    // SIN MESSAGEBOX DE EXITO
                    MostrarEnDataGrid(reservaController.ListarTodo());
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Cruce de horarios detectado, no se pudo editar.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error numérico en el formulario.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea CANCELAR esta reserva? (Esto liberará la cancha)", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    reservaController.CancelarReserva(idReservaSeleccionada);
                    MostrarEnDataGrid(reservaController.ListarTodo());
                    LimpiarCampos();
                }
            }
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvReservas.Rows[e.RowIndex];

                txtIDReserva.Text = fila.Cells["IDReserva"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);
                dtpHoraInicio.Value = DateTime.Today.Add((TimeSpan)fila.Cells["HoraInicio"].Value);
                dtpHoraFin.Value = DateTime.Today.Add((TimeSpan)fila.Cells["HoraFin"].Value);
                txtMontoTotal.Text = fila.Cells["MontoTotal"].Value.ToString();
                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();

                if (fila.Cells["Cliente"].Value != null)
                    txtIDCliente.Text = ((Cliente)fila.Cells["Cliente"].Value).IDCliente.ToString();

                if (fila.Cells["Cancha"].Value != null)
                    txtIDCancha.Text = ((Cancha)fila.Cells["Cancha"].Value).IDCancha.ToString();

                idReservaSeleccionada = int.Parse(txtIDReserva.Text);
            }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una Reserva primero.");
                return;
            }

            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null)
            {
                FormPago formPago = new FormPago(((FormPrincipal)principal).pagoController, idReservaSeleccionada);
                formPago.Show();
                this.Hide();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) { RegresarAlMenu(); }
        private void FormGestionReservas_FormClosed(object sender, FormClosedEventArgs e) { RegresarAlMenu(); }

        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null) principal.Show();
            this.Hide();
        }
    }
}
