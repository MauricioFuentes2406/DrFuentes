namespace ClinicaPro.Laboratorio
{
    partial class LaboratorioGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratorioGeneral));
            this.btnTipoExamenes = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnExamenes = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTipoExamenes
            // 
            this.btnTipoExamenes.FlatAppearance.BorderSize = 0;
            this.btnTipoExamenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipoExamenes.Image = global::ClinicaPro.Properties.Resources.blood_sample;
            this.btnTipoExamenes.Location = new System.Drawing.Point(265, 246);
            this.btnTipoExamenes.Name = "btnTipoExamenes";
            this.btnTipoExamenes.Size = new System.Drawing.Size(115, 123);
            this.btnTipoExamenes.TabIndex = 16;
            this.btnTipoExamenes.Text = "Tipo Examenes";
            this.btnTipoExamenes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTipoExamenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTipoExamenes.UseVisualStyleBackColor = true;
            this.btnTipoExamenes.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Image = global::ClinicaPro.Properties.Resources.point_of_service;
            this.button10.Location = new System.Drawing.Point(90, 246);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(115, 123);
            this.button10.TabIndex = 15;
            this.button10.Text = "Gastos";
            this.button10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnExamenes
            // 
            this.btnExamenes.FlatAppearance.BorderSize = 0;
            this.btnExamenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamenes.Image = global::ClinicaPro.Properties.Resources.microscope;
            this.btnExamenes.Location = new System.Drawing.Point(265, 89);
            this.btnExamenes.Name = "btnExamenes";
            this.btnExamenes.Size = new System.Drawing.Size(115, 123);
            this.btnExamenes.TabIndex = 14;
            this.btnExamenes.Text = "Examenes";
            this.btnExamenes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExamenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExamenes.UseVisualStyleBackColor = true;
            this.btnExamenes.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Image = global::ClinicaPro.Properties.Resources.team1;
            this.btnCliente.Location = new System.Drawing.Point(90, 89);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(115, 123);
            this.btnCliente.TabIndex = 10;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // LaboratorioGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(481, 427);
            this.Controls.Add(this.btnTipoExamenes);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.btnExamenes);
            this.Controls.Add(this.btnCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LaboratorioGeneral";
            this.Text = "Laboratorio";
            this.Load += new System.EventHandler(this.Laboratorio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnExamenes;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btnTipoExamenes;
    }
}