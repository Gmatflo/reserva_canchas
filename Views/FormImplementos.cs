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

namespace MultiSport_Manager.Views
{
    public partial class FormImplementos : Form
    {
        private ImplementoController implementoController = new ImplementoController();
        private SedeController sedeController = new SedeController();

        private int idSedeActual;
        private int idImplementoSeleccionado = -1;

        public FormImplementos(int pIdSede)
        {
            InitializeComponent();
            this.idSedeActual = pIdSede;
            lblIdSede.Text = idSedeActual.ToString();

            this.dgvImplementos.SelectionChanged += new System.EventHandler(this.dgvImplementos_SelectionChanged);
            MostrarEnDataGrid();
        }

        private void FormImplementos_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add("Disponible");
            cmbEstado.Items.Add("Agotado");
            cmbEstado.Items.Add("En Mantenimiento");
            cmbEstado.SelectedIndex = 0;

            MostrarEnDataGrid();
            LimpiarCampos();
        }

        private void MostrarEnDataGrid()
        {
            dgvImplementos.DataSource = null;
            List<Implemento> lista = implementoController.ListarPorSede(idSedeActual);

            if (lista.Count > 0)
            {
                dgvImplementos.DataSource = lista;
                if (dgvImplementos.Columns["Sede"] != null)
                    dgvImplementos.Columns["Sede"].Visible = false;
            }
        }

        private void LimpiarCampos()
        {
            txtIDImplemento.Clear();
            txtIDImplemento.Enabled = true;
            txtNombreImplemento.Clear();
            txtStockTotal.Clear();
            txtPrecioAlquiler.Clear();
            cmbEstado.SelectedIndex = 0;
            idImplementoSeleccionado = -1;
            dgvImplementos.ClearSelection();
        }

        private void btnRegistrarImplemento_Click(object sender, EventArgs e)
        {
            if (txtIDImplemento.Text == "" || txtNombreImplemento.Text == "" || txtStockTotal.Text == "" || txtPrecioAlquiler.Text == "")
            {
                MessageBox.Show("Rellene todos los campos obligatorios.");
                return;
            }

            try
            {
                Sede sedeEncontrada = sedeController.BuscarSede(idSedeActual);

                Implemento nuevo = new Implemento();
                nuevo.IDImplemento = int.Parse(txtIDImplemento.Text);
                nuevo.Nombre = txtNombreImplemento.Text;
                nuevo.StockTotal = int.Parse(txtStockTotal.Text);
                nuevo.PrecioAlquiler = double.Parse(txtPrecioAlquiler.Text);
                nuevo.Estado = cmbEstado.Text;
                nuevo.Sede = sedeEncontrada;

                nuevo.CreadoPor = 1;
                nuevo.ModificadoPor = 1;

                if (!implementoController.RegistrarImplemento(nuevo))
                {
                    MessageBox.Show("Ese ID ya existe.");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Verifique que ID, Stock y Precio sean solo números.");
                return;
            }

            MostrarEnDataGrid();
            LimpiarCampos();
        }

        private void btnModificarImplemento_Click(object sender, EventArgs e)
        {
            if (idImplementoSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un elemento de la tabla.");
                return;
            }

            try
            {
                Sede sedeEncontrada = sedeController.BuscarSede(idSedeActual);

                Implemento mod = new Implemento();
                mod.IDImplemento = idImplementoSeleccionado;
                mod.Nombre = txtNombreImplemento.Text;
                mod.StockTotal = int.Parse(txtStockTotal.Text);
                mod.PrecioAlquiler = double.Parse(txtPrecioAlquiler.Text);
                mod.Estado = cmbEstado.Text;
                mod.Sede = sedeEncontrada;

                mod.FechaModificacion = DateTime.Now;
                mod.ModificadoPor = 1;

                implementoController.EditarImplemento(mod);
            }
            catch (Exception)
            {
                MessageBox.Show("Error en los datos numéricos.");
                return;
            }

            MostrarEnDataGrid();
            LimpiarCampos();
        }

        private void btnEliminarImplemento_Click(object sender, EventArgs e)
        {
            if (idImplementoSeleccionado != -1)
            {
                    implementoController.EliminarImplemento(idImplementoSeleccionado);
                    MostrarEnDataGrid();
                    LimpiarCampos();
            }
        }

        private void dgvImplementos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvImplementos.SelectedRows.Count > 0)
            {
                var fila = dgvImplementos.SelectedRows[0];
                if (fila.Cells["IDImplemento"].Value == null) return;

                txtIDImplemento.Text = fila.Cells["IDImplemento"].Value.ToString();
                txtNombreImplemento.Text = fila.Cells["Nombre"].Value.ToString();
                txtStockTotal.Text = fila.Cells["StockTotal"].Value.ToString();
                txtPrecioAlquiler.Text = fila.Cells["PrecioAlquiler"].Value.ToString();
                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();

                idImplementoSeleccionado = Convert.ToInt32(fila.Cells["IDImplemento"].Value);
                txtIDImplemento.Enabled = false;
            }
        }

        private void lblRegresarSedes_Click(object sender, EventArgs e)
        {
            Form principal = Application.OpenForms["FormSede"];
            if (principal != null) principal.Show();
            this.Close();
        }
    }
}
