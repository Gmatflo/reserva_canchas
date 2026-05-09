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

namespace reserva_canchas.forms
{
    public partial class FormNotificaciones : Form
    {
        private NotificacionController notificacionController;
        private ClienteController clienteController;
        private int idNotificacionSeleccionada = -1;

        public FormNotificaciones(NotificacionController pNotificacionController, ClienteController pClienteController)
        {
            InitializeComponent();
            this.notificacionController = pNotificacionController;
            this.clienteController = pClienteController;
            this.dgvNotificaciones.SelectionChanged += new System.EventHandler(this.dgvNotificaciones_SelectionChanged);
            MostrarEnDataGrid(notificacionController.ListarTodo());
        }

        private void MostrarEnDataGrid(List<Notificacion> lista)
        {
            dgvNotificaciones.DataSource = null;
            if (lista.Count > 0) dgvNotificaciones.DataSource = lista;
        }

        private void FormNotificaciones_Load(object sender, EventArgs e)
        {
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            MostrarEnDataGrid(notificacionController.ListarTodo());
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtIDNotificacion.Clear();
            txtIDNotificacion.Enabled = true;
            txtIDUsuario.Clear();
            dtpFecha.Value = DateTime.Now;
            txtMensaje.Clear();
            idNotificacionSeleccionada = -1;
            dgvNotificaciones.ClearSelection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIDNotificacion.Text == "" || txtIDUsuario.Text == "" || txtMensaje.Text == "")
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            try
            {
                int idCliente = int.Parse(txtIDUsuario.Text);
                Cliente clienteReal = clienteController.BuscarClientePorID(idCliente);

                if (clienteReal == null)
                {
                    MessageBox.Show("El ID de Cliente ingresado no existe.");
                    return;
                }

                Notificacion nuevaNotificacion = new Notificacion();
                nuevaNotificacion.IDNotificacion = int.Parse(txtIDNotificacion.Text);
                nuevaNotificacion.FechaEnvio = dtpFecha.Value;
                nuevaNotificacion.Mensaje = txtMensaje.Text;
                nuevaNotificacion.ClienteDestino = clienteReal;
                nuevaNotificacion.CreadoPor = 1;
                nuevaNotificacion.ModificadoPor = 1;

                if (!notificacionController.RegistrarNotificacion(nuevaNotificacion))
                {
                    MessageBox.Show("El ID de notificación ya existe.");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Use solo números para los IDs.");
                return;
            }

            MostrarEnDataGrid(notificacionController.ListarTodo());
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idNotificacionSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una notificación.");
                return;
            }

            try
            {
                int idCliente = int.Parse(txtIDUsuario.Text);
                Cliente clienteReal = clienteController.BuscarClientePorID(idCliente);

                if (clienteReal == null)
                {
                    MessageBox.Show("El ID de Cliente no existe.");
                    return;
                }

                Notificacion notifModificada = new Notificacion();
                notifModificada.IDNotificacion = idNotificacionSeleccionada;
                notifModificada.FechaEnvio = dtpFecha.Value;
                notifModificada.Mensaje = txtMensaje.Text;
                notifModificada.ClienteDestino = clienteReal;
                notifModificada.FechaCreacion = dtpFechaCreacion.Value;
                notifModificada.CreadoPor = 1;
                notifModificada.FechaModificacion = DateTime.Now;
                notifModificada.ModificadoPor = 1;

                notificacionController.EditarNotificacion(notifModificada);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar. Verifique los datos.");
                return;
            }

            MostrarEnDataGrid(notificacionController.ListarTodo());
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idNotificacionSeleccionada != -1)
            {
                notificacionController.EliminarNotificacion(idNotificacionSeleccionada);
                MostrarEnDataGrid(notificacionController.ListarTodo());
                LimpiarCampos();
            }
        }

        private void dgvNotificaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNotificaciones.SelectedRows.Count > 0)
            {
                var fila = dgvNotificaciones.SelectedRows[0];
                if (fila.Cells["IDNotificacion"].Value == null) return;

                txtIDNotificacion.Text = fila.Cells["IDNotificacion"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["FechaEnvio"].Value);
                txtMensaje.Text = fila.Cells["Mensaje"].Value.ToString();

                if (fila.Cells["ClienteDestino"].Value != null)
                {
                    var clienteAsociado = (Cliente)fila.Cells["ClienteDestino"].Value;
                    txtIDUsuario.Text = clienteAsociado.IDCliente.ToString();
                }

                idNotificacionSeleccionada = Convert.ToInt32(fila.Cells["IDNotificacion"].Value);
                txtIDNotificacion.Enabled = false;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) { RegresarAlMenu(); }
        private void FormNotificaciones_FormClosed(object sender, FormClosedEventArgs e) { RegresarAlMenu(); }
        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null) principal.Show();
            this.Hide();
        }
    }
}
