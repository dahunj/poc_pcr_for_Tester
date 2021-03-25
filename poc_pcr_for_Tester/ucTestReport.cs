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
    public partial class ucTestReport : UserControl
    {
        ListViewItem lvi1;
        ListViewItem lvi3;
        ListViewItem lvi4;
        ListViewItem lvi5;

        SharedMemory sm = SharedMemory.GetInstance();

        public ucTestReport()
        {
            InitializeComponent();
        }

        private void ucTestReport_Load(object sender, EventArgs e)
        {
            
            //reset_IC_Result();
        }

    }
}
