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

        // El constructor recibe el controlador desde el FormPrincipal
        public FormCanchas(CanchaController pCanchaController)
        {
            InitializeComponent();
            this.canchaController = pCanchaController;
        }


        private void FormGestiondeCanchas_Load(object sender, EventArgs e)
        {
            // 1. Bloqueo de campos de auditoría (solo lectura)
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            // 2. Llenado de ComboBox Estado
            cmbEstado.Items.Add("Disponible");
            cmbEstado.Items.Add("Mantenimiento");
            cmbEstado.Items.Add("Inactiva");
            cmbEstado.SelectedIndex = 0;

            // 3. Llenado de ComboBox Deportes (Requisito del proyecto)
            cmbDeporte.Items.Add("Futbol");
            cmbDeporte.Items.Add("Tenis");
            cmbDeporte.Items.Add("Voley");
            cmbDeporte.SelectedIndex = 0;

            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvCanchas.DataSource = null;
            dgvCanchas.DataSource = canchaController.ListarPorSede(int.Parse(txtIDCancha.Text != "" ? txtIDCancha.Text : "0"));

        }

        private void LimpiarCampos()
        {
            txtIDCancha.Clear();
            txtIDCancha.Clear();
            txtPrecio.Clear();
            cmbEstado.SelectedIndex = 0;
            cmbDeporte.SelectedIndex = 0;

            txtCreadoPor.Clear();
            txtModificadoPor.Clear();
            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaModificacion.Value = DateTime.Now;

            idCanchaSeleccionada = -1;
        }

        // Botón Verde (+) -> GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cancha nuevaCancha = new Cancha();
                nuevaCancha.IDCancha = int.Parse(txtIDCancha.Text);
                nuevaCancha.PrecioHora = double.Parse(txtPrecio.Text);
                nuevaCancha.Estado = cmbEstado.Text;
                nuevaCancha.Deporte = cmbDeporte.Text;

                // Relacionamos la Sede usando el ID ingresado
                nuevaCancha.Sede = new Sede { IDSede = int.Parse(txtIDCancha.Text) };

                // Auditoría invisible
                nuevaCancha.FechaCreacion = DateTime.Now;
                nuevaCancha.FechaModificacion = DateTime.Now;
                nuevaCancha.CreadoPor = 1;
                nuevaCancha.ModificadoPor = 1;

                if (canchaController.RegistrarCancha(nuevaCancha))
                {
                    MessageBox.Show("Cancha registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El ID de Cancha ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique que los datos numéricos sean correctos. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Azul -> MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idCanchaSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una cancha de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cancha canchaModificada = new Cancha();
                canchaModificada.IDCancha = idCanchaSeleccionada;
                canchaModificada.PrecioHora = double.Parse(txtPrecio.Text);
                canchaModificada.Estado = cmbEstado.Text;
                canchaModificada.Deporte = cmbDeporte.Text;
                canchaModificada.Sede = new Sede { IDSede = int.Parse(txtIDCancha.Text) };

                // Auditoría: Se respeta la creación, se actualiza la modificación
                canchaModificada.FechaCreacion = dtpFechaCreacion.Value;
                canchaModificada.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);

                canchaModificada.FechaModificacion = DateTime.Now;
                canchaModificada.ModificadoPor = 1;

                if (canchaController.EditarCancha(canchaModificada))
                {
                    MessageBox.Show("Cancha modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (idCanchaSeleccionada != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de eliminar esta cancha?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    canchaController.EliminarCancha(idCanchaSeleccionada);
                    CargarGrilla();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una cancha de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento CellClick del DataGridView
        private void dgvCanchas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCanchas.Rows[e.RowIndex];

                txtIDCancha.Text = fila.Cells["IDCancha"].Value.ToString();
                txtPrecio.Text = fila.Cells["PrecioHora"].Value.ToString();
                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();
                cmbDeporte.Text = fila.Cells["Deporte"].Value.ToString();

                // Mapeo del ID Sede desde el objeto anidado
                if (fila.Cells["Sede"].Value != null)
                {
                    var sedeAsociada = (Sede)fila.Cells["Sede"].Value;
                    txtIDCancha.Text = sedeAsociada.IDSede.ToString();
                }

                // Auditoría
                txtCreadoPor.Text = fila.Cells["CreadoPor"].Value.ToString();
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                txtModificadoPor.Text = fila.Cells["ModificadoPor"].Value.ToString();
                dtpFechaModificacion.Value = Convert.ToDateTime(fila.Cells["FechaModificacion"].Value);

                idCanchaSeleccionada = int.Parse(txtIDCancha.Text);
            }
        }

        // Regresar al menú
        private void btnMenu_Click(object sender, EventArgs e)
        {
            RegresarAlMenu();
        }

        private void FormGestiondeCanchas_FormClosed(object sender, FormClosedEventArgs e)
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
