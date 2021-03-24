
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using poc_pcr_for_Tester.GraphPlot;
using poc_pcr_for_Tester.SerialComm;

//this is master 

namespace poc_pcr_for_Tester
{
    enum TUBE_INDEX
    {
        FAM = 0,
        HEX,
        ROX,
        CY5
    }

    public partial class UI_for_Tester : Form
    {
        PcrProtocol serial = PcrProtocol.GetInstance();
        
        // User Controls
        ucFirstPage firstPage = new ucFirstPage();
        ucTestInfo testInfo = new ucTestInfo();
        ucTestPreparation testPreparation = new ucTestPreparation();
        ucTestStart testStart = new ucTestStart();
        ucRunning running = new ucRunning();
        ucDeviceConnection dConnection = new ucDeviceConnection();
        ucSelectTest selectTest = new ucSelectTest();
        ucGraph graph = new ucGraph();

        SharedMemory sm = SharedMemory.GetInstance();

        LogWriter logToFile = new LogWriter();



        string strData;
        bool globRecv = false;
        string waitData;
        string[] procData;
        bool bSaveLog = true;

        bool firstRecv = false;
        int recv_cnt = 0;
        int routine_cnt = -1;

        // 시작여부 확인용
        bool b_start_Process = false;
        bool b_check_Door = false;
        static int nTimerNo = 0;

     


        int iRoutine_cnt = 0;
        int iTube_no = 0;
        int iDye = 0;

        public Dictionary<String, String> cmd_dic;
        int step = 0;


        public UI_for_Tester()
        {
            InitializeComponent();

            sm.testName = "COVID"; //default COVID

            //serial comm Async receive
            serial.ReceivedEvent += GetSerialString;
            //serial.ReceivedPacketEvent += RxPacket_CallBack;

            firstPage.btnNewTest_Event += btnNewTest_Click;
            firstPage.btnPrevious_Event += btnPreviousTest_Click;
            firstPage.firstPage_Back_Event += firstPage_Back_Click;

            testInfo.btnTestInfoNext_Event += btnTestInfoNext_Click;
            testInfo.testInfo_Back_Event += testInfo_Back_Click;

            testPreparation.btnTestPreparationNext_Event += btnTestPreparationNext_Click;
            testPreparation.testPreparation_Back_Event += testPreparation_Back_Click;

            testStart.btnTestStart_Event += btnStartTest_Click;
            testStart.startTest_Back_Event += startText_Back_Click;


            dConnection.btn_Connect_Main_Event += btn_Connect_Main_ClickBy;
            dConnection.btn_GetPorts_Event += btn_GetPorts_ClickBy;
            dConnection.btn_DeviceConnectionNext_Event += btn_dConnectionNext_ClickBy;

            selectTest.cbBoxSelectTest_Event += selectTest_selectedIndexChanged;
            selectTest.SelectTest_NextPage_Event += selectTestNext_Click;

            running.running_NextPage_Event += running_NextPage_Click;

            graph.graph_Back_Event += graph_Back_Click;

        }

        private void UI_for_Tester_Load(object sender, EventArgs e)
        {
            sm.isFileSaved_In_Local = false;

            sm.MEASURED_DATA = new string[Plotter.CH_CNT * Plotter.DYE_CNT, Plotter.COL_CNT];
            sm.DISPLAY_DATA = new string[Plotter.CH_CNT * Plotter.DYE_CNT, Plotter.COL_CNT];

            panel_ui.Controls.Add(firstPage);
            panel_ui.Controls.Add(testInfo);
            panel_ui.Controls.Add(testPreparation);
            panel_ui.Controls.Add(testStart);
            panel_ui.Controls.Add(running);
            panel_ui.Controls.Add(dConnection);
            panel_ui.Controls.Add(selectTest);
            panel_ui.Controls.Add(graph);
            panel_ui.Visible = true;

            selectPageYouWantToDisplay(dConnection);

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
            //Open_exec();
        }



        public void selectPageYouWantToDisplay(UserControl pageYouWantToShow)
        {
            dConnection.Visible = false;
            firstPage.Visible = false;
            selectTest.Visible = false;
            testInfo.Visible = false;
            testPreparation.Visible = false;
            testStart.Visible = false;
            running.Visible = false;
            

            pageYouWantToShow.Visible = true;
        }

