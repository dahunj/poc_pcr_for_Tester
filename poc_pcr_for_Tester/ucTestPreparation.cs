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
    public partial class ucTestPreparation : UserControl
    {
        PcrProtocol serial = PcrProtocol.GetInstance();

        public event EventHandler btnTestPreparationNext_Event;
        public event EventHandler testPreparation_Back_Event;
        public ucTestPreparation()
        {
            InitializeComponent();
            picBox_TestPreparationNext.Click += btnTestPreparationNext_Click_Event;
            picBox_Back.Click += testPreparation_Back_Click_Event;
        }

        public void testPreparation_Back_Click_Event(object sender, EventArgs e)
        {
            if (this.testPreparation_Back_Event != null)
                testPreparation_Back_Event(sender, e);
        }

        public void btnTestPreparationNext_Click_Event(object sender, EventArgs e)
        {
            if (this.btnTestPreparationNext_Event != null)
                btnTestPreparationNext_Event(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Door_Unlock_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(":DOOR_UNLOCK");
            String txt = sb.ToString();
            //if (checkBox1.Checked) 
            serial.SendLine(txt);
        }
    }
}
