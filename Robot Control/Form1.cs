using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void btnFwd_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Right";
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Left";
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
        }

        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "Back";
        }

        private void btnBack_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = "Stop";
        }
    }
}