        private void btn_dConnectionNext_ClickBy(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(firstPage);
        }

        private void btn_Connect_Main_ClickBy(object sender, EventArgs e)
        {
            //panel_ui


            // 컴포트 선택 후 연결 버튼 클릭하면 ID, PW 입력창이 활성화됨
            //showLog("장치와 연결 동작");

            //컴포트 연결시도
            //bool flag = Open_exec();

            bool flag = true; //temporary for debug
            //if (flag)
            //{
            //    firstPage.Visible = true;
            //    testInfo.Visible = false;
            //    testPreparation.Visible = false;
            //    testStart.Visible = false;
            //    running.Visible = false;
            //    dConnection.Visible = false;
            //}
            //else
            //{
            //    firstPage.Visible = false;
            //    testInfo.Visible = false;
            //    testPreparation.Visible = false;
            //    testStart.Visible = false;
            //    running.Visible = false;
            //    dConnection.Visible = true;
            //}

            //added by dahunj
            //tb_Log.Visible = true;

            //연결에 성공하면

        }

        public void btn_GetPorts_ClickBy(object sender, EventArgs e)
        {
            //string[] comlist = System.IO.Ports.SerialPort.GetPortNames();

            //dConnection.btn_GetPorts_Click(null, null);
        }

        /// First page of UI
        private void btnNewTest_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(selectTest);
        }
        private void btnPreviousTest_Click(object sender, EventArgs e)
        {

        }

