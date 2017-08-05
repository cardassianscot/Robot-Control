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
        }

        private void btnFwd_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Forward";
            serialPort1.Write("f");
        }

        private void btnFwd_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            serialPort1.Write("s");
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Right";
            serialPort1.Write("r");
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            serialPort1.Write("s");
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Left";
            serialPort1.Write("l");
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            serialPort1.Write("s");
        }

        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Back";
            serialPort1.Write("b");
        }

        private void btnBack_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            serialPort1.Write("s");
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
            serialPort1.Write(txtBoxInstructions.Text);
        }

        private void btnSensor_Click(object sender, EventArgs e)
        {
            serialPort1.Write("#");
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
                serialPort1.PortName = cbxPorts.Text;
                serialPort1.Open();
                if (cbxReadPorts.SelectedIndex != 0)
                {
                    serialPort2.PortName = cbxReadPorts.Text;
                    serialPort2.Open();
                }
                btnConnect.Text = "Disconnect";
            }
            else
            {
                serialPort1.Close();
                if (serialPort2.IsOpen)
                    serialPort2.Close();
                btnConnect.Text = "Connect";
            }
        }
    }
}
