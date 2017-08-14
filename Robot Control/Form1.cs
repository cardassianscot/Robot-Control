using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Robot_Control.Arduino;

namespace Robot_Control
{
    public partial class Form1 : Form
    {
        Arduino.Arduino arduino;

        public Form1()
        {
            InitializeComponent();
            menuStrip1.ImageScalingSize = new Size(16, 16);
            arduino = new Arduino.Arduino();
            arduino.addMenu(connectionToolStripMenuItem);
            arduino.addStatusStrip(sslConnection, sslMessage);
        }

        private void btnFwd_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Forward";
            arduino.write("f");
        }

        private void btnFwd_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            arduino.write("s");
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Right";
            arduino.write("r");
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            arduino.write("s");
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Left";
            arduino.write("l");
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            arduino.write("s");
        }

        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Back";
            arduino.write("b");
        }

        private void btnBack_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
            arduino.write("s");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            arduino.write(txtBoxInstructions.Text);
        }

        private void btnSensor_Click(object sender, EventArgs e)
        {
            arduino.write("#");
        }
    }
}
