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
using System.Threading;

namespace poc_pcr_for_Tester
{
    public partial class ucTestStart : UserControl
    {
        PcrProtocol serial = new PcrProtocol();
        public Dictionary<string, string> cmd_dic;

        public event EventHandler btnTestStart_Event;
        public event EventHandler startTest_Back_Event;
        public ucTestStart()
        {
            InitializeComponent();
            btnTestStart.Click += btnTestStart_Click_Event;
            picBox_Back.Click += startTest_Back_Click_Event;
        }



        private void ucTestStart_Load(object sender, EventArgs e)
        {
            cmd_dic = new Dictionary<string, string>();

            cmd_dic.Add(":ROUTINE_CYCLE_MAX", "");
            cmd_dic.Add(":OPTIC_OPERATION_KEEPING_TEMP_SEC", "");
            cmd_dic.Add(":OPTIC_NO_OPERATION_KEEPING_TEMP_SEC", "");
            cmd_dic.Add(":DELAY_TIME_BEFORE_OPTING_RUNING", "");
            cmd_dic.Add(":KEEPING_MINUTE_PELTIER_TEMPERATURE", "");
            cmd_dic.Add(":KEEPING_TIME_FOR_HIGH_TEMPERATURE", "");
            cmd_dic.Add(":HEAT_SETPOINT", "");
            cmd_dic.Add(":COOL_SETPOINT", "");

            cmd_dic.Add(":PRE_COND_SETPOINT", "");
            cmd_dic.Add(":PRECOND_KEEPING_TIME_MIN", "");

            cmd_dic.Add(":RT_PRE_COND_SETPOINT", "");
            cmd_dic.Add("RT_PRECOND_KEEPING_TIME_MIN", "");
        }

        public void btnTestStart_Click_Event(object sender, EventArgs e)
        {
            if (this.btnTestStart_Event != null)
                btnTestStart_Event(sender, e);
        }

        public void startTest_Back_Click_Event(object sender, EventArgs e)
        {
            if (this.startTest_Back_Event != null)
                startTest_Back_Event(sender, e);
        }

        private void btnTestStart_Click(object sender, EventArgs e)
        {
            // 시작 명령 전송
            //serial.SendLine(":start");
            //MessageBox.Show("검사시작", "설정 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Check_Start_Click(object sender, EventArgs e)
        {
            //serial.SendLine(":check_start");
            //MessageBox.Show("시작 전 체크", "설정 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Send_Protocol_Click(object sender, EventArgs e)
        {
            {
                cmd_dic[":FINAL_CYCLE"] = "45";//tb_FianlCycle_Eng.Text;
                cmd_dic[":OPTIC_OPERATION_KEEPING_TEMP_SEC"] = "35"; //tb_OCHoldSec_Eng.Text;
                cmd_dic[":2nd_STEP_KEEPING_TIME_SEC"] = "30";//tb_2HoldSec_Eng.Text;
                cmd_dic[":DELAY_TIME_BEFORE_OPTING_RUNING"] = "10";//tb_OCDelaySec_Eng.Text;
                
                cmd_dic[":1st_STEP_KEEPING_TIME_SEC"] = "10";//tb_1HoldSec_Eng.Text;
                cmd_dic[":1st_STEP_SETPOINT"] = "100";//tb_1Temp_Eng.Text;
                cmd_dic[":2nd_STEP_SETPOINT"] = "65";//tb_2Temp_Eng.Text;

                cmd_dic[":PRE_COND_SETPOINT"] = "100";//tb_PreTemp_Eng.Text;
                cmd_dic[":PRECOND_KEEPING_TIME_MIN"] = "1";//tb_PreHoldSec_Eng.Text;

                cmd_dic[":RT_PRE_COND_SETPOINT"] = "50";//tb_RT_PreTemp_Eng.Text;
                cmd_dic[":RT_PRECOND_KEEPING_TIME_MIN"] = "1";//tb_RT_PreHoldSec_Eng.Text;


                foreach (String cmd in cmd_dic.Keys)
                {
                    if (cmd_dic[cmd] != null && cmd_dic[cmd] != "")
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(cmd);
                        sb.Append(" ");
                        sb.Append(cmd_dic[cmd]);

                        String txt = sb.ToString();
                        //Apply_txt = txt;

                        // 연속 전송시 딜레이를 둠
                        Thread.Sleep(200);
                        serial.SendLine(txt);
                    }
                }
            }
            MessageBox.Show("레시피 설정 값을 MCU로 전송했습니다.", "설정 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
