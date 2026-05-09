using MultiSport_Manager.Controllers;
using reserva_canchas;
using reserva_canchas.forms;
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

namespace MultiSport_Manager.Views
{
    public partial class FormPrincipal : Form
    {
        public PagoController pagoController = new PagoController();
        public ReservaController reservaController = new ReservaController();
        public AdministradorController adminController = new AdministradorController();
        public ClienteController clienteController = new ClienteController();
        public CanchaController canchaController = new CanchaController();
        public NotificacionController notificacionController = new NotificacionController();
        public ReporteController reporteController = new ReporteController();
        public SedeController sedeController = new SedeController();
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void lblAdministradores_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos el formulario al que queremos ir
            FormAdministradores formAdmin = new FormAdministradores(this.adminController);

            // 2. Mostramos el nuevo formulario
            formAdmin.Show();

            // 3. Ocultamos el Menú Principal
            this.Hide();
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes(this.clienteController);
            formClientes.Show();
            this.Hide();
        }

        private void lblCanchas_Click(object sender, EventArgs e)
        {
            FormCanchas formCanchas = new FormCanchas(this.canchaController);
            formCanchas.Show();
            this.Hide();
        }

        private void lblPagos_Click(object sender, EventArgs e)
        {
            FormPago formPago = new FormPago(this.pagoController);
            formPago.Show();
            this.Hide();
        }

        private void lblReservas_Click(object sender, EventArgs e)
        {
            FormGestionReservas formReservas = new FormGestionReservas(this.reservaController);
            formReservas.Show();
            this.Hide();
        }
        
        private void lblReportes_Click(object sender, EventArgs e)
        {
            FormReportes formReportes = new FormReportes(this.reporteController);
            formReportes.Show();
            this.Hide();
        }

        private void lblNotificaciones_Click(object sender, EventArgs e) 
        { 
            FormNotificaciones formNotificaciones=new FormNotificaciones(this.notificacionController);
            formNotificaciones.Show();
            this.Hide();
        }

        private void lblSedes_Click(object sender, EventArgs e)
        {
            FormSede formSede = new FormSede(this.sedeController);
            formSede.Show();
            this.Hide();
        }
    }
}
