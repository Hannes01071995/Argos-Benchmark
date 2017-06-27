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
    public partial class Main : Form
    {
        #region ctor
        public Main()
        {
            InitializeComponent();

            m_RefreshProgressTimer.Interval = 100;
            m_RefreshProgressTimer.Tick += RefreshProgressTimer_Tick;

            BenchmarkRunner.Instance.Started += BenchmarkRunner_Started;
            BenchmarkRunner.Instance.Finished += BenchmarkRunner_Finished;

            DisplayConfiguration();
        }
        #endregion

        #region private members
        private BenchmarkConfiguration m_Configuration = new BenchmarkConfiguration();
        private Timer m_RefreshProgressTimer = new Timer();
        #endregion

        #region private const
        private const string START_TEXT = "Start";
        private const string STOP_TEXT = "Stop";
        #endregion

        #region private methods
        private void DisplayConfiguration()
        {
            txtApiBase.Text = m_Configuration.ApiBase;
            nupClients.Value = m_Configuration.Clients;
            nupTotalRequests.Value = m_Configuration.Requests;
        }

        private void ToggleUILock()
        {
            txtApiBase.Enabled = !txtApiBase.Enabled;
            nupClients.Enabled = !nupClients.Enabled;
            nupTotalRequests.Enabled = !nupTotalRequests.Enabled;
            bSelectSqlFile.Enabled = !bSelectSqlFile.Enabled;
        }

        private void SetProgress(double Progress)
        {
            lProgress.Text = string.Format("{0:P2}", Progress);
            this.Progress.Value = (int)(Math.Min(1, Progress) * this.Progress.Maximum);
        }

        private void RefreshProgressTimer_Tick(object sender, EventArgs e)
        {
            SetProgress(BenchmarkRunner.Instance.Progress);
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (bStart.Text == START_TEXT)
            {
                ToggleUILock();
                try
                {
                    SqlImage image = new SqlImage(txtSqlFile.Text);
                    bStart.Text = STOP_TEXT;
                    SetProgress(0);
                    BenchmarkRunner.Instance.Run(m_Configuration, image);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to parse sql", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (bStart.Text == STOP_TEXT)
            {
                BenchmarkRunner.Instance.Stop();
                bStart.Text = START_TEXT;
            }
        }

        private void txtApiBase_TextChanged(object sender, EventArgs e)
        {
            m_Configuration.ApiBase = txtApiBase.Text;
        }

        private void nupClients_ValueChanged(object sender, EventArgs e)
        {
            m_Configuration.Clients = (long)nupClients.Value;
        }

        private void nupTotalRequests_ValueChanged(object sender, EventArgs e)
        {
            m_Configuration.Requests = (long)nupTotalRequests.Value;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            BenchmarkRunner.Instance.Stop();
        }

        private void BenchmarkRunner_Started()
        {
            m_RefreshProgressTimer.Start();
        }

        private void BenchmarkRunner_Finished()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(BenchmarkRunner_Finished));
                return;
            }

            SetProgress(1);

            m_RefreshProgressTimer.Stop();
            bStart.Text = START_TEXT;
            ToggleUILock();
        }

        private void bSelectSqlFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "SQL|*.sql";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtSqlFile.Text = dialog.FileName;
            }
        }
        #endregion
    }
}
