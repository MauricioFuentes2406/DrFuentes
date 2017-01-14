namespace Frm.Configuracion
{
    partial class frmAlergias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlergias));
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgAlergia = new System.Windows.Forms.DataGridView();
            this.cbNombre = new System.Windows.Forms.ComboBox();
            this.lblCampoRequerido = new System.Windows.Forms.Label();
            this.txtEspecificacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgAlergia)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = global::Frm.Properties.Resources.notepad_2;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(230, 92);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(52, 38);
            this.btnEliminar.TabIndex = 57;
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackgroundImage = global::Frm.Properties.Resources.notepad_15;
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Location = new System.Drawing.Point(172, 92);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(52, 38);
            this.btnActualizar.TabIndex = 56;
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Frm.Properties.Resources.notepad;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(114, 92);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(52, 38);
            this.btnAgregar.TabIndex = 55;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::Frm.Properties.Resources.loading;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(56, 92);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 38);
            this.btnRefresh.TabIndex = 54;
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgAlergia
            // 
            this.dgAlergia.AllowUserToAddRows = false;
            this.dgAlergia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAlergia.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgAlergia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAlergia.Location = new System.Drawing.Point(54, 136);
            this.dgAlergia.MultiSelect = false;
            this.dgAlergia.Name = "dgAlergia";
            this.dgAlergia.ReadOnly = true;
            this.dgAlergia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgAlergia.Size = new System.Drawing.Size(267, 189);
            this.dgAlergia.TabIndex = 53;
            this.dgAlergia.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgAlergia_RowHeaderMouseClick);
            // 
            // cbNombre
            // 
            this.cbNombre.FormattingEnabled = true;
            this.cbNombre.Location = new System.Drawing.Point(153, 9);
            this.cbNombre.Name = "cbNombre";
            this.cbNombre.Size = new System.Drawing.Size(100, 21);
            this.cbNombre.TabIndex = 63;
            // 
            // lblCampoRequerido
            // 
            this.lblCampoRequerido.AutoSize = true;
            this.lblCampoRequerido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampoRequerido.ForeColor = System.Drawing.Color.Maroon;
            this.lblCampoRequerido.Location = new System.Drawing.Point(259, 11);
            this.lblCampoRequerido.Name = "lblCampoRequerido";
            this.lblCampoRequerido.Size = new System.Drawing.Size(112, 13);
            this.lblCampoRequerido.TabIndex = 62;
            this.lblCampoRequerido.Text = " Campos Requeridos *";
            this.lblCampoRequerido.Visible = false;
            // 
            // txtEspecificacion
            // 
            this.txtEspecificacion.Location = new System.Drawing.Point(153, 48);
            this.txtEspecificacion.MaxLength = 50;
            this.txtEspecificacion.Name = "txtEspecificacion";
            this.txtEspecificacion.Size = new System.Drawing.Size(100, 20);
            this.txtEspecificacion.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Especificacion*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Nombre*";
            // 
            // frmAlergias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(380, 352);
            this.Controls.Add(this.cbNombre);
            this.Controls.Add(this.lblCampoRequerido);
            this.Controls.Add(this.txtEspecificacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgAlergia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAlergias";
            this.Text = "Alergias";
            this.Load += new System.EventHandler(this.frmAlergias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAlergia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgAlergia;
        private System.Windows.Forms.ComboBox cbNombre;
        private System.Windows.Forms.Label lblCampoRequerido;
        private System.Windows.Forms.TextBox txtEspecificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}