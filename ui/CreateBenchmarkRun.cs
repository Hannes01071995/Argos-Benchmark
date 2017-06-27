using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArgosBenchmark.ui
{
    public partial class CreateBenchmarkRun : Form
    {
        #region props
        private BenchmarkRun m_Run;

        public BenchmarkRun Run
        {
            get { return m_Run; }
            set
            {
                m_Run = value;
                DisplayRun();
            }
        }
        #endregion

        #region ctor
        public CreateBenchmarkRun()
        {
            InitializeComponent();

            Run = new BenchmarkRun();
        }
        #endregion

        #region private methods
        private void DisplayRun()
        {
            nupClients.Value = Run.Clients;
            nupTotalRequests.Value = Run.Requests;
            nupRepetitions.Value = Run.Repetitions;
        }

        private void nupClients_ValueChanged(object sender, EventArgs e)
        {
            Run.Clients = (long)nupClients.Value;
        }

        private void nupTotalRequests_ValueChanged(object sender, EventArgs e)
        {
            Run.Requests = (long)nupTotalRequests.Value;
        }

        private void nupRepetitions_ValueChanged(object sender, EventArgs e)
        {
            Run.Repetitions = (long)nupRepetitions.Value;
        }
        #endregion
    }
}
