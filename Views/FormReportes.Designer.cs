namespace reserva_canchas.forms
{
    partial class FormReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarIngresos = new System.Windows.Forms.Button();
            this.btnGenerarDeportes = new System.Windows.Forms.Button();
            this.chartReporte = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Ivory;
            this.panel2.Controls.Add(this.btnMenu);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(3, -2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1203, 80);
            this.panel2.TabIndex = 56;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Ivory;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(1057, 15);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(129, 34);
            this.btnMenu.TabIndex = 88;
            this.btnMenu.Text = "↵Menú";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(80, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(245, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "Registro, modificacion y eliminacion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(301, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "📊 Gestion de Reportes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.Location = new System.Drawing.Point(19, 100);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 24);
            this.label9.TabIndex = 57;
            this.label9.Text = "Identificación";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvReportes
            // 
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(16, 367);
            this.dgvReportes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.RowHeadersWidth = 51;
            this.dgvReportes.Size = new System.Drawing.Size(659, 309);
            this.dgvReportes.TabIndex = 59;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 151);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 16);
            this.label14.TabIndex = 70;
            this.label14.Text = "Fecha Inicio";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 230);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 16);
            this.label18.TabIndex = 74;
            this.label18.Text = "Fecha Fin";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(23, 258);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(265, 22);
            this.dtpFechaFin.TabIndex = 81;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(23, 178);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(265, 22);
            this.dtpFechaInicio.TabIndex = 82;
            // 
            // btnGenerarIngresos
            // 
            this.btnGenerarIngresos.Location = new System.Drawing.Point(399, 100);
            this.btnGenerarIngresos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerarIngresos.Name = "btnGenerarIngresos";
            this.btnGenerarIngresos.Size = new System.Drawing.Size(219, 46);
            this.btnGenerarIngresos.TabIndex = 83;
            this.btnGenerarIngresos.Text = "Generar Ingresos por Sede";
            this.btnGenerarIngresos.UseVisualStyleBackColor = true;
            this.btnGenerarIngresos.Click += new System.EventHandler(this.btnGenerarIngresos_Click);
            // 
            // btnGenerarDeportes
            // 
            this.btnGenerarDeportes.Location = new System.Drawing.Point(399, 153);
            this.btnGenerarDeportes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerarDeportes.Name = "btnGenerarDeportes";
            this.btnGenerarDeportes.Size = new System.Drawing.Size(219, 54);
            this.btnGenerarDeportes.TabIndex = 84;
            this.btnGenerarDeportes.Text = "Generar Reservas por Deporte";
            this.btnGenerarDeportes.UseVisualStyleBackColor = true;
            this.btnGenerarDeportes.Click += new System.EventHandler(this.btnGenerarDeportes_Click);
            // 
            // chartReporte
            // 
            chartArea1.Name = "ChartArea1";
            this.chartReporte.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartReporte.Legends.Add(legend1);
            this.chartReporte.Location = new System.Drawing.Point(741, 123);
            this.chartReporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartReporte.Name = "chartReporte";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartReporte.Series.Add(series1);
            this.chartReporte.Size = new System.Drawing.Size(400, 369);
            this.chartReporte.TabIndex = 87;
            this.chartReporte.Text = "chart1";
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 690);
            this.Controls.Add(this.chartReporte);
            this.Controls.Add(this.btnGenerarDeportes);
            this.Controls.Add(this.btnGenerarIngresos);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormReportes";
            this.Text = "FormReportes";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Button btnGenerarIngresos;
        private System.Windows.Forms.Button btnGenerarDeportes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReporte;
        private System.Windows.Forms.Button btnMenu;
    }
}