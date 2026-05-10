namespace reserva_canchas
{
    partial class FormClientes
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.txtModificadoPor = new System.Windows.Forms.TextBox();
            this.txtCreadoPor = new System.Windows.Forms.TextBox();
            this.dtpFechaModificacion = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtIDCliente = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Ivory;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(3, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1085, 101);
            this.panel2.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(77, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(245, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "Registro, modificacion y eliminacion";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(451, 29);
            this.label10.TabIndex = 0;
            this.label10.Text = "👤 Gestion de Clientes                    ";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(384, 468);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 39);
            this.button3.TabIndex = 12;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(228, 468);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 39);
            this.button2.TabIndex = 11;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(72, 468);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 39);
            this.button1.TabIndex = 10;
            this.button1.Text = "+ Registrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel7.Controls.Add(this.dtpFechaCreacion);
            this.panel7.Controls.Add(this.txtModificadoPor);
            this.panel7.Controls.Add(this.txtCreadoPor);
            this.panel7.Controls.Add(this.dtpFechaModificacion);
            this.panel7.Controls.Add(this.label22);
            this.panel7.Controls.Add(this.label17);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.label14);
            this.panel7.Controls.Add(this.dtpFechaNacimiento);
            this.panel7.Controls.Add(this.txtTelefono);
            this.panel7.Controls.Add(this.txtNombre);
            this.panel7.Controls.Add(this.label29);
            this.panel7.Controls.Add(this.label28);
            this.panel7.Controls.Add(this.txtDNI);
            this.panel7.Controls.Add(this.txtIDCliente);
            this.panel7.Controls.Add(this.label21);
            this.panel7.Controls.Add(this.label20);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Controls.Add(this.label18);
            this.panel7.Location = new System.Drawing.Point(64, 107);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(917, 354);
            this.panel7.TabIndex = 14;
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.Enabled = false;
            this.dtpFechaCreacion.Location = new System.Drawing.Point(216, 298);
            this.dtpFechaCreacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaCreacion.TabIndex = 53;
            // 
            // txtModificadoPor
            // 
            this.txtModificadoPor.Location = new System.Drawing.Point(459, 298);
            this.txtModificadoPor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModificadoPor.Name = "txtModificadoPor";
            this.txtModificadoPor.ReadOnly = true;
            this.txtModificadoPor.Size = new System.Drawing.Size(137, 22);
            this.txtModificadoPor.TabIndex = 52;
            // 
            // txtCreadoPor
            // 
            this.txtCreadoPor.Location = new System.Drawing.Point(37, 297);
            this.txtCreadoPor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCreadoPor.Name = "txtCreadoPor";
            this.txtCreadoPor.ReadOnly = true;
            this.txtCreadoPor.Size = new System.Drawing.Size(137, 22);
            this.txtCreadoPor.TabIndex = 51;
            // 
            // dtpFechaModificacion
            // 
            this.dtpFechaModificacion.Enabled = false;
            this.dtpFechaModificacion.Location = new System.Drawing.Point(644, 297);
            this.dtpFechaModificacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaModificacion.Name = "dtpFechaModificacion";
            this.dtpFechaModificacion.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaModificacion.TabIndex = 50;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label22.Location = new System.Drawing.Point(679, 266);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(155, 18);
            this.label22.TabIndex = 49;
            this.label22.Text = "Fecha Modificacion";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(465, 266);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(121, 18);
            this.label17.TabIndex = 48;
            this.label17.Text = "Modificado por";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(247, 266);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(124, 18);
            this.label16.TabIndex = 47;
            this.label16.Text = "Fecha creación";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(44, 266);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 18);
            this.label15.TabIndex = 46;
            this.label15.Text = "creado por";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(41, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 25);
            this.label12.TabIndex = 45;
            this.label12.Text = "Auditoria";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(16, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(177, 25);
            this.label14.TabIndex = 16;
            this.label14.Text = "Datos del Cliente";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(499, 70);
            this.dtpFechaNacimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaNacimiento.TabIndex = 35;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(253, 190);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(137, 22);
            this.txtTelefono.TabIndex = 30;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(21, 190);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(137, 22);
            this.txtNombre.TabIndex = 29;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label29.Location = new System.Drawing.Point(269, 156);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(74, 18);
            this.label29.TabIndex = 25;
            this.label29.Text = "Telefono";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label28.Location = new System.Drawing.Point(20, 158);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(146, 18);
            this.label28.TabIndex = 24;
            this.label28.Text = "Nombre Completo";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(253, 71);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(137, 22);
            this.txtDNI.TabIndex = 17;
            // 
            // txtIDCliente
            // 
            this.txtIDCliente.Location = new System.Drawing.Point(21, 71);
            this.txtIDCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDCliente.Name = "txtIDCliente";
            this.txtIDCliente.Size = new System.Drawing.Size(135, 22);
            this.txtIDCliente.TabIndex = 16;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(496, 49);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(164, 18);
            this.label21.TabIndex = 10;
            this.label21.Text = "Fecha de nacimiento";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Location = new System.Drawing.Point(275, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 18);
            this.label20.TabIndex = 9;
            this.label20.Text = "DNI";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(29, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 18);
            this.label19.TabIndex = 8;
            this.label19.Text = "ID Cliente";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(16, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(139, 25);
            this.label18.TabIndex = 6;
            this.label18.Text = "Identificación";
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(31, 514);
            this.dgvClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.RowTemplate.Height = 24;
            this.dgvClientes.Size = new System.Drawing.Size(1032, 254);
            this.dgvClientes.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(956, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 45);
            this.label1.TabIndex = 8;
            this.label1.Text = "↵Menú\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 782);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormClientes";
            this.Text = "FormSistemadeGestiondeCanchas";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtIDCliente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        private System.Windows.Forms.TextBox txtModificadoPor;
        private System.Windows.Forms.TextBox txtCreadoPor;
        private System.Windows.Forms.DateTimePicker dtpFechaModificacion;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
    }
}