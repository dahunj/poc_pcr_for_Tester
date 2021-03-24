using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poc_pcr_for_Tester
{
    public partial class ucRunning : UserControl
    {
        SharedMemory sm = SharedMemory.GetInstance();

        public event EventHandler running_NextPage_Event;
        public ucRunning()
        {
            InitializeComponent();
            picBox_running_NextPage.Click += running_NextPage_Click_Event;
        }

        public void running_NextPage_Click_Event(object sender, EventArgs e)
        {
            if (this.running_NextPage_Event != null)
                running_NextPage_Event(sender, e);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
                if(sm.routine_cnt >= 45)
                {
                    circularProgressBar1.Value = 100;
                    circularProgressBar1.Update();
                }
                else
                {
                    circularProgressBar1.Value = sm.routine_cnt * 2;
                    circularProgressBar1.Text = (sm.routine_cnt*2).ToString() + "%";
                    circularProgressBar1.Update();
                }
        }

        private void ucRunning_Load(object sender, EventArgs e)
        {
            timer1.Start();
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sm.routine_cnt++;
        }
    }
}
