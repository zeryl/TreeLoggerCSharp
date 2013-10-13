using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tree_Logger_CSharp              
{                                         
                                          
    public partial class TreeLogger : Form
    {
        
        //Created by DeeBeeR -- http://www.reddit.com/u/DeeBeeR
        //Also contributed to by the Reddit and GitHub community!

        #region Variables
        //Other Variables
        bool CheckBuyBuildings = false; //Checks if the buildings panel is open
        int AutoSaveTime = 60; //Time for autosave

        //Log Variables
        public double Logs = 0; //Amount of Logs
        decimal LogsPerSecond = 0; //Amount of Logs you get per second
        double ClickLogs = 1; //Amount of Logs you get per click
        double SelfClickLogs = 0; //Amount of Logs you've clicked manually
        int TotalTimesClicked = 0; //Total times you've clicked
        double DebugLPS = 0; //Debug LPS you've added

        //Clicker Variables
        int Clicker = 0;
        double ClickerPrice = 15;
        double ClickerLPS = 0.1;

        //Lumberjack Variables
        int Lumberjack = 0;
        double LumberjackPrice = 100;
        double LumberjackLPS = 0.5;

        //Lumber Yard Variables
        int LumberYard = 0;
        double LumberYardPrice = 500;
        double LumberYardLPS = 2;

        //Sawmill Variables
        int Sawmill = 0;
        double SawmillPrice = 3000;
        double SawmillLPS = 10;

        //Forest Variables
        int Forest = 0;
        double ForestPrice = 10000;
        double ForestLPS = 40;

        //Shipment Variables
        int Shipment = 0;
        double ShipmentPrice = 40000;
        double ShipmentLPS = 100;

        //Alchemy Lab Variables
        int Alchemy = 0;
        double AlchemyPrice = 200000;
        double AlchemyLPS = 400;

        //Portal Variables
        int Portal = 0;
        double PortalPrice = 1666666;
        double PortalLPS = 6666;

        //Extractor Variables
        int Extractor = 0;
        double ExtractorPrice = 123456789;
        double ExtractorLPS = 98765;
        #endregion

        public TreeLogger()

        {
            InitializeComponent();          

            //Center game to the screen
            CenterToScreen();

            #region Load save
            // Load up save, if exists
            this.Logs = Properties.Settings.Default.Logs;
            this.LogsPerSecond = Properties.Settings.Default.LogsPerSecond;
            this.ClickLogs = Properties.Settings.Default.ClickLogs;
            this.SelfClickLogs = Properties.Settings.Default.SelfClickLogs;
            this.TotalTimesClicked = Properties.Settings.Default.TotalTimesClicked;
            this.Clicker = Properties.Settings.Default.Clicker;
            this.Lumberjack = Properties.Settings.Default.Lumberjack;
            this.LumberYard = Properties.Settings.Default.LumberYard;
            this.Sawmill = Properties.Settings.Default.Sawmill;
            this.Forest = Properties.Settings.Default.Forest;
            this.Shipment = Properties.Settings.Default.Shipment;
            this.Alchemy = Properties.Settings.Default.Alchemy;
            this.Portal = Properties.Settings.Default.Portal;
            this.Extractor = Properties.Settings.Default.Extractor;
            #endregion

        }
        #region Tree Click button
        private void btnTree_Click(object sender, EventArgs e)
        {
            Logs += ClickLogs; //Add Logs from ClickLogs
            SelfClickLogs += ClickLogs; //Adds ClickLogs to manually clicked logs
            TotalTimesClicked++; //Add 1 to total times clicked
            lblLogsInfo.Focus(); //Focus label to prevent holding enter/return abuse

        }
        #endregion

        #region All the label refreshing and LPS events
        private void tmrLPS_Tick(object sender, EventArgs e)
        {
            
            //Add all *LPS variables to LogsPerSecond
            LogsPerSecond = TotalLPS();

            //Divide LPS by 15 to make it tick for the right amount
            //per second
            Logs += Convert.ToDouble(LogsPerSecond / 15);

            //Refresh Logs and LPS
            lblLogsInfo.Text = String.Format("Logs: {0:n0}\nLPS: {1:#,###,##0.#}\nClicked: {2}",
                Logs, LogsPerSecond, SelfClickLogs); //Display how many logs you have, how many you get
                                                     //per second and total manually clicked

            //Refresh form caption to display how many logs
            Text = String.Format("{0:n0}", Logs) + " Logs";

            //Refresh BuyClicker button to see if it matches the price
            btnBuyClicker.Enabled = (Math.Round(Logs) >= ClickerPrice);

            //Refresh SellClicker button to see if you have any Clickers
            btnSellClicker.Enabled = Clicker != 0;

            //Refresh ClickerInfo to see how many owned and the price
            lblClickerInfo.Text = String.Format("Clickers owned: {0:n0}\nClicker price: {1:n0}",
                  Clicker, ClickerPrice);

            //Refresh BuyLumberjack button to see if it matches the price
            btnBuyLumberjack.Enabled = (Math.Round(Logs) >= LumberjackPrice);

            //Refresh SellLumberjack button to see if you have any Lumberjacks
            btnSellLumberjack.Enabled = Lumberjack != 0;

            //Refresh LumberjackInfo to see how many owned and the price
            lblLumberjackInfo.Text = string.Format("Lumberjacks owned: {0:n0}\nLumberjack price: {1:n0}",
                Lumberjack, LumberjackPrice);

            //Refresh BuyLumberYard button to see if it matches the price
            btnBuyLumberYard.Enabled = (Math.Round(Logs) >= LumberYardPrice);

            //Refresh SellLumberYard button to see if you have any Lumber Yards
            btnSellLumberYard.Enabled = LumberYard != 0;

            //Refresh LumberYardInfo to see how many owned and the price
            lblLumberYardInfo.Text = string.Format("Lumber Yards owned: {0:n0}\nLumber Yard price: {1:n0}",
                LumberYard, LumberYardPrice);

            //Refresh BuySawmill button to see if it matches the price
            btnBuySawmill.Enabled = (Math.Round(Logs) >= SawmillPrice);

            //Refresh SellSawmill button to see if you have any Sawmills
            btnSellSawmill.Enabled = Sawmill != 0;

            //Refresh SawmillInfo to see how many owned and the price
            lblSawmillInfo.Text = string.Format("Sawmills owned: {0:n0}\nSawmill price: {1:n0}",
                Sawmill, SawmillPrice);

            //Refresh BuyForest button to see if it matches the price
            btnBuyForest.Enabled = (Math.Round(Logs) >= ForestPrice);

            //Refresh SellForest button to see if you have any Forests
            btnSellForest.Enabled = Forest != 0;

            //Refresh ForestInfo to see how many owned and the price
            lblForestInfo.Text = string.Format("Forests owned: {0:n0}\nForest price: {1:n0}",
                Forest, ForestPrice);

            //Refresh BuyShipment button to see if it matches the price
            btnBuyShipment.Enabled = (Math.Round(Logs) >= ShipmentPrice);

            //Refresh SellShipment button to see if you have any Shipments
            btnSellShipment.Enabled = Shipment != 0;

            //Refresh ShipmentInfo to see how many owned and the price
            lblShipmentInfo.Text = string.Format("Shipments owned: {0:n0}\nShipment price: {1:n0}",
                Shipment, ShipmentPrice);

            //Refresh BuyAlchemyLab button to see if it matches the price
            btnBuyAlchemyLab.Enabled = (Math.Round(Logs) >= AlchemyPrice);

            //Refresh SellAlchemyLab button to see if you have any Alchemy Labs
            btnSellAlchemyLab.Enabled = Alchemy != 0;

            //Refresh AlchemyInfo to see how many owned and the price
            lblAlchemyLabInfo.Text = string.Format("Alchemys Labs owned: {0:n0}\nAlchemy Lab price: {1:n0}",
                Alchemy, AlchemyPrice);

            //Refresh BuyPortal button to see if it matches the price
            btnBuyPortal.Enabled = (Math.Round(Logs) >= PortalPrice);

            //Refresh SellPortal button to see if you have any Portal Labs
            btnSellPortal.Enabled = Portal != 0;

            //Refresh PortalInfo to see how many owned and the price
            lblPortalInfo.Text = string.Format("Portals owned: {0:n0}\nPortal price: {1:n0}",
                Portal, PortalPrice);

            //Refresh BuyExtractor button to see if it matches the price
            btnBuyExtractor.Enabled = (Math.Round(Logs) >= ExtractorPrice);

            //Refresh SellExtractor button to see if you have any Extractor Labs
            btnSellExtractor.Enabled = Extractor != 0;

            //Refresh ExtractorInfo to see how many owned and the price
            lblExtractorInfo.Text = string.Format("Extractors owned: {0:n0}\nExtractor price: {1:n0}",
                Extractor, ExtractorPrice);
        }
        #endregion

        #region Total LPS
        private decimal TotalLPS()
        {

           return Convert.ToDecimal((Clicker * ClickerLPS) + (Lumberjack * LumberjackLPS) + (LumberYard * LumberYardLPS) +
               (Sawmill * SawmillLPS) + (Forest * ForestLPS) + (Shipment * ShipmentLPS) +
               (Alchemy * AlchemyLPS) + (Portal * PortalLPS) + (Extractor * ExtractorLPS) + (DebugLPS));

        }
        #endregion

        #region Buttons
        private void btnBuyClicker_Click(object sender, EventArgs e)
        {
            Clicker++;  //Add a Clicker
            Logs -= ClickerPrice;   //Take away logs equal to the Clickers price
            ClickerPrice *= 1.15;   //Increase the ClickerPrice by 15%
            ClickerPrice = Math.Round(ClickerPrice);   //Round to prevent buy/sell abuse
            Logs = Math.Round(Logs);    //Round to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnSellClicker_Click(object sender, EventArgs e)
        {
            Clicker--; //Remove a Clicker
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            Logs += ClickerPrice / 1.95; //Add back half the logs from previous ClickerPrice
            ClickerPrice /= 1.15; //Return ClickerPrice back to previous price
            ClickerPrice = Math.Round(ClickerPrice); //Round ClickerPrice up
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnBuyLumberjack_Click(object sender, EventArgs e)
        {
            Lumberjack++;  //Add a Lumberjack
            Logs -= LumberjackPrice;   //Take away logs equal to the Lumberjacks price
            LumberjackPrice *= 1.15;   //Increase the LumberjackPrice by 15%
            LumberjackPrice = Math.Round(LumberjackPrice);   //Round to prevent buy/sell abuse
            Logs = Math.Round(Logs);    //Round to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnSellLumberjack_Click(object sender, EventArgs e)
        {
            Lumberjack--; //Remove a Lumberjack
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            Logs += LumberjackPrice / 1.95; //Add back half the logs from previous LumberjackPrice
            LumberjackPrice /= 1.15; //Return LumberjackPrice back to previous price
            LumberjackPrice = Math.Round(LumberjackPrice); //Round LumberjackPrice up
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse

        }

        private void btnBuyLumberYard_Click(object sender, EventArgs e)
        {
            LumberYard++;  //Add a Lumber Yard
            Logs -= LumberYardPrice;   //Take away logs equal to the Lumber Yards price
            LumberYardPrice *= 1.15;   //Increase the YardPrice by 15%
            LumberYardPrice = Math.Round(LumberYardPrice);   //Round to prevent buy/sell abuse
            Logs = Math.Round(Logs);    //Round to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnSellLumberYard_Click(object sender, EventArgs e)
        {
            LumberYard--; //Remove a Lumber Yard
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            Logs += LumberYardPrice / 1.95; //Add back half the logs from previous LumberYardPrice
            LumberYardPrice /= 1.15; //Return LumberYardPrice back to previous price
            LumberYardPrice = Math.Round(LumberYardPrice); //Round LumberYardPrice up
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }
        
        private void btnBuySawmill_Click(object sender, EventArgs e)
        {
            Sawmill++;  //Add a Sawmill
            Logs -= SawmillPrice;   //Take away logs equal to the Sawmills price
            SawmillPrice *= 1.15;   //Increase the SawmillPrice by 15%
            SawmillPrice = Math.Round(SawmillPrice);   //Round to prevent buy/sell abuse
            Logs = Math.Round(Logs);    //Round to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnSellSawmill_Click(object sender, EventArgs e)
        {
            Sawmill--; //Remove a Sawmill
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            Logs += SawmillPrice / 1.95; //Add back half the logs from previous SawmillPrice
            SawmillPrice /= 1.15; //Return SawmillPrice back to previous price
            SawmillPrice = Math.Round(SawmillPrice); //Round SawmillPrice up
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnBuyForest_Click(object sender, EventArgs e)
        {
            Forest++;  //Add a Forest
            Logs -= ForestPrice;   //Take away logs equal to the Forests price
            ForestPrice *= 1.15;   //Increase the ForestPrice by 15%
            ForestPrice = Math.Round(ForestPrice);   //Round to prevent buy/sell abuse
            Logs = Math.Round(Logs);    //Round to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse

        }

        private void btnSellForest_Click(object sender, EventArgs e)
        {
            Forest--; //Remove a Forest
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            Logs += ForestPrice / 1.95; //Add back half logs from previous ForestPrice
            ForestPrice /= 1.15; //Return ForestPrice back to previous price
            ForestPrice = Math.Round(ForestPrice); //Round ForestPrice up
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnBuyShipment_Click(object sender, EventArgs e)
        {
            Shipment++;  //Add a Shipment
            Logs -= ShipmentPrice;   //Take away logs equal to the Shipments price
            ShipmentPrice *= 1.15;   //Increase the ShipmentPrice by 15%
            ShipmentPrice = Math.Round(ShipmentPrice);   //Round to prevent buy/sell abuse
            Logs = Math.Round(Logs);    //Round to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnSellShipment_Click(object sender, EventArgs e)
        {
            Shipment--; //Remove a Shipment
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            Logs += ShipmentPrice / 1.95; //Add back half logs from previous ShipmentPrice
            ShipmentPrice /= 1.15; //Return ShipmentPrice back to previous price
            ShipmentPrice = Math.Round(ShipmentPrice); //Round ShipmentPrice up
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnBuyAlchemyLab_Click(object sender, EventArgs e)
        {

            Alchemy++;  //Add a Alchemy
            Logs -= AlchemyPrice;   //Take away logs equal to the Alchemys price
            AlchemyPrice *= 1.15;   //Increase the AlchemyPrice by 15%
            AlchemyPrice = Math.Round(AlchemyPrice);   //Round to prevent buy/sell abuse
            Logs = Math.Round(Logs);    //Round to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse

        }

        private void btnSellAlchemyLab_Click(object sender, EventArgs e)
        {
            Alchemy--; //Remove a Alchemy
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            Logs += AlchemyPrice / 1.95; //Add back half logs from previous AlchemyPrice
            AlchemyPrice /= 1.15; //Return AlchemyPrice back to previous price
            AlchemyPrice = Math.Round(AlchemyPrice); //Round AlchemyPrice up
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnBuyPortal_Click(object sender, EventArgs e)
        {
            Portal++;  //Add a Portal
            Logs -= PortalPrice;   //Take away logs equal to the Portals price
            PortalPrice *= 1.15;   //Increase the PortalPrice by 15%
            PortalPrice = Math.Round(PortalPrice);   //Round to prevent buy/sell abuse
            Logs = Math.Round(Logs);    //Round to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnSellPortal_Click(object sender, EventArgs e)
        {
            Portal--; //Remove a Portal
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            Logs += PortalPrice / 1.95; //Add back half logs from previous PortalPrice
            PortalPrice /= 1.15; //Return PortalPrice back to previous price
            PortalPrice = Math.Round(PortalPrice); //Round PortalPrice up
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnBuyExtractor_Click(object sender, EventArgs e)
        {
            Extractor++;  //Add a Extractor
            Logs -= ExtractorPrice;   //Take away logs equal to the Extractors price
            ExtractorPrice *= 1.15;   //Increase the ExtractorPrice by 15%
            ExtractorPrice = Math.Round(ExtractorPrice);   //Round to prevent buy/sell abuse
            Logs = Math.Round(Logs);    //Round to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }

        private void btnSellExtractor_Click(object sender, EventArgs e)
        {
            Extractor--; //Remove a Extractor
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            Logs += ExtractorPrice / 1.95; //Add back half logs from previous ExtractorPrice
            ExtractorPrice /= 1.15; //Return ExtractorPrice back to previous price
            ExtractorPrice = Math.Round(ExtractorPrice); //Round ExtractorPrice up
            Logs = Math.Floor(Logs); //Round number to prevent buy/sell abuse
            lblLogsInfo.Focus();   //Focus label to prevent holding enter/return abuse
        }
        #endregion

        #region Form Closing
        private void TreeLogger_FormClosing(object sender, FormClosingEventArgs e)
        {

            //Save the game
            Properties.Settings.Default.Logs = this.Logs;
            Properties.Settings.Default.LogsPerSecond = this.LogsPerSecond;
            Properties.Settings.Default.ClickLogs = this.ClickLogs;
            Properties.Settings.Default.SelfClickLogs = this.SelfClickLogs;
            Properties.Settings.Default.TotalTimesClicked = this.TotalTimesClicked;
            Properties.Settings.Default.Clicker = this.Clicker;
            Properties.Settings.Default.Lumberjack = this.Lumberjack;
            Properties.Settings.Default.LumberYard = this.LumberYard;
            Properties.Settings.Default.Sawmill = this.Sawmill;
            Properties.Settings.Default.Forest = this.Forest;
            Properties.Settings.Default.Shipment = this.Shipment;
            Properties.Settings.Default.Alchemy = this.Alchemy;
            Properties.Settings.Default.Portal = this.Portal;
            Properties.Settings.Default.Extractor = this.Extractor;
            Properties.Settings.Default.Save();


            DialogResult QuitResult =
           MessageBox.Show("Thanks for playing my game! The save feature is very immature. Are you sure you wish to quit?",
               "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Set message box text

            if (QuitResult == DialogResult.No) //Check if the result is true or false
            {
                e.Cancel = true; //Cancels the closing     
            }
        }

        private void TreeLogger_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Buy building button
        private void btnBuyBuildings_Click(object sender, EventArgs e)
        {
            if (!CheckBuyBuildings) 
            {
                Size = new Size(492, 261);
                CheckBuyBuildings = true;
            }
            else if (CheckBuyBuildings)
            {
                Size = new Size(256, 261);
                CheckBuyBuildings = false;
            }
        }
        #endregion

        #region Debug Screen Control
        private void TreeLogger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                DebugScreen showDebugScreen = new DebugScreen(); //Create a new instance of the debug screen
                showDebugScreen.Show(); //Show the debug screen
            }
        }
        #endregion

        #region Auto Save
        private void tmrAutoSave_Tick(object sender, EventArgs e)
        {

            //Auto save the game
            if (AutoSaveTime > 0) { AutoSaveTime--; lblSaved.Visible = false; }
            else
            {
                //Save to application settings
                Properties.Settings.Default.Logs = this.Logs;
                Properties.Settings.Default.LogsPerSecond = this.LogsPerSecond;
                Properties.Settings.Default.ClickLogs = this.ClickLogs;
                Properties.Settings.Default.SelfClickLogs = this.SelfClickLogs;
                Properties.Settings.Default.TotalTimesClicked = this.TotalTimesClicked;
                Properties.Settings.Default.Clicker = this.Clicker;
                Properties.Settings.Default.Lumberjack = this.Lumberjack;
                Properties.Settings.Default.LumberYard = this.LumberYard;
                Properties.Settings.Default.Sawmill = this.Sawmill;
                Properties.Settings.Default.Forest = this.Forest;
                Properties.Settings.Default.Shipment = this.Shipment;
                Properties.Settings.Default.Alchemy = this.Alchemy;
                Properties.Settings.Default.Portal = this.Portal;
                Properties.Settings.Default.Extractor = this.Extractor;
                Properties.Settings.Default.Save();
                lblSaved.Visible = true;
                AutoSaveTime = 60;
            }
        }
        #endregion
    }
}