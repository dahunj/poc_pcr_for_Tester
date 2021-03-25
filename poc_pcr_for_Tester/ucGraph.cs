using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using poc_pcr_for_Tester.GraphPlot;
using System.IO;

namespace poc_pcr_for_Tester
{
    public partial class ucGraph : UserControl
    {
        SharedMemory sm = SharedMemory.GetInstance();

        public event EventHandler graph_Back_Event;
        
        int iRoutine_cnt = 0;
        int iTube_no = 0;
        int iDye = 0;

        public ucGraph()
        {
            InitializeComponent();
            picBox_Back.Click += graph_Back_Click_Event;
        }
        private void ucGraph_Load(object sender, EventArgs e)
        {
            Plotter.Init();
            sm.baseLineNoScale = false;
            sm.baseLineScale = true;
            //SetScottPlot();           
        }

        private void ucGraph_VisibleChanged(object sender, EventArgs e)
        {
            //MatchAndFindOpticDataForResult();
            //plotUpdateFinally();
        }


        public void graph_Back_Click_Event(object sender, EventArgs e)
        {
            if (graph_Back_Event != null)
                graph_Back_Event(sender, e);
        }

       


        private void timer1_Tick(object sender, EventArgs e)
        {
            //plotUpdateFinally();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                showPlotYouWantToDisplay(formsPlot1);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                showPlotYouWantToDisplay(formsPlot2);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                showPlotYouWantToDisplay(formsPlot3);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                showPlotYouWantToDisplay(formsPlot4);
            }
        }

