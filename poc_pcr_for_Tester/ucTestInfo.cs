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

namespace poc_pcr_for_Tester
{
    public partial class ucTestInfo : UserControl
    {
        public event EventHandler btnTestInfoNext_Event;
        public event EventHandler testInfo_Back_Event;
        public event EventHandler testInfo_Exit_Event;

        SharedMemory sm = SharedMemory.GetInstance();

        DataGridView dgv_TestInfo = new DataGridView();
        public ucTestInfo()
        {
            InitializeComponent();
            picBox_TestInfoNext.Click += btnTestInfoNext_Click_Event;
            picBox_Back.Click += testInfo_Back_Click_Event;
            picBox_Exit.Click += Exit_Click_Event;
        }

        private void ucTestInfo_Load_1(object sender, EventArgs e)
        {
            //sm.testName = "COVID";
            //load
            sm.StartTime = DateTime.Now.ToString("yyyy-MM-dd / HH:mm:ss");
            string[] row0 = { sm.testName, sm.StartTime };
            dgv_test_info.Rows.Add(row0);
        }

        public void Exit_Click_Event(object sender, EventArgs e)
        {
            if (testInfo_Exit_Event != null)
                testInfo_Exit_Event(sender, e);
        }




        public void testInfo_Back_Click_Event(object sender, EventArgs e)
        {
            if (this.testInfo_Back_Event != null)
                testInfo_Back_Event(sender, e);
        }

        public void btnTestInfoNext_Click_Event(object sender, EventArgs e)
        {
            if (this.btnTestInfoNext_Event != null)
                btnTestInfoNext_Event(sender, e);
        }
        private void ucTestInfo_Load(object sender, EventArgs e)
        {
         
            //SetupDataGridView(dgv_TestInfo);
            //PopulateDataGridView(dgv_TestInfo);
        }
        
        private void SetupDataGridView(DataGridView dgv)
        {
            this.Controls.Add(dgv);

            dgv.ColumnCount = 5;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgv.Font, FontStyle.Bold);

            dgv.Name = "songsDataGridView";
            dgv.Location = new Point(8, 8);
            dgv.Size = new Size(300, 150);
            dgv.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.Black;
            dgv.RowHeadersVisible = false;

            dgv.Columns[0].Name = "Release Date";
            dgv.Columns[1].Name = "Track";
            dgv.Columns[2].Name = "Title";
            dgv.Columns[3].Name = "Artist";
            dgv.Columns[4].Name = "Album";
            dgv.Columns[4].DefaultCellStyle.Font =
                new Font(dgv.DefaultCellStyle.Font, FontStyle.Italic);

            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Dock = DockStyle.Fill;
        }

        private void PopulateDataGridView(DataGridView dgv)
        {

            string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In",
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days",
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?",
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13",
            "Scatterbrain. (As Dead As Leaves.)",
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            dgv.Rows.Add(row0);
            dgv.Rows.Add(row1);
            dgv.Rows.Add(row2);
            dgv.Rows.Add(row3);
            dgv.Rows.Add(row4);
            dgv.Rows.Add(row5);
            dgv.Rows.Add(row6);

            dgv.Columns[0].DisplayIndex = 3;
            dgv.Columns[1].DisplayIndex = 4;
            dgv.Columns[2].DisplayIndex = 0;
            dgv.Columns[3].DisplayIndex = 1;
            dgv.Columns[4].DisplayIndex = 2;
        }

        private void picBox_Save_Click_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists)
            {
                di.Create();
            }
            string fileName = di.ToString() + "\\COVID.txt";

            StreamWriter sw = new StreamWriter(fileName, true);
            string buff = "";
            //string buff = dgv_TestInfo.Rows[0].Cells[0].Value.ToString() + "," + dgv_TestInfo.Rows[0].Cells[1].Value.ToString() + ",";
                        //+ dgv_tester_info.Rows[0].Cells[0].Value.ToString() + "," + dgv_tester_info.Rows[0].Cells[1].Value.ToString() + ","
                        //+ dgv_cartridge_info.Rows[0].Cells[0].Value.ToString() + "," + dgv_cartridge_info.Rows[0].Cells[1].Value.ToString() + ","
                        //+ dgv_cartridge_info.Rows[0].Cells[2].Value.ToString()
                        //;
            sw.WriteLine(buff);
                        
            sw.Close();
        }

        public void loadInfomation(string testName)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists) di.Create();

            string fileName = di.ToString() + "\\" + testName + ".txt";//string fileName = di.ToString() + "\\COVID.txt";

            string[] lines = File.ReadAllLines(fileName);

            int readNum = 1;
            string temp = "";
            for (int i = 0; i < lines.Length; i++) //데이터가 존재하는 라인일 때에만, label에 출력한다.
            {
                temp = lines[i];

                char[] sep = { ',' };

                string[] result = temp.Split(sep);

                sm.testName = result[0];

                sm.userName = result[2];
                sm.userID = result[3];

                sm.PatientID = result[4];
                sm.SampleID = result[5];
                sm.CartridgeID = result[6];

                dgv_test_info.Rows[0].Cells[0].Value = result[0];
                dgv_tester_info.Rows[0].Cells[0].Value = result[2];
                dgv_tester_info.Rows[0].Cells[1].Value = result[3];
                dgv_cartridge_info.Rows[0].Cells[0].Value = result[4];
                dgv_cartridge_info.Rows[0].Cells[1].Value = result[5];
                dgv_cartridge_info.Rows[0].Cells[2].Value = result[6];

                //string[] data6 = new string[4] { temp, temp, temp, temp };

                //foreach (var item in result)
                //{
                //    data6[index++] = item;
                //}



                //dataGridView_Manage.Rows.Add(result);
            }
        }


        private void picBox_Load_Click_Click(object sender, EventArgs e)
        {
            loadInfomation(sm.testName);

                //string[] data6 = new string[4] { temp, temp, temp, temp };
                
                //foreach (var item in result)
                //{
                //    data6[index++] = item;
                //}
                
                //dataGridView_Manage.Rows.Add(result);
        }

        private void ucTestInfo_VisibleChanged(object sender, EventArgs e)
        {
            loadInfomation(sm.testName);
        }
    }
}
