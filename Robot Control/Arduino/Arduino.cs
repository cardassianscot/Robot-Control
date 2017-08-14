using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Robot_Control.Arduino
{
    class Arduino
    {
        private arduinoSerial serial;
        private arduinoDataReceivedRichText rtb;
        private arduinoResponseMessageBox mb;
        private arduinoResponseStatusStrip ss;
        private arduinoComboBox cb;
        private arduinoMenu m;

        public Arduino()
        {
            serial = new arduinoSerial();
        }

        public void addReceivedRichText(RichTextBox r)
        {
            rtb = new arduinoDataReceivedRichText(serial, r);
        }

        public void addResponseMessageBox()
        {
            mb = new arduinoResponseMessageBox(serial);
        }

        public void addStatusStrip(ToolStripStatusLabel connect, ToolStripStatusLabel message)
        {
            ss = new arduinoResponseStatusStrip(serial, connect, message);
        }

        public void addComboBox(ComboBox write, ComboBox read, Button connect)
        {
            cb = new arduinoComboBox(serial, write, read, connect);
        }

        public void addMenu(ToolStripMenuItem menu)
        {
            m = new arduinoMenu(serial, menu);
        }

        public void write(string s)
        {
            serial.Write(s);
        }
    }

    public class arduinoDataReceivedRichText
    {
        RichTextBox rtb;

        public arduinoDataReceivedRichText(arduinoSerial a, RichTextBox r)
        {
            rtb = r;
            a.ReceiveEvent += DataReceived;
        }

        private void DataReceived(object sender, MessageEventArgs e)
        {
            rtb.AppendText(e.Text);
        }
    }


    public class arduinoResponseMessageBox
    {
        public arduinoResponseMessageBox(arduinoSerial a)
        {
            a.DropEvent += response;
        }

        private void response(object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Text);
        }
    }

    public class arduinoResponseStatusStrip
    {
        private ToolStripStatusLabel Connect;
        private ToolStripStatusLabel Message;

        public arduinoResponseStatusStrip(arduinoSerial a, ToolStripStatusLabel connect, ToolStripStatusLabel message)
        {
            Connect = connect;
            Connect.Text = "";
            if (a.isConnected)
                Connect.Image = Properties.Resources.lime_connected_16;
            else
                Connect.Image = Properties.Resources.salmon_disconnected_16;
            Message = message;
            Message.Text = "";
            a.CloseEvent += close;
            a.OpenEvent += open;
            a.DropEvent += drop;
        }

        private void drop(object sender, MessageEventArgs e)
        {
            Message.Text = e.Text;
        }

        private void open(object sender, EventArgs e)
        {
            Connect.Image = Properties.Resources.lime_connected_16;
        }

        private void close(object sender, EventArgs e)
        {
            Connect.Image = Properties.Resources.salmon_disconnected_16;
        }
    }

    public class arduinoComboBox
    {
        private ComboBox _cbWrite;
        private ComboBox _cbRead;
        private Button _btnConnect;
        private arduinoSerial arduino;

        public arduinoComboBox(arduinoSerial a, ComboBox write, ComboBox read, Button connect)
        {
            _cbWrite = write;
            _cbRead = read;
            _btnConnect = connect;
            arduino = a;
            a.OpenEvent += updateButtonOpen;
            a.CloseEvent += updateButtonClose;
            _btnConnect.Click += btnConnect_Click;
            _cbRead.DropDown += cbRead_DropDown;
            _cbRead.SelectedValueChanged += updateRead;
            _cbWrite.DropDown += cbWrite_DropDown;
            _cbWrite.SelectedValueChanged += updateWrite;
        }

        private void cbWrite_DropDown(object sender, EventArgs e)
        {
            foreach (var name in arduino.availablePorts)
                _cbWrite.Items.Add(name);
            _cbWrite.SelectedIndex = Math.Max(Array.IndexOf(arduino.availablePorts, arduino.ReadPortName), 0);
        }

        private void cbRead_DropDown(object sender, EventArgs e)
        {
            _cbRead.Items.Add("Shared");
            foreach (var name in arduino.availablePorts)
                _cbRead.Items.Add(name);
            if (arduino.Shared)
                _cbRead.SelectedIndex = 0;
            else
                _cbWrite.SelectedIndex = Math.Max(Array.IndexOf(arduino.availablePorts, arduino.WritePortName) + 1, 1);
        }

        private void updateWrite(object sender, EventArgs e)
        {
            arduino.WritePortName = _cbWrite.Text;
        }

        private void updateRead(object sender, EventArgs e)
        {
            if (_cbRead.Text == "Shared")
                arduino.Shared = true;
            else
            {
                arduino.Shared = false;
                arduino.ReadPortName = _cbRead.Text;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_btnConnect.Text == "Connect")
                arduino.Open();
            else
                arduino.Close();
        }

        private void updateButtonOpen(object sender, EventArgs e)
        {
            _btnConnect.Text = "Disconnect";
        }

        private void updateButtonClose(object sender, EventArgs e)
        {
            _btnConnect.Text = "Connect";
        }
    }

    public class arduinoMenu
    {
        private ToolStripMenuItem _menu;
        private ToolStripMenuItem _mW;
        private ToolStripMenuItem _mR;
        private ToolStripMenuItem _mSame;
        private ToolStripMenuItem _mConnect;
        private ToolStripMenuItem _mLeonardo;
        private ToolStripMenuItem _mBaud;
        private arduinoSerial arduino;

        public arduinoMenu(arduinoSerial a, ToolStripMenuItem c)
        {
            arduino = a;
            _menu = c;
            _mW = new ToolStripMenuItem("Port", null, null, "Port");
            _mR = new ToolStripMenuItem("Read Port", null, null, "ReadPort");
            _mSame = new ToolStripMenuItem("Shared", null, toggleShared, "Shared");
            _mBaud = new ToolStripMenuItem("Baud Rate", null, null, "Baud Rate");
            _mLeonardo = new ToolStripMenuItem("Leonardo", null, toggleLeonardo, "Leonardo");
            _mConnect = new ToolStripMenuItem("Connect", null, openClose, "Connect");
            _menu.DropDownItems.Add(_mW);
            _menu.DropDownItems.Add(_mR);
            _menu.DropDownItems.Add(_mSame);
            _menu.DropDownItems.Add(_mBaud);
            menuAddBaudRates();
            _menu.DropDownItems.Add(_mLeonardo);
            _menu.DropDownItems.Add(_mConnect);
            _menu.DropDownOpening += updateMenus;
        }

        private void toggleShared(object sender, EventArgs e)
        {
            arduino.Shared = !arduino.Shared;
        }

        private void toggleLeonardo(object sender, EventArgs e)
        {
            arduino.Leonardo = !arduino.Leonardo;
        }

        private void updateMenus(object sender, EventArgs e)
        {
            UpdatePorts();
            UpdateLeonardo();
            UpdateBaudRates();
            UpdateConnect();
            if (arduino.isConnected)
                disableMenus();
            else
                enableMenus();
        }

        private void disableMenus()
        {
            _mW.Enabled = false;
            _mR.Enabled = false;
            _mSame.Enabled = false;
            _mLeonardo.Enabled = false;
            _mBaud.Enabled = false;
        }

        private void enableMenus()
        {
            _mW.Enabled = true;
            _mR.Enabled = !arduino.Shared;
            _mSame.Enabled = true;
            _mLeonardo.Enabled = true;
            _mBaud.Enabled = true;
        }

        private void UpdatePorts()
        {
            menuAddSerialPorts(_mW, arduino.WritePortName);
            if (!arduino.Shared)
            {
                menuAddSerialPorts(_mR, arduino.ReadPortName);
                _mR.Enabled = true;
                _mSame.Checked = false;
            }
            else
            {
                _mR.Enabled = false;
                _mSame.Checked = true;
            }
        }

        private void UpdateLeonardo()
        {
            _mLeonardo.Checked = arduino.Leonardo;
        }

        private void UpdateConnect()
        {
            if (arduino.isConnected)
                _mConnect.Text = "Disconnect";
            else
                _mConnect.Text = "Connect";
        }

        private void UpdateBaudRates()
        {
            foreach (ToolStripMenuItem i in _mBaud.DropDownItems)
                i.Checked = i.Name == arduino.Baud.ToString();
        }

        private void menuAddBaudRates()
        {
            _mBaud.DropDownItems.Clear();
            foreach (string rate in arduino.BaudRates)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem(rate, null, clickRate, rate);
                _mBaud.DropDownItems.Add(mi);
            }
        }

        private void clickRate(object sender, EventArgs e)
        {
            ToolStripMenuItem clicked = (ToolStripMenuItem)sender;
            arduino.Baud = Convert.ToInt32(clicked.Name);
        }

        private void menuAddSerialPorts(ToolStripMenuItem m, string sp)
        {
            m.DropDownItems.Clear();
            foreach (string name in arduino.availablePorts)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem(name, null, clickPort, m.Name + "#" + name);
                m.DropDownItems.Add(mi);
            }
            if (sp != "")
            {
                if (!m.DropDownItems.ContainsKey(m.Name + "#" + sp))
                {
                    ToolStripMenuItem mi = new ToolStripMenuItem(sp, null, null, m.Name + "#" + sp);
                    mi.Enabled = false;
                    m.DropDownItems.Add(mi);
                }
                foreach (ToolStripMenuItem mi in m.DropDownItems)
                    mi.Checked = mi.Name == m.Name + "#" + sp;
            }
        }

        private void clickPort(object sender, EventArgs e)
        {
            ToolStripMenuItem clicked = (ToolStripMenuItem)sender;
            string[] ss = clicked.Name.Split('#');
            if (ss[0] == "ReadPort")
                arduino.ReadPortName = ss[1];
            else
                arduino.WritePortName = ss[1];
        }

        private void openClose(object sender, EventArgs e)
        {
            if (arduino.isConnected)
                arduino.Close();
            else
                arduino.Open();
        }
    }

    public class MessageEventArgs : EventArgs
    {
        public readonly string Text;

        public MessageEventArgs(string s)
        {
            Text = s;
        }
    }


    public class arduinoSerial
    {
        private SerialPort serialRead;
        private SerialPort serialWrite;
        private bool shared = true;

        public List<string> BaudRates = new List<string>
                    { "300", "600", "1200", "2400", "4800", "9600", "14400", "19200",
                    "28800", "38400", "57600", "115200" };

        public event EventHandler OpenEvent;
        public event EventHandler CloseEvent;
        public event EventHandler<MessageEventArgs> DropEvent;
        public event EventHandler<MessageEventArgs> ReceiveEvent;

        protected virtual void OnOpenEvent()
        {
            OpenEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnCloseEvent()
        {
            CloseEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDropEvent(MessageEventArgs e)
        {
            DropEvent?.Invoke(this, e);
        }

        protected virtual void OnReceiveEvent(MessageEventArgs e)
        {
            ReceiveEvent?.Invoke(this, e);
        }

        public arduinoSerial()
        {
            serialRead = new SerialPort();
            serialWrite = new SerialPort();
            serialRead.ReadTimeout = 500;
            serialWrite.ReadTimeout = 500;
            serialWrite.WriteTimeout = 500;
            serialRead.DataReceived += DataReceived;
            serialWrite.DataReceived += DataReceived;
            loadSettings();
        }

        private void loadSettings()
        {
            Shared = Properties.Settings.Default.Shared;
            Leonardo = Properties.Settings.Default.Leonardo;
            Baud = Properties.Settings.Default.BaudRate;
            ReadPortName = Properties.Settings.Default.ReadPortName;
            WritePortName = Properties.Settings.Default.WritePortName;
        }

        public bool Shared
        {
            get
            {
                return shared;
            }
            set
            {
                shared = value;
                Properties.Settings.Default.Shared = value;
            }
        }

        public bool Leonardo
        {
            get
            {
                return serialRead.DtrEnable;
            }
            set
            {
                serialRead.DtrEnable = value;
                serialWrite.DtrEnable = value;
                Properties.Settings.Default.Leonardo = value;
            }
        }

        public int Baud
        {
            get
            {
                return serialRead.BaudRate;
            }
            set
            {
                serialRead.BaudRate = value;
                serialWrite.BaudRate = value;
                Properties.Settings.Default.BaudRate = value;
            }
        }

        public string ReadPortName
        {
            get
            {
                return serialRead.PortName;
            }
            set
            {
                serialRead.PortName = value;
                Properties.Settings.Default.ReadPortName = value;
            }
        }

        public string WritePortName
        {
            get
            {
                return serialWrite.PortName;
            }
            set
            {
                serialWrite.PortName = value;
                Properties.Settings.Default.WritePortName = value;
            }
        }

        public void Open()
        {
            try
            {
                serialWrite.Open();
                if (!shared)
                    serialRead.Open();
                Properties.Settings.Default.Save();
                OnOpenEvent();
            }
            catch
            {
                OnDropEvent(new MessageEventArgs("Failed to open serial port."));
                Close();
            }
        }

        public void Close()
        {
            if (serialWrite.IsOpen)
                serialWrite.Close();
            if (serialRead.IsOpen)
                serialRead.Close();
            OnCloseEvent();
        }

        public void Write(string s)
        {
            try
            {
                serialWrite.Write(s);
            }
            catch
            {
                OnDropEvent(new MessageEventArgs("Connection dropped."));
                Close();
            }
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string inData = sp.ReadExisting();
            OnReceiveEvent(new MessageEventArgs(inData));
        }

        public bool isConnected
        {
            get
            {
                return serialWrite.IsOpen;
            }
        }

        public string[] availablePorts
        {
            get
            {
                return SerialPort.GetPortNames().OrderBy(s => s).ToArray();
            }
        }
    }
}