        private void formsPlot3_Load(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        public void plotUpdateFinally()
        {
            Plotter.ResetAllPlots(formsPlot1, formsPlot2, formsPlot3, formsPlot4);
            for (int i = 0; i < Plotter.CH_CNT; i++)
            {
                if(sm.baseLineNoScale || sm.baseLineScale)//if (chkBox_baselineNoScale.Checked || chkBox_BaselineScale.Checked)
                {
                    for (int j = 0; j < Plotter.CH_CNT * Plotter.DYE_CNT; j++)
                    {
                        sm.zerosetValArray[j] = (sm.CtlineVal[j] - sm.BaselineVal[j]) * sm.scaleFactor[j];
                    }
                    updateScottPlot(i, sm.zerosetValArray);
                }
                else
                {
                    updateScottPlot(i, sm.CtlineVal);
                }
            }
        }

        private void updateScottPlot(int tube_idx, double[] hValue)
        {
            // chamberIndex : 1~4
            // columindex : base~final (1~8)

            // 기존 그리드 값을 읽어온 후 값을 업데이트 하고 다시 그리드 값을 설정하자
            //string[] chamberName = { "chamber1", "chamber2", "chamber3", "chamber4" };
            string[] d1 = new string[Plotter.COL_CNT];
            string[] d2 = new string[Plotter.COL_CNT];
            string[] d3 = new string[Plotter.COL_CNT];
            string[] d4 = new string[Plotter.COL_CNT];

            for (int w = 0; w < Plotter.COL_CNT; w++)
            {
                d1[w] = sm.DISPLAY_DATA[Plotter.CH_CNT * (tube_idx), w];
                //d1[w] = ((int)(Convert.ToDouble(MEASURED_DATA[Plotter.CH_CNT *(tube_idx) , w]) - BaselineVal[Plotter.CH_CNT * (tube_idx)])*scaleFactor[Plotter.CH_CNT * (tube_idx)]).ToString();
                if (d1[w] == "0") d1[w] = null;
            }
            for (int w = 0; w < Plotter.COL_CNT; w++)
            {
                d2[w] = sm.DISPLAY_DATA[Plotter.CH_CNT * (tube_idx) + 1, w];
                //d2[w] = MEASURED_DATA[Plotter.CH_CNT * (tube_idx) + 1, w];
                //d2[w] = ((int)(Convert.ToDouble(MEASURED_DATA[Plotter.CH_CNT * (tube_idx)+1, w]) - BaselineVal[Plotter.CH_CNT * (tube_idx)+1]) * scaleFactor[Plotter.CH_CNT * (tube_idx)+1]).ToString();
                if (d2[w] == "0") d2[w] = null;
            }
            for (int w = 0; w < Plotter.COL_CNT; w++)
            {
                d3[w] = sm.DISPLAY_DATA[Plotter.CH_CNT * (tube_idx) + 2, w];
                //d3[w] = MEASURED_DATA[Plotter.CH_CNT * (tube_idx ) + 2, w];
                //d3[w] = ((int)(Convert.ToDouble(MEASURED_DATA[Plotter.CH_CNT * (tube_idx) + 2, w]) - BaselineVal[Plotter.CH_CNT * (tube_idx) + 2]) * scaleFactor[Plotter.CH_CNT * (tube_idx) + 2]).ToString();

                if (d3[w] == "0") d3[w] = null;
            }
            for (int w = 0; w < Plotter.COL_CNT; w++)
            {
                d4[w] = sm.DISPLAY_DATA[Plotter.CH_CNT * (tube_idx) + 3, w];
                //d4[w] = ((int)(Convert.ToDouble(MEASURED_DATA[Plotter.CH_CNT * (tube_idx) + 3, w]) - BaselineVal[Plotter.CH_CNT * (tube_idx) + 3]) * scaleFactor[Plotter.CH_CNT * (tube_idx) + 3]).ToString();

                if (d4[w] == "0") d4[w] = null;
            }


            int[] iD1 = new int[Plotter.COL_CNT];
            int[] iD2 = new int[Plotter.COL_CNT];
            int[] iD3 = new int[Plotter.COL_CNT];
            int[] iD4 = new int[Plotter.COL_CNT];

            //for(int q=0; q < sm.measured_cnt ; q++)
            for (int q = 0; q < Plotter.COL_CNT; q++)
            {
                Int32.TryParse(d1[q], out iD1[q]);
                Int32.TryParse(d2[q], out iD2[q]);
                Int32.TryParse(d3[q], out iD3[q]);
                Int32.TryParse(d4[q], out iD4[q]);
            }

            //for(int i = 0; i < sm.measured_cnt; i++)
            for (int i = 0; i < Plotter.COL_CNT; i++)
            {
                switch (tube_idx + 1)
                {
                    case 1:
                        Plotter.ch1DataDic["FAM"].Add(iD1[i]);
                        Plotter.ch1DataDic["ROX"].Add(iD2[i]);
                        Plotter.ch1DataDic["HEX"].Add(iD3[i]);
                        Plotter.ch1DataDic["CY5"].Add(iD4[i]);
                        Plotter.UpdatePlot(formsPlot1, "Tube1", 0, Plotter.ch1DataDic, cBoxCh1FAM, cBoxCh1ROX, cBoxCh1HEX, cBoxCh1CY5, (int)hValue[0], (int)hValue[1], (int)hValue[2], (int)hValue[3]);
                        break;
                    case 2:
                        Plotter.ch2DataDic["FAM"].Add(iD1[i]);
                        Plotter.ch2DataDic["ROX"].Add(iD2[i]);
                        Plotter.ch2DataDic["HEX"].Add(iD3[i]);
                        Plotter.ch2DataDic["CY5"].Add(iD4[i]);
                        Plotter.UpdatePlot(formsPlot2, "Tube2", 1, Plotter.ch2DataDic, cBoxCh2FAM, cBoxCh2ROX, cBoxCh2HEX, cBoxCh2CY5, (int)hValue[4], (int)hValue[5], (int)hValue[6], (int)hValue[7]);
                        break;
                    case 3:
                        Plotter.ch3DataDic["FAM"].Add(iD1[i]);
                        Plotter.ch3DataDic["ROX"].Add(iD2[i]);
                        Plotter.ch3DataDic["HEX"].Add(iD3[i]);
                        Plotter.ch3DataDic["CY5"].Add(iD4[i]);
                        Plotter.UpdatePlot(formsPlot3, "Tube3", 2, Plotter.ch3DataDic, cBoxCh3FAM, cBoxCh3ROX, cBoxCh3HEX, cBoxCh3CY5, (int)hValue[8], (int)hValue[9], (int)hValue[10], (int)hValue[11]);
                        break;
                    case 4:
                        Plotter.ch4DataDic["FAM"].Add(iD1[i]);
                        Plotter.ch4DataDic["ROX"].Add(iD2[i]);
                        Plotter.ch4DataDic["HEX"].Add(iD3[i]);
                        Plotter.ch4DataDic["CY5"].Add(iD4[i]);
                        Plotter.UpdatePlot(formsPlot4, "Tube4", 3, Plotter.ch4DataDic, cBoxCh4FAM, cBoxCh4ROX, cBoxCh4HEX, cBoxCh4CY5, (int)hValue[12], (int)hValue[13], (int)hValue[14], (int)hValue[15]);
                        break;
                    default:
                        break;
                }
            }
        }

        private async void SetScottPlot()
        {
            var inputDataY = new double[] { 1, 4, 9, 16, 25, 19, 22, 30, 1, 4, 9, 16, 25, 19, 22, 30, 300, 600, 900, 1200, 1500, 1800, 2100, 2200, 2250, 2220, 2210, 2200 };
            var inputDataY2 = new double[] { 1, 2, 3, 5, 8, 29, 12, 20, 1, 2, 3, 5, 8, 29, 12, 20, 200, 400, 600, 800, 1000, 1200, 1500, 1700, 1750, 1720, 1710, 1800 };
            var inputDataY3 = new double[] { 2, 2, 4, 7, 8, 29, 22, 20, 2, 2, 4, 7, 8, 29, 22, 20, 200, 600, 600, 1200, 1000, 1800, 1500, 2200, 1750, 2220, 2210, 2200 };
            var inputDataY4 = new double[] { 6, 3, 3, 7, 8, 20, 12, 24, 6, 3, 3, 7, 8, 20, 12, 24, 300, 600, 600, 1200, 1500, 1200, 2100, 1700, 2250, 1720, 2210, 2200 };

            var progress = new Progress<int>(index =>
            {
                Plotter.ch1DataDic["FAM"].Add(inputDataY[index]);
                Plotter.ch1DataDic["ROX"].Add(inputDataY2[index]);
                Plotter.ch1DataDic["HEX"].Add(inputDataY3[index]);
                Plotter.ch1DataDic["CY5"].Add(inputDataY4[index]);

                Plotter.ch2DataDic["FAM"].Add(inputDataY[index]);
                Plotter.ch2DataDic["ROX"].Add(inputDataY2[index]);
                Plotter.ch2DataDic["HEX"].Add(inputDataY3[index]);
                Plotter.ch2DataDic["CY5"].Add(inputDataY4[index]);

                Plotter.ch3DataDic["FAM"].Add(inputDataY[index]);
                Plotter.ch3DataDic["ROX"].Add(inputDataY2[index]);
                Plotter.ch3DataDic["HEX"].Add(inputDataY3[index]);
                Plotter.ch3DataDic["CY5"].Add(inputDataY4[index]);

                Plotter.ch4DataDic["FAM"].Add(inputDataY[index]);
                Plotter.ch4DataDic["ROX"].Add(inputDataY2[index]);
                Plotter.ch4DataDic["HEX"].Add(inputDataY3[index]);
                Plotter.ch4DataDic["CY5"].Add(inputDataY4[index]);

                Plotter.UpdatePlot(formsPlot1, "Tube1", 0, Plotter.ch1DataDic, cBoxCh1FAM, cBoxCh1ROX, cBoxCh1HEX, cBoxCh1CY5, 0, 0, 0, 0);
                Plotter.UpdatePlot(formsPlot2, "Tube2", 1, Plotter.ch2DataDic, cBoxCh2FAM, cBoxCh2ROX, cBoxCh2HEX, cBoxCh2CY5, 0, 0, 0, 0);
                Plotter.UpdatePlot(formsPlot3, "Tube3", 2, Plotter.ch3DataDic, cBoxCh3FAM, cBoxCh3ROX, cBoxCh3HEX, cBoxCh3CY5, 0, 0, 0, 0);
                Plotter.UpdatePlot(formsPlot4, "Tube4", 3, Plotter.ch4DataDic, cBoxCh4FAM, cBoxCh4ROX, cBoxCh4HEX, cBoxCh4CY5, 0, 0, 0, 0);
            });

            var plotTask = Task.Run(() => AsyncInputSimulator(progress));
            await plotTask;
        }
        private void AsyncInputSimulator(IProgress<int> progress)
        {
            for (int i = 0; i < 28; i++)
            {
                if (progress != null)
                    progress.Report(i);

                Thread.Sleep(1000);
            }
        }

      

        public void showPlotYouWantToDisplay(FormsPlot plotYouWant)
        {
            formsPlot1.Visible = false;
            formsPlot2.Visible = false;
            formsPlot3.Visible = false;
            formsPlot4.Visible = false;

            plotYouWant.Visible = true;
        }

        

      
    }
}
