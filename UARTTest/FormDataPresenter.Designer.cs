namespace UARTTest
{
    partial class FormDataPresenter
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
            this.dataGridViewMeasures = new System.Windows.Forms.DataGridView();
            this.chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floatValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floatValueWithGain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMeasures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMeasures
            // 
            this.dataGridViewMeasures.AllowUserToAddRows = false;
            this.dataGridViewMeasures.AllowUserToDeleteRows = false;
            this.dataGridViewMeasures.AllowUserToResizeColumns = false;
            this.dataGridViewMeasures.AllowUserToResizeRows = false;
            this.dataGridViewMeasures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMeasures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndex,
            this.ColumnValue,
            this.floatValue,
            this.floatValueWithGain});
            this.dataGridViewMeasures.Location = new System.Drawing.Point(12, 318);
            this.dataGridViewMeasures.Name = "dataGridViewMeasures";
            this.dataGridViewMeasures.RowHeadersVisible = false;
            this.dataGridViewMeasures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewMeasures.Size = new System.Drawing.Size(425, 141);
            this.dataGridViewMeasures.TabIndex = 0;
            // 
            // chartData
            // 
            chartArea1.Name = "ChartArea1";
            this.chartData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartData.Legends.Add(legend1);
            this.chartData.Location = new System.Drawing.Point(12, 12);
            this.chartData.Name = "chartData";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "mV";
            this.chartData.Series.Add(series1);
            this.chartData.Size = new System.Drawing.Size(1087, 300);
            this.chartData.TabIndex = 1;
            this.chartData.Text = "chart1";
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.HeaderText = "Index";
            this.ColumnIndex.Name = "ColumnIndex";
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Raw Value";
            this.ColumnValue.Name = "ColumnValue";
            // 
            // floatValue
            // 
            this.floatValue.HeaderText = "Float Value";
            this.floatValue.Name = "floatValue";
            // 
            // floatValueWithGain
            // 
            this.floatValueWithGain.HeaderText = "Float Value * Gain";
            this.floatValueWithGain.Name = "floatValueWithGain";
            this.floatValueWithGain.Width = 120;
            // 
            // FormDataPresenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 517);
            this.Controls.Add(this.chartData);
            this.Controls.Add(this.dataGridViewMeasures);
            this.Name = "FormDataPresenter";
            this.Text = "FormDataPresenter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMeasures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMeasures;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn floatValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn floatValueWithGain;
    }
}