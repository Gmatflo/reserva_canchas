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
    public partial class FormClientes : Form
    {
        private ClienteController clienteController;
        private int idClienteSeleccionado = -1;

        // El constructor recibe el controlador instanciado en el FormPrincipal
        public FormClientes(ClienteController pClienteController)
        {
            InitializeComponent();
            this.clienteController = pClienteController;
        }


        private void FormClientes_Load(object sender, EventArgs e)
        {
            // Bloqueamos los campos de auditoría para que el usuario no los edite manualmente
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clienteController.ListarTodo();

            // Ocultamos columnas internas que no aportan a la vista rápida del administrador
            if (dgvClientes.Columns["Contrasena"] != null) dgvClientes.Columns["Contrasena"].Visible = false;
            if (dgvClientes.Columns["IDUsuario"] != null) dgvClientes.Columns["IDUsuario"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtIDCliente.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;

            txtCreadoPor.Clear();
            txtModificadoPor.Clear();
            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaModificacion.Value = DateTime.Now;

            idClienteSeleccionado = -1;
        }

        // Botón Verde (+) -> GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevoCliente = new Cliente();
                nuevoCliente.IDCliente = int.Parse(txtIDCliente.Text);
                nuevoCliente.DNI = txtDNI.Text;
                nuevoCliente.Nombre = txtNombre.Text; // Este atributo lo hereda de la clase Usuario
                nuevoCliente.Telefono = txtTelefono.Text;
                nuevoCliente.FechaNacimiento = dtpFechaNacimiento.Value;

                // Auditoría invisible automatizada
                nuevoCliente.FechaCreacion = DateTime.Now;
                nuevoCliente.FechaModificacion = DateTime.Now;
                nuevoCliente.CreadoPor = 1;
                nuevoCliente.ModificadoPor = 1;

                if (clienteController.RegistrarCliente(nuevoCliente))
                {
                    MessageBox.Show("Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El DNI o ID de Cliente ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique que los datos sean correctos. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Azul -> MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un cliente de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cliente clienteModificado = new Cliente();
                clienteModificado.IDCliente = idClienteSeleccionado;
                clienteModificado.DNI = txtDNI.Text;
                clienteModificado.Nombre = txtNombre.Text;
                clienteModificado.Telefono = txtTelefono.Text;
                clienteModificado.FechaNacimiento = dtpFechaNacimiento.Value;

                // Auditoría: Mantenemos la creación, actualizamos la modificación
                clienteModificado.FechaCreacion = dtpFechaCreacion.Value;
                clienteModificado.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);

                clienteModificado.FechaModificacion = DateTime.Now;
                clienteModificado.ModificadoPor = 1;

                if (clienteController.EditarCliente(clienteModificado))
                {
                    MessageBox.Show("Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Rojo -> ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    clienteController.EliminarCliente(idClienteSeleccionado);
                    CargarGrilla();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento CellClick del DataGridView
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                txtIDCliente.Text = fila.Cells["IDCliente"].Value.ToString();
                txtDNI.Text = fila.Cells["DNI"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(fila.Cells["FechaNacimiento"].Value);

                // Auditoría
                txtCreadoPor.Text = fila.Cells["CreadoPor"].Value.ToString();
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                txtModificadoPor.Text = fila.Cells["ModificadoPor"].Value.ToString();
                dtpFechaModificacion.Value = Convert.ToDateTime(fila.Cells["FechaModificacion"].Value);

                idClienteSeleccionado = int.Parse(txtIDCliente.Text);
            }
        }

        // Navegación para regresar al menú
        private void btnMenu_Click(object sender, EventArgs e)
        {
            RegresarAlMenu();
        }

        private void FormClientes_FormClosed(object sender, FormClosedEventArgs e)
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
