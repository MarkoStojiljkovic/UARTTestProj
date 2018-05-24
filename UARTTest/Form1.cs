using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UARTTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!serialPort1.IsOpen)
            {
                //serialPort1.Open();
                tbRX.Text = "port is closed for another form :) ";
            }
            else
                tbRX.Text = "port busy :( ";
        }
        private string rxString;
        

        private void buttonSend_Click(object sender, EventArgs e)
        {
            serialPort1.Write(tbTX.Text);
        }
        
        Stopwatch stopWatch = new Stopwatch();
        private static bool firstTime = true;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
            //this.Invoke(new EventHandler(displayText));

            rxString = serialPort1.ReadExisting();
            AppendToDisplay(rxString);

            if (firstTime)
            {
                firstTime = false;
                stopWatch.Start();
            }
            else
            {
                //stopWatch.Stop();
                TimeSpan elapsed = stopWatch.Elapsed;
                string elapsedtime = string.Format("{0:00}:{1:00}.{2:000}", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds);
                Console.WriteLine(elapsedtime);
                stopWatch.Reset();
                stopWatch.Start();
            }
            
        }
        

        private void AppendToDisplay(string s)
        {
            if (tbRX.InvokeRequired)
            {
                // Call thread that owns this textbox to execute appending
                this.Invoke(new Action<string>(AppendToDisplay), new object[] {s});
                return;
            }
            tbRX.AppendText(s);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            tbTX.Clear();
            tbRX.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        private void tbTX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (serialPort1.IsOpen && checkBox1.Checked)
            {
                char[] ch = new char[1];
                ch[0] = e.KeyChar;
                serialPort1.Write(ch, 0, 1);
            }
        }

        private void SendACK()
        {
            serialPort1.Write("ack");
        }

        private int CharToInt(char c)
        {
            int tmp = c - '0';
            if (tmp > 9 || tmp < 0)
            {
                throw new Exception("Wrong number of data parameter");
            }
            return tmp;
        }

        private string RemoveASCIIZeroes(string s)
        {

            StringBuilder sb = new StringBuilder();

            foreach (char c in s)
            {
                if ((int)c != 0)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        
        private void buttonDebug_Click(object sender, EventArgs e)
        {
            byte[] final = ConertStringToBytes(tbTX.Text);
            serialPort1.Write(final, 0, final.Length);
            //serialPort1.Write(sb.ToString());
        }

        private void buttonSendHardcoded_Click(object sender, EventArgs e)
        {

        }

        enum State { normal, specialDec, specialHex };
        byte[] ConertStringToBytes(string s)
        {
            State state = State.normal;
            int specialRegDec = 100;
            int specialRegHex = 16;
            int finalValue = 0;
            List<byte> sb = new List<byte>();

            foreach (char item in tbTX.Text)
            {
                switch (state)
                {
                    case State.normal:
                        if (item == '$')
                        {
                            finalValue = 0;
                            state = State.specialDec;
                        }
                        else if (item == '%')
                        {
                            finalValue = 0;
                            state = State.specialHex;
                        }
                        else
                        {
                            sb.Add((byte)item);
                        }
                        break;
                    case State.specialDec: // after $ sign, calculate next 3 chars writen in ascii as 1 char, "$101" = 0d101 = 'e'
                        int tempDec = (int)item - 0x30;
                        if (tempDec < 0 || tempDec > 9)
                        {
                            Console.WriteLine("Error at parsing special $ sequence");
                            throw new Exception("Error at parsing special $ sequence");
                        }
                        tempDec *= specialRegDec;
                        finalValue += tempDec;

                        if (specialRegDec == 1)
                        {
                            sb.Add((byte)finalValue);
                            specialRegDec = 100;
                            state = State.normal;
                        }
                        else
                        {
                            specialRegDec /= 10;
                        }
                        break;
                    case State.specialHex:
                        int tempHex;
                        if (item >= '0' && item <= '9') tempHex = (item - 48) * specialRegHex;
                        else if (item >= 'A' && item <= 'F') tempHex = (item - 55) * specialRegHex;
                        else if (item >= 'a' && item <= 'f') tempHex = (item - 87) * specialRegHex;
                        else
                        {
                            Console.WriteLine("Error at parsing special % sequence");
                            throw new Exception("Error at parsing special % sequence");
                        }

                        finalValue += tempHex;
                        if (specialRegHex == 1)
                        {
                            sb.Add((byte)finalValue);
                            specialRegHex = 16;
                            state = State.normal;
                        }
                        else
                        {
                            specialRegHex /= 16;
                        }

                        break;
                }
            }

            return  sb.ToArray();
        }

        private void buttonDataReader_Click(object sender, EventArgs e)
        {
            FormDataReader fdr = new FormDataReader();
            fdr.Show();
        }
    }
}
