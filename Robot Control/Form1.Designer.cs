namespace Robot_Control
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFwd = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxInstructions = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cbxPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtBoxSensor = new System.Windows.Forms.TextBox();
            this.btnSensor = new System.Windows.Forms.Button();
            this.cbxReadPorts = new System.Windows.Forms.ComboBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnFwd, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRight, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBack, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 81);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(256, 250);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnFwd
            // 
            this.btnFwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFwd.Location = new System.Drawing.Point(88, 3);
            this.btnFwd.Name = "btnFwd";
            this.btnFwd.Size = new System.Drawing.Size(79, 77);
            this.btnFwd.TabIndex = 0;
            this.btnFwd.Text = "↑";
            this.btnFwd.UseVisualStyleBackColor = true;
            this.btnFwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnFwd_MouseDown);
            this.btnFwd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnFwd_MouseUp);
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Location = new System.Drawing.Point(173, 86);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(80, 77);
            this.btnRight.TabIndex = 1;
            this.btnRight.Text = "→";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseUp);
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(88, 169);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(79, 78);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "↓";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBack_MouseDown);
            this.btnBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBack_MouseUp);
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Location = new System.Drawing.Point(3, 86);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(79, 77);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "←";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(88, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 83);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxInstructions
            // 
            this.txtBoxInstructions.Location = new System.Drawing.Point(26, 352);
            this.txtBoxInstructions.Multiline = true;
            this.txtBoxInstructions.Name = "txtBoxInstructions";
            this.txtBoxInstructions.Size = new System.Drawing.Size(397, 81);
            this.txtBoxInstructions.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(440, 369);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(89, 42);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // cbxPorts
            // 
            this.cbxPorts.FormattingEnabled = true;
            this.cbxPorts.Location = new System.Drawing.Point(26, 26);
            this.cbxPorts.Name = "cbxPorts";
            this.cbxPorts.Size = new System.Drawing.Size(178, 28);
            this.cbxPorts.TabIndex = 3;
            this.cbxPorts.DropDown += new System.EventHandler(this.cbxPorts_DropDown);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(409, 26);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(120, 35);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtBoxSensor
            // 
            this.txtBoxSensor.Location = new System.Drawing.Point(303, 81);
            this.txtBoxSensor.Multiline = true;
            this.txtBoxSensor.Name = "txtBoxSensor";
            this.txtBoxSensor.ReadOnly = true;
            this.txtBoxSensor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxSensor.Size = new System.Drawing.Size(226, 185);
            this.txtBoxSensor.TabIndex = 5;
            // 
            // btnSensor
            // 
            this.btnSensor.Location = new System.Drawing.Point(355, 282);
            this.btnSensor.Name = "btnSensor";
            this.btnSensor.Size = new System.Drawing.Size(120, 43);
            this.btnSensor.TabIndex = 6;
            this.btnSensor.Text = "Sensor";
            this.btnSensor.UseVisualStyleBackColor = true;
            this.btnSensor.Click += new System.EventHandler(this.btnSensor_Click);
            // 
            // cbxReadPorts
            // 
            this.cbxReadPorts.FormattingEnabled = true;
            this.cbxReadPorts.Location = new System.Drawing.Point(210, 26);
            this.cbxReadPorts.Name = "cbxReadPorts";
            this.cbxReadPorts.Size = new System.Drawing.Size(178, 28);
            this.cbxReadPorts.TabIndex = 7;
            this.cbxReadPorts.DropDown += new System.EventHandler(this.cbxReadPorts_DropDown);
            // 
            // serialPort2
            // 
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 455);
            this.Controls.Add(this.cbxReadPorts);
            this.Controls.Add(this.btnSensor);
            this.Controls.Add(this.txtBoxSensor);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbxPorts);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtBoxInstructions);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Robot Control";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnFwd;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxInstructions;
        private System.Windows.Forms.Button btnSend;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cbxPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtBoxSensor;
        private System.Windows.Forms.Button btnSensor;
        private System.Windows.Forms.ComboBox cbxReadPorts;
        private System.IO.Ports.SerialPort serialPort2;
    }
}

