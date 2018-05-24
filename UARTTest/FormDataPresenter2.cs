using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UARTTest
{
    public partial class FormDataPresenter2 : Form
    {
        
        int[] values;

        public FormDataPresenter2(byte[] data)
        {
            InitializeComponent();

            ByteArrayDecoderClass dec = new ByteArrayDecoderClass(data);
            int size = dec.Get2BytesAsInt() / 2;
            values = new int[size];
            //int value = dec.Get2BytesAsInt16();

            for (int i = 0; i < size; i++)
            {
                values[i] = dec.Get2BytesAsInt16();
            }

            textBoxGainCH0.Text = "1"; // Default value
            textBoxGainCH1.Text = "1"; // Default value

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            float gainCH0, gainCH1;
            try
            {
                string fvalueCh0 = textBoxGainCH0.Text.Replace('.', ',');
                string fvalueCh1 = textBoxGainCH1.Text.Replace('.', ',');
                gainCH0 = float.Parse(fvalueCh0);
                gainCH1 = float.Parse(fvalueCh1);
            }
            catch (Exception)
            {
                MessageBox.Show("Enter valid float number for gain");
                return;
            }

            // First clear all graphs and dataGrids
            dataGridViewCHDual.DataSource = null;
            dataGridViewCHDual.Rows.Clear();
            dataGridViewCH0.DataSource = null;
            dataGridViewCH0.Rows.Clear();
            dataGridViewCH1.DataSource = null;
            dataGridViewCH1.Rows.Clear();
            chartCHDUAL.Series["mV"].Points.Clear();
            chartCH0.Series["mV"].Points.Clear();
            chartCH1.Series["mV"].Points.Clear();

            //dataGridView.DataSource = this.GetNewValues();
            // Calculate dual channel graph and fill its dataGrid values
            for (int i = 0; i < values.Length; i++)
            {
                dataGridViewCHDual.Rows.Add();
                dataGridViewCHDual.Rows[i].Cells[0].Value = i + 1; // Index
                int tmpInt = values[i];
                // Represent in mV
                float fValue = (tmpInt * 3300) / 32768;
                float fValueGain = fValue;
                dataGridViewCHDual.Rows[i].Cells[1].Value = values[i].ToString(); // Raw
                dataGridViewCHDual.Rows[i].Cells[2].Value = fValue.ToString(); // float
                dataGridViewCHDual.Rows[i].Cells[3].Value = fValueGain.ToString(); // float with gain
                chartCHDUAL.Series["mV"].Points.AddXY(i, fValueGain);
            }

            // Calculate CH0 graph and fill its dataGrid values
            for (int i = 0; i < values.Length; i+=2)
            {
                dataGridViewCH0.Rows.Add();
                dataGridViewCH0.Rows[i/2].Cells[0].Value = i + 1; // Index
                int tmpInt = values[i];
                // Represent in mV
                float fValue = (tmpInt * 3300) / 32768;
                float fValueGain = fValue * gainCH0;
                dataGridViewCH0.Rows[i/2].Cells[1].Value = values[i].ToString(); // Raw
                dataGridViewCH0.Rows[i/2].Cells[2].Value = fValue.ToString(); // float
                dataGridViewCH0.Rows[i/2].Cells[3].Value = fValueGain.ToString(); // float with gain
                chartCH0.Series["mV"].Points.AddXY(i/2, fValueGain);
            }

            // Calculate CH1 graph and fill its dataGrid values
            for (int i = 1; i < values.Length; i += 2)
            {
                int tmpIndex = (i - 1) / 2;
                dataGridViewCH1.Rows.Add();
                dataGridViewCH1.Rows[tmpIndex].Cells[0].Value = i + 1; // Index
                int tmpInt = values[i];
                // Represent in mV
                float fValue = (tmpInt * 3300) / 32768;
                float fValueGain = fValue * gainCH1;
                dataGridViewCH1.Rows[tmpIndex].Cells[1].Value = values[i].ToString(); // Raw
                dataGridViewCH1.Rows[tmpIndex].Cells[2].Value = fValue.ToString(); // float
                dataGridViewCH1.Rows[tmpIndex].Cells[3].Value = fValueGain.ToString(); // float with gain
                chartCH1.Series["mV"].Points.AddXY(i, fValueGain);
            }
        }
    }
}
