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

        public event EventHandler testReportNext_Event;

        public ucTestReport()
        {
            InitializeComponent();
            picBox_Btn_Next.Click += testReportNext_Click_Event;
        }

        private void ucTestReport_Load(object sender, EventArgs e)
        {
            init_Test_Info();
            init_Tester_Info();
            init_Cartridge_Info();
            init_Test_Result();
            init_Analytic_Result();
            //reset_IC_Result();
        }

        private void testReportNext_Click_Event(object sender, EventArgs e)
        {
            if (testReportNext_Event != null)
                testReportNext_Event(sender, e);
        }

        public void init_Test_Info()
        {
            dgv_test_info.Rows[0].Cells[0].Value = sm.testName;
            dgv_test_info.Rows[0].Cells[1].Value = sm.StartTime;
            dgv_test_info.Rows[0].Cells[2].Value = sm.EndTime;
        }

        public void init_Tester_Info()
        {
            dgv_tester_info.Rows[0].Cells[0].Value = sm.userName;
            dgv_tester_info.Rows[0].Cells[1].Value = sm.userID;

        }
        public void init_Cartridge_Info()
        {
            dgv_cartridge_info.Rows[0].Cells[0].Value = sm.PatientID;
            dgv_cartridge_info.Rows[0].Cells[1].Value = sm.SampleID;
            dgv_cartridge_info.Rows[0].Cells[2].Value = sm.CartridgeID;
        }

        public void init_Test_Result()
        {
            if(sm.testName == "COVID")
            {
                dgv_testResult.ColumnCount = 2;
                dgv_testResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv_testResult.RowHeadersVisible = false;

                dgv_testResult.Columns[0].Name = "COVID";
                dgv_testResult.Columns[0].MinimumWidth = 520;
                dgv_testResult.Columns[1].Name = "FLU";
                dgv_testResult.Columns[1].MinimumWidth = 520;

                dgv_testResult.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dgv_testResult.MultiSelect = false;

            }
            else if(sm.testName == "TB")
            {
                dgv_testResult.ColumnCount = 3;
                dgv_testResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv_testResult.RowHeadersVisible = false;

                dgv_testResult.Columns[0].Name = "MTC";
                dgv_testResult.Columns[0].MinimumWidth = 350;
                dgv_testResult.Columns[1].Name = "NTM";
                dgv_testResult.Columns[1].MinimumWidth = 350;
                dgv_testResult.Columns[2].Name = "RIF";
                dgv_testResult.Columns[2].MinimumWidth = 340;

                dgv_testResult.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dgv_testResult.MultiSelect = false;

            }
            
        }

        public void init_Analytic_Result()
        {
            if (sm.testName == "COVID")
            {
                dgv_analyticResult.ColumnCount = 7;
                dgv_analyticResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv_analyticResult.RowHeadersVisible = false;

                dgv_analyticResult.Columns[0].Name = "";
                dgv_analyticResult.Columns[0].MinimumWidth = 148;

                dgv_analyticResult.Columns[1].Name = "E1";
                dgv_analyticResult.Columns[1].MinimumWidth = 148;
                dgv_analyticResult.Columns[2].Name = "N1";
                dgv_analyticResult.Columns[2].MinimumWidth = 148;
                dgv_analyticResult.Columns[3].Name = "IC";
                dgv_analyticResult.Columns[3].MinimumWidth = 149;

                dgv_analyticResult.Columns[4].Name = "E2";
                dgv_analyticResult.Columns[4].MinimumWidth = 149;
                dgv_analyticResult.Columns[5].Name = "N2";
                dgv_analyticResult.Columns[5].MinimumWidth = 149;
                dgv_analyticResult.Columns[6].Name = "IC";
                dgv_analyticResult.Columns[6].MinimumWidth = 149;
                
                dgv_analyticResult.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dgv_analyticResult.MultiSelect = false;

                string[] Ct = { "Ct", "", "", "", "", "", "" };
                string[] result = { "Result", "", "", "", "", "", "" };
                dgv_analyticResult.Rows.Add(Ct);
                dgv_analyticResult.Rows.Add(result);

            }
            else if (sm.testName == "TB")
            {
                dgv_analyticResult.ColumnCount = 9;
                dgv_analyticResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv_analyticResult.RowHeadersVisible = false;

                dgv_analyticResult.Columns[0].Name = "";
                dgv_analyticResult.Columns[0].MinimumWidth = 115;

                dgv_analyticResult.Columns[1].Name = "MTC";
                dgv_analyticResult.Columns[1].MinimumWidth = 115;
                dgv_analyticResult.Columns[2].Name = "IC";
                dgv_analyticResult.Columns[2].MinimumWidth = 115;
                dgv_analyticResult.Columns[3].Name = "NTM";
                dgv_analyticResult.Columns[3].MinimumWidth = 115;
                dgv_analyticResult.Columns[4].Name = "RIF1";
                dgv_analyticResult.Columns[4].MinimumWidth = 115;
                dgv_analyticResult.Columns[5].Name = "RIF2";
                dgv_analyticResult.Columns[5].MinimumWidth = 115;
                dgv_analyticResult.Columns[6].Name = "RIF3";
                dgv_analyticResult.Columns[6].MinimumWidth = 115;
                dgv_analyticResult.Columns[7].Name = "RIF4";
                dgv_analyticResult.Columns[7].MinimumWidth = 115;
                dgv_analyticResult.Columns[8].Name = "RIF5";
                dgv_analyticResult.Columns[8].MinimumWidth = 115;

                dgv_analyticResult.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dgv_analyticResult.MultiSelect = false;

                string[] Ct = { "Ct", "", "", "", "", "", "" };
                string[] result = { "Result", "", "", "", "", "", "" };
            }
        }

        public void update_analytic_result()
        {


        }

    }
}
