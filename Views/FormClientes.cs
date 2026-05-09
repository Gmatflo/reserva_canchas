using MultiSport_Manager.Controllers;
using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
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
            this.dgvClientes.SelectionChanged += new System.EventHandler(this.dgvClientes_SelectionChanged);
            MostrarEnDataGrid(clienteController.ListarTodo());
        }

        private void MostrarEnDataGrid(List<Cliente> lista)
        {
            dgvClientes.DataSource = null;
            if (lista.Count > 0)
            {
                dgvClientes.DataSource = lista;

                if (dgvClientes.Columns["Contrasena"] != null) dgvClientes.Columns["Contrasena"].Visible = false;
                if (dgvClientes.Columns["IDUsuario"] != null) dgvClientes.Columns["IDUsuario"].Visible = false;

                if (dgvClientes.Columns["FechaNacimiento"] != null)
                    dgvClientes.Columns["FechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
            txtIDCliente.Enabled = true;
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
                nuevoCliente.FechaNacimiento = dtpFechaNacimiento.Value.Date;

                nuevoCliente.CreadoPor = 1;
                nuevoCliente.ModificadoPor = 1;

                if (!clienteController.RegistrarCliente(nuevoCliente))
                {
                    MessageBox.Show("El DNI o ID de Cliente ya existe en el sistema.");
                    return;
                }

                MostrarEnDataGrid(clienteController.ListarTodo());
                LimpiarCampos();
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
                clienteModificado.IDCliente = idClienteSeleccionado; // ID Original
                clienteModificado.DNI = txtDNI.Text;
                clienteModificado.Nombre = txtNombre.Text;
                clienteModificado.Telefono = txtTelefono.Text;
                clienteModificado.FechaNacimiento = dtpFechaNacimiento.Value.Date;

                clienteModificado.FechaCreacion = dtpFechaCreacion.Value;
                clienteModificado.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);

                clienteModificado.FechaModificacion = DateTime.Now;
                clienteModificado.ModificadoPor = 1;

                if (clienteController.EditarCliente(clienteModificado))
                {
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

                clienteController.EliminarCliente(idClienteSeleccionado);
                MostrarEnDataGrid(clienteController.ListarTodo());
                LimpiarCampos();

            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var fila = dgvClientes.SelectedRows[0];

                txtIDCliente.Text = fila.Cells["IDCliente"].Value.ToString();
                txtDNI.Text = fila.Cells["DNI"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();

                if (fila.Cells["FechaNacimiento"].Value != null)
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
