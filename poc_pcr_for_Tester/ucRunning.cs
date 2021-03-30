using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using poc_pcr_for_Tester.GraphPlot;

namespace poc_pcr_for_Tester
{
    public partial class ucRunning : UserControl
    {
        SharedMemory sm = SharedMemory.GetInstance();


        int iRoutine_cnt = 0;
        int iTube_no = 0;
        int iDye = 0;

        public event EventHandler running_NextPage_Event;
        public event EventHandler running_BackPage_Event;
       

        public ucRunning()
        {
            InitializeComponent();
            picBox_running_NextPage.Click += running_NextPage_Click_Event;
            picBox_Btn_Back.Click += running_BackPage_Click_Event;
            sm.ProgressFirst = 5;
        }
        
        public void running_NextPage_Click_Event(object sender, EventArgs e)
        {
            if (this.running_NextPage_Event != null)
                running_NextPage_Event(sender, e);
        }

        public void running_BackPage_Click_Event(object sender, EventArgs e)
        {
            if (this.running_BackPage_Event != null)
                running_BackPage_Event(sender, e);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
                if(sm.routine_cnt >= 45)
                {
                    if(sm.ProcessEndFlag)
                    {
                        lbl_Status.Text = "Finished";
                        lbl_Status.ForeColor = Color.OrangeRed;
                        sm.ProcessEndFlag = false;
                        
                    }
                    circularProgressBar1.Value = sm.ProgressFirst + sm.ProgressSecond;
                    circularProgressBar1.Update();
                }
                else
                {
                    lbl_Status.Text = "Running";
                    lbl_Status.ForeColor = Color.LawnGreen;
                
                    sm.ProgressSecond = ( sm.routine_cnt * 2);

                    circularProgressBar1.Value = sm.ProgressFirst + sm.ProgressSecond;//sm.ProgressPercentage;
                    circularProgressBar1.Text = (sm.ProgressFirst + sm.ProgressSecond).ToString() + "%";
                    circularProgressBar1.Update();
                }
        }

        private void ucRunning_Load(object sender, EventArgs e)
        {
            timer1.Start();
            circularProgressBar1.Value = 5;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sm.routine_cnt++;
        }

        private void picBox_running_NextPage_Click(object sender, EventArgs e)
        {
           
        }


        
    }
}