        private void firstPage_Back_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(dConnection);
        }

        /// Test Information page
        private void selectTestNext_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(testInfo);
        }

        private void testInfo_Back_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(selectTest);
        }

        /// Test Information page
        private void btnTestInfoNext_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(testPreparation);
        }


       private void testPreparation_Back_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(testInfo);
            //SetProtocolAuto();
        }

        /// Test preparation page 
        private void btnTestPreparationNext_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(testStart);
            SetProtocolAuto(sm.testName);
        }

        private void running_NextPage_Click(object sender, EventArgs e)
        {
            //panel_ui
            selectPageYouWantToDisplay(graph);
        }

        private void graph_Back_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(testStart);
        }


        public void SetProtocolAuto(string testName)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists) di.Create();

            string fileName = di.ToString() + "\\" + testName + ".rcp";//string fileName = di.ToString() + "\\COVID.txt";

            string[] lines = File.ReadAllLines(fileName);

            int readNum = 1;
            string temp = "";

            string[] result = new string[11];

            for (int i = 0; i < lines.Length; i++) //데이터가 존재하는 라인일 때에만, label에 출력한다.
            {
                temp = lines[i];

                char[] sep = { ',' };

                result = temp.Split(sep);
            }
            //tb_FianlCycle_Eng.Text;

            cmd_dic[":RT_PRE_COND_SETPOINT"] = result[0];//tb_RT_PreTemp_Eng.Text;
            cmd_dic[":RT_PRECOND_KEEPING_TIME_MIN"] = result[1];//tb_RT_PreHoldSec_Eng.Text;

            cmd_dic[":PRE_COND_SETPOINT"] = result[2];//tb_PreTemp_Eng.Text;
            cmd_dic[":PRECOND_KEEPING_TIME_MIN"] = result[3];//tb_PreHoldSec_Eng.Text;
            
            cmd_dic[":1st_STEP_SETPOINT"] = result[4];//tb_1Temp_Eng.Text;
            cmd_dic[":1st_STEP_KEEPING_TIME_SEC"] = result[5];//tb_1HoldSec_Eng.Text;
            
            cmd_dic[":2nd_STEP_SETPOINT"] = result[6];//tb_2Temp_Eng.Text;
            cmd_dic[":2nd_STEP_KEEPING_TIME_SEC"] = result[7];//tb_2HoldSec_Eng.Text;


            cmd_dic[":DELAY_TIME_BEFORE_OPTING_RUNING"] = result[8];//tb_OCDelaySec_Eng.Text;
            cmd_dic[":OPTIC_OPERATION_KEEPING_TEMP_SEC"] = result[9]; //tb_OCHoldSec_Eng.Text;

            cmd_dic[":FINAL_CYCLE"] = result[10];
            /*
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
            */

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
            
            //MessageBox.Show("레시피 설정 값을 MCU로 전송했습니다.", "설정 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void startText_Back_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(testPreparation);
        }
        /// ucTestStart
        /// test start button!!!!
        private void btnStartTest_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(running);
            _start_Process();
            MessageBox.Show("검사시작", "설정 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*
            switch (step)
            {
                case 0:
                    step = 1;
                    break;
                case 1:
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(":SHOW_GLOB_VARS");

                        String txt = sb.ToString();
                        //Apply_txt = txt;
                        serial.SendLine(txt);
                    }
                    MessageBox.Show("검사체크", "설정 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    step = 2;
                    break;
                case 2:
                    serial.SendLine(":check_start");
                    //selectPageYouWantToDisplay(running);
                    MessageBox.Show("검사 체크", "설정 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    step = 3;
                    break;
                case 3:
                    _start_Process();
                    MessageBox.Show("검사시작", "설정 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //selectPageYouWantToDisplay(running);
                    step = 0;
                    break;
            }
            */
            
        }

        private void _start_Process()
        {
            bSaveLog = true;
            logToFile.MakeNewFile();

            serial.SendLine(":start");
        }

        private void _reset_Process()
        {
            logToFile.CloseFile();
            bSaveLog = false;
        }

        /// Firs
        private void selectTest_selectedIndexChanged(object sender, EventArgs e)
        {
            //panel_ui
            selectPageYouWantToDisplay(testInfo);
        }

       

        //



        struct DataParameter
        {
            public int Delay;
        }

        private DataParameter _inputparameter;


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            int delay = ((DataParameter)e.Argument).Delay;
            int index = 0;
            try
            {
                if (!backgroundWorker1.CancellationPending)
                {

                    Thread.Sleep(delay);
                }

            }
            catch (Exception ex)
            {
                backgroundWorker1.CancelAsync();
                //MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIon.Error);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(sm.isFileSaved_In_Local)
            {
                MatchAndFindOpticDataForResult();
            }
            else
            {
                MatchAndFindOpticDataForResultForRealTime();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                _inputparameter.Delay = 0;

                backgroundWorker1.RunWorkerAsync(_inputparameter);
            }
        }



        void GetSerialString(object sender)
        {
                byte[] raw;
                strData = serial.ReceiveString(out raw);
                //SetDataBox(strData);
                strData = strData.Replace(" ", "");

                if (strData.Contains("<"))
                {
                    globRecv = true;
                }

                waitData += strData;

                if (strData.Contains("-"))
                {
                    globRecv = false;
                }


                if (!globRecv)
                {
                    if (waitData.IndexOf('\n') > -1)
                    {
                        procData = waitData.Split('\n');
                        foreach (string tmp in procData)
                        {
                            SetCommRXProc(tmp);
                            waitData = "";
                        }
                    }
                }

                if (bSaveLog)
                {
                    if ((!string.IsNullOrEmpty(strData)) && (strData.Length > 0))
                    {
                        logToFile.Append(strData);
                        //sm.isLogSaving = false;
                    }
                }
           
        }


        public void SetCommRXProc(string str)
        {
            str = str.Replace(" ", "");
            //str = str.Replace("-", "");
            //str = str.Replace(">", "");
            //str = str.Replace("<", "");

            string[] commVar = str.Split('=');
            if (commVar.Length > 1)
            {
                if (commVar[0].Equals("g_FINAL_CYCLE"))
                {
                    //tb_FianlCycleMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_FianlCycleMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_OPTIC_OPERATION_KEEPING_TEMP_SEC"))
                {
                    //tb_OCHoldSecMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_OCHoldSecMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_2nd_STEP_KEEPING_TIME_SEC"))
                {
                    //tb_2HoldSecMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_2HoldSecMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_DELAY_TIME_BEFORE_OPTING_RUNING"))
                {
                    //tb_OCDelaySecMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_OCDelaySecMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_PRECOND_KEEPING_TIME_MIN"))
                {
                    //tb_PreHoldSecMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_PreHoldSecMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_1st_STEP_KEEPING_TIME_SEC"))
                {
                    //tb_1HoldSecMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_1HoldSecMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_1st_STEP_SETPOINT"))
                {
                    //tb_1TempMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_1TempMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_2nd_STEP_SETPOINT"))
                {
                    //tb_2TempMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_2TempMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_PRE_COND_SETPOINT"))
                {
                    //tb_PreTempMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_PreTempMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_RT_PRE_COND_SETPOINT"))
                {
                    //tb_PreTempMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_RT_PreTempMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_RT_PRECOND_KEEPING_TIME_MIN"))
                {
                    //tb_PreTempMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_RT_PreHoldSecMCU_Eng, commVar[1]);
                }
                else if (commVar[0].Equals("g_rountine_cnt"))
                {
                    //tb_PreTempMCU_Eng.Text = commVar[1];
                    //SetTextBox(tb_PreTempMCU_Eng, commVar[1]);
                    Int32.TryParse(commVar[1], out routine_cnt);
                    sm.routine_cnt = routine_cnt;
                }

            }

            if (str.Equals("g_check_door\n") || str.Equals("g_check_door"))
            {
                //_check_Door();
                b_check_Door = true;
            }
            else if (str.Equals("g_ok_door\n") || str.Equals("g_ok_door"))
            {
                //_start_Process();
                b_start_Process = true;
            }
            else if (str.Equals("g_end_process") || str.Equals("g_end_process\n"))
            {
                //_endProcess();
                //sm.opticReceivedFlag = true;
            }
            else if (str.Equals("pel>Cycledone\n") || str.Equals("pel>Cycledone"))
            {
                //_endProcess();
                //_check_Door();
                //b_check_Door = true;
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


        public void MatchAndFindOpticDataForResultForRealTime()
        {
            string sPath;
            string sFileName;

            sPath = Path.Combine(Environment.CurrentDirectory, "log");
            //sFileName = Path.Combine(sPath, ".txt");

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(sPath);
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".txt") == 0)
                {
                    String FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                    String FullFileName = File.FullName;
                    //MessageBox.Show(FullFileName + " " + FileNameOnly);
                }
            }
            string fileName = "";
            //if (checkBox3.Checked)
            //{
            //    fileName = sm.currentLogFileName;
            //}
            //else
            {
                fileName = sPath + @"\" + sm.current_Log_Name + ".txt"; //di.ToString() + "\\" + str + ".rcp";
            }
            //string fileName = sPath + @"\" + "temp" + ".txt"; //di.ToString() + "\\" + str + ".rcp";

            //string fileName = sPath + @"\Pcr 2021-02-24 17-46-11.txt";//@"\Pcr 2021-02-16 13-25-31" + ".txt";

            try
            {
                int line_count = 0;

                //string[] lines = File.ReadAllLines(fileName);
                sm.allDataArray = sm.allData.Split('\n');
                line_count = sm.allDataArray.Length;//line_count = File.ReadAllLines(fileName).Length;

                for (int i = 0; i < line_count; i++)
                {
                    //if (lines[i].Contains("optd") && sm.measured_cnt > -1)
                    if (sm.allDataArray[i].Contains("optd") && sm.measured_cnt > -1)
                    {
                        string temp = sm.allDataArray[i];

                        char[] sep = { ',' };
                        string[] result = temp.Split(sep);

                        char[] sep2 = { '=' };
                        string[] routine_cnt = result[1].Split(sep2);

                        Int32.TryParse(routine_cnt[1], out iRoutine_cnt);

                        string[] tube_no = result[2].Split(sep2);
                        Int32.TryParse(tube_no[1], out iTube_no);

                        string[] dye = result[3].Split(sep2);

                        int dye_idx = 0;
                        if (dye[0] == "e1d1[0]")
                        {
                            dye_idx = (int)TUBE_INDEX.FAM;
                        }
                        else if (dye[0] == "e2d2[0]")
                        {
                            dye_idx = (int)TUBE_INDEX.HEX;
                        }
                        else if (dye[0] == "e1d1[1]")
                        {
                            dye_idx = (int)TUBE_INDEX.ROX;
                        }
                        else if (dye[0] == "e2d2[1]")
                        {
                            dye_idx = (int)TUBE_INDEX.CY5;
                        }

                        Int32.TryParse(dye[1], out iDye);

                        for (int j = 0; j < Plotter.COL_CNT; j++)
                        {
                            if (Plotter.Optic_Measure_Idx[j] == iRoutine_cnt)
                            {
                                Plotter.isOpticData_buffer_filled[j]++;
                                sm.MEASURED_DATA[4 * (iTube_no - 1) + dye_idx, j] = iDye.ToString();
                                sm.DISPLAY_DATA[4 * (iTube_no - 1) + dye_idx, j] = iDye.ToString();
                                if (sm.MEASURED_DATA[4 * (iTube_no - 1) + dye_idx, j] == "0")
                                {
                                    //MEASURED_DATA[4 * (iTube_no - 1) + dye_idx, j] = "";
                                }
                                sm.DataUpdateFlag = true;


                                

                            }
                        }
                    }
                    else if (sm.allDataArray[i].Contains("pel>Cycledone\n") )//lines[i].Contains("g_end_process") 
                    {
                        //_endProcess();
                        sm.ProcessEndFlag = true;
                    }

                }
            }
            catch (Exception ex)
            {
                //logToFile.Append(ex.ToString());
            }


        }

      

        public void MatchAndFindOpticDataForResult()
        {
            string sPath;
            string sFileName;

            sPath = Path.Combine(Environment.CurrentDirectory, "log");
            //sFileName = Path.Combine(sPath, ".txt");

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(sPath);
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".txt") == 0)
                {
                    String FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                    String FullFileName = File.FullName;
                    //MessageBox.Show(FullFileName + " " + FileNameOnly);
                }
            }
            string fileName = "";
            if (sm.isFileSaved_In_Local)
            {
                //fileName = sm.currentLogFileName;
                fileName = sPath + @"\Pcr 2021-03-18 16-57-00.txt";//@"\Pcr 2021-02-16 13-25-31" + ".txt";
            }
            else
            {
                fileName = sPath + @"\" + sm.current_Log_Name + ".txt"; //di.ToString() + "\\" + str + ".rcp";
            }
            //string fileName = sPath + @"\" + "temp" + ".txt"; //di.ToString() + "\\" + str + ".rcp";

            


            int line_count = 0;
            string[] lines = File.ReadAllLines(fileName);
            line_count = File.ReadAllLines(fileName).Length;

            for (int i = 0; i < line_count; i++)
            {
                if (lines[i].Contains("optd") && sm.measured_cnt > -1)
                //if (lines[i].Contains("routine_cnt"))
                {
                    string temp = lines[i];

                    char[] sep = { ',' };
                    string[] result = temp.Split(sep);

                    char[] sep2 = { '=' };
                    string[] routine_cnt = result[1].Split(sep2);

                    Int32.TryParse(routine_cnt[1], out iRoutine_cnt);

                    string[] tube_no = result[2].Split(sep2);
                    Int32.TryParse(tube_no[1], out iTube_no);

                    string[] dye = result[3].Split(sep2);

                    int dye_idx = 0;
                    if (dye[0] == "e1d1[0]")
                    {
                        dye_idx = (int)TUBE_INDEX.FAM;
                    }
                    else if (dye[0] == "e2d2[0]")
                    {
                        dye_idx = (int)TUBE_INDEX.HEX;
                    }
                    else if (dye[0] == "e1d1[1]")
                    {
                        dye_idx = (int)TUBE_INDEX.ROX;
                    }
                    else if (dye[0] == "e2d2[1]")
                    {
                        dye_idx = (int)TUBE_INDEX.CY5;
                    }

                    Int32.TryParse(dye[1], out iDye);

                    for (int j = 0; j < Plotter.COL_CNT; j++)
                    {
                        if (Plotter.Optic_Measure_Idx[j] == iRoutine_cnt)
                        {
                            Plotter.isOpticData_buffer_filled[j]++;
                            sm.MEASURED_DATA[4 * (iTube_no - 1) + dye_idx, j] = iDye.ToString();
                            sm.DISPLAY_DATA[4 * (iTube_no - 1) + dye_idx, j] = iDye.ToString();
                            if (sm.MEASURED_DATA[4 * (iTube_no - 1) + dye_idx, j] == "0")
                            {
                                //MEASURED_DATA[4 * (iTube_no - 1) + dye_idx, j] = "";
                            }
                            sm.DataUpdateFlag = true;
                           

                        }
                    }
                }
                else if (lines[i].Contains("pel>Cycledone\n") //lines[i].Contains("g_end_process") 
                   
                    && !sm.DataUpdateFlag)
                {
                    //_endProcess();
                    sm.ProcessEndFlag = true;
                }
            }

        }

    }

}
