namespace Frm
{
    partial class AuxiliarLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuxiliarLogin));
            this.btnAdministrador = new System.Windows.Forms.Button();
            this.btnLaboratorio = new System.Windows.Forms.Button();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.btnSecretaria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.FlatAppearance.BorderSize = 0;
            this.btnAdministrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrador.Image = global::Frm.Properties.Resources.team1;
            this.btnAdministrador.Location = new System.Drawing.Point(192, 53);
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Size = new System.Drawing.Size(115, 123);
            this.btnAdministrador.TabIndex = 1;
            this.btnAdministrador.Text = "Administrador";
            this.btnAdministrador.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdministrador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdministrador.UseVisualStyleBackColor = true;
            this.btnAdministrador.Click += new System.EventHandler(this.btnAdministrador_Click);
            // 
            // btnLaboratorio
            // 
            this.btnLaboratorio.FlatAppearance.BorderSize = 0;
            this.btnLaboratorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaboratorio.Image = global::Frm.Properties.Resources.team1;
            this.btnLaboratorio.Location = new System.Drawing.Point(345, 53);
            this.btnLaboratorio.Name = "btnLaboratorio";
            this.btnLaboratorio.Size = new System.Drawing.Size(115, 123);
            this.btnLaboratorio.TabIndex = 2;
            this.btnLaboratorio.Text = "Laboratorio";
            this.btnLaboratorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLaboratorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLaboratorio.UseVisualStyleBackColor = true;
            this.btnLaboratorio.Click += new System.EventHandler(this.btnLaboratorio_Click);
            // 
            // btnGeneral
            // 
            this.btnGeneral.FlatAppearance.BorderSize = 0;
            this.btnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneral.Image = global::Frm.Properties.Resources.team1;
            this.btnGeneral.Location = new System.Drawing.Point(25, 53);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(115, 123);
            this.btnGeneral.TabIndex = 0;
            this.btnGeneral.Text = "General";
            this.btnGeneral.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGeneral.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // btnSecretaria
            // 
            this.btnSecretaria.FlatAppearance.BorderSize = 0;
            this.btnSecretaria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecretaria.Image = global::Frm.Properties.Resources.team1;
            this.btnSecretaria.Location = new System.Drawing.Point(499, 53);
            this.btnSecretaria.Name = "btnSecretaria";
            this.btnSecretaria.Size = new System.Drawing.Size(115, 123);
            this.btnSecretaria.TabIndex = 3;
            this.btnSecretaria.Text = "Secretaria";
            this.btnSecretaria.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSecretaria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSecretaria.UseVisualStyleBackColor = true;
            this.btnSecretaria.Click += new System.EventHandler(this.btnSecretaria_Click);
            // 
            // AuxiliarLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(693, 259);
            this.Controls.Add(this.btnSecretaria);
            this.Controls.Add(this.btnGeneral);
            this.Controls.Add(this.btnLaboratorio);
            this.Controls.Add(this.btnAdministrador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AuxiliarLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AuxiliarLogin_FormClosed);
            this.Load += new System.EventHandler(this.AuxiliarLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdministrador;
        private System.Windows.Forms.Button btnLaboratorio;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.Button btnSecretaria;
    }
}