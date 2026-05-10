using MultiSport_Manager.Controllers;
using MultiSport_Manager.Entities;
using MultiSport_Manager.Views;
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
    public partial class FormSede : Form
    {
        private SedeController sedeController;
        private int idSedeSeleccionada = -1;

        public FormSede(SedeController pSedeController)
        {
            InitializeComponent();
            this.sedeController = pSedeController;

            this.Load += FormSede_Load;
            this.dgvUbigeos.CellClick += dgvUbigeos_CellClick;
            this.dgvSedes.CellClick += dgvSedes_CellClick;
        }

        private List<Ubigeo> listaUbigeosGlobal = new List<Ubigeo>
        {
            new Ubigeo { IDUbigeo = 1, Departamento = "Lima", Provincia = "Lima", Distrito = "San Miguel" },
            new Ubigeo { IDUbigeo = 2, Departamento = "Lima", Provincia = "Lima", Distrito = "Miraflores" },
            new Ubigeo { IDUbigeo = 3, Departamento = "Lima", Provincia = "Lima", Distrito = "Los Olivos" }
        };

        private void MostrarSedesEnDataGrid(List<Sede> lista)
        {
            dgvSedes.DataSource = null;
            if (lista.Count > 0)
            {
                dgvSedes.DataSource = lista;
            }
        }

        private void FormSede_Load(object sender, EventArgs e)
        {
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            dtpHoraApertura.Format = DateTimePickerFormat.Time;
            dtpHoraApertura.ShowUpDown = true;
            dtpHoraCierre.Format = DateTimePickerFormat.Time;
            dtpHoraCierre.ShowUpDown = true;

            MostrarSedesEnDataGrid(sedeController.ListarTodo());
            CargarGrillaUbigeos();
        }

        private void CargarGrillaUbigeos()
        {
            dgvUbigeos.DataSource = null;
            dgvUbigeos.DataSource = listaUbigeosGlobal;

            if (dgvUbigeos.Columns["CreadoPor"] != null) dgvUbigeos.Columns["CreadoPor"].Visible = false;
            if (dgvUbigeos.Columns["ModificadoPor"] != null) dgvUbigeos.Columns["ModificadoPor"].Visible = false;
            if (dgvUbigeos.Columns["FechaCreacion"] != null) dgvUbigeos.Columns["FechaCreacion"].Visible = false;
            if (dgvUbigeos.Columns["FechaModificacion"] != null) dgvUbigeos.Columns["FechaModificacion"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtIDSede.Clear();
            txtIDSede.Enabled = true;
            txtNombre.Clear();
            txtIDUbigeo.Clear();
            dtpHoraApertura.Value = DateTime.Now;
            dtpHoraCierre.Value = DateTime.Now;
            idSedeSeleccionada = -1;
        }

        private void dgvUbigeos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUbigeos.Rows[e.RowIndex];
                txtIDUbigeo.Text = fila.Cells["IDUbigeo"].Value.ToString();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtIDSede.Text == "" || txtNombre.Text == "" || txtIDUbigeo.Text == "")
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            try
            {
                int idUbigeo = int.Parse(txtIDUbigeo.Text);
                TimeSpan apertura = dtpHoraApertura.Value.TimeOfDay;
                TimeSpan cierre = dtpHoraCierre.Value.TimeOfDay;

                if (!listaUbigeosGlobal.Exists(u => u.IDUbigeo == idUbigeo))
                {
                    MessageBox.Show("El ID de Ubigeo no es válido.");
                    return;
                }

                if (apertura >= cierre)
                {
                    MessageBox.Show("La hora de apertura debe ser menor a la de cierre.");
                    return;
                }

                Sede nuevaSede = new Sede();
                nuevaSede.IDSede = int.Parse(txtIDSede.Text);
                nuevaSede.Nombre = txtNombre.Text;
                nuevaSede.HoraApertura = dtpHoraApertura.Value.TimeOfDay;
                nuevaSede.HoraCierre = dtpHoraCierre.Value.TimeOfDay;
                nuevaSede.Ubigeo = new Ubigeo { IDUbigeo = int.Parse(txtIDUbigeo.Text) };

                nuevaSede.CreadoPor = 1;
                nuevaSede.ModificadoPor = 1;

                if (sedeController.RegistrarSede(nuevaSede))
                {
                    MostrarSedesEnDataGrid(sedeController.ListarTodo());
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El ID de Sede ya existe en el sistema.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Verifique que los campos ID sean números enteros.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSedeSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una sede de la tabla.");
                return;
            }

            try
            {
                Sede sedeModificada = new Sede();
                sedeModificada.IDSede = idSedeSeleccionada;
                sedeModificada.Nombre = txtNombre.Text;
                sedeModificada.HoraApertura = dtpHoraApertura.Value.TimeOfDay;
                sedeModificada.HoraCierre = dtpHoraCierre.Value.TimeOfDay;
                sedeModificada.Ubigeo = new Ubigeo { IDUbigeo = int.Parse(txtIDUbigeo.Text) };

                sedeModificada.FechaCreacion = dtpFechaCreacion.Value;
                sedeModificada.CreadoPor = string.IsNullOrEmpty(txtCreadoPor.Text) ? 1 : int.Parse(txtCreadoPor.Text);
                sedeModificada.ModificadoPor = 1;

                if (sedeController.EditarSede(sedeModificada))
                {
                    MessageBox.Show("Sede modificada correctamente.");
                    MostrarSedesEnDataGrid(sedeController.ListarTodo());
                    LimpiarCampos();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error numérico al intentar modificar la sede.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSedeSeleccionada != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de eliminar esta sede?", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    sedeController.EliminarSede(idSedeSeleccionada);
                    MostrarSedesEnDataGrid(sedeController.ListarTodo());
                    LimpiarCampos();
                }
            }
        }

        private void dgvSedes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvSedes.Rows[e.RowIndex];

                txtIDSede.Text = fila.Cells["IDSede"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();

                dtpHoraApertura.Value = DateTime.Today.Add((TimeSpan)fila.Cells["HoraApertura"].Value);
                dtpHoraCierre.Value = DateTime.Today.Add((TimeSpan)fila.Cells["HoraCierre"].Value);

                if (fila.Cells["Ubigeo"].Value != null)
                {
                    var ubigeoAsociado = (Ubigeo)fila.Cells["Ubigeo"].Value;
                    txtIDUbigeo.Text = ubigeoAsociado.IDUbigeo.ToString();
                }

                idSedeSeleccionada = int.Parse(txtIDSede.Text);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) { RegresarAlMenu(); }
        private void FormSede_FormClosed(object sender, FormClosedEventArgs e) { RegresarAlMenu(); }
        private void RegresarAlMenu()
        {
            Form principal = Application.OpenForms["FormPrincipal"];
            if (principal != null) principal.Show();
            this.Hide();
        }

        private void btnRegistrarImplementos_Click(object sender, EventArgs e)
        {
            if (dgvSedes.SelectedRows.Count > 0)
            {
                var fila = dgvSedes.SelectedRows[0];
                int idSede = Convert.ToInt32(fila.Cells["IDSede"].Value);

                FormImplementos formImplemento = new FormImplementos(idSede);
                formImplemento.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seleccione una sede primero");
            }
        }
    }
}
