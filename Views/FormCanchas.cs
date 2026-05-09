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
    public partial class FormCanchas : Form
    {
        private CanchaController canchaController;
        private int idCanchaSeleccionada = -1;

        public FormCanchas(CanchaController pCanchaController)
        {
            InitializeComponent();
            this.canchaController = pCanchaController;
        }

        private void MostrarEnDataGrid(List<Cancha> lista)
        {
            dgvCanchas.DataSource = null;
            if (lista.Count > 0)
            {
                dgvCanchas.DataSource = lista;
            }
        }

        private void FormGestiondeCanchas_Load(object sender, EventArgs e)
        {
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            cmbEstado.Items.Add("Disponible");
            cmbEstado.Items.Add("Mantenimiento");
            cmbEstado.Items.Add("Inactiva");
            cmbEstado.SelectedIndex = 0;

            cmbDeporte.Items.Add("Futbol");
            cmbDeporte.Items.Add("Tenis");
            cmbDeporte.Items.Add("Voley");
            cmbDeporte.SelectedIndex = 0;

            MostrarEnDataGrid(canchaController.ListarTodo());
        }

        private void LimpiarCampos()
        {
            txtIDCancha.Clear();
            txtIDSede.Clear();
            txtPrecio.Clear();
            cmbEstado.SelectedIndex = 0;
            cmbDeporte.SelectedIndex = 0;
            idCanchaSeleccionada = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIDCancha.Text == "" || txtPrecio.Text == "" || txtIDSede.Text == "")
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            try
            {
                Cancha nuevaCancha = new Cancha();
                nuevaCancha.IDCancha = int.Parse(txtIDCancha.Text);
                nuevaCancha.PrecioHora = double.Parse(txtPrecio.Text);
                nuevaCancha.Estado = cmbEstado.Text;
                nuevaCancha.Deporte = cmbDeporte.Text;

                // BUG CORREGIDO: Se debe usar txtIDSede, no txtIDCancha
                nuevaCancha.Sede = new Sede { IDSede = int.Parse(txtIDSede.Text) };

                nuevaCancha.CreadoPor = 1;
                nuevaCancha.ModificadoPor = 1;

                if (canchaController.RegistrarCancha(nuevaCancha))
                {
                    MessageBox.Show("Cancha registrada correctamente.");
                    MostrarEnDataGrid(canchaController.ListarTodo());
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El ID de Cancha ya existe.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Verifique que ID y Precio sean solo números.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idCanchaSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una cancha de la lista.");
                return;
            }

            try
            {
                Cancha canchaModificada = new Cancha();
                canchaModificada.IDCancha = idCanchaSeleccionada;
                canchaModificada.PrecioHora = double.Parse(txtPrecio.Text);
                canchaModificada.Estado = cmbEstado.Text;
                canchaModificada.Deporte = cmbDeporte.Text;
                canchaModificada.Sede = new Sede { IDSede = int.Parse(txtIDSede.Text) };

                canchaModificada.FechaCreacion = dtpFechaCreacion.Value;
                canchaModificada.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);
                canchaModificada.ModificadoPor = 1;

                if (canchaController.EditarCancha(canchaModificada))
                {
                    MessageBox.Show("Cancha modificada correctamente.");
                    MostrarEnDataGrid(canchaController.ListarTodo());
                    LimpiarCampos();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error numérico al intentar modificar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idCanchaSeleccionada != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de eliminar esta cancha?", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    canchaController.EliminarCancha(idCanchaSeleccionada);
                    MostrarEnDataGrid(canchaController.ListarTodo());
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una cancha de la lista.");
            }
        }

        private void dgvCanchas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCanchas.Rows[e.RowIndex];

                txtIDCancha.Text = fila.Cells["IDCancha"].Value.ToString();
                txtPrecio.Text = fila.Cells["PrecioHora"].Value.ToString();
                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();
                cmbDeporte.Text = fila.Cells["Deporte"].Value.ToString();

                if (fila.Cells["Sede"].Value != null)
                {
                    var sedeAsociada = (Sede)fila.Cells["Sede"].Value;
                    txtIDSede.Text = sedeAsociada.IDSede.ToString();
                }

                idCanchaSeleccionada = int.Parse(txtIDCancha.Text);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) { RegresarAlMenu(); }
        private void FormGestiondeCanchas_FormClosed(object sender, FormClosedEventArgs e) { RegresarAlMenu(); }

        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null) principal.Show();
            this.Hide();
        }
    }
}
