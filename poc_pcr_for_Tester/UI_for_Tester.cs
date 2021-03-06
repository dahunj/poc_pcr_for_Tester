
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        ucTestReport testReport = new ucTestReport();
        ucInterpretation interpretation = new ucInterpretation();

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

            sm.testName = "TB"; //default COVID

            //serial comm Async receive
            serial.ReceivedEvent += GetSerialString;
            //serial.ReceivedPacketEvent += RxPacket_CallBack;

            firstPage.btnNewTest_Event += btnNewTest_Click;
            firstPage.btnPrevious_Event += btnPreviousTest_Click;
            firstPage.firstPage_Back_Event += firstPage_Back_Click;

            testInfo.btnTestInfoNext_Event += btnTestInfoNext_Click;
            testInfo.testInfo_Back_Event += testInfo_Back_Click;
            testInfo.testInfo_Exit_Event += Exit_Click;

            testPreparation.btnTestPreparationNext_Event += btnTestPreparationNext_Click;
            testPreparation.testPreparation_Back_Event += testPreparation_Back_Click;

            testStart.btnTestStart_Event += btnStartTest_Click;
            testStart.startTest_Back_Event += startText_Back_Click;


            dConnection.btn_Connect_Main_Event += btn_Connect_Main_ClickBy;
            dConnection.btn_GetPorts_Event += btn_GetPorts_ClickBy;
            dConnection.btn_DeviceConnectionNext_Event += btn_dConnectionNext_ClickBy;

            selectTest.cbBoxSelectTest_Event += selectTest_selectedIndexChanged;
            selectTest.SelectTest_NextPage_Event += selectTestNext_Click;
            selectTest.selectTest_BackPage_Event += selectTestBack_Click;

            running.running_NextPage_Event += running_NextPage_Click;
            running.running_BackPage_Event += running_BackPage_Click;

            graph.graph_Back_Event += graph_Back_Click;

            testReport.testReportNext_Event += testReport_Btn_Next_Click;
        }

        private void UI_for_Tester_Load(object sender, EventArgs e)
        {
            sm.isFileSaved_In_Local = true;

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
            panel_ui.Controls.Add(testReport);
            panel_ui.Controls.Add(interpretation);
            panel_ui.Visible = true;


            
            selectPageYouWantToDisplay(interpretation);
            //selectPageYouWantToDisplay(dConnection);

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
            testReport.Visible = false;
            graph.Visible = false;

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

        private void selectTestBack_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(firstPage);
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

        private void Exit_Click(object sender, EventArgs ee)
        {
            UI_for_Tester_FormClosing(sender, null);
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

        private void running_BackPage_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(testStart);
        }

        private void running_NextPage_Click(object sender, EventArgs e)
        {
            //panel_ui
            selectPageYouWantToDisplay(testReport);

            //graph process
            //updateOpticDataGraph();

        }

        public void updateOpticDataGraph()
        {
            //1. get measured data
            MatchAndFindOpticDataForResult();
            //2. find and calculate baseline value with standard deviation 
            FindCyclesForBaseCalculation();

            baseCalculationDeviation();
            //3. scale factor calculation 
            scaleFactorCalculation();
            //4. ct cycle calculation 
            CtCyclesCalculation();

            updateDataGridOpticDatas(sm.DISPLAY_DATA);
            //5. update graph 
            //updateAllPlots();
        }

        private void testReport_Btn_Next_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(graph);
        }

        private void graph_Back_Click(object sender, EventArgs e)
        {
            selectPageYouWantToDisplay(running);
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
            sm.ProcessEndFlag = false;
            bSaveLog = true;
            logToFile.MakeNewFile();

            serial.SendLine(":start");
        }

        private void _reset_Process()
        {
            logToFile.CloseFile();
            bSaveLog = false;
            sm.ProcessEndFlag = false;
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
               //MatchAndFindOpticDataForResult();
            }
            else
            {
                //MatchAndFindOpticDataForResultForRealTime();
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
                sm.ProcessEndFlag = true;

                selectPageYouWantToDisplay(testReport);
                //_endProcess();
                //_check_Door();
                //b_check_Door = true;
            }
            else if (str.Contains("LOGpel_startext_seq_id=0") || str.Contains("LOGpel_startext_seq_id=0\n"))
            {
                sm.ProgressFirst = 8;
            }
            else if (str.Equals("PEL:JOB_READY") || str.Equals("PEL:JOB_READY\n"))
            {
                sm.ProgressFirst = 10;
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
                fileName = sPath + @"\Pcr 2021-03-19 15-02-55.txt";//@"\Pcr 2021-02-16 13-25-31" + ".txt";
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


        public double[] baseCalculationDeviation()
        {
            int temp;

            double[] base_avg = new double[Plotter.CH_CNT * Plotter.DYE_CNT];
            double[] base_temp = new double[Plotter.COL_CNT];
            double[] base_deviation = new double[Plotter.CH_CNT * Plotter.DYE_CNT];


            for (int l = 0; l < Plotter.COL_CNT; l++)
            {
                base_temp[l] = 0;
            }


            for (int k = 0; k < Plotter.CH_CNT * Plotter.DYE_CNT; k++)
            {
                //BaselineVal[k] = 0;
                base_avg[k] = 0;
            }

            for (int i = 0; i < 16; i++)
            {
                string sigma_scale = "10";//dgv_diagnosis_ct.Rows[i].Cells[1].FormattedValue.ToString();

                double fSigma_scale;
                fSigma_scale = Convert.ToDouble(sigma_scale);
                //Int32.TryParse(ct_temp, out iCt_temp);
                for (int j = 0; j < Plotter.COL_CNT; j++)
                {
                    if (Plotter.isThisCycleWouldbeUsedForBaseCal[j] == 1)
                    {
                        if (j > Plotter.MaxCycleForBaseCalculation)
                            Plotter.MaxCycleForBaseCalculation = j;

                        base_temp[j] = Convert.ToDouble(sm.MEASURED_DATA[i, j]);

                        //Int32.TryParse(MEASURED_DATA[i, j], out temp);
                        base_avg[i] += base_temp[j];
                    }
                    else
                    {
                        base_temp[j] = 0;
                    }
                }

                base_avg[i] = (base_avg[i]) / (Plotter.CycleCntForBaseCal);
                sm.BaselineVal[i] = base_avg[i];

                for (int m = 0; m < Plotter.COL_CNT; m++)
                {
                    if (Plotter.isThisCycleWouldbeUsedForBaseCal[m] == 1)
                    {
                        base_temp[m] = Convert.ToDouble(sm.MEASURED_DATA[i, m]);

                        base_deviation[i] += (base_temp[m] - base_avg[i]) * (base_temp[m] - base_avg[i]);
                    }
                }
                base_deviation[i] /= Plotter.CycleCntForBaseCal;
                base_deviation[i] = Math.Pow(base_deviation[i], 0.5);
                //Int32.TryParse(MEASURED_DATA[i, 0], out ic_value[i]);
                //CtlineVal[i] = (double)(iCt_temp * BaselineVal[i]);
                //ic_value[i] = MEASURED_DATA[i, 0];
                sm.CtlineVal[i] = base_avg[i] + (fSigma_scale * base_deviation[i]);
            }
            return base_deviation;
        }

        public void scaleFactorCalculation()
        {
            for (int i = 0; i < 16; i++)
            {
                sm.scaleFactor[i] = (double)(2500 / (2500 - sm.BaselineVal[i]));
            }
        }

        public double[] CtCyclesCalculation()
        {
            double tempCt = 0;
            double value = 0;

            for (int i = 0; i < 16; i++)
            {
                tempCt = 0;
                for (int j = 0; j < Plotter.COL_CNT; j++)
                {
                    value = (Convert.ToDouble(sm.MEASURED_DATA[i, j]) - sm.BaselineVal[i]) * sm.scaleFactor[i];
                    if (value < 0) value = 0;
                    //if (Convert.ToDouble(MEASURED_DATA[i, j]) > CtlineVal[i])
                    if (value > (sm.CtlineVal[i] - sm.BaselineVal[i]) * sm.scaleFactor[i])
                    {
                        Plotter.CtCycles[i] = j; // start at 3 cycles
                        tempCt = j;
                        break;
                    }
                    else if (value < (sm.CtlineVal[i] - sm.BaselineVal[i]) * sm.scaleFactor[i])
                    {
                        Plotter.CtCycles[i] = 0;
                    }
                }
                if (tempCt < 10)
                {

                }
                else
                {
                    double tempCtline = Convert.ToDouble(sm.MEASURED_DATA[i, (int)tempCt - 1]);
                    double delta = Math.Abs(((Convert.ToDouble(sm.MEASURED_DATA[i, (int)tempCt]) - tempCtline)) / 100);
                    delta *= sm.scaleFactor[8];
                    Plotter.CtCycles[i] = tempCt;
                    for (int k = 0; k < 100; k++)
                    {
                        Plotter.CtCycles[i] += 0.01;
                        if (((tempCtline - sm.BaselineVal[i]) * sm.scaleFactor[i] + (delta * k)) >= (sm.CtlineVal[i] - sm.BaselineVal[i]) * sm.scaleFactor[i])
                        {
                            Plotter.CtCycles[i] += sm.scaleFactor[i];
                            break;
                        }
                        //else
                        //{
                        //    if (k == 99) Plotter.CtCycles[i] = 0;
                        //}
                    }

                    if (Plotter.CtCycles[i] < 12) Plotter.CtCycles[i] = 0;
                }

            }

            return Plotter.CtCycles;
        }

        private void updateDataGridOpticDatas( string[,] stringArray)
        {
            int iTemp2;
            

            //dataGridView_Diagnosis.Columns[9].Name = "INH";

            //dataGridView5.Rows[0].DefaultCellStyle.BackColor = Color.AliceBlue;

            string[,] FluoresenceValuesOne = new string[Plotter.DYE_CNT * Plotter.CH_CNT, Plotter.COL_CNT + 1];
            FluoresenceValuesOne[0, 0] = "FAM";
            FluoresenceValuesOne[1, 0] = "ROX";
            FluoresenceValuesOne[2, 0] = "HEX";
            FluoresenceValuesOne[3, 0] = "CY5";
            FluoresenceValuesOne[4, 0] = "FAM";
            FluoresenceValuesOne[5, 0] = "ROX";
            FluoresenceValuesOne[6, 0] = "HEX";
            FluoresenceValuesOne[7, 0] = "CY5";
            FluoresenceValuesOne[8, 0] = "FAM";
            FluoresenceValuesOne[9, 0] = "ROX";
            FluoresenceValuesOne[10, 0] = "HEX";
            FluoresenceValuesOne[11, 0] = "CY5";
            FluoresenceValuesOne[12, 0] = "FAM";
            FluoresenceValuesOne[13, 0] = "ROX";
            FluoresenceValuesOne[14, 0] = "HEX";
            FluoresenceValuesOne[15, 0] = "CY5";

            string[] temp = new string[Plotter.COL_CNT + 1];
            int[] iTemp = new int[Plotter.COL_CNT + 1];

            for (int k = 0; k < Plotter.CH_CNT; k++)
            {
                for (int j = 0; j < Plotter.DYE_CNT; j++)
                {
                    temp[0] = FluoresenceValuesOne[j, 0];
                    for (int i = 0; i < Plotter.COL_CNT; i++)
                    {
                        if(sm.baseLineNoScale)//if (chkBox_baselineNoScale.Checked)
                        {
                            if (i < Plotter.MaxCycleForBaseCalculation)
                            {
                                temp[i + 1] = "0"; // 0until bas calculated  
                            }
                            else
                            {
                                Int32.TryParse(stringArray[Plotter.CH_CNT * k + j, i], out iTemp[i + 1]);
                                if (iTemp[i + 1] > sm.CtlineVal[j + Plotter.CH_CNT * k])
                                {
                                    //temp[i + 1] = (iTemp[i + 1]).ToString();
                                    temp[i + 1] = ((int)(iTemp[i + 1] - sm.CtlineVal[Plotter.CH_CNT * k + j])).ToString();
                                }
                                else
                                {
                                    temp[i + 1] = "0";
                                }
                                //temp[i + 1] = stringArray[Plotter.CH_CNT * k + j, i];
                            }
                        }
                        else if(sm.baseLineScale)//else if (chkBox_BaselineScale.Checked)
                        {
                            if (i < Plotter.MaxCycleForBaseCalculation)
                            {
                                temp[i + 1] = "0"; // 0 until bas calculated  
                            }
                            else
                            {
                                Int32.TryParse(stringArray[Plotter.CH_CNT * k + j, i], out iTemp[i + 1]);
                                if (iTemp[i + 1] > sm.BaselineVal[j + Plotter.CH_CNT * k])
                                {
                                    //temp[i + 1] = (iTemp[i + 1]).ToString();
                                    //double scaleFactor = (double)(2500 / (2500 - CtlineVal[Plotter.CH_CNT * k + j]));

                                    //temp[i + 1] = ((iTemp[i + 1] - CtlineVal[Plotter.CH_CNT * k + j]) * scaleFactor).ToString();
                                    temp[i + 1] = ((iTemp[i + 1] - sm.BaselineVal[Plotter.CH_CNT * k + j]) * sm.scaleFactor[j + Plotter.CH_CNT * k]).ToString();
                                }
                                else
                                {
                                    temp[i + 1] = "0";
                                }
                                //temp[i + 1] = stringArray[Plotter.CH_CNT * k + j, i];
                            }
                        }
                        else
                        {
                            Int32.TryParse(stringArray[Plotter.CH_CNT * k + j, i], out iTemp[i + 1]);
                            //if (iTemp[i + 1] > CtlineVal[j + Plotter.CH_CNT * k])
                            //{
                            temp[i + 1] = (iTemp[i + 1]).ToString();
                            //temp[i + 1] = (iTemp[i + 1] - base_calculated[Plotter.CH_CNT*k +j]).ToString();
                            //}
                            //else
                            //{
                            //temp[i + 1] = "0";
                            //}
                        }
                        double dTemp1;
                        dTemp1 = Convert.ToDouble(temp[i + 1]);
                        iTemp2 = (int)dTemp1;
                        temp[i + 1] = iTemp2.ToString();
                        sm.DISPLAY_DATA[Plotter.CH_CNT * k + j, i] = iTemp2.ToString();
                        //DISPLAY_DATA[Plotter.CH_CNT * k + j, i] = (temp[i + 1];
                        FluoresenceValuesOne[Plotter.CH_CNT * k + j, i + 1] = stringArray[Plotter.CH_CNT * k + j, i];
                    }
                    //dgv[k].Rows.Add();
                    
                }

            }
        }

        public void FindCyclesForBaseCalculation()
        {
            //dgv_CycleForBaseCalculation.Rows[0].Cells[0].Value = "";
            //Plotter.isThisCycleWouldbeUsedForBaseCal[0] = dgv_CycleForBaseCalculation.Rows[0].Cells[0].FormattedValue.ToString();
            Plotter.CycleCntForBaseCal = 0;
            for (int i = 0; i < 45; i++)
            {
                //if (dgv_CycleForBaseCalculation.Rows[0].Cells[i].FormattedValue.ToString() == "v" || dgv_CycleForBaseCalculation.Rows[0].Cells[i].FormattedValue.ToString() == "V")
                if(Plotter.isThisCycleWouldbeUsedForBaseCal[i] == 1)
                {
                    Plotter.CycleCntForBaseCal++;                    
                }
                else
                {
                    //PASS
                    //Plotter.isThisCycleWouldbeUsedForBaseCal[i] = 0;
                }
            }
        }

        private void UI_for_Tester_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "종료 안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // 종료 
                //e.Cancel = false;                
                foreach (Process process in Process.GetProcesses())
                {
                    //프로그램명으로 시작되는 프로세스를 모두 죽인다. 엉뚱한 프로세스를 죽이지 않게 IF문을 잘 사용한다.
                    if(process.ProcessName.Contains("poc_pcr_for_Tester"))//if (process.ProcessName.ToUpper().StartsWith("poc_pcr_for_Tester"))
                    {
                        process.Kill();
                    }
                }
            }
            else   // 취소
            {
                //e.Cancel = true;
            }
        }
    }

}
