namespace reserva_canchas
{
    partial class FormPago
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
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.txtModificadoPor = new System.Windows.Forms.TextBox();
            this.txtCreadoPor = new System.Windows.Forms.TextBox();
            this.dtpFechaModificacion = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbEstadoPago = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.txtMontoPagado = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.txtIDPago = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblFaltante = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPagado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMontoTotalReserva = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIDReservaValue = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPagos
            // 
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Location = new System.Drawing.Point(11, 374);
            this.dgvPagos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.RowHeadersWidth = 51;
            this.dgvPagos.RowTemplate.Height = 24;
            this.dgvPagos.Size = new System.Drawing.Size(857, 288);
            this.dgvPagos.TabIndex = 22;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(348, 338);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(124, 32);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(194, 338);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(138, 32);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(43, 338);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(141, 32);
            this.btnRegistrar.TabIndex = 19;
            this.btnRegistrar.Text = "+ Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel7.Controls.Add(this.dtpFechaCreacion);
            this.panel7.Controls.Add(this.txtModificadoPor);
            this.panel7.Controls.Add(this.txtCreadoPor);
            this.panel7.Controls.Add(this.dtpFechaModificacion);
            this.panel7.Controls.Add(this.label22);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.cmbEstadoPago);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.dtpFechaPago);
            this.panel7.Controls.Add(this.txtMontoPagado);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Controls.Add(this.cmbMetodoPago);
            this.panel7.Controls.Add(this.txtIDPago);
            this.panel7.Controls.Add(this.label25);
            this.panel7.Controls.Add(this.label26);
            this.panel7.Controls.Add(this.label30);
            this.panel7.Controls.Add(this.label18);
            this.panel7.Location = new System.Drawing.Point(11, 95);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(857, 239);
            this.panel7.TabIndex = 17;
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.Enabled = false;
            this.dtpFechaCreacion.Location = new System.Drawing.Point(147, 178);
            this.dtpFechaCreacion.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(151, 20);
            this.dtpFechaCreacion.TabIndex = 58;
            // 
            // txtModificadoPor
            // 
            this.txtModificadoPor.Location = new System.Drawing.Point(329, 178);
            this.txtModificadoPor.Margin = new System.Windows.Forms.Padding(2);
            this.txtModificadoPor.Name = "txtModificadoPor";
            this.txtModificadoPor.ReadOnly = true;
            this.txtModificadoPor.Size = new System.Drawing.Size(104, 20);
            this.txtModificadoPor.TabIndex = 57;
            // 
            // txtCreadoPor
            // 
            this.txtCreadoPor.Location = new System.Drawing.Point(13, 177);
            this.txtCreadoPor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCreadoPor.Name = "txtCreadoPor";
            this.txtCreadoPor.ReadOnly = true;
            this.txtCreadoPor.Size = new System.Drawing.Size(104, 20);
            this.txtCreadoPor.TabIndex = 56;
            // 
            // dtpFechaModificacion
            // 
            this.dtpFechaModificacion.Enabled = false;
            this.dtpFechaModificacion.Location = new System.Drawing.Point(468, 177);
            this.dtpFechaModificacion.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaModificacion.Name = "dtpFechaModificacion";
            this.dtpFechaModificacion.Size = new System.Drawing.Size(151, 20);
            this.dtpFechaModificacion.TabIndex = 55;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label22.Location = new System.Drawing.Point(494, 152);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(132, 15);
            this.label22.TabIndex = 54;
            this.label22.Text = "Fecha Modificacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(334, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 53;
            this.label1.Text = "Modificado por";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(170, 152);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 15);
            this.label16.TabIndex = 52;
            this.label16.Text = "Fecha creación";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(18, 152);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 15);
            this.label15.TabIndex = 51;
            this.label15.Text = "creado por";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(16, 125);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 20);
            this.label12.TabIndex = 50;
            this.label12.Text = "Auditoria";
            // 
            // cmbEstadoPago
            // 
            this.cmbEstadoPago.FormattingEnabled = true;
            this.cmbEstadoPago.Items.AddRange(new object[] {
            "Completado",
            "Parcial",
            "Reembolsado"});
            this.cmbEstadoPago.Location = new System.Drawing.Point(460, 95);
            this.cmbEstadoPago.Margin = new System.Windows.Forms.Padding(2);
            this.cmbEstadoPago.Name = "cmbEstadoPago";
            this.cmbEstadoPago.Size = new System.Drawing.Size(151, 21);
            this.cmbEstadoPago.TabIndex = 49;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(340, 96);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 15);
            this.label11.TabIndex = 48;
            this.label11.Text = "- Estado de Pago:";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Location = new System.Drawing.Point(460, 46);
            this.dtpFechaPago.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(151, 20);
            this.dtpFechaPago.TabIndex = 42;
            this.dtpFechaPago.Value = new System.DateTime(2026, 5, 7, 0, 0, 0, 0);
            // 
            // txtMontoPagado
            // 
            this.txtMontoPagado.Location = new System.Drawing.Point(143, 75);
            this.txtMontoPagado.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoPagado.Name = "txtMontoPagado";
            this.txtMontoPagado.Size = new System.Drawing.Size(151, 20);
            this.txtMontoPagado.TabIndex = 41;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(334, 70);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 15);
            this.label19.TabIndex = 40;
            this.label19.Text = "- Metodo de Pago:";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Online"});
            this.cmbMetodoPago.Location = new System.Drawing.Point(460, 70);
            this.cmbMetodoPago.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(151, 21);
            this.cmbMetodoPago.TabIndex = 38;
            // 
            // txtIDPago
            // 
            this.txtIDPago.Location = new System.Drawing.Point(143, 49);
            this.txtIDPago.Margin = new System.Windows.Forms.Padding(2);
            this.txtIDPago.Name = "txtIDPago";
            this.txtIDPago.Size = new System.Drawing.Size(151, 20);
            this.txtIDPago.TabIndex = 37;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label25.Location = new System.Drawing.Point(340, 46);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(116, 15);
            this.label25.TabIndex = 36;
            this.label25.Text = "- Fecha de Pago:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label26.Location = new System.Drawing.Point(23, 80);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(113, 15);
            this.label26.TabIndex = 35;
            this.label26.Text = "- Monto Pagado:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label30.Location = new System.Drawing.Point(29, 54);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(71, 15);
            this.label30.TabIndex = 34;
            this.label30.Text = "- ID Pago:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(12, 7);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(117, 20);
            this.label18.TabIndex = 6;
            this.label18.Text = "Identificación";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblFaltante);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblPagado);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblMontoTotalReserva);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.lblIDReservaValue);
            this.panel3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Location = new System.Drawing.Point(641, 95);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(38, 41, 38, 41);
            this.panel3.Size = new System.Drawing.Size(227, 239);
            this.panel3.TabIndex = 13;
            // 
            // lblFaltante
            // 
            this.lblFaltante.AutoSize = true;
            this.lblFaltante.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaltante.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblFaltante.Location = new System.Drawing.Point(146, 162);
            this.lblFaltante.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFaltante.Name = "lblFaltante";
            this.lblFaltante.Size = new System.Drawing.Size(27, 29);
            this.lblFaltante.TabIndex = 13;
            this.lblFaltante.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(12, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Faltante:";
            // 
            // lblPagado
            // 
            this.lblPagado.AutoSize = true;
            this.lblPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagado.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPagado.Location = new System.Drawing.Point(146, 117);
            this.lblPagado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPagado.Name = "lblPagado";
            this.lblPagado.Size = new System.Drawing.Size(27, 29);
            this.lblPagado.TabIndex = 11;
            this.lblPagado.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Pagado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Monto Total:";
            // 
            // lblMontoTotalReserva
            // 
            this.lblMontoTotalReserva.AutoSize = true;
            this.lblMontoTotalReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotalReserva.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblMontoTotalReserva.Location = new System.Drawing.Point(146, 77);
            this.lblMontoTotalReserva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMontoTotalReserva.Name = "lblMontoTotalReserva";
            this.lblMontoTotalReserva.Size = new System.Drawing.Size(27, 29);
            this.lblMontoTotalReserva.TabIndex = 8;
            this.lblMontoTotalReserva.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(12, 42);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 25);
            this.label10.TabIndex = 7;
            this.label10.Text = "ID Reserva:";
            // 
            // lblIDReservaValue
            // 
            this.lblIDReservaValue.AutoSize = true;
            this.lblIDReservaValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDReservaValue.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblIDReservaValue.Location = new System.Drawing.Point(146, 39);
            this.lblIDReservaValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIDReservaValue.Name = "lblIDReservaValue";
            this.lblIDReservaValue.Size = new System.Drawing.Size(27, 29);
            this.lblIDReservaValue.TabIndex = 6;
            this.lblIDReservaValue.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Ivory;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(1, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(867, 89);
            this.panel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(752, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 33);
            this.label2.TabIndex = 23;
            this.label2.Text = "↵Menú\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(58, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Registro, modificacion y eliminacion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(253, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "📅 Gestion de Pagos       ";
            // 
            // FormPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 675);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvPagos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRegistrar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPago";
            this.Text = "Pagos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.TextBox txtMontoPagado;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.TextBox txtIDPago;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblIDReservaValue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbEstadoPago;
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        private System.Windows.Forms.TextBox txtModificadoPor;
        private System.Windows.Forms.TextBox txtCreadoPor;
        private System.Windows.Forms.DateTimePicker dtpFechaModificacion;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMontoTotalReserva;
        private System.Windows.Forms.Label lblFaltante;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPagado;
        private System.Windows.Forms.Label label4;
    }
}