namespace ClinicaPro.Reportes
{
    partial class frmCitas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel3 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel4 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel5 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel6 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCitas));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClienteAsociado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSePresentaron = new System.Windows.Forms.TextBox();
            this.txtNoPresentaron = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chartCitaTotal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartCitaCAtegoria = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCitaTotal)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCitaCAtegoria)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 469);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtTotal);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtNoCliente);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtClienteAsociado);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtSePresentaron);
            this.tabPage1.Controls.Add(this.txtNoPresentaron);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chartCitaTotal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(775, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Total";
            this.tabPage1.UseVisualStyleBackColor = true;            
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(596, 6);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 13);
            this.txtTotal.TabIndex = 26;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(559, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 25;
            this.lblTotal.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Citas con Clientes No asociados :";
            // 
            // txtNoCliente
            // 
            this.txtNoCliente.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNoCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoCliente.Location = new System.Drawing.Point(456, 28);
            this.txtNoCliente.Name = "txtNoCliente";
            this.txtNoCliente.ReadOnly = true;
            this.txtNoCliente.Size = new System.Drawing.Size(100, 13);
            this.txtNoCliente.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Citas con Clientes asociados :";
            // 
            // txtClienteAsociado
            // 
            this.txtClienteAsociado.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtClienteAsociado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClienteAsociado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteAsociado.Location = new System.Drawing.Point(177, 28);
            this.txtClienteAsociado.Name = "txtClienteAsociado";
            this.txtClienteAsociado.ReadOnly = true;
            this.txtClienteAsociado.Size = new System.Drawing.Size(100, 13);
            this.txtClienteAsociado.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Se Presentaron a la Cita :";
            // 
            // txtSePresentaron
            // 
            this.txtSePresentaron.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSePresentaron.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSePresentaron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSePresentaron.Location = new System.Drawing.Point(177, 6);
            this.txtSePresentaron.Name = "txtSePresentaron";
            this.txtSePresentaron.ReadOnly = true;
            this.txtSePresentaron.Size = new System.Drawing.Size(100, 13);
            this.txtSePresentaron.TabIndex = 17;
            // 
            // txtNoPresentaron
            // 
            this.txtNoPresentaron.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNoPresentaron.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNoPresentaron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoPresentaron.Location = new System.Drawing.Point(456, 6);
            this.txtNoPresentaron.Name = "txtNoPresentaron";
            this.txtNoPresentaron.ReadOnly = true;
            this.txtNoPresentaron.Size = new System.Drawing.Size(100, 13);
            this.txtNoPresentaron.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = " NO Presentaron a la Cita :";
            // 
            // chartCitaTotal
            // 
            this.chartCitaTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartCitaTotal.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Total";
            this.chartCitaTotal.Legends.Add(legend1);
            this.chartCitaTotal.Location = new System.Drawing.Point(0, 58);
            this.chartCitaTotal.Name = "chartCitaTotal";
            this.chartCitaTotal.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.MarkerSize = 7;
            series1.MarkerStep = 4;
            series1.Name = "Citas";
            series1.XValueMember = "Ciudad";
            series1.YValueMembers = "Cantidad";
            this.chartCitaTotal.Series.Add(series1);
            this.chartCitaTotal.Size = new System.Drawing.Size(779, 397);
            this.chartCitaTotal.TabIndex = 16;
            this.chartCitaTotal.Text = "chart2";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartCitaCAtegoria);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(775, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Categorías";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartCitaCAtegoria
            // 
            this.chartCitaCAtegoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            customLabel1.Text = "1";
            customLabel2.Text = "2";
            customLabel3.Text = "3";
            customLabel4.Text = "4";
            chartArea2.AxisX.CustomLabels.Add(customLabel1);
            chartArea2.AxisX.CustomLabels.Add(customLabel2);
            chartArea2.AxisX.CustomLabels.Add(customLabel3);
            chartArea2.AxisX.CustomLabels.Add(customLabel4);
            chartArea2.AxisX.StripLines.Add(stripLine1);
            chartArea2.AxisX.Title = "relative";
            chartArea2.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            customLabel5.LabelMark = System.Windows.Forms.DataVisualization.Charting.LabelMarkStyle.SideMark;
            customLabel5.Text = "YText0";
            customLabel6.LabelMark = System.Windows.Forms.DataVisualization.Charting.LabelMarkStyle.LineSideMark;
            customLabel6.RowIndex = 1;
            customLabel6.Text = "YText2";
            chartArea2.AxisY.CustomLabels.Add(customLabel5);
            chartArea2.AxisY.CustomLabels.Add(customLabel6);
            chartArea2.AxisY.Title = "Titulo Y";
            chartArea2.Name = "ChartArea1";
            this.chartCitaCAtegoria.ChartAreas.Add(chartArea2);
            this.chartCitaCAtegoria.ImeMode = System.Windows.Forms.ImeMode.Disable;
            legend2.Name = "Legend1";
            legend2.Title = "Categorias Citas";
            this.chartCitaCAtegoria.Legends.Add(legend2);
            this.chartCitaCAtegoria.Location = new System.Drawing.Point(-4, 6);
            this.chartCitaCAtegoria.Name = "chartCitaCAtegoria";
            this.chartCitaCAtegoria.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.XValueMember = "EstadoCita";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.YValueMembers = "Cantidad";
            this.chartCitaCAtegoria.Series.Add(series2);
            this.chartCitaCAtegoria.Size = new System.Drawing.Size(737, 421);
            this.chartCitaCAtegoria.TabIndex = 2;
            this.chartCitaCAtegoria.Text = "chart1";
            // 
            // frmCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(779, 469);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCitas";
            this.Text = "Reporte Citas";
            this.Load += new System.EventHandler(this.frmCitas_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCitaTotal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCitaCAtegoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClienteAsociado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSePresentaron;
        private System.Windows.Forms.TextBox txtNoPresentaron;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCitaTotal;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCitaCAtegoria;

    }
}