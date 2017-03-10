namespace Frm
{
    partial class ConfiguracionGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguracionGeneral));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMaterialesCasa = new System.Windows.Forms.Button();
            this.btnFamiliar = new System.Windows.Forms.Button();
            this.btnRespuestaGenerales = new System.Windows.Forms.Button();
            this.btnVacuna = new System.Windows.Forms.Button();
            this.btnDrogas = new System.Windows.Forms.Button();
            this.btnAlergias = new System.Windows.Forms.Button();
            this.btnDiccionario = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAlergias);
            this.panel1.Controls.Add(this.btnDiccionario);
            this.panel1.Controls.Add(this.btnMaterialesCasa);
            this.panel1.Controls.Add(this.btnServicios);
            this.panel1.Controls.Add(this.btnFamiliar);
            this.panel1.Controls.Add(this.btnRespuestaGenerales);
            this.panel1.Controls.Add(this.btnVacuna);
            this.panel1.Controls.Add(this.btnDrogas);
            this.panel1.Location = new System.Drawing.Point(35, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 337);
            this.panel1.TabIndex = 4;
            // 
            // btnMaterialesCasa
            // 
            this.btnMaterialesCasa.FlatAppearance.BorderSize = 0;
            this.btnMaterialesCasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterialesCasa.Image = global::Frm.Properties.Resources.home;
            this.btnMaterialesCasa.Location = new System.Drawing.Point(608, 10);
            this.btnMaterialesCasa.Name = "btnMaterialesCasa";
            this.btnMaterialesCasa.Size = new System.Drawing.Size(115, 123);
            this.btnMaterialesCasa.TabIndex = 7;
            this.btnMaterialesCasa.Text = "Materiales Casa";
            this.btnMaterialesCasa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMaterialesCasa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMaterialesCasa.UseVisualStyleBackColor = true;
            this.btnMaterialesCasa.Click += new System.EventHandler(this.btnMaterialesCasa_Click);
            // 
            // btnFamiliar
            // 
            this.btnFamiliar.FlatAppearance.BorderSize = 0;
            this.btnFamiliar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFamiliar.Image = global::Frm.Properties.Resources.family;
            this.btnFamiliar.Location = new System.Drawing.Point(466, 10);
            this.btnFamiliar.Name = "btnFamiliar";
            this.btnFamiliar.Size = new System.Drawing.Size(115, 123);
            this.btnFamiliar.TabIndex = 6;
            this.btnFamiliar.Text = "Familiar";
            this.btnFamiliar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFamiliar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFamiliar.UseVisualStyleBackColor = true;
            this.btnFamiliar.Click += new System.EventHandler(this.btnFamiliar_Click);
            // 
            // btnRespuestaGenerales
            // 
            this.btnRespuestaGenerales.FlatAppearance.BorderSize = 0;
            this.btnRespuestaGenerales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRespuestaGenerales.Image = global::Frm.Properties.Resources.RespuestaGeneral_4;
            this.btnRespuestaGenerales.Location = new System.Drawing.Point(318, 10);
            this.btnRespuestaGenerales.Name = "btnRespuestaGenerales";
            this.btnRespuestaGenerales.Size = new System.Drawing.Size(118, 123);
            this.btnRespuestaGenerales.TabIndex = 5;
            this.btnRespuestaGenerales.Text = "Respustas Generales";
            this.btnRespuestaGenerales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRespuestaGenerales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRespuestaGenerales.UseVisualStyleBackColor = true;
            this.btnRespuestaGenerales.Click += new System.EventHandler(this.btnRespuestaGenerales_Click);
            // 
            // btnVacuna
            // 
            this.btnVacuna.FlatAppearance.BorderSize = 0;
            this.btnVacuna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVacuna.Image = global::Frm.Properties.Resources.syringe;
            this.btnVacuna.Location = new System.Drawing.Point(173, 10);
            this.btnVacuna.Name = "btnVacuna";
            this.btnVacuna.Size = new System.Drawing.Size(115, 123);
            this.btnVacuna.TabIndex = 3;
            this.btnVacuna.Text = "Vacunas";
            this.btnVacuna.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVacuna.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVacuna.UseVisualStyleBackColor = true;
            this.btnVacuna.Click += new System.EventHandler(this.btnVacuna_Click);
            // 
            // btnDrogas
            // 
            this.btnDrogas.FlatAppearance.BorderSize = 0;
            this.btnDrogas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrogas.Image = global::Frm.Properties.Resources.marijuana;
            this.btnDrogas.Location = new System.Drawing.Point(28, 10);
            this.btnDrogas.Name = "btnDrogas";
            this.btnDrogas.Size = new System.Drawing.Size(115, 123);
            this.btnDrogas.TabIndex = 2;
            this.btnDrogas.Text = "Drogas";
            this.btnDrogas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDrogas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDrogas.UseVisualStyleBackColor = true;
            this.btnDrogas.Click += new System.EventHandler(this.btnDrogas_Click);
            // 
            // btnAlergias
            // 
            this.btnAlergias.BackgroundImage = global::Frm.Properties.Resources.molecule_100;
            this.btnAlergias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAlergias.FlatAppearance.BorderSize = 0;
            this.btnAlergias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlergias.Location = new System.Drawing.Point(321, 180);
            this.btnAlergias.Name = "btnAlergias";
            this.btnAlergias.Size = new System.Drawing.Size(115, 123);
            this.btnAlergias.TabIndex = 9;
            this.btnAlergias.Text = "Alergias";
            this.btnAlergias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlergias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAlergias.UseVisualStyleBackColor = true;
            this.btnAlergias.Click += new System.EventHandler(this.btnAlergias_Click);
            // 
            // btnDiccionario
            // 
            this.btnDiccionario.FlatAppearance.BorderSize = 0;
            this.btnDiccionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiccionario.Image = global::Frm.Properties.Resources.dictionary__100;
            this.btnDiccionario.Location = new System.Drawing.Point(166, 178);
            this.btnDiccionario.Name = "btnDiccionario";
            this.btnDiccionario.Size = new System.Drawing.Size(115, 123);
            this.btnDiccionario.TabIndex = 8;
            this.btnDiccionario.Text = "Diccionario";
            this.btnDiccionario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDiccionario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDiccionario.UseVisualStyleBackColor = true;
            this.btnDiccionario.Click += new System.EventHandler(this.btnDiccionario_Click);
            // 
            // btnServicios
            // 
            this.btnServicios.FlatAppearance.BorderSize = 0;
            this.btnServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicios.Image = global::Frm.Properties.Resources.open;
            this.btnServicios.Location = new System.Drawing.Point(21, 178);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(115, 123);
            this.btnServicios.TabIndex = 7;
            this.btnServicios.Text = "Servicios";
            this.btnServicios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnServicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnServicios.UseVisualStyleBackColor = true;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // ConfiguracionGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(827, 432);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "ConfiguracionGeneral";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "ConfiguracionGeneral";
            this.Load += new System.EventHandler(this.ConfiguracionGeneral_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFamiliar;
        private System.Windows.Forms.Button btnRespuestaGenerales;
        private System.Windows.Forms.Button btnVacuna;
        private System.Windows.Forms.Button btnDrogas;
        private System.Windows.Forms.Button btnMaterialesCasa;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnDiccionario;
        private System.Windows.Forms.Button btnAlergias;
    }
}