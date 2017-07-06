namespace ClinicaPro
{
    partial class Administrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrador));
            this.btnCrearRespaldo = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrearRespaldo
            // 
            this.btnCrearRespaldo.FlatAppearance.BorderSize = 0;
            this.btnCrearRespaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearRespaldo.Image = global::ClinicaPro.Properties.Resources.database_9;
            this.btnCrearRespaldo.Location = new System.Drawing.Point(331, 110);
            this.btnCrearRespaldo.Name = "btnCrearRespaldo";
            this.btnCrearRespaldo.Size = new System.Drawing.Size(115, 123);
            this.btnCrearRespaldo.TabIndex = 4;
            this.btnCrearRespaldo.Text = "Crear Respaldo";
            this.btnCrearRespaldo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrearRespaldo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCrearRespaldo.UseVisualStyleBackColor = true;
            this.btnCrearRespaldo.Click += new System.EventHandler(this.btnCrearBackUp_Click);
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = global::ClinicaPro.Properties.Resources.user_49;
            this.button7.Location = new System.Drawing.Point(34, 110);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(115, 123);
            this.button7.TabIndex = 3;
            this.button7.Text = "Usuarios";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(624, 357);
            this.Controls.Add(this.btnCrearRespaldo);
            this.Controls.Add(this.button7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Administrador";
            this.Text = "Administrador";
            this.Load += new System.EventHandler(this.Administrador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnCrearRespaldo;
    }
}