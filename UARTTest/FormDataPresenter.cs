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
    public partial class FormDataPresenter : Form
    {
        public const float GAIN = 1.06f;

        public FormDataPresenter(byte[] data)
        {
            InitializeComponent();


            ByteArrayDecoderClass dec = new ByteArrayDecoderClass(data);
            int size = dec.Get2BytesAsInt() / 2;

            for (int i = 0; i < size; i++)
            {
                dataGridViewMeasures.Rows.Add();
                dataGridViewMeasures.Rows[i].Cells[0].Value = i + 1; // Index
                int value = dec.Get2BytesAsInt16();
                // Represent in mV
                float fValue = (value * 3300) / 32768;
                float fValueGain = fValue * GAIN;
                dataGridViewMeasures.Rows[i].Cells[1].Value = value.ToString(); // Raw
                dataGridViewMeasures.Rows[i].Cells[2].Value = fValue.ToString(); // float
                dataGridViewMeasures.Rows[i].Cells[3].Value = fValueGain.ToString(); // float with gain
                chartData.Series["mV"].Points.AddXY(i, fValueGain);
            }


            
        }
    }
}
