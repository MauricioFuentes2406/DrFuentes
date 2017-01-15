namespace Frm.Diccionario
{
    partial class frmBusquedaAvanzada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaAvanzada));
            this.dgBusqueda = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSintoma = new System.Windows.Forms.TextBox();
            this.txtTratamiento = new System.Windows.Forms.TextBox();
            this.txtEnfeRelacionada = new System.Windows.Forms.TextBox();
            this.txtDescricpcion = new System.Windows.Forms.TextBox();
            this.btnBusquedaNombre = new System.Windows.Forms.Button();
            this.btnBusquedaSintoma = new System.Windows.Forms.Button();
            this.btnBusquedaTratamiento = new System.Windows.Forms.Button();
            this.btnBusquedaEnfermedadRelaionada = new System.Windows.Forms.Button();
            this.btnBusquedaDescripcion = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBusqueda
            // 
            this.dgBusqueda.AllowUserToAddRows = false;
            this.dgBusqueda.AllowUserToDeleteRows = false;
            this.dgBusqueda.AllowUserToOrderColumns = true;
            this.dgBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBusqueda.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgBusqueda.Location = new System.Drawing.Point(39, 103);
            this.dgBusqueda.MultiSelect = false;
            this.dgBusqueda.Name = "dgBusqueda";
            this.dgBusqueda.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBusqueda.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgBusqueda.Size = new System.Drawing.Size(741, 289);
            this.dgBusqueda.TabIndex = 10;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(189, 15);
            this.txtNombre.MaxLength = 70;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(187, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
<<<<<<< HEAD
            this.label2.Text = "Sintoma";            
=======
            this.label2.Text = "Sintoma";
            this.label2.Click += new System.EventHandler(this.label2_Click);
>>>>>>> 8fc416171393af624873d94fe5df1cead5e5a5e5
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tratamiento";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enfermedad Relacionada";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Descripcion Adicional";
            // 
            // txtSintoma
            // 
            this.txtSintoma.Location = new System.Drawing.Point(189, 43);
            this.txtSintoma.MaxLength = 400;
            this.txtSintoma.Name = "txtSintoma";
            this.txtSintoma.Size = new System.Drawing.Size(187, 20);
            this.txtSintoma.TabIndex = 2;
            // 
            // txtTratamiento
            // 
            this.txtTratamiento.Location = new System.Drawing.Point(190, 68);
            this.txtTratamiento.MaxLength = 350;
            this.txtTratamiento.Name = "txtTratamiento";
            this.txtTratamiento.Size = new System.Drawing.Size(187, 20);
<<<<<<< HEAD
            this.txtTratamiento.TabIndex = 4;            
=======
            this.txtTratamiento.TabIndex = 4;
            this.txtTratamiento.TextChanged += new System.EventHandler(this.txtTratamiento_TextChanged);
>>>>>>> 8fc416171393af624873d94fe5df1cead5e5a5e5
            // 
            // txtEnfeRelacionada
            // 
            this.txtEnfeRelacionada.Location = new System.Drawing.Point(554, 15);
            this.txtEnfeRelacionada.MaxLength = 300;
            this.txtEnfeRelacionada.Name = "txtEnfeRelacionada";
            this.txtEnfeRelacionada.Size = new System.Drawing.Size(187, 20);
            this.txtEnfeRelacionada.TabIndex = 6;
            // 
            // txtDescricpcion
            // 
            this.txtDescricpcion.Location = new System.Drawing.Point(554, 43);
            this.txtDescricpcion.MaxLength = 400;
            this.txtDescricpcion.Multiline = true;
            this.txtDescricpcion.Name = "txtDescricpcion";
            this.txtDescricpcion.Size = new System.Drawing.Size(187, 20);
            this.txtDescricpcion.TabIndex = 8;
            // 
            // btnBusquedaNombre
            // 
            this.btnBusquedaNombre.FlatAppearance.BorderSize = 0;
            this.btnBusquedaNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaNombre.Image = global::Frm.Properties.Resources.search;
            this.btnBusquedaNombre.Location = new System.Drawing.Point(382, 13);
            this.btnBusquedaNombre.Name = "btnBusquedaNombre";
            this.btnBusquedaNombre.Size = new System.Drawing.Size(28, 23);
            this.btnBusquedaNombre.TabIndex = 1;
            this.btnBusquedaNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusquedaNombre.UseVisualStyleBackColor = true;
            this.btnBusquedaNombre.Click += new System.EventHandler(this.btnBusquedaNombre_Click);
            // 
            // btnBusquedaSintoma
            // 
            this.btnBusquedaSintoma.FlatAppearance.BorderSize = 0;
            this.btnBusquedaSintoma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaSintoma.Image = global::Frm.Properties.Resources.search;
            this.btnBusquedaSintoma.Location = new System.Drawing.Point(382, 41);
            this.btnBusquedaSintoma.Name = "btnBusquedaSintoma";
            this.btnBusquedaSintoma.Size = new System.Drawing.Size(28, 23);
            this.btnBusquedaSintoma.TabIndex = 3;
            this.btnBusquedaSintoma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusquedaSintoma.UseVisualStyleBackColor = true;
            this.btnBusquedaSintoma.Click += new System.EventHandler(this.btnBusquedaSintoma_Click);
            // 
            // btnBusquedaTratamiento
            // 
            this.btnBusquedaTratamiento.FlatAppearance.BorderSize = 0;
            this.btnBusquedaTratamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaTratamiento.Image = global::Frm.Properties.Resources.search;
            this.btnBusquedaTratamiento.Location = new System.Drawing.Point(382, 67);
            this.btnBusquedaTratamiento.Name = "btnBusquedaTratamiento";
            this.btnBusquedaTratamiento.Size = new System.Drawing.Size(28, 23);
            this.btnBusquedaTratamiento.TabIndex = 5;
            this.btnBusquedaTratamiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusquedaTratamiento.UseVisualStyleBackColor = true;
            this.btnBusquedaTratamiento.Click += new System.EventHandler(this.btnBusquedaTratamiento_Click);
            // 
            // btnBusquedaEnfermedadRelaionada
            // 
            this.btnBusquedaEnfermedadRelaionada.FlatAppearance.BorderSize = 0;
            this.btnBusquedaEnfermedadRelaionada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaEnfermedadRelaionada.Image = global::Frm.Properties.Resources.search;
            this.btnBusquedaEnfermedadRelaionada.Location = new System.Drawing.Point(752, 15);
            this.btnBusquedaEnfermedadRelaionada.Name = "btnBusquedaEnfermedadRelaionada";
            this.btnBusquedaEnfermedadRelaionada.Size = new System.Drawing.Size(28, 23);
            this.btnBusquedaEnfermedadRelaionada.TabIndex = 7;
            this.btnBusquedaEnfermedadRelaionada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusquedaEnfermedadRelaionada.UseVisualStyleBackColor = true;
            this.btnBusquedaEnfermedadRelaionada.Click += new System.EventHandler(this.btnBusquedaEnfermedadRelaionada_Click);
            // 
            // btnBusquedaDescripcion
            // 
            this.btnBusquedaDescripcion.FlatAppearance.BorderSize = 0;
            this.btnBusquedaDescripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaDescripcion.Image = global::Frm.Properties.Resources.search;
            this.btnBusquedaDescripcion.Location = new System.Drawing.Point(752, 41);
            this.btnBusquedaDescripcion.Name = "btnBusquedaDescripcion";
            this.btnBusquedaDescripcion.Size = new System.Drawing.Size(28, 23);
            this.btnBusquedaDescripcion.TabIndex = 9;
            this.btnBusquedaDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusquedaDescripcion.UseVisualStyleBackColor = true;
            this.btnBusquedaDescripcion.Click += new System.EventHandler(this.btnBusquedaDescripcion_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::Frm.Properties.Resources.loading;
            this.btnRefresh.Location = new System.Drawing.Point(39, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 75);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmBusquedaAvanzada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(797, 404);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBusquedaDescripcion);
            this.Controls.Add(this.btnBusquedaEnfermedadRelaionada);
            this.Controls.Add(this.btnBusquedaTratamiento);
            this.Controls.Add(this.btnBusquedaSintoma);
            this.Controls.Add(this.btnBusquedaNombre);
            this.Controls.Add(this.txtDescricpcion);
            this.Controls.Add(this.txtEnfeRelacionada);
            this.Controls.Add(this.txtTratamiento);
            this.Controls.Add(this.txtSintoma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.dgBusqueda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBusquedaAvanzada";
            this.Text = "BusquedaAvanzada";
            this.Load += new System.EventHandler(this.frmBusquedaAvanzada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBusqueda;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSintoma;
        private System.Windows.Forms.TextBox txtTratamiento;
        private System.Windows.Forms.TextBox txtEnfeRelacionada;
        private System.Windows.Forms.TextBox txtDescricpcion;
        private System.Windows.Forms.Button btnBusquedaNombre;
        private System.Windows.Forms.Button btnBusquedaSintoma;
        private System.Windows.Forms.Button btnBusquedaTratamiento;
        private System.Windows.Forms.Button btnBusquedaEnfermedadRelaionada;
        private System.Windows.Forms.Button btnBusquedaDescripcion;
        private System.Windows.Forms.Button btnRefresh;
    }
}