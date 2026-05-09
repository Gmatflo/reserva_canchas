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


        private void FormNotificaciones_Load(object sender, EventArgs e)
        {
            // Bloqueo de campos de auditoría
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            // Configuración del ComboBox de estado de lectura
            cmbLeido.Items.Add("Si");
            cmbLeido.Items.Add("No");
            cmbLeido.SelectedIndex = 1; // Por defecto "No" al registrar

            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvNotificaciones.DataSource = null;
            // Asumiendo que agregaron un ListarTodo() a su controlador para la vista de administrador
            // dgvNotificaciones.DataSource = notificacionController.ListarTodo();
        }

        private void LimpiarCampos()
        {
            txtIDNotificacion.Clear();
            txtIDUsuario.Clear();
            dtpFecha.Value = DateTime.Now;
            txtMensaje.Clear();
            cmbLeido.SelectedIndex = 1;

            txtCreadoPor.Clear();
            txtModificadoPor.Clear();
            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaModificacion.Value = DateTime.Now;

            idNotificacionSeleccionada = -1;
        }

        // Botón Verde (+) -> GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Notificacion nuevaNotificacion = new Notificacion();
                nuevaNotificacion.IDNotificacion = int.Parse(txtIDNotificacion.Text);
                nuevaNotificacion.FechaEnvio = dtpFecha.Value;
                nuevaNotificacion.Mensaje = txtMensaje.Text;

                // Si agregaron la propiedad Leido en la entidad:
                // nuevaNotificacion.Leido = cmbLeido.Text;

                // Instanciamos un usuario temporal solo con el ID para mantener la relación
                nuevaNotificacion.UsuarioDestino = new Usuario { IDUsuario = int.Parse(txtIDUsuario.Text) };

                // Auditoría invisible
                nuevaNotificacion.FechaCreacion = DateTime.Now;
                nuevaNotificacion.FechaModificacion = DateTime.Now;
                nuevaNotificacion.CreadoPor = 1;
                nuevaNotificacion.ModificadoPor = 1;

                // Asumiendo que el controlador fue adaptado para recibir el objeto completo
                // if (notificacionController.RegistrarNotificacion(nuevaNotificacion))
                // {
                MessageBox.Show("Notificación registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique que los campos numéricos sean correctos. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Azul -> MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idNotificacionSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una notificación de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Notificacion notifModificada = new Notificacion();
                notifModificada.IDNotificacion = idNotificacionSeleccionada;
                notifModificada.FechaEnvio = dtpFecha.Value;
                notifModificada.Mensaje = txtMensaje.Text;
                // notifModificada.Leido = cmbLeido.Text;
                notifModificada.UsuarioDestino = new Usuario { IDUsuario = int.Parse(txtIDUsuario.Text) };

                // Auditoría: Mantenemos la creación, actualizamos la modificación
                notifModificada.FechaCreacion = dtpFechaCreacion.Value;
                notifModificada.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);

                notifModificada.FechaModificacion = DateTime.Now;
                notifModificada.ModificadoPor = 1;

                // if (notificacionController.EditarNotificacion(notifModificada))
                // {
                MessageBox.Show("Notificación modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Rojo -> ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idNotificacionSeleccionada != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de eliminar esta notificación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    // notificacionController.EliminarNotificacion(idNotificacionSeleccionada);
                    CargarGrilla();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una notificación de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento CellClick del DataGridView
        private void dgvNotificaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvNotificaciones.Rows[e.RowIndex];

                txtIDNotificacion.Text = fila.Cells["IDNotificacion"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["FechaEnvio"].Value);
                txtMensaje.Text = fila.Cells["Mensaje"].Value.ToString();

                // Mapeo del atributo Leido si lo implementaron
                // cmbLeido.Text = fila.Cells["Leido"].Value.ToString();

                if (fila.Cells["UsuarioDestino"].Value != null)
                {
                    var usuarioAsociado = (Usuario)fila.Cells["UsuarioDestino"].Value;
                    txtIDUsuario.Text = usuarioAsociado.IDUsuario.ToString();
                }

                // Auditoría
                txtCreadoPor.Text = fila.Cells["CreadoPor"].Value.ToString();
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                txtModificadoPor.Text = fila.Cells["ModificadoPor"].Value.ToString();
                dtpFechaModificacion.Value = Convert.ToDateTime(fila.Cells["FechaModificacion"].Value);

                idNotificacionSeleccionada = int.Parse(txtIDNotificacion.Text);
            }
        }

        // Navegación para regresar al menú
        private void btnMenu_Click(object sender, EventArgs e)
        {
            RegresarAlMenu();
        }

        private void FormNotificaciones_FormClosed(object sender, FormClosedEventArgs e)
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
