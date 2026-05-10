namespace MultiSport_Manager.Views
{
    partial class FormReservaImplemento
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
            this.dgImplementoSede = new System.Windows.Forms.DataGridView();
            this.btnQuitarImplemento = new System.Windows.Forms.Button();
            this.btnAñadirImplemento = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPrecioCongelado = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblRegresarReserva = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvImplementoReserva = new System.Windows.Forms.DataGridView();
            this.lblIdReserva = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgImplementoSede)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImplementoReserva)).BeginInit();
            this.SuspendLayout();
            // 
            // dgImplementoSede
            // 
            this.dgImplementoSede.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgImplementoSede.Location = new System.Drawing.Point(26, 147);
            this.dgImplementoSede.Margin = new System.Windows.Forms.Padding(2);
            this.dgImplementoSede.Name = "dgImplementoSede";
            this.dgImplementoSede.RowHeadersWidth = 51;
            this.dgImplementoSede.RowTemplate.Height = 24;
            this.dgImplementoSede.Size = new System.Drawing.Size(299, 415);
            this.dgImplementoSede.TabIndex = 59;
            // 
            // btnQuitarImplemento
            // 
            this.btnQuitarImplemento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnQuitarImplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarImplemento.Location = new System.Drawing.Point(34, 208);
            this.btnQuitarImplemento.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitarImplemento.Name = "btnQuitarImplemento";
            this.btnQuitarImplemento.Size = new System.Drawing.Size(206, 43);
            this.btnQuitarImplemento.TabIndex = 58;
            this.btnQuitarImplemento.Text = "<- Quitar Implemento";
            this.btnQuitarImplemento.UseVisualStyleBackColor = false;
            this.btnQuitarImplemento.Click += new System.EventHandler(this.btnQuitarImplemento_Click);
            // 
            // btnAñadirImplemento
            // 
            this.btnAñadirImplemento.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAñadirImplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirImplemento.Location = new System.Drawing.Point(34, 152);
            this.btnAñadirImplemento.Margin = new System.Windows.Forms.Padding(2);
            this.btnAñadirImplemento.Name = "btnAñadirImplemento";
            this.btnAñadirImplemento.Size = new System.Drawing.Size(206, 41);
            this.btnAñadirImplemento.TabIndex = 56;
            this.btnAñadirImplemento.Text = "Añadir Implemento ->";
            this.btnAñadirImplemento.UseVisualStyleBackColor = false;
            this.btnAñadirImplemento.Click += new System.EventHandler(this.btnAñadirImplemento_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.btnQuitarImplemento);
            this.panel7.Controls.Add(this.txtCantidad);
            this.panel7.Controls.Add(this.label18);
            this.panel7.Controls.Add(this.btnAñadirImplemento);
            this.panel7.Controls.Add(this.txtPrecioCongelado);
            this.panel7.Controls.Add(this.label20);
            this.panel7.Location = new System.Drawing.Point(344, 174);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(281, 277);
            this.panel7.TabIndex = 55;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(17, 102);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 15);
            this.label12.TabIndex = 47;
            this.label12.Text = "- Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(153, 101);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(106, 20);
            this.txtCantidad.TabIndex = 46;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(16, 20);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 20);
            this.label18.TabIndex = 16;
            this.label18.Text = "Opciones:";
            // 
            // txtPrecioCongelado
            // 
            this.txtPrecioCongelado.Location = new System.Drawing.Point(155, 69);
            this.txtPrecioCongelado.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecioCongelado.Name = "txtPrecioCongelado";
            this.txtPrecioCongelado.Size = new System.Drawing.Size(104, 20);
            this.txtPrecioCongelado.TabIndex = 17;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Location = new System.Drawing.Point(17, 70);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(134, 15);
            this.label20.TabIndex = 9;
            this.label20.Text = "- Precio Congelado:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Ivory;
            this.panel2.Controls.Add(this.lblRegresarReserva);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(1, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 84);
            this.panel2.TabIndex = 54;
            // 
            // lblRegresarReserva
            // 
            this.lblRegresarReserva.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegresarReserva.Location = new System.Drawing.Point(776, 15);
            this.lblRegresarReserva.Name = "lblRegresarReserva";
            this.lblRegresarReserva.Size = new System.Drawing.Size(186, 46);
            this.lblRegresarReserva.TabIndex = 54;
            this.lblRegresarReserva.Text = "↵Regresar a Reserva";
            this.lblRegresarReserva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRegresarReserva.Click += new System.EventHandler(this.lblRegresarReserva_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 23);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(663, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "🔔 Gestion de Implementos para la Reserva                                       ";
            // 
            // dgvImplementoReserva
            // 
            this.dgvImplementoReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImplementoReserva.Location = new System.Drawing.Point(652, 147);
            this.dgvImplementoReserva.Margin = new System.Windows.Forms.Padding(2);
            this.dgvImplementoReserva.Name = "dgvImplementoReserva";
            this.dgvImplementoReserva.RowHeadersWidth = 51;
            this.dgvImplementoReserva.RowTemplate.Height = 24;
            this.dgvImplementoReserva.Size = new System.Drawing.Size(299, 415);
            this.dgvImplementoReserva.TabIndex = 60;
            // 
            // lblIdReserva
            // 
            this.lblIdReserva.AutoSize = true;
            this.lblIdReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdReserva.Location = new System.Drawing.Point(522, 136);
            this.lblIdReserva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdReserva.Name = "lblIdReserva";
            this.lblIdReserva.Size = new System.Drawing.Size(20, 25);
            this.lblIdReserva.TabIndex = 55;
            this.lblIdReserva.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 50);
            this.label1.TabIndex = 55;
            this.label1.Text = "Implementos Disponibles      \r\npara la reserva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(681, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 25);
            this.label2.TabIndex = 61;
            this.label2.Text = "Implementos Reservados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(378, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 25);
            this.label3.TabIndex = 62;
            this.label3.Text = "ID Reserva:";
            // 
            // FormReservaImplemento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 573);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIdReserva);
            this.Controls.Add(this.dgvImplementoReserva);
            this.Controls.Add(this.dgImplementoSede);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel2);
            this.Name = "FormReservaImplemento";
            this.Text = "Implementos para Reserva";
            ((System.ComponentModel.ISupportInitialize)(this.dgImplementoSede)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImplementoReserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgImplementoSede;
        private System.Windows.Forms.Button btnQuitarImplemento;
        private System.Windows.Forms.Button btnAñadirImplemento;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPrecioCongelado;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblRegresarReserva;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvImplementoReserva;
        private System.Windows.Forms.Label lblIdReserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}