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
        private AdministradorController adminController;
        private int idAdminSeleccionado = -1;

        public FormAdministradores(AdministradorController pAdminController)
        {
            InitializeComponent();
            this.adminController = pAdminController;
        }

        private void MostrarEnDataGrid(List<Administrador> lista)
        {
            dgvAdministradores.DataSource = null;
            if (lista.Count > 0)
            {
                dgvAdministradores.DataSource = lista;
                if (dgvAdministradores.Columns["Contrasena"] != null)
                    dgvAdministradores.Columns["Contrasena"].Visible = false;
            }
        }

        private void FormAdministradores_Load(object sender, EventArgs e)
        {
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            cmbPermiso.Items.Add("SuperAdmin");
            cmbPermiso.Items.Add("Admin Estandar");
            cmbPermiso.Items.Add("Recepcionista");
            cmbPermiso.SelectedIndex = 0;

            MostrarEnDataGrid(adminController.ListarTodo());
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtContrasena.Clear();
            cmbPermiso.SelectedIndex = 0;
            idAdminSeleccionado = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtDNI.Text == "" || txtNombre.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            try
            {
                Administrador nuevoAdmin = new Administrador();
                nuevoAdmin.IDAdministrador = int.Parse(txtID.Text);
                nuevoAdmin.DNI = txtDNI.Text;
                nuevoAdmin.Nombre = txtNombre.Text;
                nuevoAdmin.Telefono = txtTelefono.Text;
                nuevoAdmin.Permisos = cmbPermiso.Text;
                nuevoAdmin.Contrasena = txtContrasena.Text;

                nuevoAdmin.CreadoPor = 1;
                nuevoAdmin.ModificadoPor = 1;

                bool registroExito = adminController.RegistrarAdministrador(nuevoAdmin);

                if (!registroExito)
                {
                    MessageBox.Show("El DNI o ID ya existe en el sistema.");
                    return;
                }

                MessageBox.Show("Administrador registrado correctamente.");
                MostrarEnDataGrid(adminController.ListarTodo());
                LimpiarCampos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Asegúrese de ingresar solo números en el ID.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idAdminSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un administrador de la tabla.");
                return;
            }

            try
            {
                Administrador adminModificado = new Administrador();
                adminModificado.IDAdministrador = idAdminSeleccionado;
                adminModificado.DNI = txtDNI.Text;
                adminModificado.Nombre = txtNombre.Text;
                adminModificado.Telefono = txtTelefono.Text;
                adminModificado.Permisos = cmbPermiso.Text;
                adminModificado.Contrasena = txtContrasena.Text;

                adminModificado.FechaCreacion = dtpFechaCreacion.Value;
                adminModificado.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);
                adminModificado.ModificadoPor = 1;

                bool editado = adminController.EditarAdministrador(adminModificado);
                if (editado)
                {
                    MessageBox.Show("Administrador modificado.");
                    MostrarEnDataGrid(adminController.ListarTodo());
                    LimpiarCampos();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar. Verifique los datos numéricos.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idAdminSeleccionado != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de eliminar este administrador?", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    adminController.EliminarAdministrador(idAdminSeleccionado);
                    MostrarEnDataGrid(adminController.ListarTodo());
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un administrador de la tabla.");
            }
        }

        private void dgvAdministradores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAdministradores.Rows[e.RowIndex];

                txtID.Text = fila.Cells["IDAdministrador"].Value.ToString();
                txtDNI.Text = fila.Cells["DNI"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                cmbPermiso.Text = fila.Cells["Permisos"].Value.ToString();

                if (fila.Cells["Contrasena"].Value != null)
                    txtContrasena.Text = fila.Cells["Contrasena"].Value.ToString();

                txtCreadoPor.Text = fila.Cells["CreadoPor"].Value.ToString();
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                txtModificadoPor.Text = fila.Cells["ModificadoPor"].Value.ToString();
                dtpFechaModificacion.Value = Convert.ToDateTime(fila.Cells["FechaModificacion"].Value);

                idAdminSeleccionado = int.Parse(txtID.Text);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) { RegresarAlMenu(); }
        private void FormAdministradores_FormClosed(object sender, FormClosedEventArgs e) { RegresarAlMenu(); }

        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null) principal.Show();
            this.Hide();
        }
    }
}
