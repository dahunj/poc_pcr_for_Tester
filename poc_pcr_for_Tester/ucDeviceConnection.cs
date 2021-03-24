using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using poc_pcr_for_Tester.SerialComm;

namespace poc_pcr_for_Tester
{
    public partial class ucDeviceConnection : UserControl
    {
        PcrProtocol serial = PcrProtocol.GetInstance();
        SharedMemory sm = SharedMemory.GetInstance();

        public event EventHandler btn_Connect_Main_Event;
        public event EventHandler btn_GetPorts_Event;
        public event EventHandler btn_DeviceConnectionNext_Event;
        public ucDeviceConnection()
        {
            InitializeComponent();

            btn_Connect_Main.Click += btn_Connect_Main_Click_Event;
            btn_GetPorts.Click += btn_GetPorts_Click_Event;
            picBox_deviceConnectionNext.Click += btn_Next_Click_Event;
        }

        private void ucDeviceConnection_Load(object sender, EventArgs e)
        {
            string[] comlist = System.IO.Ports.SerialPort.GetPortNames();
            //COM Port가 있는 경우에만 콤보 박스에 추가.
            if (comlist.Length > 0)
            {
                cb_Port_Main.Items.AddRange(comlist);
                //제일 처음에 위치한 녀석을 선택
                cb_Port_Main.SelectedIndex = 0;
            }
        }

        public void btn_Connect_Main_Click_Event(object sender, EventArgs e)
        {
            if (this.btn_Connect_Main_Event != null)
                btn_Connect_Main_Event(sender, e);
        }

        public void btn_GetPorts_Click_Event(object sender, EventArgs e)
        {
            if (this.btn_GetPorts_Event != null)
                btn_GetPorts_Event(sender, e);
        }

        public void btn_Next_Click_Event(object sender, EventArgs e)
        {
            if (this.btn_DeviceConnectionNext_Event != null)
                btn_DeviceConnectionNext_Event(sender, e);
        }

        private void cb_Port_Main_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void btn_Connect_Main_Click(object sender, EventArgs e)
        {
            try
            {
                sm.DevicePort = cb_Port_Main.SelectedItem.ToString();
                bool flag = Open_exec();
            }
            catch(Exception ex)
            {
                
            }
            
            if (sm.isDeviceConnected)
            {
                //tb_ID_Main.Enabled = true;
                //tb_PW_Main.Enabled = true;
                //btn_Login_Main.Enabled = true;
                btn_Connect_Main.Text = "Disconnect";
            }
            else
            {
                //tb_ID_Main.Enabled = false;
                //tb_PW_Main.Enabled = false;
                //btn_Login_Main.Enabled = false;
                btn_Connect_Main.Text = "Connect";
            }
        }

        public void btn_GetPorts_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cb_Port_Main.Items.Count; i++)
            {
                cb_Port_Main.Items.RemoveAt(0);
            }
            string[] comlist = System.IO.Ports.SerialPort.GetPortNames();
            //COM Port가 있는 경우에만 콤보 박스에 추가.
            if (comlist.Length > 0)
            {
                cb_Port_Main.Items.AddRange(comlist);
                //제일 처음에 위치한 녀석을 선택
                cb_Port_Main.SelectedIndex = 0;
            }
        }


        private bool Open_exec()
        {
            if (sm.isDeviceConnected)
            {
                serial.Close();
                sm.isDeviceConnected = false;
                //ConnectChanged(this, EventArgs.Empty);
                return false;
            }
            else
            {
                bool success = false;

                if ((serial != null) && (serial.IsConnect() == false))
                {
                    bool tryConnect = false;

                    try
                    {
                        tryConnect = serial.Connect(sm.DevicePort); //serial.Connect(cb_Port_Main.SelectedItem.ToString());
                    }
                    catch
                    { }

                    if (tryConnect)
                    {
                        if (true)
                        {
                            //Open_cmd.CanSet = false;
                            sm.isDeviceConnected = true;
                            success = true;
                            return true;
                        }
                    }
                }

                if (success != true)
                {

                }
                else
                {

                }

                return false;
            }
        }

    }
}
