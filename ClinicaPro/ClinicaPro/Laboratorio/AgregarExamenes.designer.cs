namespace ClinicaPro.Laboratorio
{
    partial class AgregarExamenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarExamenes));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFechaHoy = new System.Windows.Forms.DateTimePicker();
            this.cbTipoExamen = new System.Windows.Forms.ComboBox();
            this.cbEstadoExamen = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtFechaResultado = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.numCliente = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBusquedaCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TipoExamen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Actual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Estado Examen";
            // 
            // dtFechaHoy
            // 
            this.dtFechaHoy.Enabled = false;
            this.dtFechaHoy.Location = new System.Drawing.Point(178, 24);
            this.dtFechaHoy.Name = "dtFechaHoy";
            this.dtFechaHoy.Size = new System.Drawing.Size(212, 20);
            this.dtFechaHoy.TabIndex = 0;
            this.dtFechaHoy.Value = new System.DateTime(2016, 7, 5, 19, 12, 52, 0);
            // 
            // cbTipoExamen
            // 
            this.cbTipoExamen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbTipoExamen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoExamen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTipoExamen.FormattingEnabled = true;
            this.cbTipoExamen.Location = new System.Drawing.Point(178, 72);
            this.cbTipoExamen.Name = "cbTipoExamen";
            this.cbTipoExamen.Size = new System.Drawing.Size(212, 21);
            this.cbTipoExamen.TabIndex = 1;
            this.cbTipoExamen.SelectionChangeCommitted += new System.EventHandler(this.cbTipoExamen_SelectionChangeCommitted);
            // 
            // cbEstadoExamen
            // 
            this.cbEstadoExamen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoExamen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbEstadoExamen.FormattingEnabled = true;
            this.cbEstadoExamen.Location = new System.Drawing.Point(178, 169);
            this.cbEstadoExamen.Name = "cbEstadoExamen";
            this.cbEstadoExamen.Size = new System.Drawing.Size(212, 21);
            this.cbEstadoExamen.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::ClinicaPro.Properties.Resources.unchecked_24;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(298, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cancelar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Image = global::ClinicaPro.Properties.Resources.diskette;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(178, 272);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 38);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dtFechaResultado
            // 
            this.dtFechaResultado.Enabled = false;
            this.dtFechaResultado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaResultado.Location = new System.Drawing.Point(178, 110);
            this.dtFechaResultado.Name = "dtFechaResultado";
            this.dtFechaResultado.Size = new System.Drawing.Size(212, 20);
            this.dtFechaResultado.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Entrega Resultado";
            // 
            // numCliente
            // 
            this.numCliente.Location = new System.Drawing.Point(178, 211);
            this.numCliente.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numCliente.Name = "numCliente";
            this.numCliente.Size = new System.Drawing.Size(212, 20);
            this.numCliente.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Numero Cliente";
            // 
            // btnBusquedaCliente
            // 
            this.btnBusquedaCliente.FlatAppearance.BorderSize = 0;
            this.btnBusquedaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaCliente.Image = global::ClinicaPro.Properties.Resources.search;
            this.btnBusquedaCliente.Location = new System.Drawing.Point(407, 211);
            this.btnBusquedaCliente.Name = "btnBusquedaCliente";
            this.btnBusquedaCliente.Size = new System.Drawing.Size(28, 23);
            this.btnBusquedaCliente.TabIndex = 5;
            this.btnBusquedaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusquedaCliente.UseVisualStyleBackColor = true;
            this.btnBusquedaCliente.Click += new System.EventHandler(this.btnBusquedaCliente_Click);
            // 
            // AgregarExamenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(476, 366);
            this.Controls.Add(this.btnBusquedaCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numCliente);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cbEstadoExamen);
            this.Controls.Add(this.dtFechaResultado);
            this.Controls.Add(this.cbTipoExamen);
            this.Controls.Add(this.dtFechaHoy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AgregarExamenes";
            this.Text = "Agregar Examenes";
            this.Load += new System.EventHandler(this.AgregarExamenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFechaHoy;
        private System.Windows.Forms.ComboBox cbTipoExamen;
        private System.Windows.Forms.ComboBox cbEstadoExamen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DateTimePicker dtFechaResultado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBusquedaCliente;
    }
}