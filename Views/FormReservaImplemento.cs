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
    public partial class FormReservaImplemento : Form
    {
        private ReservaController reservaController;
        private ImplementoController implementoController = new ImplementoController();
        private DetalleReservaImplementoController detalleController = new DetalleReservaImplementoController();

        private int idReservaActual;
        private Reserva reservaActual;

        private int idImplementoSedeSeleccionado = -1;
        private int idImplementoAsignadoSeleccionado = -1;

        // Constructor con inyección del controlador
        public FormReservaImplemento(int pIdReserva, ReservaController pReservaController)
        {
            InitializeComponent();

            this.idReservaActual = pIdReserva;
            this.reservaController = pReservaController;

            this.reservaActual = reservaController.ListarTodo().Find(r => r.IDReserva == pIdReserva);

            this.Load += FormReservaImplemento_Load;
            this.dgImplementoSede.SelectionChanged += dgImplementoSede_SelectionChanged;
            this.dgvImplementoReserva.SelectionChanged += dgvImplementoReserva_SelectionChanged;
        }

        private void FormReservaImplemento_Load(object sender, EventArgs e)
        {
            lblIdReserva.Text = idReservaActual.ToString();

            if (reservaActual == null)
            {
                MessageBox.Show("Error: No se encontró la reserva en memoria.");
                return;
            }

            RefrescarTablas();
        }

        private void RefrescarTablas()
        {
            dgImplementoSede.DataSource = null;
            if (reservaActual != null && reservaActual.Cancha != null && reservaActual.Cancha.Sede != null)
            {
                int idSede = reservaActual.Cancha.Sede.IDSede;

                var implementosDisponibles = implementoController.ListarPorSede(idSede)
                    .Select(i => new {
                        IDImplemento = i.IDImplemento,
                        Nombre = i.Nombre,
                        StockDisponible = i.StockTotal,
                        PrecioAlquiler = i.PrecioAlquiler
                    }).ToList();

                dgImplementoSede.DataSource = implementosDisponibles;
            }

            dgvImplementoReserva.DataSource = null;
            var asignados = detalleController.ListarPorReserva(idReservaActual);
            if (asignados.Count > 0)
            {
                var sourceAsignados = asignados.Select(d => new {
                    IDImplemento = d.Implemento.IDImplemento,
                    Nombre = d.Implemento.Nombre,
                    Cantidad = d.Cantidad,
                    PrecioCongelado = d.PrecioCongelado,
                    Subtotal = d.PrecioCongelado * d.Cantidad 
                }).ToList();

                dgvImplementoReserva.DataSource = sourceAsignados;
            }
        }

        private void dgImplementoSede_SelectionChanged(object sender, EventArgs e)
        {
            if (dgImplementoSede.SelectedRows.Count > 0)
            {
                var fila = dgImplementoSede.SelectedRows[0];
                if (fila.Cells["PrecioAlquiler"].Value != null)
                {
                    txtPrecioCongelado.Text = fila.Cells["PrecioAlquiler"].Value.ToString();
                    txtCantidad.Text = "1";
                    idImplementoSedeSeleccionado = Convert.ToInt32(fila.Cells["IDImplemento"].Value);
                }
            }
        }

        private void dgvImplementoReserva_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvImplementoReserva.SelectedRows.Count > 0)
            {
                var fila = dgvImplementoReserva.SelectedRows[0];
                if (fila.Cells["IDImplemento"].Value != null)
                {
                    idImplementoAsignadoSeleccionado = Convert.ToInt32(fila.Cells["IDImplemento"].Value);
                }
            }
        }

        private void btnAñadirImplemento_Click(object sender, EventArgs e)
        {
            if (idImplementoSedeSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un implemento de la sede primero.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioCongelado.Text))
            {
                MessageBox.Show("Ingrese una cantidad y un precio válido.");
                return;
            }

            try
            {
                int cant = int.Parse(txtCantidad.Text);
                double precio = double.Parse(txtPrecioCongelado.Text);

                if (cant <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0.");
                    return;
                }

                var impReal = implementoController.ListarTodo().Find(i => i.IDImplemento == idImplementoSedeSeleccionado);

                if (cant > impReal.StockTotal)
                {
                    MessageBox.Show("No hay suficiente stock. Disponible: " + impReal.StockTotal);
                    return;
                }

                DetalleReservaImplemento nuevoDetalle = new DetalleReservaImplemento
                {
                    Reserva = reservaActual,
                    Implemento = impReal,
                    PrecioCongelado = precio,
                    Cantidad = cant,
                    CreadoPor = 1,          // Auditoría obligatoria de tu rúbrica
                    ModificadoPor = 1
                };

                // El método AgregarDetalle resta el stock automáticamente
                if (detalleController.AgregarDetalle(nuevoDetalle))
                {
                    idImplementoSedeSeleccionado = -1;
                    txtCantidad.Clear();
                    txtPrecioCongelado.Clear();
                    RefrescarTablas();
                }
                else
                {
                    MessageBox.Show("Este implemento ya está en la reserva. Si desea modificar la cantidad, quítelo y vuelva a agregarlo.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Verifique que la cantidad sea un número entero y el precio sea numérico.");
            }
        }

        private void btnQuitarImplemento_Click(object sender, EventArgs e)
        {
            if (idImplementoAsignadoSeleccionado != -1)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de quitar este implemento de la reserva?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // El método QuitarDetalle devuelve el stock automáticamente
                    detalleController.QuitarDetalle(idReservaActual, idImplementoAsignadoSeleccionado);
                    idImplementoAsignadoSeleccionado = -1;
                    RefrescarTablas();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un implemento asignado en la tabla de abajo para quitarlo.");
            }
        }

        private void lblRegresarReserva_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormGestionReservas"];
            if (frm != null) frm.Show();
            this.Close();
        }

        // Cierre seguro: si el usuario presiona la "X" de la ventana, regresamos a Reservas
        private void FormReservaImplemento_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = Application.OpenForms["FormGestionReservas"];
            if (frm != null) frm.Show();
        }
    }
}
