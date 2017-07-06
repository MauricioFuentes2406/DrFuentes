namespace ClinicaPro.Diccionario
{
    partial class frmDiccionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiccionario));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pictureBoxImg = new System.Windows.Forms.PictureBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSintoma = new System.Windows.Forms.TextBox();
            this.txtTratamiento = new System.Windows.Forms.TextBox();
            this.txtEnfermedadRelacionada = new System.Windows.Forms.TextBox();
            this.txtDescripcionAdicional = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnExaminarImagen = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblCampoRequerido = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chkActivarGuardar = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::ClinicaPro.Properties.Resources.unchecked_24;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(372, 367);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 38);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Image = global::ClinicaPro.Properties.Resources.diskette;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(480, 367);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 38);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pictureBoxImg
            // 
            this.pictureBoxImg.Location = new System.Drawing.Point(3, 0);
            this.pictureBoxImg.Name = "pictureBoxImg";
            this.pictureBoxImg.Size = new System.Drawing.Size(292, 257);
            this.pictureBoxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxImg.TabIndex = 17;
            this.pictureBoxImg.TabStop = false;
            this.pictureBoxImg.WaitOnLoad = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(84, 12);
            this.txtNombre.MaxLength = 70;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(232, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nombre*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Síntoma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tratamiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Enfermedad Relacionada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Descripcion Adicional";
            // 
            // txtSintoma
            // 
            this.txtSintoma.Location = new System.Drawing.Point(28, 76);
            this.txtSintoma.MaxLength = 400;
            this.txtSintoma.Multiline = true;
            this.txtSintoma.Name = "txtSintoma";
            this.txtSintoma.Size = new System.Drawing.Size(288, 93);
            this.txtSintoma.TabIndex = 1;
            // 
            // txtTratamiento
            // 
            this.txtTratamiento.Location = new System.Drawing.Point(28, 227);
            this.txtTratamiento.MaxLength = 350;
            this.txtTratamiento.Multiline = true;
            this.txtTratamiento.Name = "txtTratamiento";
            this.txtTratamiento.Size = new System.Drawing.Size(288, 93);
            this.txtTratamiento.TabIndex = 2;
            // 
            // txtEnfermedadRelacionada
            // 
            this.txtEnfermedadRelacionada.Location = new System.Drawing.Point(331, 76);
            this.txtEnfermedadRelacionada.MaxLength = 300;
            this.txtEnfermedadRelacionada.Multiline = true;
            this.txtEnfermedadRelacionada.Name = "txtEnfermedadRelacionada";
            this.txtEnfermedadRelacionada.Size = new System.Drawing.Size(288, 93);
            this.txtEnfermedadRelacionada.TabIndex = 3;
            // 
            // txtDescripcionAdicional
            // 
            this.txtDescripcionAdicional.Location = new System.Drawing.Point(331, 227);
            this.txtDescripcionAdicional.MaxLength = 400;
            this.txtDescripcionAdicional.Multiline = true;
            this.txtDescripcionAdicional.Name = "txtDescripcionAdicional";
            this.txtDescripcionAdicional.Size = new System.Drawing.Size(288, 93);
            this.txtDescripcionAdicional.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(631, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Imagen";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Imagen";
            // 
            // btnExaminarImagen
            // 
            this.btnExaminarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminarImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExaminarImagen.Location = new System.Drawing.Point(625, 341);
            this.btnExaminarImagen.Name = "btnExaminarImagen";
            this.btnExaminarImagen.Size = new System.Drawing.Size(67, 26);
            this.btnExaminarImagen.TabIndex = 5;
            this.btnExaminarImagen.Text = "Examinar";
            this.btnExaminarImagen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExaminarImagen.UseVisualStyleBackColor = true;
            this.btnExaminarImagen.Click += new System.EventHandler(this.btnBuscarImagen_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::ClinicaPro.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(322, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 26);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblCampoRequerido
            // 
            this.lblCampoRequerido.AutoSize = true;
            this.lblCampoRequerido.ForeColor = System.Drawing.Color.Maroon;
            this.lblCampoRequerido.Location = new System.Drawing.Point(81, 35);
            this.lblCampoRequerido.Name = "lblCampoRequerido";
            this.lblCampoRequerido.Size = new System.Drawing.Size(96, 13);
            this.lblCampoRequerido.TabIndex = 31;
            this.lblCampoRequerido.Text = "Campo Requerido*";
            this.lblCampoRequerido.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(379, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "BusquedaAvanzada";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnBusquedaAvanzada);
            // 
            // chkActivarGuardar
            // 
            this.chkActivarGuardar.AutoSize = true;
            this.chkActivarGuardar.Location = new System.Drawing.Point(206, 34);
            this.chkActivarGuardar.Name = "chkActivarGuardar";
            this.chkActivarGuardar.Size = new System.Drawing.Size(100, 17);
            this.chkActivarGuardar.TabIndex = 34;
            this.chkActivarGuardar.Text = "Activar Guardar";
            this.chkActivarGuardar.UseVisualStyleBackColor = true;
            this.chkActivarGuardar.CheckedChanged += new System.EventHandler(this.chkActivarBusqueda_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBoxImg);
            this.panel1.Location = new System.Drawing.Point(625, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 267);
            this.panel1.TabIndex = 35;
            // 
            // frmDiccionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(929, 434);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkActivarGuardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCampoRequerido);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnExaminarImagen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescripcionAdicional);
            this.Controls.Add(this.txtEnfermedadRelacionada);
            this.Controls.Add(this.txtTratamiento);
            this.Controls.Add(this.txtSintoma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDiccionario";
            this.Text = "Diccionario";
            this.Load += new System.EventHandler(this.frmBusquedas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.PictureBox pictureBoxImg;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSintoma;
        private System.Windows.Forms.TextBox txtTratamiento;
        private System.Windows.Forms.TextBox txtEnfermedadRelacionada;
        private System.Windows.Forms.TextBox txtDescripcionAdicional;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnExaminarImagen;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCampoRequerido;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkActivarGuardar;
        private System.Windows.Forms.Panel panel1;
    }
}