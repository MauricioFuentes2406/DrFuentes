namespace ClinicaPro.Reportes
{
    partial class frmCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente));
            this.chartCobroAnoActual = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalHombres = new System.Windows.Forms.TextBox();
            this.txtMujeres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExtrajeros = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartRangoEdades = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtClientesTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartCobroAnoActual)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRangoEdades)).BeginInit();
            this.SuspendLayout();
            // 
            // chartCobroAnoActual
            // 
            this.chartCobroAnoActual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartCobroAnoActual.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Personas por Ciudad";
            this.chartCobroAnoActual.Legends.Add(legend1);
            this.chartCobroAnoActual.Location = new System.Drawing.Point(0, 103);
            this.chartCobroAnoActual.Name = "chartCobroAnoActual";
            this.chartCobroAnoActual.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.MarkerSize = 7;
            series1.MarkerStep = 4;
            series1.Name = "Personas";
            series1.XValueMember = "Ciudad";
            series1.YValueMembers = "Cantidad";
            this.chartCobroAnoActual.Series.Add(series1);
            this.chartCobroAnoActual.Size = new System.Drawing.Size(777, 371);
            this.chartCobroAnoActual.TabIndex = 3;
            this.chartCobroAnoActual.Text = "chart2";            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total Hombres :";
            // 
            // txtTotalHombres
            // 
            this.txtTotalHombres.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTotalHombres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalHombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHombres.Location = new System.Drawing.Point(113, 34);
            this.txtTotalHombres.Name = "txtTotalHombres";
            this.txtTotalHombres.ReadOnly = true;
            this.txtTotalHombres.Size = new System.Drawing.Size(63, 13);
            this.txtTotalHombres.TabIndex = 0;            
            // 
            // txtMujeres
            // 
            this.txtMujeres.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMujeres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMujeres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMujeres.Location = new System.Drawing.Point(275, 34);
            this.txtMujeres.Name = "txtMujeres";
            this.txtMujeres.ReadOnly = true;
            this.txtMujeres.Size = new System.Drawing.Size(63, 13);
            this.txtMujeres.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total Mujeres :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total Extranjeros :";
            // 
            // txtExtrajeros
            // 
            this.txtExtrajeros.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtExtrajeros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExtrajeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtrajeros.Location = new System.Drawing.Point(677, 34);
            this.txtExtrajeros.Name = "txtExtrajeros";
            this.txtExtrajeros.ReadOnly = true;
            this.txtExtrajeros.Size = new System.Drawing.Size(63, 13);
            this.txtExtrajeros.TabIndex = 2;
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
            this.tabControl1.Size = new System.Drawing.Size(781, 503);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtClientesTotal);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.chartCobroAnoActual);
            this.tabPage1.Controls.Add(this.txtExtrajeros);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtTotalHombres);
            this.tabPage1.Controls.Add(this.txtMujeres);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(773, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;            
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartRangoEdades);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(773, 477);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edad";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartRangoEdades
            // 
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
            this.chartRangoEdades.ChartAreas.Add(chartArea2);
            this.chartRangoEdades.ImeMode = System.Windows.Forms.ImeMode.Disable;
            legend2.Name = "Legend1";
            legend2.Title = "Personas En Rango Edad";
            this.chartRangoEdades.Legends.Add(legend2);
            this.chartRangoEdades.Location = new System.Drawing.Point(-4, 0);
            this.chartRangoEdades.Name = "chartRangoEdades";
            this.chartRangoEdades.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chartRangoEdades.Series.Add(series2);
            this.chartRangoEdades.Size = new System.Drawing.Size(777, 393);
            this.chartRangoEdades.TabIndex = 0;
            this.chartRangoEdades.Text = "chart1";            
            // 
            // txtClientesTotal
            // 
            this.txtClientesTotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtClientesTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClientesTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientesTotal.Location = new System.Drawing.Point(486, 34);
            this.txtClientesTotal.Name = "txtClientesTotal";
            this.txtClientesTotal.ReadOnly = true;
            this.txtClientesTotal.Size = new System.Drawing.Size(63, 13);
            this.txtClientesTotal.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Total Clientes Registrados :";
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(784, 504);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCliente";
            this.Text = "Reporte cliente";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartCobroAnoActual)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRangoEdades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartCobroAnoActual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalHombres;
        private System.Windows.Forms.TextBox txtMujeres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExtrajeros;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRangoEdades;
        private System.Windows.Forms.TextBox txtClientesTotal;
        private System.Windows.Forms.Label label4;

    }
}