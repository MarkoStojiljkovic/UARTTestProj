namespace UARTTest
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.tbTX = new System.Windows.Forms.RichTextBox();
            this.tbRX = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonDebug = new System.Windows.Forms.Button();
            this.buttonSendHardcoded = new System.Windows.Forms.Button();
            this.buttonDataReader = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(866, 14);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(866, 481);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // tbTX
            // 
            this.tbTX.Location = new System.Drawing.Point(12, 14);
            this.tbTX.Name = "tbTX";
            this.tbTX.Size = new System.Drawing.Size(848, 101);
            this.tbTX.TabIndex = 2;
            this.tbTX.Text = "";
            this.tbTX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTX_KeyPress);
            // 
            // tbRX
            // 
            this.tbRX.Location = new System.Drawing.Point(13, 148);
            this.tbRX.Name = "tbRX";
            this.tbRX.Size = new System.Drawing.Size(847, 356);
            this.tbRX.TabIndex = 3;
            this.tbRX.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(867, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Continuous Mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // buttonDebug
            // 
            this.buttonDebug.Location = new System.Drawing.Point(867, 79);
            this.buttonDebug.Name = "buttonDebug";
            this.buttonDebug.Size = new System.Drawing.Size(75, 23);
            this.buttonDebug.TabIndex = 5;
            this.buttonDebug.Text = "Debug Send";
            this.buttonDebug.UseVisualStyleBackColor = true;
            this.buttonDebug.Click += new System.EventHandler(this.buttonDebug_Click);
            // 
            // buttonSendHardcoded
            // 
            this.buttonSendHardcoded.Location = new System.Drawing.Point(867, 125);
            this.buttonSendHardcoded.Name = "buttonSendHardcoded";
            this.buttonSendHardcoded.Size = new System.Drawing.Size(75, 23);
            this.buttonSendHardcoded.TabIndex = 6;
            this.buttonSendHardcoded.Text = "StopWait";
            this.buttonSendHardcoded.UseVisualStyleBackColor = true;
            this.buttonSendHardcoded.Click += new System.EventHandler(this.buttonSendHardcoded_Click);
            // 
            // buttonDataReader
            // 
            this.buttonDataReader.Location = new System.Drawing.Point(867, 168);
            this.buttonDataReader.Name = "buttonDataReader";
            this.buttonDataReader.Size = new System.Drawing.Size(96, 23);
            this.buttonDataReader.TabIndex = 7;
            this.buttonDataReader.Text = "Data Reader";
            this.buttonDataReader.UseVisualStyleBackColor = true;
            this.buttonDataReader.Click += new System.EventHandler(this.buttonDataReader_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 516);
            this.Controls.Add(this.buttonDataReader);
            this.Controls.Add(this.buttonSendHardcoded);
            this.Controls.Add(this.buttonDebug);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tbRX);
            this.Controls.Add(this.tbTX);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSend);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.RichTextBox tbTX;
        private System.Windows.Forms.RichTextBox tbRX;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonDebug;
        private System.Windows.Forms.Button buttonSendHardcoded;
        private System.Windows.Forms.Button buttonDataReader;
    }
}

