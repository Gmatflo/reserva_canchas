using MultiSport_Manager.Controllers;
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
    public partial class FormReportes : Form
    {
        private ReporteController reporteController;

        public FormReportes()
        {
            InitializeComponent();
        }

        public FormReportes(ReporteController reporteController)
        {
            this.reporteController = reporteController;
        }
    }
}
