using reserva_canchas;
using reserva_canchas.forms;
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
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void lblAdministradores_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos el formulario al que queremos ir
            FormAdministradores formAdmin = new FormAdministradores();

            // 2. Mostramos el nuevo formulario
            formAdmin.Show();

            // 3. Ocultamos el Menú Principal
            this.Hide();
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.Show();
            this.Hide();
        }

        private void lblCanchas_Click(object sender, EventArgs e)
        {
            FormCanchas formCanchas = new FormCanchas();
            formCanchas.Show();
            this.Hide();
        }

        private void lblPagos_Click(object sender, EventArgs e)
        {
            FormPago formPago = new FormPago();
            formPago.Show();
            this.Hide();
        }

        private void lblReservas_Click(object sender, EventArgs e)
        {
            FormReservas formReservas = new FormReservas();
            formReservas.Show();
            this.Hide();
        }
        
        private void lblReportes_Click(object sender, EventArgs e)
        {
            FormReportes formReportes = new FormReportes();
            formReportes.Show();
            this.Hide();
        }

        private void lblNotificaciones_Click(object sender, EventArgs e) 
        { 
            FormNotificaciones formNotificaciones=new FormNotificaciones();
            formNotificaciones.Show();
            this.Hide();
        }
    }
}
