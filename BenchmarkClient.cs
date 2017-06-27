using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArgosBenchmark
{
    public class BenchmarkClient : IBenchmarkResult
    {
        #region events
        public delegate void BenchmarkClientEventHandler(BenchmarkClient Sender);

        public event BenchmarkClientEventHandler Finished;
        #endregion

        #region IBenchmarkResult
        public TimeSpan MinTime { get; private set; } = TimeSpan.MaxValue;

        public TimeSpan MaxTime { get; private set; } = TimeSpan.MinValue;

        public TimeSpan TotTime { get; private set; } = new TimeSpan();

        public TimeSpan AvgTime
        {
            get
            {
                return TimeSpan.FromTicks(TotTime.Ticks / Math.Max(1, (SucceededRequests + FailedRequests)));
            }
        }

        public long SucceededRequests { get; private set; } = 0;

        public long FailedRequests { get; private set; } = 0;

        public double Progress
        {
            get
            {
                return (SucceededRequests + FailedRequests) / (double)Math.Max(1, m_TotalRequests);
            }
        }
        #endregion

        #region props
        public bool Running
        {
            get { return m_KeepRunning; }
        }
        #endregion

        #region public methods
        public void Start()
        {
            if (m_KeepRunning)
            {
                return;
            }

            m_KeepRunning = true;
            m_Thread.Start();
        }

        public void Stop()
        {
            m_KeepRunning = false;
        }
        #endregion

        #region ctor
        public BenchmarkClient(long Requests, long SimultaneosRequests)
        {
            m_TotalRequests = Requests;
            m_SimultaneosRequests = SimultaneosRequests;

            m_Thread = new Thread(Run);
        }
        #endregion

        #region private members
        private Thread m_Thread;
        private HttpClient m_HttpClient = new HttpClient() { Timeout = TimeSpan.FromMinutes(1) };
        private long m_TotalRequests;
        private long m_SimultaneosRequests;
        private long m_CurrentRequests = 0;
        private bool m_KeepRunning = false;
        private object m_Lock = new object();
        #endregion

        #region private methods
        private void IncrementCurrentRequests()
        {
            lock (m_Lock)
            {
                m_CurrentRequests++;
            }
        }

        private void DecrementCurrentRequests()
        {
            lock (m_Lock)
            {
                m_CurrentRequests--;
            }
        }

        private async Task ExecuteRequest()
        {
            IncrementCurrentRequests();
            Stopwatch sw = Stopwatch.StartNew();
            Tuple<string, HttpResponseMessage> response = null;
            try
            {
                response = await BenchmarkRunner.Instance.RequestFactory.SendRequestAsync(m_HttpClient);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Timeout while executing request");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while executin request: " + ex.Message);
            }
            sw.Stop();

            DecrementCurrentRequests();
            bool success = response?.Item2?.IsSuccessStatusCode == true;
            TimeSpan responseTime = sw.Elapsed;

            if (!success)
            {
                if (response != null)
                {
                    Console.WriteLine($"{response?.Item1} -> {response?.Item2?.StatusCode}");
                }

                return;
            }

            TotTime = TotTime.Add(responseTime);

            //Console.WriteLine($"[{m_Thread.ManagedThreadId}] [{responseTime.TotalMilliseconds} ms] {response.StatusCode}");

            if (responseTime > MaxTime)
            {
                MaxTime = responseTime;
            }

            if (responseTime < MinTime)
            {
                MinTime = responseTime;
            }

            if (success)
            {
                SucceededRequests++;
            }
            else
            {
                FailedRequests++;
            }
        }

        private void Run()
        {
            while (m_KeepRunning && (SucceededRequests + FailedRequests) < m_TotalRequests)
            {
                if (m_CurrentRequests >= m_SimultaneosRequests || (SucceededRequests + FailedRequests + m_CurrentRequests) >= m_TotalRequests)
                {
                    Thread.Sleep(1);
                    continue;
                }

                try
                {
                    ExecuteRequest();
                }
                catch (Exception ex)
                {

                }
            }

            m_KeepRunning = false;
            Finished?.Invoke(this);
        }
        #endregion
    }
}
