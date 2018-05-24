namespace UARTTest
{
    partial class FormDataPresenter2
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartCH0 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewCHDual = new System.Windows.Forms.DataGridView();
            this.ColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floatValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floatValueWithGain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCH0 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCH1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.textBoxGainCH0 = new System.Windows.Forms.TextBox();
            this.chartCH1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCHDUAL = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxGainCH1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartCH0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCHDual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCH0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCHDUAL)).BeginInit();
            this.SuspendLayout();
            // 
            // chartCH0
            // 
            chartArea1.Name = "ChartArea1";
            this.chartCH0.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartCH0.Legends.Add(legend1);
            this.chartCH0.Location = new System.Drawing.Point(16, 319);
            this.chartCH0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartCH0.Name = "chartCH0";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "mV";
            this.chartCH0.Series.Add(series1);
            this.chartCH0.Size = new System.Drawing.Size(1056, 286);
            this.chartCH0.TabIndex = 1;
            this.chartCH0.Text = "chart2";
            // 
            // dataGridViewCHDual
            // 
            this.dataGridViewCHDual.AllowUserToAddRows = false;
            this.dataGridViewCHDual.AllowUserToDeleteRows = false;
            this.dataGridViewCHDual.AllowUserToResizeColumns = false;
            this.dataGridViewCHDual.AllowUserToResizeRows = false;
            this.dataGridViewCHDual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCHDual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndex,
            this.ColumnValue,
            this.floatValue,
            this.floatValueWithGain});
            this.dataGridViewCHDual.Location = new System.Drawing.Point(1080, 15);
            this.dataGridViewCHDual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewCHDual.Name = "dataGridViewCHDual";
            this.dataGridViewCHDual.RowHeadersVisible = false;
            this.dataGridViewCHDual.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCHDual.Size = new System.Drawing.Size(463, 286);
            this.dataGridViewCHDual.TabIndex = 4;
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.HeaderText = "Index";
            this.ColumnIndex.Name = "ColumnIndex";
            this.ColumnIndex.Width = 60;
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Raw Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 80;
            // 
            // floatValue
            // 
            this.floatValue.HeaderText = "Float Value";
            this.floatValue.Name = "floatValue";
            this.floatValue.Width = 80;
            // 
            // floatValueWithGain
            // 
            this.floatValueWithGain.HeaderText = "Float Value * Gain";
            this.floatValueWithGain.Name = "floatValueWithGain";
            this.floatValueWithGain.Width = 120;
            // 
            // dataGridViewCH0
            // 
            this.dataGridViewCH0.AllowUserToAddRows = false;
            this.dataGridViewCH0.AllowUserToDeleteRows = false;
            this.dataGridViewCH0.AllowUserToResizeColumns = false;
            this.dataGridViewCH0.AllowUserToResizeRows = false;
            this.dataGridViewCH0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCH0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewCH0.Location = new System.Drawing.Point(1080, 319);
            this.dataGridViewCH0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewCH0.Name = "dataGridViewCH0";
            this.dataGridViewCH0.RowHeadersVisible = false;
            this.dataGridViewCH0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCH0.Size = new System.Drawing.Size(463, 286);
            this.dataGridViewCH0.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Index";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Raw Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Float Value";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Float Value * Gain";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewCH1
            // 
            this.dataGridViewCH1.AllowUserToAddRows = false;
            this.dataGridViewCH1.AllowUserToDeleteRows = false;
            this.dataGridViewCH1.AllowUserToResizeColumns = false;
            this.dataGridViewCH1.AllowUserToResizeRows = false;
            this.dataGridViewCH1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCH1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dataGridViewCH1.Location = new System.Drawing.Point(1080, 612);
            this.dataGridViewCH1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewCH1.Name = "dataGridViewCH1";
            this.dataGridViewCH1.RowHeadersVisible = false;
            this.dataGridViewCH1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCH1.Size = new System.Drawing.Size(463, 286);
            this.dataGridViewCH1.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Index";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Raw Value";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Float Value";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Float Value * Gain";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(17, 906);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(100, 28);
            this.buttonCalculate.TabIndex = 8;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // textBoxGainCH0
            // 
            this.textBoxGainCH0.Location = new System.Drawing.Point(223, 911);
            this.textBoxGainCH0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGainCH0.Name = "textBoxGainCH0";
            this.textBoxGainCH0.Size = new System.Drawing.Size(132, 22);
            this.textBoxGainCH0.TabIndex = 9;
            // 
            // chartCH1
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCH1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCH1.Legends.Add(legend2);
            this.chartCH1.Location = new System.Drawing.Point(16, 617);
            this.chartCH1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartCH1.Name = "chartCH1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "mV";
            this.chartCH1.Series.Add(series2);
            this.chartCH1.Size = new System.Drawing.Size(1056, 286);
            this.chartCH1.TabIndex = 10;
            this.chartCH1.Text = "chart2";
            // 
            // chartCHDUAL
            // 
            chartArea3.Name = "ChartArea1";
            this.chartCHDUAL.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartCHDUAL.Legends.Add(legend3);
            this.chartCHDUAL.Location = new System.Drawing.Point(16, 15);
            this.chartCHDUAL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartCHDUAL.Name = "chartCHDUAL";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "mV";
            this.chartCHDUAL.Series.Add(series3);
            this.chartCHDUAL.Size = new System.Drawing.Size(1056, 286);
            this.chartCHDUAL.TabIndex = 11;
            this.chartCHDUAL.Text = "chart2";
            // 
            // textBoxGainCH1
            // 
            this.textBoxGainCH1.Location = new System.Drawing.Point(465, 911);
            this.textBoxGainCH1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxGainCH1.Name = "textBoxGainCH1";
            this.textBoxGainCH1.Size = new System.Drawing.Size(132, 22);
            this.textBoxGainCH1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 912);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "CH0 gain";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 912);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "CH1 gain";
            // 
            // FormDataPresenter2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1580, 603);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxGainCH1);
            this.Controls.Add(this.chartCHDUAL);
            this.Controls.Add(this.chartCH1);
            this.Controls.Add(this.textBoxGainCH0);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.dataGridViewCH1);
            this.Controls.Add(this.dataGridViewCH0);
            this.Controls.Add(this.dataGridViewCHDual);
            this.Controls.Add(this.chartCH0);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormDataPresenter2";
            this.Text = "FormDataPresenter2";
            ((System.ComponentModel.ISupportInitialize)(this.chartCH0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCHDual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCH0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCHDUAL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCH0;
        private System.Windows.Forms.DataGridView dataGridViewCHDual;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn floatValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn floatValueWithGain;
        private System.Windows.Forms.DataGridView dataGridViewCH0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dataGridViewCH1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.TextBox textBoxGainCH0;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCH1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCHDUAL;
        private System.Windows.Forms.TextBox textBoxGainCH1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}