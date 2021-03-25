using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_pcr_for_Tester.GraphPlot;

namespace poc_pcr_for_Tester
{
    public class SharedMemory
    {
        public int measured_cnt { get; set; }

        public string userID { get; set; } // Tester ID = login ID at first
        public string userPW { get; set; }  // Tester PW = login PW at first
        public string userName { get; set; } // Tester Name

        public string testName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string PatientID { get; set; }
        public string SampleID { get; set; }
        public string CartridgeID { get; set; }
        public string QualityControl { get; set; }
        
        public string userAccessibility { get; set; }
        public bool isLoginSucceeded { get; set; }
        public string currentLogFileName { get; set; }

        public bool isDeviceConnected { get; set; }
        public string DevicePort { get; set; }

        public int routine_cnt { get; set; }
        public int ProgressPercentage { get; set; }

        public string current_Log_Name { get; set; }
        public bool DataUpdateFlag { get; set; }
        public bool ProcessEndFlag { get; set; }

        public string[,] ALL_DATA;
        public string[,] MEASURED_DATA;
        public string[,] DISPLAY_DATA;

        public string[] allDataArray;
        public string allData;

        public bool isFileSaved_In_Local;

        public bool baseLineNoScale;
        public bool baseLineScale;

        public double[] CtlineVal = new double[Plotter.DYE_CNT * Plotter.CH_CNT];
        public double[] BaselineVal = new double[Plotter.DYE_CNT * Plotter.CH_CNT];
        public double[] BaseStandardDeviation = new double[Plotter.DYE_CNT * Plotter.CH_CNT];
        public double[] zerosetValArray = new double[Plotter.DYE_CNT * Plotter.CH_CNT];
        
        public double[] scaleFactor = new double[Plotter.CH_CNT * Plotter.DYE_CNT];

      

        private static SharedMemory _instance = null;
        public static SharedMemory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SharedMemory();
            }
            return _instance;
        }
    }
}
