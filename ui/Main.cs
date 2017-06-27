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
            txtSqlFile.Text = m_Configuration.SqlImage?.SqlFilePath;
        }

        private void ToggleUILock()
        {
            txtApiBase.Enabled = !txtApiBase.Enabled;
            bSelectSqlFile.Enabled = !bSelectSqlFile.Enabled;
            contextListRuns.Enabled = !contextListRuns.Enabled;
        }

        private void SetProgress(double CurrentProgress, double TotalProgress)
        {
            for (int i = 0; i < BenchmarkRunner.Instance.CurrentRunIndex; i++)
            {
                string finished = string.Format("{0:P2}", 1);

                if (listRuns.Items[i].SubItems[0].Text != finished)
                {
                    listRuns.Items[i].SubItems[0].Text = finished;
                }
            }

            listRuns.Items[BenchmarkRunner.Instance.CurrentRunIndex].SubItems[0].Text = string.Format("{0:P2}", CurrentProgress);
            lProgress.Text = string.Format("{0:P2}", TotalProgress);
            Progress.Value = (int)(Math.Min(1, TotalProgress) * Progress.Maximum);
        }

        private void RefreshProgressTimer_Tick(object sender, EventArgs e)
        {
            double progress = Math.Max(0, Math.Min(1, BenchmarkRunner.Instance.Progress));
            SetProgress(progress, (BenchmarkRunner.Instance.CurrentRunIndex / ((double)m_Configuration.Runs.Count)) + (progress / m_Configuration.Runs.Count));
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (bStart.Text == START_TEXT)
            {
                ToggleUILock();
                try
                {
                    if (m_Configuration.SqlImage?.SqlFilePath != txtSqlFile.Text)
                    {
                        m_Configuration.SqlImage = new SqlImage(txtSqlFile.Text);
                    }

                    bStart.Text = STOP_TEXT;
                    BenchmarkRunner.Instance.Run(m_Configuration);
                    SetProgress(0, 0);
                }
                catch (Exception ex)
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

            SetProgress(1, 1);

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

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateBenchmarkRun newRun = new CreateBenchmarkRun();

            if (m_Configuration.Runs.Count > 0)
            {
                newRun.Run = m_Configuration.Runs.Last().Copy();
            }

            if (newRun.ShowDialog() == DialogResult.OK)
            {
                m_Configuration.Runs.Add(newRun.Run);

                ListViewItem newItem = new ListViewItem(string.Format("{0:P2}", 0));
                newItem.SubItems.Add(newRun.Run.Clients.ToString());
                newItem.SubItems.Add(newRun.Run.Requests.ToString());
                newItem.SubItems.Add(newRun.Run.Repetitions.ToString());

                listRuns.Items.Add(newItem);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listRuns.SelectedItems.Count != 0)
            {
                return;
            }

            m_Configuration.Runs.RemoveAt(listRuns.SelectedItems[0].Index);
            listRuns.Items.Remove(listRuns.SelectedItems[0]);
        }
        #endregion
    }
}
