namespace ClinicaPro.Reportes
{
    partial class frmReporteGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteGeneral));
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnGastosIngresos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConsulta
            // 
            this.btnConsulta.FlatAppearance.BorderSize = 0;
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.Image = global::ClinicaPro.Properties.Resources.report;
            this.btnConsulta.Location = new System.Drawing.Point(237, 37);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(115, 123);
            this.btnConsulta.TabIndex = 5;
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Image = global::ClinicaPro.Properties.Resources.team1;
            this.btnCliente.Location = new System.Drawing.Point(37, 37);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(115, 123);
            this.btnCliente.TabIndex = 4;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.Image = global::ClinicaPro.Properties.Resources.calendar_7;
            this.btnCitas.Location = new System.Drawing.Point(237, 186);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(115, 123);
            this.btnCitas.TabIndex = 7;
            this.btnCitas.Text = "Ver Citas";
            this.btnCitas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCitas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnGastosIngresos
            // 
            this.btnGastosIngresos.FlatAppearance.BorderSize = 0;
            this.btnGastosIngresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGastosIngresos.Image = global::ClinicaPro.Properties.Resources.point_of_service;
            this.btnGastosIngresos.Location = new System.Drawing.Point(37, 186);
            this.btnGastosIngresos.Name = "btnGastosIngresos";
            this.btnGastosIngresos.Size = new System.Drawing.Size(115, 123);
            this.btnGastosIngresos.TabIndex = 8;
            this.btnGastosIngresos.Text = "Gastos e Ingresos";
            this.btnGastosIngresos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGastosIngresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGastosIngresos.UseVisualStyleBackColor = true;
            this.btnGastosIngresos.Click += new System.EventHandler(this.btnGastosIngresos_Click);
            // 
            // frmReporteGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(406, 369);
            this.Controls.Add(this.btnGastosIngresos);
            this.Controls.Add(this.btnCitas);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReporteGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte General";
            this.Load += new System.EventHandler(this.frmReporteGeneral_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnGastosIngresos;

    }
}