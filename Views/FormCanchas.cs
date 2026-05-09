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
        private SedeController sedeController;
        private int idCanchaSeleccionada = -1;

        public FormCanchas(CanchaController pCanchaController, SedeController pSedeController)
        {
            InitializeComponent();
            this.canchaController = pCanchaController;
            this.sedeController = pSedeController;
            this.dgvCanchas.SelectionChanged += new System.EventHandler(this.dgvCanchas_SelectionChanged);
            MostrarEnDataGrid(canchaController.ListarTodo());
        }

        private void MostrarEnDataGrid(List<Cancha> lista)
        {
            dgvCanchas.DataSource = null;
            if (lista.Count > 0) dgvCanchas.DataSource = lista;
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
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtIDCancha.Clear();
            txtIDCancha.Enabled = true;
            txtIDSede.Clear();
            txtPrecio.Clear();
            cmbEstado.SelectedIndex = 0;
            cmbDeporte.SelectedIndex = 0;
            idCanchaSeleccionada = -1;
            dgvCanchas.ClearSelection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIDCancha.Text == "" || txtPrecio.Text == "" || txtIDSede.Text == "" || cmbEstado.Text == "" || cmbDeporte.Text == "")
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            try
            {
                int idSede = int.Parse(txtIDSede.Text);

                // --- VALIDACIÓN DE INTEGRIDAD ---
                Sede sedeReal = sedeController.BuscarSede(idSede);
                if (sedeReal == null)
                {
                    MessageBox.Show("El ID de Sede ingresado no se encuentra registrado. Registre la Sede primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cancha nuevaCancha = new Cancha();
                nuevaCancha.IDCancha = int.Parse(txtIDCancha.Text);
                nuevaCancha.PrecioHora = double.Parse(txtPrecio.Text);
                nuevaCancha.Estado = cmbEstado.Text;
                nuevaCancha.Deporte = cmbDeporte.Text;
                nuevaCancha.Sede = sedeReal;

                nuevaCancha.CreadoPor = 1;
                nuevaCancha.ModificadoPor = 1;

                if (!canchaController.RegistrarCancha(nuevaCancha))
                {
                    MessageBox.Show("El ID de Cancha ya existe.");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Verifique que ID y Precio sean solo números.");
                return;
            }

            MostrarEnDataGrid(canchaController.ListarTodo());
            LimpiarCampos();
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
                int idSede = int.Parse(txtIDSede.Text);

                Sede sedeReal = sedeController.BuscarSede(idSede);
                if (sedeReal == null)
                {
                    MessageBox.Show("El ID de Sede ingresado no existe en el sistema.");
                    return;
                }

                Cancha canchaModificada = new Cancha();
                canchaModificada.IDCancha = idCanchaSeleccionada;
                canchaModificada.PrecioHora = double.Parse(txtPrecio.Text);
                canchaModificada.Estado = cmbEstado.Text;
                canchaModificada.Deporte = cmbDeporte.Text;
                canchaModificada.Sede = sedeReal;

                canchaModificada.FechaCreacion = dtpFechaCreacion.Value;
                canchaModificada.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);
                canchaModificada.FechaModificacion = DateTime.Now;
                canchaModificada.ModificadoPor = 1;

                if (!canchaController.EditarCancha(canchaModificada))
                {
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error numérico al intentar modificar.");
                return;
            }

            MostrarEnDataGrid(canchaController.ListarTodo());
            LimpiarCampos();
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
        }

        private void dgvCanchas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCanchas.SelectedRows.Count > 0)
            {
                var fila = dgvCanchas.SelectedRows[0];
                if (fila.Cells["IDCancha"].Value == null) return;

                txtIDCancha.Text = fila.Cells["IDCancha"].Value.ToString();
                txtPrecio.Text = fila.Cells["PrecioHora"].Value.ToString();
                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();
                cmbDeporte.Text = fila.Cells["Deporte"].Value.ToString();

                if (fila.Cells["Sede"].Value != null)
                {
                    var sedeAsociada = (Sede)fila.Cells["Sede"].Value;
                    txtIDSede.Text = sedeAsociada.IDSede.ToString();
                }

                txtCreadoPor.Text = fila.Cells["CreadoPor"].Value.ToString();
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                txtModificadoPor.Text = fila.Cells["ModificadoPor"].Value.ToString();
                dtpFechaModificacion.Value = Convert.ToDateTime(fila.Cells["FechaModificacion"].Value);

                idCanchaSeleccionada = Convert.ToInt32(fila.Cells["IDCancha"].Value);
                txtIDCancha.Enabled = false;
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
