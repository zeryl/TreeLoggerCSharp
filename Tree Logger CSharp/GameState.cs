using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Logger_CSharp
{
    public class GameState
    {
        //Logs
        public double Logs { get; set; } // Amount of Logs
        public decimal LogsPerSecond { get; set; } // Amount of Logs per second
        public double ClickLogs { get; set; } // Amount of logs you get per click
        public double SelfClickedLogs { get; set; } // Amount of logs you're clicked manually
        public int TotalTimesClicked { get; set; } // Total times you've clicked
        public double DebugLPS { get; set; } // Debug LPS you've added

        //Other Variables
        bool CheckBuyBuildings = false; //Checks if the buildings panel is open
        bool CheckOptions = false; //Checks if the options panel is open
        int AutoSaveTime = 60; //Time for autosave

        //Clicker Variables
        public int Clicker = 0;
        double ClickerPrice = 15;
        double ClickerLPS = 0.1;

        //Lumberjack Variables
        public int Lumberjack = 0;
        double LumberjackPrice = 100;
        double LumberjackLPS = 0.5;

        //Lumber Yard Variables
        public int LumberYard = 0;
        double LumberYardPrice = 500;
        double LumberYardLPS = 2;

        //Sawmill Variables
        public int Sawmill = 0;
        double SawmillPrice = 3000;
        double SawmillLPS = 10;

        //Forest Variables
        public int Forest = 0;
        double ForestPrice = 10000;
        double ForestLPS = 40;

        //Shipment Variables
        public int Shipment = 0;
        double ShipmentPrice = 40000;
        double ShipmentLPS = 100;

        //Alchemy Lab Variables
        public int Alchemy = 0;
        double AlchemyPrice = 200000;
        double AlchemyLPS = 400;

        //Portal Variables
        public int Portal = 0;
        double PortalPrice = 1666666;
        double PortalLPS = 6666;

        //Extractor Variables
        public int Extractor = 0;
        double ExtractorPrice = 123456789;
        double ExtractorLPS = 98765;
    }
}
