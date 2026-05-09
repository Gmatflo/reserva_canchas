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

        public FormClientes(ClienteController pClienteController)
        {
            InitializeComponent();
            this.clienteController = pClienteController;
        }

        private void MostrarEnDataGrid(List<Cliente> lista)
        {
            dgvClientes.DataSource = null;
            if (lista.Count > 0)
            {
                dgvClientes.DataSource = lista;
                if (dgvClientes.Columns["Contrasena"] != null) dgvClientes.Columns["Contrasena"].Visible = false;
                if (dgvClientes.Columns["IDUsuario"] != null) dgvClientes.Columns["IDUsuario"].Visible = false;
            }
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            MostrarEnDataGrid(clienteController.ListarTodo());
        }

        private void LimpiarCampos()
        {
            txtIDCliente.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;

            idClienteSeleccionado = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIDCliente.Text == "" || txtDNI.Text == "" || txtNombre.Text == "")
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            try
            {
                Cliente nuevoCliente = new Cliente();
                nuevoCliente.IDCliente = int.Parse(txtIDCliente.Text);
                nuevoCliente.DNI = txtDNI.Text;
                nuevoCliente.Nombre = txtNombre.Text;
                nuevoCliente.Telefono = txtTelefono.Text;
                nuevoCliente.FechaNacimiento = dtpFechaNacimiento.Value;

                nuevoCliente.CreadoPor = 1;
                nuevoCliente.ModificadoPor = 1;

                if (clienteController.RegistrarCliente(nuevoCliente))
                {
                    MessageBox.Show("Cliente registrado correctamente.");
                    MostrarEnDataGrid(clienteController.ListarTodo());
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El DNI o ID de Cliente ya existe en el sistema.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Asegúrese de ingresar solo números en el ID.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un cliente de la tabla.");
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

                clienteModificado.FechaCreacion = dtpFechaCreacion.Value;
                clienteModificado.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);
                clienteModificado.ModificadoPor = 1;

                if (clienteController.EditarCliente(clienteModificado))
                {
                    MessageBox.Show("Cliente modificado correctamente.");
                    MostrarEnDataGrid(clienteController.ListarTodo());
                    LimpiarCampos();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar. Verifique los datos ingresados.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    clienteController.EliminarCliente(idClienteSeleccionado);
                    MostrarEnDataGrid(clienteController.ListarTodo());
                    LimpiarCampos();
                }
            }
        }

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

                txtCreadoPor.Text = fila.Cells["CreadoPor"].Value.ToString();
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                txtModificadoPor.Text = fila.Cells["ModificadoPor"].Value.ToString();
                dtpFechaModificacion.Value = Convert.ToDateTime(fila.Cells["FechaModificacion"].Value);

                idClienteSeleccionado = int.Parse(txtIDCliente.Text);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) { RegresarAlMenu(); }
        private void FormClientes_FormClosed(object sender, FormClosedEventArgs e) { RegresarAlMenu(); }
        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null) principal.Show();
            this.Hide();
        }
    }
}
