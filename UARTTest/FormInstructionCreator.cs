using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UARTTest
{
    public partial class FormInstructionCreator : Form
    {
        CommandFormerClass com;
        byte deviceAddr = 0x31;
        byte startSeq = 254;
        SerialPort serial;


        public FormInstructionCreator(SerialPort ser)
        {
            InitializeComponent();
            com = new CommandFormerClass(startSeq, deviceAddr);
            serial = ser;
            //comboBoxSerialPorts.Items.AddRange(SerialPort.GetPortNames());
            //serial.ReadTimeout = 500; // 500ms
            //serial.WriteTimeout = 500; // 500ms



        }

        private void buttonResetInstructions_Click(object sender, EventArgs e)
        {
            com = new CommandFormerClass(startSeq, deviceAddr);
            textBoxInstructionPool.Text = "";
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            var data = com.GetFinalCommandList();
            try
            {
                serial.Write(data, 0, data.Length);
            }
            catch (Exception)
            {
                MessageBox.Show("Open COM port first!");

            }
            // Reset everything
            buttonResetInstructions_Click(this, EventArgs.Empty);
        }

        
        #region ACTION BUTTONS
        private void buttonDataRecTask_Click(object sender, EventArgs e)
        {
            byte ch;
            byte op;
            uint prescaler;
            uint targetPoints;

            // Parse input fields
            try
            {
                ch = InputValidatorHelperClass.GetChModeFromComboBox(comboBoxDataRecTaskCh);
                op = InputValidatorHelperClass.GetOperationModeFromComboBox(comboBoxDataRecTaskOpMode);
                prescaler = Convert.ToUInt32(textBoxPrescaler.Text);
                targetPoints = Convert.ToUInt32(textBoxTargetPoints.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Values for Data Recorder!");
                return;
            }

            // Values are valid, add command to the list
            com.AppendDataRecorderTask(ch, op, prescaler, targetPoints, DateTime.Now);

            // Append to display
            textBoxInstructionPool.Text += "DataRecTask(" + comboBoxDataRecTaskCh.Text + ", " + comboBoxDataRecTaskOpMode.Text + " ," + prescaler +
                ", " + targetPoints + ") \r\n";

        }

        private void buttonWaitDataRecToFinish_Click(object sender, EventArgs e)
        {
            com.AppendWaitForDataRecorderToFinish();
            textBoxInstructionPool.Text += "Wair for data recorder to finish\r\n";
        }

        private void buttonWaitForMs_Click(object sender, EventArgs e)
        {
            UInt32 ms;
            try
            {
                ms = Convert.ToUInt32(textBoxWaitInMiliseconds.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid number for delay!");
                return;
            }

            com.AppendWaitForMs(ms);
            textBoxInstructionPool.Text += "Delay in ms: " + ms.ToString() + "\r\n";
        }

        private void buttonDataRecFinish_Click(object sender, EventArgs e)
        {
            com.AppendDataRecFinish();
            textBoxInstructionPool.Text += "Data recorder finish (continious mode)\r\n";
        }

        private void buttonWaitForValueRising_Click(object sender, EventArgs e)
        {
            byte ch;
            UInt16 latency;
            float value;

            try
            {
                ch = InputValidatorHelperClass.GetChModeFromComboBox(comboBoxWaitForValueRising);
                latency = Convert.ToUInt16(textBoxWaitForValueRisingLatency.Text);
                value = float.Parse(textBoxWaitForValueRisingValue.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid values!");
                return;
            }


            com.AppendWaitForValueRising(ch, latency, value);
            textBoxInstructionPool.Text += "WaitForValueRising(" + comboBoxWaitForValueRising.Text + ", " + latency +
                ", " + textBoxWaitForValueRisingValue.Text + ")\r\n";

        }

        private void buttonWaitForValueFalling_Click(object sender, EventArgs e)
        {
            byte ch;
            UInt16 latency;
            float value;

            try
            {
                ch = InputValidatorHelperClass.GetChModeFromComboBox(comboBoxWaitForValueFalling);
                latency = Convert.ToUInt16(textBoxWaitForValueFallingLatency.Text);
                value = float.Parse(textBoxWaitForValueFallingValue.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid values!");
                return;
            }


            com.AppendWaitForValueFalling(ch, latency, value);
            textBoxInstructionPool.Text += "WaitForValueFalling(" + comboBoxWaitForValueFalling.Text + ", " + latency +
                ", " + textBoxWaitForValueFallingValue.Text + ")\r\n";
        }

        private void buttonSetCriticalLow_Click(object sender, EventArgs e)
        {
            byte ch;
            float value;

            try
            {
                ch = InputValidatorHelperClass.GetChModeFromComboBox(comboBoxSetCritLow);
                value = float.Parse(textBoxSetCriticalLow.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid values!");
                return;
            }


            com.AppendSetCriticalLow(value, ch);
            textBoxInstructionPool.Text += "SetCriticalLow(" + textBoxSetCriticalLow.Text + ", " + comboBoxSetCritLow.Text + ")\r\n";
        }

        private void buttonSetCriticalHigh_Click(object sender, EventArgs e)
        {
            byte ch;
            float value;

            try
            {
                ch = InputValidatorHelperClass.GetChModeFromComboBox(comboBoxSetCritHigh);
                value = float.Parse(textBoxSetCriticalHigh.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid values!");
                return;
            }


            com.AppendSetCriticalHigh(value, ch);
            textBoxInstructionPool.Text += "SetCriticalHigh(" + textBoxSetCriticalHigh.Text + ", " + comboBoxSetCritHigh.Text + ")\r\n";
        }


        private void buttonLedOn_Click(object sender, EventArgs e)
        {
            byte ledNum;

            try
            {
                ledNum = Convert.ToByte(textBoxLedOn.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid value!");
                return;
            }
            com.AppendLedOn(ledNum);
            textBoxInstructionPool.Text += "LedOn(" + ledNum + ")\r\n";
        }

        private void buttonLedOff_Click(object sender, EventArgs e)
        {
            byte ledNum;

            try
            {
                ledNum = Convert.ToByte(textBoxLedOff.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid value!");
                return;
            }
            com.AppendLedOff(ledNum);
            textBoxInstructionPool.Text += "LedOff(" + ledNum + ")\r\n";
        }


        #endregion

        private void buttonPinSetHigh_Click(object sender, EventArgs e)
        {
            byte pinNum;

            try
            {
                pinNum = Convert.ToByte(textBoxPinSetHigh.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid value!");
                return;
            }
            com.AppendPinSetHigh(pinNum);
            textBoxInstructionPool.Text += "PinSetHigh(" + pinNum + ")\r\n";
        }

        private void buttonPinSetLow_Click(object sender, EventArgs e)
        {
            byte pinNum;

            try
            {
                pinNum = Convert.ToByte(textBoxPinSetLow.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid value!");
                return;
            }
            com.AppendPinSetLow(pinNum);
            textBoxInstructionPool.Text += "PinSetLow(" + pinNum + ")\r\n";
        }

        private void buttonChargerOn_Click(object sender, EventArgs e)
        {
            com.AppendChargerOn();
            textBoxInstructionPool.Text += "ChargerOn\r\n";
        }

        private void buttonChargerOff_Click(object sender, EventArgs e)
        {
            com.AppendChargerOff();
            textBoxInstructionPool.Text += "ChargerOff\r\n";
        }

        private void buttonDischarger100AOn_Click(object sender, EventArgs e)
        {
            com.AppendDischarger100AOn();
            textBoxInstructionPool.Text += "Discharger100AOn\r\n";
        }

        private void buttonDischarger100AOffS1_Click(object sender, EventArgs e)
        {
            com.AppendDischarger100AOffS1();
            textBoxInstructionPool.Text += "Discharger100AOff S1\r\n";
        }

        private void buttonDischarger100AOffS2_Click(object sender, EventArgs e)
        {
            com.AppendDischarger100AOffS2();
            textBoxInstructionPool.Text += "Discharger100AOff S2\r\n";
        }

        private void buttonDischarger10AOn_Click(object sender, EventArgs e)
        {
            com.AppendDischarger10AOn();
            textBoxInstructionPool.Text += "Discharger10AOn\r\n";
        }

        private void buttonDischarger10AOffS1_Click(object sender, EventArgs e)
        {
            com.AppendDischarger10AOffS1();
            textBoxInstructionPool.Text += "Discharger10AOff S1\r\n";
        }

        private void buttonDischarger10AOffS2_Click(object sender, EventArgs e)
        {
            com.AppendDischarger10AOffS2();
            textBoxInstructionPool.Text += "Discharger10AOff S2\r\n";
        }

        private void buttonFanoxOn_Click(object sender, EventArgs e)
        {
            com.AppendFanoxOn();
            textBoxInstructionPool.Text += "FanoxOn\r\n";
        }

        private void buttonFanoxOff_Click(object sender, EventArgs e)
        {
            com.AppendFanoxOff();
            textBoxInstructionPool.Text += "FanoxOff\r\n";
        }

        private void buttonResOn_Click(object sender, EventArgs e)
        {
            com.AppendResOn();
            textBoxInstructionPool.Text += "ResOn\r\n";
        }

        private void buttonResOff_Click(object sender, EventArgs e)
        {
            com.AppendResOff();
            textBoxInstructionPool.Text += "ResOff\r\n";
        }

        private void buttonCompositeFinishDisch10A_Click(object sender, EventArgs e)
        {
            UInt32 ms;
            try
            {
                ms = Convert.ToUInt32(textBoxCompositeMsDelay.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid number for delay!");
                return;
            }

            com.AppendDischarger10AOffS1();
            textBoxInstructionPool.Text += "Discharger10AOff S1\r\n";

            com.AppendWaitForMs(ms);
            textBoxInstructionPool.Text += "Delay in ms: " + ms.ToString() + "\r\n";

            com.AppendDischarger10AOffS2();
            textBoxInstructionPool.Text += "Discharger10AOff S2\r\n";
        }

        private void buttonCompositeFinishDisch100A_Click(object sender, EventArgs e)
        {
            UInt32 ms;
            try
            {
                ms = Convert.ToUInt32(textBoxCompositeMsDelay.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert valid number for delay!");
                return;
            }

            com.AppendDischarger100AOffS1();
            textBoxInstructionPool.Text += "Discharger100AOff S1\r\n";

            com.AppendWaitForMs(ms);
            textBoxInstructionPool.Text += "Delay in ms: " + ms.ToString() + "\r\n";

            com.AppendDischarger100AOffS2();
            textBoxInstructionPool.Text += "Discharger100AOff S2\r\n";
        }
    }
}
