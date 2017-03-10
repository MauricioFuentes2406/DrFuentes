namespace Frm
{
    partial class Agregar_Modificar_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agregar_Modificar_Cliente));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtSegundo_Apellido = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCampoRequerido = new System.Windows.Forms.Label();
            this.cbTipoSangre = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.NumericUpDown();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.cbExtrajero = new System.Windows.Forms.ComboBox();
            this.cbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbHombre = new System.Windows.Forms.RadioButton();
            this.rbMujer = new System.Windows.Forms.RadioButton();
            this.txtPrimer_Apellido = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdad)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Window;
            this.txtNombre.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNombre.Location = new System.Drawing.Point(103, 46);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(144, 20);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // txtSegundo_Apellido
            // 
            this.txtSegundo_Apellido.Location = new System.Drawing.Point(105, 111);
            this.txtSegundo_Apellido.MaxLength = 25;
            this.txtSegundo_Apellido.Name = "txtSegundo_Apellido";
            this.txtSegundo_Apellido.Size = new System.Drawing.Size(142, 20);
            this.txtSegundo_Apellido.TabIndex = 2;
            this.txtSegundo_Apellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSegundo_Apellido_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCampoRequerido);
            this.groupBox1.Controls.Add(this.cbTipoSangre);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCiudad);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtEdad);
            this.groupBox1.Controls.Add(this.txtCelular);
            this.groupBox1.Controls.Add(this.txtCedula);
            this.groupBox1.Controls.Add(this.cbExtrajero);
            this.groupBox1.Controls.Add(this.cbEstadoCivil);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtPrimer_Apellido);
            this.groupBox1.Controls.Add(this.txtSegundo_Apellido);
            this.groupBox1.Location = new System.Drawing.Point(41, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 313);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Personales";
            // 
            // lblCampoRequerido
            // 
            this.lblCampoRequerido.AutoSize = true;
            this.lblCampoRequerido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampoRequerido.ForeColor = System.Drawing.Color.Maroon;
            this.lblCampoRequerido.Location = new System.Drawing.Point(6, 16);
            this.lblCampoRequerido.Name = "lblCampoRequerido";
            this.lblCampoRequerido.Size = new System.Drawing.Size(112, 13);
            this.lblCampoRequerido.TabIndex = 36;
            this.lblCampoRequerido.Text = " Campos Requeridos *";
            this.lblCampoRequerido.Visible = false;
            // 
            // cbTipoSangre
            // 
            this.cbTipoSangre.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbTipoSangre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoSangre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTipoSangre.FormattingEnabled = true;
            this.cbTipoSangre.Location = new System.Drawing.Point(368, 260);
            this.cbTipoSangre.Name = "cbTipoSangre";
            this.cbTipoSangre.Size = new System.Drawing.Size(128, 21);
            this.cbTipoSangre.TabIndex = 11;
            this.cbTipoSangre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTipoSangre_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(297, 260);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Tipo Sangre";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(369, 146);
            this.txtCiudad.MaxLength = 50;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(127, 20);
            this.txtCiudad.TabIndex = 8;
            this.txtCiudad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCiudad_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(297, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Ciudad*";
            // 
            // txtEdad
            // 
            this.txtEdad.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtEdad.Location = new System.Drawing.Point(103, 256);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(144, 20);
            this.txtEdad.TabIndex = 6;
            this.txtEdad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdad_KeyDown);
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(103, 146);
            this.txtCelular.Mask = "00000000";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCelular.Size = new System.Drawing.Size(144, 20);
            this.txtCelular.TabIndex = 3;
            this.txtCelular.ValidatingType = typeof(string);
            this.txtCelular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCelular_KeyDown);
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(105, 183);
            this.txtCedula.Mask = "0 0000 0000";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(142, 20);
            this.txtCedula.TabIndex = 4;
            this.txtCedula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCedula_KeyDown);
            // 
            // cbExtrajero
            // 
            this.cbExtrajero.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbExtrajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExtrajero.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbExtrajero.FormattingEnabled = true;
            this.cbExtrajero.Location = new System.Drawing.Point(107, 217);
            this.cbExtrajero.Name = "cbExtrajero";
            this.cbExtrajero.Size = new System.Drawing.Size(140, 21);
            this.cbExtrajero.TabIndex = 5;
            this.cbExtrajero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbExtrajero_KeyDown);
            // 
            // cbEstadoCivil
            // 
            this.cbEstadoCivil.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoCivil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbEstadoCivil.FormattingEnabled = true;
            this.cbEstadoCivil.Location = new System.Drawing.Point(369, 217);
            this.cbEstadoCivil.Name = "cbEstadoCivil";
            this.cbEstadoCivil.Size = new System.Drawing.Size(127, 21);
            this.cbEstadoCivil.TabIndex = 10;
            this.cbEstadoCivil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEstadoCivil_KeyDown);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(369, 180);
            this.txtEmail.MaxLength = 40;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(127, 20);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Edad*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Estado Civil";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Celular";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Extrajero*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Cédula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Segundo  Apellido*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Primer  Apellido*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nombre *";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbHombre);
            this.groupBox2.Controls.Add(this.rbMujer);
            this.groupBox2.Location = new System.Drawing.Point(303, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 73);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sexo*";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // rbHombre
            // 
            this.rbHombre.AutoSize = true;
            this.rbHombre.Checked = true;
            this.rbHombre.Image = global::Frm.Properties.Resources.user_4;
            this.rbHombre.Location = new System.Drawing.Point(30, 19);
            this.rbHombre.Name = "rbHombre";
            this.rbHombre.Size = new System.Drawing.Size(62, 41);
            this.rbHombre.TabIndex = 0;
            this.rbHombre.TabStop = true;
            this.rbHombre.Text = "Hombre";
            this.rbHombre.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.rbHombre.UseVisualStyleBackColor = true;
            // 
            // rbMujer
            // 
            this.rbMujer.AutoSize = true;
            this.rbMujer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbMujer.Image = global::Frm.Properties.Resources.user_5;
            this.rbMujer.Location = new System.Drawing.Point(117, 19);
            this.rbMujer.Name = "rbMujer";
            this.rbMujer.Size = new System.Drawing.Size(51, 41);
            this.rbMujer.TabIndex = 1;
            this.rbMujer.Text = "Mujer";
            this.rbMujer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.rbMujer.UseVisualStyleBackColor = false;
            // 
            // txtPrimer_Apellido
            // 
            this.txtPrimer_Apellido.Location = new System.Drawing.Point(105, 76);
            this.txtPrimer_Apellido.MaxLength = 25;
            this.txtPrimer_Apellido.Name = "txtPrimer_Apellido";
            this.txtPrimer_Apellido.Size = new System.Drawing.Size(142, 20);
            this.txtPrimer_Apellido.TabIndex = 1;
            this.txtPrimer_Apellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrimer_Apellido_KeyDown);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::Frm.Properties.Resources.unchecked_24;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(194, 331);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 38);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Image = global::Frm.Properties.Resources.diskette;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(341, 331);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 38);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Agregar_Modificar_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(604, 391);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Agregar_Modificar_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar/Modificar Cliente";
            this.Load += new System.EventHandler(this.AgregarCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtSegundo_Apellido;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbMujer;
        private System.Windows.Forms.RadioButton rbHombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbEstadoCivil;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbExtrajero;
        private System.Windows.Forms.MaskedTextBox txtCedula;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.NumericUpDown txtEdad;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbTipoSangre;
        private System.Windows.Forms.Label lblCampoRequerido;
        private System.Windows.Forms.TextBox txtPrimer_Apellido;
    }
}