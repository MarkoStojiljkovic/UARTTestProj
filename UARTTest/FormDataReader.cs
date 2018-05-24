using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace UARTTest
{
    public partial class FormDataReader : Form
    {
        byte[] tempBuff = new byte[1];
        SerialPort serial = new SerialPort();

        byte deviceAddr = 0x31;
        byte startSeq = 254;
        byte commandRead = 6; // Read command
        byte commandErase = 7; // Erase all measurements
        

        const int MEASURE_INFO_BASE = 512;
        const int MEASURE_INFO_LEN = 34;
        const int HEADER_LENGTH = 14;

        delegate void ProcessUARTData(byte[] data); // Declare type for fucntion pointer

        ProcessUARTData processFunction = Dummy; // Default processing method
        
        UARTMeasurementReceiverClass uartReceiver = new UARTMeasurementReceiverClass();

        List<MeasurementHeaderClass> headers = new List<MeasurementHeaderClass>();
        int currentHeader = 0;


        private Label[][] _headerLabels = new Label[8][];

        public FormDataReader()
        {
            InitializeComponent();
            comboBoxSerialPorts.Items.AddRange(SerialPort.GetPortNames());
            serial.ReadTimeout = 500; // 500ms
            serial.WriteTimeout = 500; // 500ms
            serial.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived); // Subscribe to fucking handler
            //serial.DtrEnable = true;
            //serial.RtsEnable = true;


            //if (!serialPort1.IsOpen)
            //{
            //    serialPort1.Open();
            //}
            //else
            //{
            //    throw new Exception("Error with serial port");
            //}

            _headerLabels[0] = new Label[] { label11, label12, label13, label14, label15, label16};
            _headerLabels[1] = new Label[] { label21, label22, label23, label24, label25, label26 };
            _headerLabels[2] = new Label[] { label31, label32, label33, label34, label35, label36 };
            _headerLabels[3] = new Label[] { label41, label42, label43, label44, label45, label46 };
            _headerLabels[4] = new Label[] { label51, label52, label53, label54, label55, label56 };
            _headerLabels[5] = new Label[] { label61, label62, label63, label64, label65, label66 };
            _headerLabels[6] = new Label[] { label71, label72, label73, label74, label75, label76 };
            _headerLabels[7] = new Label[] { label81, label82, label83, label84, label85, label86 };

        }

        private void buttonSerialOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (serial.IsOpen)
                {
                    MessageBox.Show("Port is already open");
                    return;
                }
                serial.PortName = (string)comboBoxSerialPorts.SelectedItem;
                serial.Open();
                labelSerialStatus.Text = "Ready " + (string)comboBoxSerialPorts.SelectedItem;
                
            }
            catch (Exception ex)
            {
                labelSerialStatus.Text = "COM port error";
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSerialClose_Click(object sender, EventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.Close();
                labelSerialStatus.Text = "Not connected!";
            }
        }


        private void buttonRead_Click(object sender, EventArgs e)
        {
#warning Update to use CommandFormerClass
            uartReceiver.Reset();
            processFunction = DebugRead;

            List<byte> sb = new List<byte>();

            sb.Add(startSeq);
            sb.Add(deviceAddr);
            // Append message length, include shecksum
            sb.Add(0);
            sb.Add(9);
            // Append command
            sb.Add(commandRead); // 1B

            // Get and append address
            int temp = Convert.ToInt32(this.textBoxAddress.Text);
            byte[] bAddress = CustomConvertorClass.ConvertIntTo4Bytes(temp);
            sb.AddRange(bAddress); // 4B
            // Get and append length
            temp = Convert.ToInt32(this.textBoxLen.Text);
            byte[] bLen = CustomConvertorClass.ConvertIntTo2Bytes(temp);
            sb.AddRange(bLen); // 2B

            // Now calculate and append checksum
            UInt16 csum = ChecksumClass.CalculateChecksum(sb.ToArray());
            byte[] bcsum = CustomConvertorClass.ConvertIntTo2BytesBE(csum);
            sb.AddRange(bcsum); // 2B

            serial.Write(sb.ToArray(), 0, sb.Count);
        }

        int totalReads = 0;
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            tempBuff = new byte[serial.BytesToRead];
            totalReads += serial.Read(tempBuff, 0, tempBuff.Length);
            if (uartReceiver.CollectData(tempBuff))
            {
                // All data collected, process it based on pressed button
                processFunction(uartReceiver.bData);
                totalReads = 0;

            }
        }
        
        
        /// <summary>
        /// Call this method from extern module when timeout occured
        /// </summary>
        public void DataReaderTimeout()
        {
            // Reset state machine or something like that
        }

        private void buttonGetMeasurements_Click(object sender, EventArgs e)
        {
#warning Update to use CommandFormerClass
            uartReceiver.Reset();
            processFunction = ProcessGetMeasurementInfo;
            // Send command to get measurement header
            List<byte> sb = new List<byte>();

            sb.Add(startSeq);
            sb.Add(deviceAddr);
            // Append message length
            sb.Add(0);
            sb.Add(9);
            // Append command
            sb.Add(commandRead);

            // Get and append address
            byte[] bAddress = CustomConvertorClass.ConvertIntTo4Bytes(MEASURE_INFO_BASE);
            sb.AddRange(bAddress);
            // Get and append length
            byte[] bLen = CustomConvertorClass.ConvertIntTo2Bytes(MEASURE_INFO_LEN);
            sb.AddRange(bLen);

            // Debug checksum test
            //sb.Add(0x1);
            //sb.Add(0x2);

            // Now calculate and append checksum
            UInt16 csum = ChecksumClass.CalculateChecksum(sb.ToArray());
            byte[] bcsum = CustomConvertorClass.ConvertIntTo2BytesBE(csum);
            sb.AddRange(bcsum); // 2B


            serial.Write(sb.ToArray(), 0, sb.Count);

        }

        /// <summary>
        /// Default method for processing UART received data
        /// </summary>
        /// <param name="b"></param>
        private static void Dummy(byte[] b)
        {
            Console.WriteLine("Dummy");
        }

        
        /// <summary>
        /// Measurement info is received, decode data and send requests to read measurement headers
        /// </summary>
        /// <param name="b"></param>
        private void ProcessGetMeasurementInfo(byte[] b)
        {
            // Check checksum and remove from message
            ChecksumClass cs = new ChecksumClass();
            if (cs.VerifyChecksumFromReceivedMessage(b))
                Console.WriteLine("CHECKSUM MATCH");
            else
            {
                Console.WriteLine("CHECKSUM DONT MATCH");
                return;
            }

            var newArr = UARTHelperClass.RemoveChecksumFromMessage(b);


            ByteArrayDecoderClass decoder = new ByteArrayDecoderClass(newArr);
            
            decoder.Get2BytesAsInt(); // Remove first 2 values (number of data transmited)
            EraseLabels();
            // Get number of measurements and their header starting addresses 
            int numOfMeasurements = decoder.Get2BytesAsInt();
            Console.WriteLine("Number of measurements: " + numOfMeasurements);
            if (numOfMeasurements == 0)
            {
                // if no measurements leave it as it is
                processFunction = Dummy;
                return;
            }
            headers = new List<MeasurementHeaderClass>(); // Reset headers list
            for (int i = 0; i < numOfMeasurements; i++)
            {
                headers.Add(new MeasurementHeaderClass(decoder.Get4BytesAsInt()));
            }
            
            // Reset UART receiver and set new method for data processing
            uartReceiver.Reset();
            processFunction = FetchHeaders;
            currentHeader = 0; // Reset header index


            // Bootstrap
#warning Update to use CommandFormerClass
            // Send command to get measurement header
            List<byte> sb = new List<byte>();

            sb.Add(startSeq);
            sb.Add(deviceAddr);
            // Append message length
            sb.Add(0);
            sb.Add(9);
            // Append command
            sb.Add(commandRead);

            // Get and append address
            byte[] bAddress = CustomConvertorClass.ConvertIntTo4Bytes(headers[0].headerAddress);
            sb.AddRange(bAddress);
            // Get and append length
            byte[] bLen = CustomConvertorClass.ConvertIntTo2Bytes(HEADER_LENGTH);
            sb.AddRange(bLen);
            //Thread.Sleep(200);
            //Console.WriteLine("ProcessGetMeasurementInfo --sending " + sb.Count);

            // Now calculate and append checksum
            UInt16 csum = ChecksumClass.CalculateChecksum(sb.ToArray());
            byte[] bcsum = CustomConvertorClass.ConvertIntTo2BytesBE(csum);
            sb.AddRange(bcsum); // 2B

            serial.Write(sb.ToArray(), 0, sb.Count);
        }

        private void FetchHeaders(byte[] b)
        {

            // Check checksum and remove from message
            ChecksumClass cs = new ChecksumClass();
            if (cs.VerifyChecksumFromReceivedMessage(b))
                Console.WriteLine("CHECKSUM MATCH");
            else
            {
                Console.WriteLine("CHECKSUM DONT MATCH");
                return;
            }

            var newArr = UARTHelperClass.RemoveChecksumFromMessage(b);


            ByteArrayDecoderClass decoder = new ByteArrayDecoderClass(newArr);
            decoder.Get2BytesAsInt(); // Remove first 2 values (number of data transmited)

            int[] timestamp = decoder.Get6BytesAsTimestamp();
            int prescaler = decoder.Get4BytesAsInt();
            int numOfPoints = decoder.Get2BytesAsInt();
            int operatingMode = decoder.Get1ByteAsInt();
            int channelMode = decoder.Get1ByteAsInt();
            // Fill header with remaining data
            headers[currentHeader].timestamp = timestamp;
            headers[currentHeader].prescaler = prescaler;
            headers[currentHeader].numOfPoints = numOfPoints;
            headers[currentHeader].operatingMode = operatingMode;
            headers[currentHeader].channel = channelMode;
            headers[currentHeader].ready = true;
            // Fill labels
            FillLabelGroup(currentHeader, headers[currentHeader].headerAddress, timestamp, prescaler, numOfPoints, operatingMode, channelMode);
            
            uartReceiver.Reset();

            currentHeader++;
            if (currentHeader == headers.Count) // Last time in here, reset everything
            {
                processFunction = Dummy;
                return;
            }
#warning Update to use CommandFormerClass
            // Send command to get measurement header
            List<byte> sb = new List<byte>();

            sb.Add(startSeq);
            sb.Add(deviceAddr);
            // Append message length and include checksum
            sb.Add(0);
            sb.Add(9);
            // Append command
            sb.Add(commandRead);

            // Get and append address
            byte[] bAddress = CustomConvertorClass.ConvertIntTo4Bytes(headers[currentHeader].headerAddress);
            sb.AddRange(bAddress);
            // Get and append length
            byte[] bLen = CustomConvertorClass.ConvertIntTo2Bytes(HEADER_LENGTH);
            sb.AddRange(bLen);
            Thread.Sleep(50);
            //Console.WriteLine("FetchHeaders -- sending " + sb.Count);

            // Now calculate and append checksum
            UInt16 csum = ChecksumClass.CalculateChecksum(sb.ToArray());
            byte[] bcsum = CustomConvertorClass.ConvertIntTo2BytesBE(csum);
            sb.AddRange(bcsum); // 2B

            serial.Write(sb.ToArray(), 0, sb.Count);
            
        }

        private void DebugRead(byte[] b)
        {
            uartReceiver.Reset();
            // Check checksum and remove from message
            ChecksumClass cs = new ChecksumClass();
            if (cs.VerifyChecksumFromReceivedMessage(b))
                Console.WriteLine("CHECKSUM MATCH");
            else
            {
                Console.WriteLine("CHECKSUM DONT MATCH");
                return;
            }

            var newArr = UARTHelperClass.RemoveChecksumFromMessage(b);

            Console.WriteLine("in debug, read bytes: " + b.Length);
            this.Invoke(new Action(() =>
            {
                //FormDataPresenter fdp = new FormDataPresenter(newArr);
                FormDataPresenter2 fdp = new FormDataPresenter2(newArr);
                fdp.Show();
            }));
            
        }

        private void ReceiveGain(byte[] b)
        {
            ChecksumClass cs = new ChecksumClass();
            if (cs.VerifyChecksumFromReceivedMessage(b))
                Console.WriteLine("CHECKSUM MATCH");
            else
            {
                Console.WriteLine("CHECKSUM DONT MATCH");
                return;
            }

            var newArr = UARTHelperClass.RemoveChecksumFromMessage(b);

            ByteArrayDecoderClass dec = new ByteArrayDecoderClass(newArr);
            //int size = dec.Get2BytesAsInt() / 2;
            dec.Get2BytesAsInt(); // Just remove 2 bytes i know length for this message

            float temp = dec.Get4BytesAsFloat();
            this.Invoke(new Action(() =>
            {
                textBoxGain.Text = temp.ToString();
            }));
        }

        private void FillLabelGroup(int index, int address, int[] timestamp, int prescaler, int numOfPoints, int operatingMode, int channelMode)
        {
            // Form timestamp string first
            string time = (timestamp[0] + 2000).ToString() + "/" + timestamp[1].ToString() + "/" + timestamp[2].ToString() + " " +
                timestamp[3].ToString() + ":" + timestamp[4].ToString() + ":" + timestamp[5].ToString();

            this.Invoke(new Action(() =>
            {
                Label[] labels = _headerLabels[index];
                labels[0].Text = address.ToString();
                labels[1].Text = time;
                labels[2].Text = prescaler.ToString();
                labels[3].Text = numOfPoints.ToString();
                labels[4].Text = operatingMode.ToString();
                labels[5].Text = channelMode.ToString();
            }));
            
        }

        private void EraseLabels()
        {
            for (int i = 0; i < _headerLabels.Length; i++)
            {
                this.Invoke(new Action(() =>
                {
                    Label[] labels = _headerLabels[i];
                    labels[0].Text = "xxxxx";
                    labels[1].Text = "xxxxx";
                    labels[2].Text = "xxxxx";
                    labels[3].Text = "xxxxx";
                    labels[4].Text = "xxxxx";
                    labels[5].Text = "xxxxx";
                }));
            }
            
        }

        
        private void buttonErase_Click(object sender, EventArgs e)
        {
            // Send command to erase measurement header
            List<byte> sb = new List<byte>();

            sb.Add(startSeq);
            sb.Add(deviceAddr);
            // Append message length, and include checksum
            sb.Add(0);
            sb.Add(3);
            // Append command
            sb.Add(commandErase);

            // Now calculate and append checksum
            UInt16 csum = ChecksumClass.CalculateChecksum(sb.ToArray());
            byte[] bcsum = CustomConvertorClass.ConvertIntTo2BytesBE(csum);
            sb.AddRange(bcsum); // 2B

            serial.Write(sb.ToArray(), 0, sb.Count);
        }

        private void buttonRecordTask_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // (uint8_t chMode, uint8_t operationMode, uint32_t prescaler, uint32_t targetPoints)
            //    int chMode = Convert.ToInt32(textBoxChMode.Text);
            //    int opMode = Convert.ToInt32(textBoxOpMode.Text);
            //    int prescaler = Convert.ToInt32(textBoxPrescaler.Text);
            //    int targetPoints = Convert.ToInt32(textBoxTargetPoints.Text);
            //    // Check here for invalid values

            //    // Send command to erase measurement header
            //    List<byte> sb = new List<byte>();

            //    sb.Add(startSeq);
            //    sb.Add(deviceAddr);
            //    // Append message length, and include checksum
            //    sb.Add(0);
            //    sb.Add(13);
            //    sb.Add(commandStartRecorder); //1
            //    // Convert values to separate bytes
            //    byte bChMode = CustomConvertorClass.ConvertIntTo1Byte(chMode); // 2
            //    byte bOpMode = CustomConvertorClass.ConvertIntTo1Byte(opMode); // 3
            //    byte[] bPrescaler = CustomConvertorClass.ConvertIntTo4Bytes(prescaler); //  7
            //    byte[] bTargetPoints = CustomConvertorClass.ConvertIntTo4Bytes(targetPoints); // 11

            //    sb.Add(bChMode);
            //    sb.Add(bOpMode);
            //    sb.AddRange(bPrescaler);
            //    sb.AddRange(bTargetPoints);

            //    // Now calculate and append checksum
            //    UInt16 csum = ChecksumClass.CalculateChecksum(sb.ToArray());
            //    byte[] bcsum = CustomConvertorClass.ConvertIntTo2BytesBE(csum);
            //    sb.AddRange(bcsum); // 2B

            //    serialPort1.Write(sb.ToArray(), 0, sb.Count);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            // First parse values from dropdown list



            try
            {
                int chMode = InputValidatorHelperClass.GetChModeFromComboBox(comboBoxChannelSel);
                int opMode = InputValidatorHelperClass.GetOperationModeFromComboBox(comboBoxOperationSel);
                int prescaler = Convert.ToInt32(textBoxPrescaler.Text);
                int targetPoints = Convert.ToInt32(textBoxTargetPoints.Text);

                CommandFormerClass cm = new CommandFormerClass(startSeq, deviceAddr);
                cm.AppendDataRecorderTask((byte)chMode, (byte)opMode, (uint)prescaler, (uint)targetPoints, DateTime.Now);

                var data = cm.GetFinalCommandList();
                serial.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void ReadAndDisplayData(int index)
        {

            MeasurementHeaderClass header;
            try
            {
                header = headers[index];
            }
            catch (Exception)
            {
                MessageBox.Show("Header not present");
                return;
            }


            uartReceiver.Reset();
            processFunction = DebugRead;
#warning Update to use CommandFormerClass
            List<byte> sb = new List<byte>();

            sb.Add(startSeq);
            sb.Add(deviceAddr);
            // Append message length, include checksum
            sb.Add(0);
            sb.Add(9);
            // Append command
            sb.Add(commandRead); //1

            // Append address
            byte[] bAddress = CustomConvertorClass.ConvertIntTo4Bytes(header.dataAddress); //5
            sb.AddRange(bAddress);
            // Get and append length
            byte[] bLen = CustomConvertorClass.ConvertIntTo2Bytes(header.numOfPoints * 2); //7      1 measure is 2 bytes
            sb.AddRange(bLen);

            // Now calculate and append checksum
            UInt16 csum = ChecksumClass.CalculateChecksum(sb.ToArray());
            byte[] bcsum = CustomConvertorClass.ConvertIntTo2BytesBE(csum);
            sb.AddRange(bcsum); // 2B

            serial.Write(sb.ToArray(), 0, sb.Count);
        }

        private void buttonM1_Click(object sender, EventArgs e)
        {
            // Use header with index 0
            ReadAndDisplayData(0);

        }

        private void buttonM2_Click(object sender, EventArgs e)
        {
            // Use header with index 1
            ReadAndDisplayData(1);
        }

        private void buttonM3_Click(object sender, EventArgs e)
        {
            // Use header with index 2
            ReadAndDisplayData(2);
        }

        private void buttonM4_Click(object sender, EventArgs e)
        {
            // Use header with index 3
            ReadAndDisplayData(3);
        }

        private void buttonM5_Click(object sender, EventArgs e)
        {
            // Use header with index 4
            ReadAndDisplayData(4);
        }

        private void buttonM6_Click(object sender, EventArgs e)
        {
            // Use header with index 5
            ReadAndDisplayData(5);
        }

        private void buttonM7_Click(object sender, EventArgs e)
        {
            // Use header with index 6
            ReadAndDisplayData(6);
        }

        private void buttonM8_Click(object sender, EventArgs e)
        {
            // Use header with index 7
            ReadAndDisplayData(7);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            serial.DiscardInBuffer();
            uartReceiver.Reset();
        }

        private void buttonDebug_Click(object sender, EventArgs e)
        {
            FormInstructionCreator fi = new FormInstructionCreator(serial);
            fi.Show();
        }

        private void buttonGetGain_Click(object sender, EventArgs e)
        {
            try
            {
                uartReceiver.Reset();
                processFunction = ReceiveGain;

                CommandFormerClass cm = new CommandFormerClass(startSeq, deviceAddr);
                cm.GetGain();

                var data = cm.GetFinalCommandList();
                serial.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
