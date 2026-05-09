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
    public partial class FormAdministradores : Form
    {
        // Variable global para usar el controlador con los datos en memoria
        private AdministradorController adminController;

        // Variable para saber qué administrador seleccionamos en la grilla
        private int idAdminSeleccionado = -1;

        // Modificamos el constructor para recibir el controlador desde el FormPrincipal
        public FormAdministradores(AdministradorController pAdminController)
        {
            InitializeComponent();
            this.adminController = pAdminController;
        }


        private void FormAdministradores_Load(object sender, EventArgs e)
        {
            // Bloqueamos los campos de auditoría para que el usuario no pueda editarlos
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            // Llenamos el ComboBox de Permisos
            cmbPermiso.Items.Add("SuperAdmin");
            cmbPermiso.Items.Add("Admin Estandar");
            cmbPermiso.Items.Add("Recepcionista");
            cmbPermiso.SelectedIndex = 0;

            CargarGrilla();
        }

        // Método para actualizar el DataGridView
        private void CargarGrilla()
        {
            dgvAdministradores.DataSource = null;
            dgvAdministradores.DataSource = adminController.ListarTodo();

            // Opcional: Ocultar columnas que no queremos mostrar en la tabla (como la contraseña)
            if (dgvAdministradores.Columns["Contrasena"] != null)
                dgvAdministradores.Columns["Contrasena"].Visible = false;
        }

        // Método para limpiar las cajas de texto
        private void LimpiarCampos()
        {
            txtID.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtContrasena.Clear();
            cmbPermiso.SelectedIndex = 0;

            txtCreadoPor.Clear();
            txtModificadoPor.Clear();
            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaModificacion.Value = DateTime.Now;
            dtpFechaInicio.Value = DateTime.Now;

            idAdminSeleccionado = -1;
        }

        // Evento del Botón Verde (+) -> GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Administrador nuevoAdmin = new Administrador();
                nuevoAdmin.IDAdministrador = int.Parse(txtID.Text);
                nuevoAdmin.DNI = txtDNI.Text;
                nuevoAdmin.Nombre = txtNombre.Text;
                nuevoAdmin.Telefono = txtTelefono.Text;
                nuevoAdmin.Permisos = cmbPermiso.Text;
                nuevoAdmin.Contrasena = txtContrasena.Text;

                // Campos de Auditoría automatizados por el sistema
                nuevoAdmin.FechaCreacion = DateTime.Now;
                nuevoAdmin.FechaModificacion = DateTime.Now;
                nuevoAdmin.CreadoPor = 1;      // ID simulado del usuario logueado
                nuevoAdmin.ModificadoPor = 1;  // ID simulado del usuario logueado

                if (adminController.RegistrarAdministrador(nuevoAdmin))
                {
                    MessageBox.Show("Administrador registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El DNI o ID ya existe en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, verifique que los datos (como el ID) sean correctos. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del Botón Azul -> MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idAdminSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un administrador de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Administrador adminModificado = new Administrador();
            adminModificado.IDAdministrador = idAdminSeleccionado;
            adminModificado.DNI = txtDNI.Text;
            adminModificado.Nombre = txtNombre.Text;
            adminModificado.Telefono = txtTelefono.Text;
            adminModificado.Permisos = cmbPermiso.Text;
            adminModificado.Contrasena = txtContrasena.Text;

            // Mantenemos la fecha de creación original que ya está en el control,
            // pero actualizamos la fecha de modificación al instante actual.
            adminModificado.FechaCreacion = dtpFechaCreacion.Value;
            adminModificado.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);

            adminModificado.FechaModificacion = DateTime.Now;
            adminModificado.ModificadoPor = 1; // ID del usuario que está haciendo el cambio

            if (adminController.EditarAdministrador(adminModificado))
            {
                MessageBox.Show("Administrador modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
            }
        }

        // Evento del Botón Rojo -> ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idAdminSeleccionado != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de eliminar este administrador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    adminController.EliminarAdministrador(idAdminSeleccionado);
                    CargarGrilla();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un administrador de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento para cuando el usuario hace clic en una fila del DataGridView
        private void dgvAdministradores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no se haya hecho clic en la cabecera de la columna
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAdministradores.Rows[e.RowIndex];

                // Llenamos los datos en las cajas de texto
                txtID.Text = fila.Cells["IDAdministrador"].Value.ToString();
                txtDNI.Text = fila.Cells["DNI"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                cmbPermiso.Text = fila.Cells["Permisos"].Value.ToString();

                // Extraemos la contraseña (aunque esté oculta en la grilla, el valor existe)
                if (fila.Cells["Contrasena"].Value != null)
                    txtContrasena.Text = fila.Cells["Contrasena"].Value.ToString();

                // Llenamos los campos de auditoría de solo lectura
                txtCreadoPor.Text = fila.Cells["CreadoPor"].Value.ToString();
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                txtModificadoPor.Text = fila.Cells["ModificadoPor"].Value.ToString();
                dtpFechaModificacion.Value = Convert.ToDateTime(fila.Cells["FechaModificacion"].Value);

                // Guardamos el ID seleccionado para usarlo en Editar o Eliminar
                idAdminSeleccionado = int.Parse(txtID.Text);
            }
        }

        // Evento del Botón de Regresar al Menú Principal
        private void btnMenu_Click(object sender, EventArgs e)
        {
            RegresarAlMenu();
        }

        // Evento para la "X" roja de la ventana
        private void FormAdministradores_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegresarAlMenu();
        }

        // Método auxiliar para evitar repetir código de regreso
        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null)
            {
                principal.Show();
            }
            this.Hide(); // Ocultamos en lugar de Close() si estamos en el evento FormClosed para no causar conflictos, o lo cerramos
        }
    }
}
