using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using ABI_POC_PCR.SerialComm;

namespace ABI_POC_PCR
{
    public partial class UI_for_Tester : Form
    {

        PcrProtocol serial = PcrProtocol.GetInstance();

        ucFirstPage firstScreen = new ucFirstPage();
        ucTestInfo testInfo = new ucTestInfo();
        ucTestPreparation testPreparation = new ucTestPreparation();
        ucTestStart testStart = new ucTestStart();
        ucRunning running = new ucRunning();


        public UI_for_Tester()
        {
            InitializeComponent();

            firstScreen.btnNewTest_Event += btnNewTest_Click;
            firstScreen.btnPrevious_Event += btnPreviousTest_Click;

            testInfo.btnTestInfoNext_Event += btnTestInfoNext_Click;
            testPreparation.btnTestPreparationNext_Event += btnTestPreparationNext_Click;

            testStart.btnTestStart_Event += btnStartTest_Click;
        }
        
        private void UI_for_Tester_Load(object sender, EventArgs e)
        {
            panel_ui.Controls.Add(firstScreen);
            panel_ui.Controls.Add(testInfo);
            panel_ui.Controls.Add(testPreparation);
            panel_ui.Controls.Add(testStart);
            panel_ui.Controls.Add(running);
            panel_ui.Visible = true;
        }

        /// <summary>
        /// First page of UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnNewTest_Click(object sender, EventArgs e)
        {
            //panel_ui
            firstScreen.Visible = false;
            testInfo.Visible = true;
            testPreparation.Visible = false;
            testStart.Visible = false;
        }
        private void btnPreviousTest_Click(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// Test Information page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestInfoNext_Click(object sender, EventArgs e)
        {
            firstScreen.Visible = false;
            testInfo.Visible = false;
            testPreparation.Visible = true;
            testStart.Visible = false;
        }

        /// <summary>
        /// Test preparation page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestPreparationNext_Click(object sender, EventArgs e)
        {
            firstScreen.Visible = false;
            testInfo.Visible = false;
            testPreparation.Visible = false;
            running.Visible = false;

            testStart.Visible = true;            
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            //panel_ui
            firstScreen.Visible = false;
            testInfo.Visible = false;
            testPreparation.Visible = false;
            testStart.Visible = false;

            running.Visible = true;
            
            serial.SendLine(":check_start");
        }


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

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                _inputparameter.Delay = 0;

                backgroundWorker1.RunWorkerAsync(_inputparameter);
            }

        }
    }
}
