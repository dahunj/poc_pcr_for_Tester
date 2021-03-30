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
    public partial class ucInterpretation : UserControl
    {
        SharedMemory sm = SharedMemory.GetInstance();
        public ucInterpretation()
        {
            InitializeComponent();
        }

        private void ucInterpretation_Load(object sender, EventArgs e)
        {
            init_Interpretation_howTo();
        }

        public void init_Interpretation_howTo()
        {
            if (sm.testName == "COVID")
            {
                dgv_interpretation_howTo.ColumnCount = 7;
                dgv_interpretation_howTo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv_interpretation_howTo.RowHeadersVisible = false;

                dgv_interpretation_howTo.Columns[0].Name = "";
                dgv_interpretation_howTo.Columns[0].Width = 148;

                dgv_interpretation_howTo.Columns[1].Name = "E1";
                dgv_interpretation_howTo.Columns[1].Width = 148;
                dgv_interpretation_howTo.Columns[2].Name = "N1";
                dgv_interpretation_howTo.Columns[2].Width = 148;
                dgv_interpretation_howTo.Columns[3].Name = "IC1";
                dgv_interpretation_howTo.Columns[3].Width = 149;

                dgv_interpretation_howTo.Columns[4].Name = "E2";
                dgv_interpretation_howTo.Columns[4].Width = 149;
                dgv_interpretation_howTo.Columns[5].Name = "N2";
                dgv_interpretation_howTo.Columns[5].Width = 149;
                dgv_interpretation_howTo.Columns[6].Name = "IC2";
                dgv_interpretation_howTo.Columns[6].Width = 149;

                dgv_interpretation_howTo.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dgv_interpretation_howTo.MultiSelect = false;

                string[] Ct = { "COVID", "", "", "", "", "", "" };
                string[] result = { "FLU", "", "", "", "", "", "" };

                dgv_interpretation_howTo.Rows.Add(Ct);
                dgv_interpretation_howTo.Rows.Add(result);

                int rowCnt = dgv_interpretation_howTo.Rows.GetRowCount(DataGridViewElementStates.Visible);

                for (int i = 1; i < rowCnt; i++)
                {
                    //if (dgvArr[j].Rows.GetRowCount(DataGridViewElementStates.Visible) != 0)
                    //{
                    dgv_interpretation_howTo.Rows.RemoveAt(0);
                    //}
                }


            }
            else if (sm.testName == "TB")
            {
                dgv_interpretation_howTo.ColumnCount = 9;
                dgv_interpretation_howTo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv_interpretation_howTo.RowHeadersVisible = false;

                dgv_interpretation_howTo.Columns[0].Name = "";
                dgv_interpretation_howTo.Columns[0].MinimumWidth = 120;
                dgv_interpretation_howTo.Columns[0].Width = 120;

                dgv_interpretation_howTo.Columns[1].Name = "FAM1";
                dgv_interpretation_howTo.Columns[1].MinimumWidth = 120;
                dgv_interpretation_howTo.Columns[1].Width = 120;

                dgv_interpretation_howTo.Columns[2].Name = "CY51";
                dgv_interpretation_howTo.Columns[2].MinimumWidth = 120;
                dgv_interpretation_howTo.Columns[2].Width = 120;

                dgv_interpretation_howTo.Columns[3].Name = "FAM2";
                dgv_interpretation_howTo.Columns[3].MinimumWidth = 120;
                dgv_interpretation_howTo.Columns[3].Width = 120;

                dgv_interpretation_howTo.Columns[4].Name = "CY52";
                dgv_interpretation_howTo.Columns[4].MinimumWidth = 120;
                dgv_interpretation_howTo.Columns[4].Width = 120;

                dgv_interpretation_howTo.Columns[5].Name = "FAM3";
                dgv_interpretation_howTo.Columns[5].MinimumWidth = 120;
                dgv_interpretation_howTo.Columns[5].Width = 120;

                dgv_interpretation_howTo.Columns[6].Name = "CY53";
                dgv_interpretation_howTo.Columns[6].MinimumWidth = 120;
                dgv_interpretation_howTo.Columns[6].Width = 120;

                dgv_interpretation_howTo.Columns[7].Name = "FAM4";
                dgv_interpretation_howTo.Columns[7].MinimumWidth = 120;
                dgv_interpretation_howTo.Columns[7].Width = 120;

                dgv_interpretation_howTo.Columns[8].Name = "CY54";
                dgv_interpretation_howTo.Columns[8].MinimumWidth = 120;
                dgv_interpretation_howTo.Columns[8].Width = 120;

                dgv_interpretation_howTo.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dgv_interpretation_howTo.MultiSelect = false;

                string[] mtc = { "MTC", "+", "+", "", "", "", "", "", "" };
                string[] ntm = { "NTM", "-", "+", "+", "", "", "", "", "" };
                string[] neg = { "NEG", "-", "+", "-", "", "", "", "", "" };
                string[] rif1 = { "RIF1", "", "", "", "", "", "", "", "" };
                string[] rif2 = { "RIF2", "", "", "", "", "", "", "", "" };
                string[] rif3 = { "RIF3", "", "", "", "", "", "", "", "" };
                string[] rif4 = { "RIF4", "", "", "", "", "", "", "", "" };
                string[] rif5 = { "RIF5", "", "", "", "", "", "", "", "" };

                int rowCnt = dgv_interpretation_howTo.Rows.GetRowCount(DataGridViewElementStates.Visible);

                for (int i = 1; i < rowCnt; i++)
                {
                    //if (dgvArr[j].Rows.GetRowCount(DataGridViewElementStates.Visible) != 0)
                    //{
                    dgv_interpretation_howTo.Rows.RemoveAt(0);
                    //}
                }

                dgv_interpretation_howTo.Rows.Add(mtc);
                dgv_interpretation_howTo.Rows.Add(ntm);
                dgv_interpretation_howTo.Rows.Add(neg);
                dgv_interpretation_howTo.Rows.Add(rif1);
                dgv_interpretation_howTo.Rows.Add(rif2);
                dgv_interpretation_howTo.Rows.Add(rif3);
                dgv_interpretation_howTo.Rows.Add(rif4);
                dgv_interpretation_howTo.Rows.Add(rif5);
            }
        }


        private void btn_save_interpretation_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");

            string fileName = di.ToString() + "\\" + sm.testName + "_interpretation.csv";
            Save_Csv_Interpretation(fileName, dgv_interpretation_howTo, true);//Save_Csv(fileName, dataGridView_Manage, true);
        }

        private void Save_Csv_Interpretation(string fileName, DataGridView dgv, bool header)
        {
            // 현재 선택한 셀의 정보를 삭제 후
            //dataGridView_Manage.Rows.RemoveAt(this.dataGridView_Manage.SelectedRows[0].Index);
            //int sIndex = dgv.CurrentCell.RowIndex;
            //dgv.Rows.RemoveAt(sIndex);

            // 그리드뷰를 파일로 저장함
            string delimiter = ",";  // 구분자
            FileStream fs = new FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter csvExport = new StreamWriter(fs, System.Text.Encoding.UTF8);

            if (dgv.Rows.Count == 0) return;

            // 헤더정보 출력
            if (header)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    csvExport.Write(dgv.Columns[i].HeaderText);
                    if (i != dgv.Columns.Count - 1)
                    {
                        csvExport.Write(delimiter);
                    }
                }
            }

            csvExport.Write(csvExport.NewLine); // add new line

            // 데이터 출력
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        csvExport.Write(row.Cells[i].Value);
                        if (i != dgv.Columns.Count - 1)
                        {
                            csvExport.Write(delimiter);
                        }
                    }
                    csvExport.Write(csvExport.NewLine); // write new line
                }
            }

            csvExport.Flush(); // flush from the buffers.
            csvExport.Close();
            fs.Close();
            MessageBox.Show("Interpretation Information Saved.", "Info Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_load_interpretation_Click(object sender, EventArgs e)
        {
            Interpretation_Load();
        }


        public void Interpretation_Load()
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists) di.Create();

            string fileName = di.ToString() + "\\" + sm.testName + "_interpretation.csv";

            string[] lines = File.ReadAllLines(fileName);
            string[] result;

            int readNum = 1;
            string temp = "";

            for (int i = 1; i < lines.Length; i++) //데이터가 존재하는 라인일 때에만, label에 출력한다.
            {
                temp = lines[i];

                char[] sep = { ',' };

                result = temp.Split(sep);

                if (dgv_interpretation_howTo.Rows.GetRowCount(DataGridViewElementStates.Visible) > 1)
                {
                    dgv_interpretation_howTo.Rows.RemoveAt(0);
                }
                dgv_interpretation_howTo.Rows.Add(result);
            }
            //return result;
        }

       
    }
}
