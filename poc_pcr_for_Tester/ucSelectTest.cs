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
    enum PROTOCOL_SELECTED
    {
        TB = 0,
        COVID,
    }
    public partial class ucSelectTest : UserControl
    {
        SharedMemory sm = SharedMemory.GetInstance();

        public event EventHandler cbBoxSelectTest_Event;
        public event EventHandler SelectTest_NextPage_Event;
        public event EventHandler selectTest_BackPage_Event;

        public ucSelectTest()
        {
            InitializeComponent();
            cbBox_SelectTest.SelectedIndexChanged += cbBox_SelectedIndexChanged_Event;
            picBox_SelectTestNext.Click += SelectTest_NextPage_Click_Event;
            picBox_btn_back.Click += selectTest_BackPage_Click_Event;
        }
        private void ucSelectTest_Load(object sender, EventArgs e)
        {
             
        }

        public void selectTest_BackPage_Click_Event(object sender, EventArgs e)
        {
            if (selectTest_BackPage_Event != null)
                selectTest_BackPage_Event(sender, e);
        }

        public void cbBox_SelectedIndexChanged_Event(object sender, EventArgs e)
        {
            if (this.cbBoxSelectTest_Event != null)
                cbBoxSelectTest_Event(sender, e);
        }

        public void SelectTest_NextPage_Click_Event(object sender, EventArgs e)
        {
            if (this.SelectTest_NextPage_Event != null)
                SelectTest_NextPage_Event(sender, e);
        }

        private void cbBox_SelectTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbBox_SelectTest.SelectedIndex == (int)PROTOCOL_SELECTED.TB)     //TB 
            {
                sm.testName = "TB";
            }
            else if(cbBox_SelectTest.SelectedIndex == (int)PROTOCOL_SELECTED.COVID) //COVID
            {
                sm.testName = "COVID";
            }
        }

        
    }
}
