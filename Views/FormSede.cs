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
    public partial class FormSede : Form
    {
        private SedeController sedeController;
        private int idSedeSeleccionada = -1;

        // Recibimos el controlador principal
        public FormSede(SedeController pSedeController)
        {
            InitializeComponent();
            this.sedeController = pSedeController;
        }

        private void FormSede_Load(object sender, EventArgs e)
        {
            // 1. Bloqueo de auditoría
            txtCreadoPor.ReadOnly = true;
            txtModificadoPor.ReadOnly = true;
            dtpFechaCreacion.Enabled = false;
            dtpFechaModificacion.Enabled = false;

            // 2. Configurar los DateTimePickers de hora para que solo muestren tiempo
            dtpHoraApertura.Format = DateTimePickerFormat.Time;
            dtpHoraApertura.ShowUpDown = true;
            dtpHoraCierre.Format = DateTimePickerFormat.Time;
            dtpHoraCierre.ShowUpDown = true;

            CargarGrillaSedes();
            CargarGrillaUbigeos(); // Método para llenar el panel derecho
        }

        private void CargarGrillaSedes()
        {
            dgvSedes.DataSource = null;
            dgvSedes.DataSource = sedeController.ListarTodo();
        }

        private void CargarGrillaUbigeos()
        {
            // Como no hicimos un UbigeoController explícito, aquí simulamos una lista 
            // para que su prototipo funcional de mañana se vea completo en la exposición.
            List<Ubigeo> listaUbigeos = new List<Ubigeo>
            {
                new Ubigeo { IDUbigeo = 1, Departamento = "Lima", Provincia = "Lima", Distrito = "San Miguel" },
                new Ubigeo { IDUbigeo = 2, Departamento = "Lima", Provincia = "Lima", Distrito = "Miraflores" },
                new Ubigeo { IDUbigeo = 3, Departamento = "Lima", Provincia = "Lima", Distrito = "Los Olivos" }
            };

            dgvUbigeos.DataSource = listaUbigeos;

            // Ocultamos la auditoría en esta grilla lateral para que se vea limpio
            if (dgvUbigeos.Columns["CreadoPor"] != null) dgvUbigeos.Columns["CreadoPor"].Visible = false;
            if (dgvUbigeos.Columns["ModificadoPor"] != null) dgvUbigeos.Columns["ModificadoPor"].Visible = false;
            if (dgvUbigeos.Columns["FechaCreacion"] != null) dgvUbigeos.Columns["FechaCreacion"].Visible = false;
            if (dgvUbigeos.Columns["FechaModificacion"] != null) dgvUbigeos.Columns["FechaModificacion"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtIDSede.Clear();
            txtNombre.Clear();
            txtIDUbigeo.Clear();
            dtpHoraApertura.Value = DateTime.Now;
            dtpHoraCierre.Value = DateTime.Now;

            txtCreadoPor.Clear();
            txtModificadoPor.Clear();
            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaModificacion.Value = DateTime.Now;

            idSedeSeleccionada = -1;
        }

        // Evento para que al hacer clic en un Ubigeo de la derecha, se llene el TextBox automáticamente
        private void dgvUbigeos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUbigeos.Rows[e.RowIndex];
                txtIDUbigeo.Text = fila.Cells["IDUbigeo"].Value.ToString();
            }
        }

        // Botón Verde (+) -> REGISTRAR
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Sede nuevaSede = new Sede();
                nuevaSede.IDSede = int.Parse(txtIDSede.Text);
                nuevaSede.Nombre = txtNombre.Text;

                // Extraemos solo la porción del tiempo (TimeSpan)
                nuevaSede.HoraApertura = dtpHoraApertura.Value.TimeOfDay;
                nuevaSede.HoraCierre = dtpHoraCierre.Value.TimeOfDay;

                nuevaSede.Ubigeo = new Ubigeo { IDUbigeo = int.Parse(txtIDUbigeo.Text) };

                // Auditoría invisible
                nuevaSede.FechaCreacion = DateTime.Now;
                nuevaSede.FechaModificacion = DateTime.Now;
                nuevaSede.CreadoPor = 1;
                nuevaSede.ModificadoPor = 1;

                if (sedeController.RegistrarSede(nuevaSede))
                {
                    MessageBox.Show("Sede registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrillaSedes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El ID de Sede ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique los datos ingresados. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Azul -> MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSedeSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una sede de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                sedeModificada.FechaModificacion = DateTime.Now;
                sedeModificada.ModificadoPor = 1;

                if (sedeController.EditarSede(sedeModificada))
                {
                    MessageBox.Show("Sede modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrillaSedes();
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
            if (idSedeSeleccionada != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de eliminar esta sede?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    sedeController.EliminarSede(idSedeSeleccionada);
                    CargarGrillaSedes();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una sede de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento CellClick de la grilla principal de Sedes
        private void dgvSedes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvSedes.Rows[e.RowIndex];

                txtIDSede.Text = fila.Cells["IDSede"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();

                // Convertir TimeSpan devuelta a DateTime para el DateTimePicker
                TimeSpan apertura = (TimeSpan)fila.Cells["HoraApertura"].Value;
                dtpHoraApertura.Value = DateTime.Today.Add(apertura);

                TimeSpan cierre = (TimeSpan)fila.Cells["HoraCierre"].Value;
                dtpHoraCierre.Value = DateTime.Today.Add(cierre);

                if (fila.Cells["Ubigeo"].Value != null)
                {
                    var ubigeoAsociado = (Ubigeo)fila.Cells["Ubigeo"].Value;
                    txtIDUbigeo.Text = ubigeoAsociado.IDUbigeo.ToString();
                }

                // Auditoría
                txtCreadoPor.Text = fila.Cells["CreadoPor"].Value.ToString();
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                txtModificadoPor.Text = fila.Cells["ModificadoPor"].Value.ToString();
                dtpFechaModificacion.Value = Convert.ToDateTime(fila.Cells["FechaModificacion"].Value);

                idSedeSeleccionada = int.Parse(txtIDSede.Text);
            }
        }

        // Botones de acceso directo (Opcional según tu flujo)
        private void btnRegistrarImplementos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí abrirías tu Formulario de Implementos", "Navegación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegistrarCanchas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí abrirías tu Formulario de Canchas", "Navegación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Navegación para regresar al menú
        private void btnMenu_Click(object sender, EventArgs e)
        {
            RegresarAlMenu();
        }

        private void FormSede_FormClosed(object sender, FormClosedEventArgs e)
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
