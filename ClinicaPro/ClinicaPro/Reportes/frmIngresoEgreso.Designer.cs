namespace ClinicaPro.Reportes
{
    partial class frmIngresoEgreso
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel3 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel4 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel5 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel6 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoEgreso));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chartCobroAnoActual = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.charIngresoEgresoTotal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartCategoriasGasto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCobroAnoActual)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.charIngresoEgresoTotal)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategoriasGasto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(695, 488);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chartCobroAnoActual);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(687, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Año Actual";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chartCobroAnoActual
            // 
            this.chartCobroAnoActual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.Title = "Colones";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chartCobroAnoActual.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Año Actual";
            this.chartCobroAnoActual.Legends.Add(legend1);
            this.chartCobroAnoActual.Location = new System.Drawing.Point(3, 3);
            this.chartCobroAnoActual.Name = "chartCobroAnoActual";
            this.chartCobroAnoActual.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Lime;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.DarkGreen;
            series1.Legend = "Legend1";
            series1.MarkerSize = 7;
            series1.MarkerStep = 4;
            series1.Name = "Ingresos";
            series1.XValueMember = "Ingresos";
            series1.YValueMembers = "Cantidad";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.LabelForeColor = System.Drawing.Color.Crimson;
            series2.Legend = "Legend1";
            series2.Name = "Gastos";
            this.chartCobroAnoActual.Series.Add(series1);
            this.chartCobroAnoActual.Series.Add(series2);
            this.chartCobroAnoActual.Size = new System.Drawing.Size(684, 449);
            this.chartCobroAnoActual.TabIndex = 4;
            this.chartCobroAnoActual.Text = "chart2";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.charIngresoEgresoTotal);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(687, 462);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Todo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // charIngresoEgresoTotal
            // 
            this.charIngresoEgresoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.Title = "Colones";
            chartArea2.Name = "ChartArea1";
            this.charIngresoEgresoTotal.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            legend2.Title = "Total";
            this.charIngresoEgresoTotal.Legends.Add(legend2);
            this.charIngresoEgresoTotal.Location = new System.Drawing.Point(3, 3);
            this.charIngresoEgresoTotal.Name = "charIngresoEgresoTotal";
            this.charIngresoEgresoTotal.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Lime;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.LabelForeColor = System.Drawing.Color.DarkGreen;
            series3.Legend = "Legend1";
            series3.MarkerSize = 7;
            series3.MarkerStep = 4;
            series3.Name = "Ingresos";
            series3.XValueMember = "Ingresos";
            series3.YValueMembers = "Cantidad";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.IsValueShownAsLabel = true;
            series4.LabelForeColor = System.Drawing.Color.Crimson;
            series4.Legend = "Legend1";
            series4.Name = "Gastos";
            this.charIngresoEgresoTotal.Series.Add(series3);
            this.charIngresoEgresoTotal.Series.Add(series4);
            this.charIngresoEgresoTotal.Size = new System.Drawing.Size(684, 449);
            this.charIngresoEgresoTotal.TabIndex = 5;
            this.charIngresoEgresoTotal.Text = "chart2";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartCategoriasGasto);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(687, 462);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Categorías";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chartCategoriasGasto
            // 
            customLabel1.Text = "1";
            customLabel2.Text = "2";
            customLabel3.Text = "3";
            customLabel4.Text = "4";
            chartArea3.AxisX.CustomLabels.Add(customLabel1);
            chartArea3.AxisX.CustomLabels.Add(customLabel2);
            chartArea3.AxisX.CustomLabels.Add(customLabel3);
            chartArea3.AxisX.CustomLabels.Add(customLabel4);
            chartArea3.AxisX.StripLines.Add(stripLine1);
            chartArea3.AxisX.Title = "relative";
            chartArea3.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            customLabel5.LabelMark = System.Windows.Forms.DataVisualization.Charting.LabelMarkStyle.SideMark;
            customLabel5.Text = "YText0";
            customLabel6.LabelMark = System.Windows.Forms.DataVisualization.Charting.LabelMarkStyle.LineSideMark;
            customLabel6.RowIndex = 1;
            customLabel6.Text = "YText2";
            chartArea3.AxisY.CustomLabels.Add(customLabel5);
            chartArea3.AxisY.CustomLabels.Add(customLabel6);
            chartArea3.AxisY.Title = "Titulo Y";
            chartArea3.Name = "ChartArea1";
            this.chartCategoriasGasto.ChartAreas.Add(chartArea3);
            this.chartCategoriasGasto.ImeMode = System.Windows.Forms.ImeMode.Disable;
            legend3.Name = "Legend1";
            legend3.Title = "Uso Categorias Gasto";
            this.chartCategoriasGasto.Legends.Add(legend3);
            this.chartCategoriasGasto.Location = new System.Drawing.Point(-4, 0);
            this.chartCategoriasGasto.Name = "chartCategoriasGasto";
            this.chartCategoriasGasto.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.IsValueShownAsLabel = true;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            series5.XValueMember = "Categoria";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series5.YValueMembers = "Cantidad";
            this.chartCategoriasGasto.Series.Add(series5);
            this.chartCategoriasGasto.Size = new System.Drawing.Size(691, 462);
            this.chartCategoriasGasto.TabIndex = 1;
            this.chartCategoriasGasto.Text = "chart1";
            // 
            // frmIngresoEgreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(695, 487);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIngresoEgreso";
            this.Text = "Ingreso y Egresos";
            this.Load += new System.EventHandler(this.frmIngresoEgreso_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCobroAnoActual)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.charIngresoEgresoTotal)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCategoriasGasto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCobroAnoActual;
        private System.Windows.Forms.DataVisualization.Charting.Chart charIngresoEgresoTotal;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategoriasGasto;
    }
}