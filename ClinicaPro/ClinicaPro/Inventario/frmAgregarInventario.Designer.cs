namespace ClinicaPro.Inventario
{
    partial class frmAgregarInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarInventario));
            this.btnAddEstado = new System.Windows.Forms.Button();
            this.btnAddTipoUnidad = new System.Windows.Forms.Button();
            this.lblCampoRequerido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.numCantidadAlerta = new System.Windows.Forms.NumericUpDown();
            this.txtPresentacion = new System.Windows.Forms.TextBox();
            this.cbTipoUnidad = new System.Windows.Forms.ComboBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadAlerta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddEstado
            // 
            this.btnAddEstado.FlatAppearance.BorderSize = 0;
            this.btnAddEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEstado.Image = global::ClinicaPro.Properties.Resources.list;
            this.btnAddEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddEstado.Location = new System.Drawing.Point(347, 197);
            this.btnAddEstado.Name = "btnAddEstado";
            this.btnAddEstado.Size = new System.Drawing.Size(39, 31);
            this.btnAddEstado.TabIndex = 10;
            this.btnAddEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddEstado.UseVisualStyleBackColor = true;
            this.btnAddEstado.Click += new System.EventHandler(this.btnAddEstado_Click);
            // 
            // btnAddTipoUnidad
            // 
            this.btnAddTipoUnidad.FlatAppearance.BorderSize = 0;
            this.btnAddTipoUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTipoUnidad.Image = global::ClinicaPro.Properties.Resources.list;
            this.btnAddTipoUnidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTipoUnidad.Location = new System.Drawing.Point(347, 57);
            this.btnAddTipoUnidad.Name = "btnAddTipoUnidad";
            this.btnAddTipoUnidad.Size = new System.Drawing.Size(39, 31);
            this.btnAddTipoUnidad.TabIndex = 9;
            this.btnAddTipoUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTipoUnidad.UseVisualStyleBackColor = true;
            this.btnAddTipoUnidad.Click += new System.EventHandler(this.btnAddTipoUnidad_Click);
            // 
            // lblCampoRequerido
            // 
            this.lblCampoRequerido.AutoSize = true;
            this.lblCampoRequerido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampoRequerido.ForeColor = System.Drawing.Color.Maroon;
            this.lblCampoRequerido.Location = new System.Drawing.Point(43, 9);
            this.lblCampoRequerido.Name = "lblCampoRequerido";
            this.lblCampoRequerido.Size = new System.Drawing.Size(112, 13);
            this.lblCampoRequerido.TabIndex = 47;
            this.lblCampoRequerido.Text = " Campos Requeridos *";
            this.lblCampoRequerido.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(138, 34);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(197, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Nombre*";
            // 
            // numPrecio
            // 
            this.numPrecio.Location = new System.Drawing.Point(138, 100);
            this.numPrecio.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(197, 20);
            this.numPrecio.TabIndex = 2;
            this.numPrecio.ThousandsSeparator = true;
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(138, 135);
            this.numCantidad.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(197, 20);
            this.numCantidad.TabIndex = 3;
            this.numCantidad.ThousandsSeparator = true;
            // 
            // numCantidadAlerta
            // 
            this.numCantidadAlerta.Location = new System.Drawing.Point(138, 172);
            this.numCantidadAlerta.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numCantidadAlerta.Name = "numCantidadAlerta";
            this.numCantidadAlerta.Size = new System.Drawing.Size(197, 20);
            this.numCantidadAlerta.TabIndex = 4;
            this.numCantidadAlerta.ThousandsSeparator = true;
            // 
            // txtPresentacion
            // 
            this.txtPresentacion.Location = new System.Drawing.Point(138, 240);
            this.txtPresentacion.MaxLength = 50;
            this.txtPresentacion.Multiline = true;
            this.txtPresentacion.Name = "txtPresentacion";
            this.txtPresentacion.Size = new System.Drawing.Size(197, 76);
            this.txtPresentacion.TabIndex = 6;
            // 
            // cbTipoUnidad
            // 
            this.cbTipoUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTipoUnidad.FormattingEnabled = true;
            this.cbTipoUnidad.Location = new System.Drawing.Point(138, 63);
            this.cbTipoUnidad.Name = "cbTipoUnidad";
            this.cbTipoUnidad.Size = new System.Drawing.Size(197, 21);
            this.cbTipoUnidad.TabIndex = 1;
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(138, 205);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(197, 21);
            this.cbEstado.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "TipoUnidad*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Precio*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Cantidad Existente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Cantidad Alerta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Estado*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Presentacion";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::ClinicaPro.Properties.Resources.unchecked_24;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(272, 337);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 38);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Image = global::ClinicaPro.Properties.Resources.diskette;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(138, 337);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 38);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmAgregarInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(409, 401);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.cbTipoUnidad);
            this.Controls.Add(this.txtPresentacion);
            this.Controls.Add(this.numCantidadAlerta);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.numPrecio);
            this.Controls.Add(this.lblCampoRequerido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddTipoUnidad);
            this.Controls.Add(this.btnAddEstado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAgregarInventario";
            this.Text = "Agregar Articulo";
            this.Load += new System.EventHandler(this.frmAgregarInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadAlerta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddEstado;
        private System.Windows.Forms.Button btnAddTipoUnidad;
        private System.Windows.Forms.Label lblCampoRequerido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.NumericUpDown numCantidadAlerta;
        private System.Windows.Forms.TextBox txtPresentacion;
        private System.Windows.Forms.ComboBox cbTipoUnidad;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}