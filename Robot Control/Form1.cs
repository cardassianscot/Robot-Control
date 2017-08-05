using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Robot_Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            disableButtons();
        }

        private void btnFwd_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Forward";
            serialWrite("f");
        }

        private void btnFwd_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            serialWrite("s");
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Right";
            serialWrite("r");
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            serialWrite("s");
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Left";
            serialWrite("l");
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            serialWrite("s");
        }

        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Back";
            serialWrite("b");
        }

        private void btnBack_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            serialWrite("s");
        }

        private void cbxPorts_DropDown(object sender, EventArgs e)
        {
            string[] names = SerialPort.GetPortNames();
            Array.Sort(names);
            foreach (var name in names)
                cbxPorts.Items.Add(name);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            serialWrite(txtBoxInstructions.Text);
        }

        private void btnSensor_Click(object sender, EventArgs e)
        {
            serialWrite("#");
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string inData = sp.ReadExisting();
            inData = inData.Replace("\r", "");
            BeginInvoke(new EventHandler(delegate
            {
                txtBoxSensor.AppendText(inData);
                txtBoxSensor.ScrollToCaret();
            }));
        }

        private void cbxReadPorts_DropDown(object sender, EventArgs e)
        {
            string[] names = SerialPort.GetPortNames();
            Array.Sort(names);
            cbxPorts.Items.Add("Shared");
            foreach (var name in names)
                cbxPorts.Items.Add(name);
            cbxPorts.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                if (cbxPorts.SelectedIndex == -1)
                {
                    MessageBox.Show("You have not selected a Serial Port");
                }
                else
                {
                    try
                    {
                        serialPort1.PortName = cbxPorts.Text;
                        serialPort1.Open();
                        if (cbxReadPorts.SelectedIndex != 0)
                        {
                            serialPort2.PortName = cbxReadPorts.Text;
                            serialPort2.Open();
                        }
                        btnConnect.Text = "Disconnect";
                        enableButtons();
                    }
                    catch
                    {
                        MessageBox.Show("Serial Port connection has failed.");
                        serialClose();
                    }
                }
            }
            else
            {
                serialClose();
            }
        }

        private void serialClose()
        {
            disableButtons();
            serialPort1.Close();
            if (serialPort2.IsOpen)
                serialPort2.Close();
            btnConnect.Text = "Connect";
        }

        private void serialWrite(string s)
        {
            try
            {
                serialPort1.Write(s);
            }
            catch
            {
                MessageBox.Show("Serial Port connection has failed.");
                serialClose();
            }
        }

        private void disableButtons()
        {
            btnSend.Enabled = false;
            btnFwd.Enabled = false;
            btnBack.Enabled = false;
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
            btnSensor.Enabled = false;
        }

        private void enableButtons()
        {
            btnSend.Enabled = true;
            btnFwd.Enabled = true;
            btnBack.Enabled = true;
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            btnSensor.Enabled = true;
        }
    }
}
