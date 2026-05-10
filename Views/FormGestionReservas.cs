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
            this.dgvReservas.SelectionChanged += new System.EventHandler(this.dgvReservas_SelectionChanged);
            this.VisibleChanged += FormGestionReservas_VisibleChanged;
            MostrarEnDataGrid(reservaController.ListarTodo());
        }

        private void MostrarEnDataGrid(List<Reserva> lista)
        {
            dgvReservas.DataSource = null;

            List<Reserva> listaActual = reservaController.ListarTodo();

            if (listaActual.Count > 0)
            {
                dgvReservas.DataSource = listaActual;
            }

            lblTotalReservas.Text = listaActual.Count.ToString();
            lblConfirmadas.Text = listaActual.Count(r => r.Estado == "Confirmada").ToString();
            lblPendientes.Text = listaActual.Count(r => r.Estado == "Pendiente").ToString();
            lblCanceladas.Text = listaActual.Count(r => r.Estado == "Cancelada").ToString();
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
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtIDReserva.Clear();
            txtIDReserva.Enabled = true;
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
            dgvReservas.ClearSelection();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtIDReserva.Text == "" || txtIDCliente.Text == "" || txtIDCancha.Text == "" || txtMontoTotal.Text == "" || cmbEstado.Text == "")
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            try
            {
                int idCliente = int.Parse(txtIDCliente.Text);
                int idCancha = int.Parse(txtIDCancha.Text);

                Cliente clienteReal = clienteController.BuscarClientePorID(idCliente);
                Cancha canchaReal = canchaController.BuscarCancha(idCancha);

                if (clienteReal == null || canchaReal == null)
                {
                    MessageBox.Show("Error: El ID de Cliente o de Cancha no existen.");
                    return;
                }

                if (canchaReal.Estado != "Disponible")
                {
                    MessageBox.Show("La cancha no está disponible. Estado actual: " + canchaReal.Estado);
                    return;
                }

                TimeSpan inicio = dtpHoraInicio.Value.TimeOfDay;
                TimeSpan fin = dtpHoraFin.Value.TimeOfDay;

                if (inicio < canchaReal.Sede.HoraApertura || fin > canchaReal.Sede.HoraCierre)
                {
                    MessageBox.Show(string.Format("La Sede atiende de {0} a {1}. Reserva fuera de rango.",
                        canchaReal.Sede.HoraApertura.ToString(@"hh\:mm"), canchaReal.Sede.HoraCierre.ToString(@"hh\:mm")));
                    return;
                }

                if (inicio >= fin || (fin - inicio).TotalMinutes % 60 != 0)
                {
                    MessageBox.Show("La reserva debe ser por bloques de horas exactas (ej: 1h, 2h) y el inicio antes que el fin.");
                    return;
                }

                Reserva nuevaReserva = new Reserva();
                nuevaReserva.IDReserva = int.Parse(txtIDReserva.Text);
                nuevaReserva.Fecha = dtpFecha.Value.Date;
                nuevaReserva.HoraInicio = inicio;
                nuevaReserva.HoraFin = fin;
                nuevaReserva.MontoTotal = double.Parse(txtMontoTotal.Text);
                nuevaReserva.Estado = cmbEstado.Text;
                nuevaReserva.Cliente = clienteReal;
                nuevaReserva.Cancha = canchaReal;
                nuevaReserva.CreadoPor = 1;
                nuevaReserva.ModificadoPor = 1;

                if (!reservaController.RegistrarReserva(nuevaReserva))
                {
                    MessageBox.Show("ID duplicado o Cruce de horarios detectado.");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Verifique que los datos numéricos (IDs, Monto) sean correctos.");
                return;
            }

            MostrarEnDataGrid(reservaController.ListarTodo());
            LimpiarCampos();
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

                Cliente clienteReal = clienteController.BuscarClientePorID(idCliente);
                Cancha canchaReal = canchaController.BuscarCancha(idCancha);

                if (clienteReal == null || canchaReal == null)
                {
                    MessageBox.Show("Error: El ID de Cliente o de Cancha no existen.");
                    return;
                }

                TimeSpan inicio = dtpHoraInicio.Value.TimeOfDay;
                TimeSpan fin = dtpHoraFin.Value.TimeOfDay;

                if (inicio >= fin || (fin - inicio).TotalMinutes % 60 != 0)
                {
                    MessageBox.Show("Debe ser por bloques de 1 hora exacta.");
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

                // Auditoría
                reservaModificada.FechaCreacion = dtpFechaCreacion.Value;
                reservaModificada.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);
                reservaModificada.FechaModificacion = DateTime.Now;
                reservaModificada.ModificadoPor = 1;

                if (!reservaController.EditarReserva(reservaModificada))
                {
                    MessageBox.Show("Error: No se pudo editar por cruce de horarios.");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique los datos ingresados.");
                return;
            }

            MostrarEnDataGrid(reservaController.ListarTodo());
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea CANCELAR esta reserva?", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    reservaController.CancelarReserva(idReservaSeleccionada);
                    MostrarEnDataGrid(reservaController.ListarTodo());
                    LimpiarCampos();
                }
            }
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                var fila = dgvReservas.SelectedRows[0];
                if (fila.Cells["IDReserva"].Value == null) return;

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

                // Auditoría
                txtCreadoPor.Text = fila.Cells["CreadoPor"].Value.ToString();
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                txtModificadoPor.Text = fila.Cells["ModificadoPor"].Value.ToString();
                dtpFechaModificacion.Value = Convert.ToDateTime(fila.Cells["FechaModificacion"].Value);

                idReservaSeleccionada = Convert.ToInt32(fila.Cells["IDReserva"].Value);
                txtIDReserva.Enabled = false; // Bloqueamos el ID para evitar ediciones de PK
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
                FormPago formPago = new FormPago(((FormPrincipal)principal).pagoController, this.reservaController, idReservaSeleccionada);
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

        private void btnImplementoReserva_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada != -1)
            {
                // Llamamos al NUEVO nombre del form y le pasamos el controlador correcto
                FormReservaImplemento form = new FormReservaImplemento(idReservaSeleccionada, this.reservaController);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seleccione una reserva primero.");
            }
        }

        private void FormGestionReservas_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                MostrarEnDataGrid(reservaController.ListarTodo());
                LimpiarCampos();
            }
        }
    }
}
