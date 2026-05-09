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
        private int idNotificacionSeleccionada = -1;

        public FormNotificaciones(NotificacionController pNotificacionController)
        {
            InitializeComponent();
            this.notificacionController = pNotificacionController;
        }

        private void MostrarEnDataGrid(List<Notificacion> lista)
        {
            dgvNotificaciones.DataSource = null;
            if (lista.Count > 0)
            {
                dgvNotificaciones.DataSource = lista;
            }
        }

        private void FormNotificaciones_Load(object sender, EventArgs e)
        {
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            cmbLeido.Items.Add("Si");
            cmbLeido.Items.Add("No");
            cmbLeido.SelectedIndex = 1;

            MostrarEnDataGrid(notificacionController.ListarTodo());
        }

        private void LimpiarCampos()
        {
            txtIDNotificacion.Clear();
            txtIDUsuario.Clear();
            dtpFecha.Value = DateTime.Now;
            txtMensaje.Clear();
            cmbLeido.SelectedIndex = 1;
            idNotificacionSeleccionada = -1;
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
                Notificacion nuevaNotificacion = new Notificacion();
                nuevaNotificacion.IDNotificacion = int.Parse(txtIDNotificacion.Text);
                nuevaNotificacion.FechaEnvio = dtpFecha.Value;
                nuevaNotificacion.Mensaje = txtMensaje.Text;

                nuevaNotificacion.UsuarioDestino = new Usuario { IDUsuario = int.Parse(txtIDUsuario.Text) };

                nuevaNotificacion.CreadoPor = 1;
                nuevaNotificacion.ModificadoPor = 1;

                if (notificacionController.RegistrarNotificacion(nuevaNotificacion))
                {
                    MessageBox.Show("Notificación guardada.");
                    MostrarEnDataGrid(notificacionController.ListarTodo());
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El ID de notificación ya existe.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Asegúrese de ingresar números en los campos de ID.");
            }
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
                Notificacion notifModificada = new Notificacion();
                notifModificada.IDNotificacion = idNotificacionSeleccionada;
                notifModificada.FechaEnvio = dtpFecha.Value;
                notifModificada.Mensaje = txtMensaje.Text;
                notifModificada.UsuarioDestino = new Usuario { IDUsuario = int.Parse(txtIDUsuario.Text) };

                notifModificada.FechaCreacion = dtpFechaCreacion.Value;
                notifModificada.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);
                notifModificada.ModificadoPor = 1;

                if (notificacionController.EditarNotificacion(notifModificada))
                {
                    MessageBox.Show("Notificación actualizada.");
                    MostrarEnDataGrid(notificacionController.ListarTodo());
                    LimpiarCampos();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error numérico en los campos de ID.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idNotificacionSeleccionada != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Eliminar esta notificación?", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    notificacionController.EliminarNotificacion(idNotificacionSeleccionada);
                    MostrarEnDataGrid(notificacionController.ListarTodo());
                    LimpiarCampos();
                }
            }
        }

        private void dgvNotificaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvNotificaciones.Rows[e.RowIndex];

                txtIDNotificacion.Text = fila.Cells["IDNotificacion"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["FechaEnvio"].Value);
                txtMensaje.Text = fila.Cells["Mensaje"].Value.ToString();

                if (fila.Cells["UsuarioDestino"].Value != null)
                {
                    var usuarioAsociado = (Usuario)fila.Cells["UsuarioDestino"].Value;
                    txtIDUsuario.Text = usuarioAsociado.IDUsuario.ToString();
                }

                idNotificacionSeleccionada = int.Parse(txtIDNotificacion.Text);
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
