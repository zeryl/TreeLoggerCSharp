using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace Tree_Logger_CSharp
{
    public partial class DebugScreen : Form
    {
        private readonly TreeLogger _game;
        public DebugScreen(TreeLogger gameForm)
        {
            _game = gameForm;
            InitializeComponent(); //WIP
        }

        private void DebugScreen_Load(object sender, EventArgs e)
        {
        }

        private void btnAddLogs_Click(object sender, EventArgs e)
        {
            _game.Logs += Convert.ToInt32(this.txtAddLogs.Value);
        }

        private void btnAddLPS_Click(object sender, EventArgs e)
        {
            _game.DebugLPS += Convert.ToInt32(this.txtAddLPS.Value);
        }

        private void btnAddClicker_Click(object sender, EventArgs e)
        {
            _game.Clicker += Convert.ToInt32(this.txtAddClicker.Value);
        }

        private void btnAddLumberjack_Click(object sender, EventArgs e)
        {
            _game.Lumberjack += Convert.ToInt32(this.txtAddLumberjack.Value);
        }

        private void btnAddLumberYard_Click(object sender, EventArgs e)
        {
            _game.LumberYard += Convert.ToInt32(this.txtAddLumberYard.Value);
        }

        private void btnAddSawmill_Click(object sender, EventArgs e)
        {
            _game.Sawmill += Convert.ToInt32(this.txtAddSawmill.Value);
        }

        private void btnAddForest_Click(object sender, EventArgs e)
        {
            _game.Forest += Convert.ToInt32(this.txtAddForest.Value);
        }

        private void btnAddShipment_Click(object sender, EventArgs e)
        {
            _game.Shipment += Convert.ToInt32(this.txtAddShipment.Value);
        }

        private void btnAddAlchemyLab_Click(object sender, EventArgs e)
        {
            _game.Alchemy += Convert.ToInt32(this.txtAddAlchemyLab.Value);
        }

        private void btnAddPortal_Click(object sender, EventArgs e)
        {
            _game.Portal += Convert.ToInt32(this.txtAddPortal.Value);
        }

        private void btnAddExtractor_Click(object sender, EventArgs e)
        {
            _game.Extractor += Convert.ToInt32(this.txtAddExtractor.Value);
        }
    }
}
