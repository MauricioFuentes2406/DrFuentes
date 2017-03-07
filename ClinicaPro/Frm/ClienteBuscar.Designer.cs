namespace Frm
{
    partial class ClienteBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteBuscar));
            this.btnEViviendaDetalle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.gbRangoEdad = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEdadMaxima = new System.Windows.Forms.NumericUpDown();
            this.txtEdadMinima = new System.Windows.Forms.NumericUpDown();
            this.txtIdCliente = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApellido1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbHombre = new System.Windows.Forms.RadioButton();
            this.rbMujer = new System.Windows.Forms.RadioButton();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cbTipoSangre = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbRangoEdad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdadMaxima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdadMinima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdCliente)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEViviendaDetalle
            // 
            this.btnEViviendaDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEViviendaDetalle.Image = global::Frm.Properties.Resources.search;
            this.btnEViviendaDetalle.Location = new System.Drawing.Point(160, 394);
            this.btnEViviendaDetalle.Name = "btnEViviendaDetalle";
            this.btnEViviendaDetalle.Size = new System.Drawing.Size(46, 40);
            this.btnEViviendaDetalle.TabIndex = 0;
            this.btnEViviendaDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEViviendaDetalle.UseVisualStyleBackColor = true;
            this.btnEViviendaDetalle.Click += new System.EventHandler(this.btnEViviendaDetalle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbTipoSangre);
            this.groupBox1.Controls.Add(this.txtCedula);
            this.groupBox1.Controls.Add(this.gbRangoEdad);
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCiudad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtApellido1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(22, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 362);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Métodos  de Filtrado";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(22, 59);
            this.txtCedula.Mask = "0 0000 0000";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(109, 20);
            this.txtCedula.TabIndex = 0;
            // 
            // gbRangoEdad
            // 
            this.gbRangoEdad.Controls.Add(this.label7);
            this.gbRangoEdad.Controls.Add(this.label6);
            this.gbRangoEdad.Controls.Add(this.txtEdadMaxima);
            this.gbRangoEdad.Controls.Add(this.txtEdadMinima);
            this.gbRangoEdad.Location = new System.Drawing.Point(22, 281);
            this.gbRangoEdad.Name = "gbRangoEdad";
            this.gbRangoEdad.Size = new System.Drawing.Size(279, 57);
            this.gbRangoEdad.TabIndex = 3;
            this.gbRangoEdad.TabStop = false;
            this.gbRangoEdad.Text = "Rango Edad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(134, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Máxima";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Minima";
            // 
            // txtEdadMaxima
            // 
            this.txtEdadMaxima.Location = new System.Drawing.Point(183, 21);
            this.txtEdadMaxima.Name = "txtEdadMaxima";
            this.txtEdadMaxima.Size = new System.Drawing.Size(51, 20);
            this.txtEdadMaxima.TabIndex = 1;
            // 
            // txtEdadMinima
            // 
            this.txtEdadMinima.Location = new System.Drawing.Point(58, 19);
            this.txtEdadMinima.Name = "txtEdadMinima";
            this.txtEdadMinima.Size = new System.Drawing.Size(51, 20);
            this.txtEdadMinima.TabIndex = 0;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(176, 125);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(125, 20);
            this.txtIdCliente.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Número Cliente";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(176, 191);
            this.txtCiudad.MaxLength = 50;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(125, 20);
            this.txtCiudad.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ciudad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Apellidos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cédula:";
            // 
            // txtApellido1
            // 
            this.txtApellido1.Location = new System.Drawing.Point(22, 191);
            this.txtApellido1.MaxLength = 50;
            this.txtApellido1.Name = "txtApellido1";
            this.txtApellido1.Size = new System.Drawing.Size(109, 20);
            this.txtApellido1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbHombre);
            this.groupBox2.Controls.Add(this.rbMujer);
            this.groupBox2.Location = new System.Drawing.Point(176, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 79);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sexo*";
            // 
            // rbHombre
            // 
            this.rbHombre.AutoSize = true;
            this.rbHombre.Image = global::Frm.Properties.Resources.user_4;
            this.rbHombre.Location = new System.Drawing.Point(6, 19);
            this.rbHombre.Name = "rbHombre";
            this.rbHombre.Size = new System.Drawing.Size(62, 41);
            this.rbHombre.TabIndex = 0;
            this.rbHombre.Text = "Hombre";
            this.rbHombre.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.rbHombre.UseVisualStyleBackColor = true;
            // 
            // rbMujer
            // 
            this.rbMujer.AutoSize = true;
            this.rbMujer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbMujer.Image = global::Frm.Properties.Resources.user_5;
            this.rbMujer.Location = new System.Drawing.Point(74, 19);
            this.rbMujer.Name = "rbMujer";
            this.rbMujer.Size = new System.Drawing.Size(51, 41);
            this.rbMujer.TabIndex = 1;
            this.rbMujer.Text = "Mujer";
            this.rbMujer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.rbMujer.UseVisualStyleBackColor = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(22, 124);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(109, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // cbTipoSangre
            // 
            this.cbTipoSangre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoSangre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTipoSangre.FormattingEnabled = true;
            this.cbTipoSangre.Location = new System.Drawing.Point(22, 239);
            this.cbTipoSangre.Name = "cbTipoSangre";
            this.cbTipoSangre.Size = new System.Drawing.Size(109, 21);
            this.cbTipoSangre.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tipo de Sangre";
            // 
            // ClienteBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(411, 446);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEViviendaDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClienteBuscar";
            this.Text = "Buscar Cliente";
            this.Load += new System.EventHandler(this.ClienteBuscar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbRangoEdad.ResumeLayout(false);
            this.gbRangoEdad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdadMaxima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdadMinima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdCliente)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEViviendaDetalle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbHombre;
        private System.Windows.Forms.RadioButton rbMujer;
        private System.Windows.Forms.TextBox txtApellido1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtIdCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbRangoEdad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtEdadMaxima;
        private System.Windows.Forms.NumericUpDown txtEdadMinima;
        private System.Windows.Forms.MaskedTextBox txtCedula;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTipoSangre;
    }
}