namespace Frm.IngresoGastos
{
    partial class frmVentanaInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentanaInicial));
            this.chkConsultasDelmes = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cbFuenteIngreso = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.txtIngresos = new System.Windows.Forms.TextBox();
            this.txtGastos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGastos = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnListaMovimientos = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgUltimos10 = new System.Windows.Forms.DataGridView();
            this.btnCategoriasGasto = new System.Windows.Forms.Button();
            this.btnCategoriaIngreso = new System.Windows.Forms.Button();
            this.btnFuenteIngreso = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUltimos10)).BeginInit();
            this.SuspendLayout();
            // 
            // chkConsultasDelmes
            // 
            this.chkConsultasDelmes.AutoSize = true;
            this.chkConsultasDelmes.Location = new System.Drawing.Point(309, 54);
            this.chkConsultasDelmes.Name = "chkConsultasDelmes";
            this.chkConsultasDelmes.Size = new System.Drawing.Size(155, 17);
            this.chkConsultasDelmes.TabIndex = 0;
            this.chkConsultasDelmes.Text = "Ingresos Consultas del Mes";
            this.chkConsultasDelmes.UseVisualStyleBackColor = true;
            this.chkConsultasDelmes.CheckedChanged += new System.EventHandler(this.chkConsultasDelmes_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbFuenteIngreso);
            this.panel1.Location = new System.Drawing.Point(-7, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 54);
            this.panel1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "FuenteIngreso";
            // 
            // cbFuenteIngreso
            // 
            this.cbFuenteIngreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuenteIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFuenteIngreso.FormattingEnabled = true;
            this.cbFuenteIngreso.Items.AddRange(new object[] {
            "Todos"});
            this.cbFuenteIngreso.Location = new System.Drawing.Point(171, 17);
            this.cbFuenteIngreso.Name = "cbFuenteIngreso";
            this.cbFuenteIngreso.Size = new System.Drawing.Size(175, 21);
            this.cbFuenteIngreso.TabIndex = 0;
            this.cbFuenteIngreso.SelectionChangeCommitted += new System.EventHandler(this.cbFuenteIngreso_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Balance Mensual";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(25, 89);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(34, 13);
            this.labelFecha.TabIndex = 3;
            this.labelFecha.Text = "fecha";
            // 
            // txtIngresos
            // 
            this.txtIngresos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngresos.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtIngresos.Location = new System.Drawing.Point(124, 12);
            this.txtIngresos.Name = "txtIngresos";
            this.txtIngresos.ReadOnly = true;
            this.txtIngresos.Size = new System.Drawing.Size(87, 14);
            this.txtIngresos.TabIndex = 4;
            this.txtIngresos.Text = "0";
            this.txtIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGastos
            // 
            this.txtGastos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtGastos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastos.ForeColor = System.Drawing.Color.Maroon;
            this.txtGastos.Location = new System.Drawing.Point(124, 41);
            this.txtGastos.Name = "txtGastos";
            this.txtGastos.ReadOnly = true;
            this.txtGastos.Size = new System.Drawing.Size(87, 13);
            this.txtGastos.TabIndex = 5;
            this.txtGastos.Text = "0";
            this.txtGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Saldo :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ingresos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Gastos";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSaldo.Location = new System.Drawing.Point(124, 76);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(87, 14);
            this.txtSaldo.TabIndex = 10;
            this.txtSaldo.Text = "0";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtSaldo);
            this.panel2.Controls.Add(this.txtIngresos);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtGastos);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(122, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 142);
            this.panel2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "_______________";
            // 
            // btnGastos
            // 
            this.btnGastos.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGastos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGastos.Image = global::Frm.Properties.Resources.minus_1;
            this.btnGastos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGastos.Location = new System.Drawing.Point(309, 262);
            this.btnGastos.Name = "btnGastos";
            this.btnGastos.Size = new System.Drawing.Size(92, 38);
            this.btnGastos.TabIndex = 13;
            this.btnGastos.Text = "Gastos";
            this.btnGastos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGastos.UseVisualStyleBackColor = true;
            this.btnGastos.Click += new System.EventHandler(this.btnGastos_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Image = global::Frm.Properties.Resources.add_1;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(122, 262);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 38);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Ingresos";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnListaMovimientos);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.dgUltimos10);
            this.panel3.Location = new System.Drawing.Point(468, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(484, 447);
            this.panel3.TabIndex = 14;
            // 
            // btnListaMovimientos
            // 
            this.btnListaMovimientos.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnListaMovimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaMovimientos.Image = global::Frm.Properties.Resources.diagram_2;
            this.btnListaMovimientos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListaMovimientos.Location = new System.Drawing.Point(389, 3);
            this.btnListaMovimientos.Name = "btnListaMovimientos";
            this.btnListaMovimientos.Size = new System.Drawing.Size(92, 38);
            this.btnListaMovimientos.TabIndex = 15;
            this.btnListaMovimientos.Text = "todos";
            this.btnListaMovimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListaMovimientos.UseVisualStyleBackColor = true;
            this.btnListaMovimientos.Click += new System.EventHandler(this.btnListaMovimientos_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "UltimosRegistros";
            // 
            // dgUltimos10
            // 
            this.dgUltimos10.AllowUserToAddRows = false;
            this.dgUltimos10.AllowUserToDeleteRows = false;
            this.dgUltimos10.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgUltimos10.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgUltimos10.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgUltimos10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUltimos10.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgUltimos10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgUltimos10.EnableHeadersVisualStyles = false;
            this.dgUltimos10.Location = new System.Drawing.Point(0, 47);
            this.dgUltimos10.Name = "dgUltimos10";
            this.dgUltimos10.ReadOnly = true;
            this.dgUltimos10.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgUltimos10.RowHeadersVisible = false;
            this.dgUltimos10.RowTemplate.Height = 44;
            this.dgUltimos10.RowTemplate.ReadOnly = true;
            this.dgUltimos10.Size = new System.Drawing.Size(484, 400);
            this.dgUltimos10.TabIndex = 0;
            // 
            // btnCategoriasGasto
            // 
            this.btnCategoriasGasto.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCategoriasGasto.FlatAppearance.BorderSize = 0;
            this.btnCategoriasGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoriasGasto.Image = global::Frm.Properties.Resources.diagramGasto;
            this.btnCategoriasGasto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCategoriasGasto.Location = new System.Drawing.Point(392, 357);
            this.btnCategoriasGasto.Name = "btnCategoriasGasto";
            this.btnCategoriasGasto.Size = new System.Drawing.Size(72, 88);
            this.btnCategoriasGasto.TabIndex = 15;
            this.btnCategoriasGasto.Text = "Categorias Gastos";
            this.btnCategoriasGasto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategoriasGasto.UseVisualStyleBackColor = true;
            this.btnCategoriasGasto.Click += new System.EventHandler(this.btnCategoriasGasto_Click);
            // 
            // btnCategoriaIngreso
            // 
            this.btnCategoriaIngreso.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCategoriaIngreso.FlatAppearance.BorderSize = 0;
            this.btnCategoriaIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoriaIngreso.Image = global::Frm.Properties.Resources.diagramaIngreso;
            this.btnCategoriaIngreso.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCategoriaIngreso.Location = new System.Drawing.Point(323, 357);
            this.btnCategoriaIngreso.Name = "btnCategoriaIngreso";
            this.btnCategoriaIngreso.Size = new System.Drawing.Size(72, 88);
            this.btnCategoriaIngreso.TabIndex = 16;
            this.btnCategoriaIngreso.Text = "Categorias Ingreso";
            this.btnCategoriaIngreso.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategoriaIngreso.UseVisualStyleBackColor = true;
            this.btnCategoriaIngreso.Click += new System.EventHandler(this.btnCategoriaIngreso_Click);
            // 
            // btnFuenteIngreso
            // 
            this.btnFuenteIngreso.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFuenteIngreso.FlatAppearance.BorderSize = 0;
            this.btnFuenteIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuenteIngreso.Image = global::Frm.Properties.Resources.diagramaFuente;
            this.btnFuenteIngreso.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFuenteIngreso.Location = new System.Drawing.Point(259, 358);
            this.btnFuenteIngreso.Name = "btnFuenteIngreso";
            this.btnFuenteIngreso.Size = new System.Drawing.Size(72, 88);
            this.btnFuenteIngreso.TabIndex = 17;
            this.btnFuenteIngreso.Text = "Fuente Ingreso";
            this.btnFuenteIngreso.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFuenteIngreso.UseVisualStyleBackColor = true;
            this.btnFuenteIngreso.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmVentanaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(952, 446);
            this.Controls.Add(this.btnFuenteIngreso);
            this.Controls.Add(this.btnCategoriaIngreso);
            this.Controls.Add(this.btnCategoriasGasto);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnGastos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkConsultasDelmes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmVentanaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Gastos e Ingresos";
            this.Load += new System.EventHandler(this.frmVentanaInicial_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUltimos10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkConsultasDelmes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbFuenteIngreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.TextBox txtIngresos;
        private System.Windows.Forms.TextBox txtGastos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGastos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgUltimos10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnListaMovimientos;
        private System.Windows.Forms.Button btnCategoriasGasto;
        private System.Windows.Forms.Button btnCategoriaIngreso;
        private System.Windows.Forms.Button btnFuenteIngreso;
    }
}