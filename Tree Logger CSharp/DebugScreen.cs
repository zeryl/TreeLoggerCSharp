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
            _game.Logs += Convert.ToInt32(this.txtAddLogs.Text);
        }

        private void btnAddLPS_Click(object sender, EventArgs e)
        {
            _game.DebugLPS += Convert.ToInt32(this.txtAddLPS.Text);
        }

        private void btnAddClicker_Click(object sender, EventArgs e)
        {
            _game.Clicker += Convert.ToInt32(this.txtAddClicker.Text);
        }
    }
}
