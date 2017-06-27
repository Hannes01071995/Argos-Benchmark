using ArgosBenchmark.argos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark
{
    public class BenchmarkRunner : IBenchmarkResult
    {
        #region events
        public delegate void BenchmarkRunnerEventHandler();

        public event BenchmarkRunnerEventHandler Started;
        public event BenchmarkRunnerEventHandler Finished;
        #endregion

        #region IBenchmarkResult
        public TimeSpan MinTime
        {
            get
            {
                TimeSpan minTime = TimeSpan.MaxValue;

                foreach (BenchmarkClient client in m_Clients)
                {
                    if (client.MinTime < minTime)
                    {
                        minTime = client.MinTime;
                    }
                }

                return minTime;
            }
        }

        public TimeSpan MaxTime
        {
            get
            {
                TimeSpan maxTime = TimeSpan.Zero;

                foreach (BenchmarkClient client in m_Clients)
                {
                    if (client.MaxTime > maxTime)
                    {
                        maxTime = client.MaxTime;
                    }
                }

                return maxTime;
            }
        }

        public TimeSpan TotTime
        {
            get
            {
                TimeSpan totTime = new TimeSpan();

                foreach (BenchmarkClient client in m_Clients)
                {
                    totTime = totTime.Add(client.TotTime);
                }

                return totTime;
            }
        }

        public TimeSpan AvgTime
        {
            get
            {
                TimeSpan avgTime = new TimeSpan();

                foreach (BenchmarkClient client in m_Clients)
                {
                    avgTime = avgTime.Add(client.AvgTime);
                }

                return TimeSpan.FromTicks(avgTime.Ticks / Math.Max(1, m_Clients.Count));
            }
        }

        public long SucceededRequests
        {
            get
            {
                long succeededRequests = 0;

                foreach (BenchmarkClient client in m_Clients)
                {
                    succeededRequests += client.SucceededRequests;
                }

                return succeededRequests;
            }
        }

        public long FailedRequests
        {
            get
            {
                long failedRequests = 0;

                foreach (BenchmarkClient client in m_Clients)
                {
                    failedRequests += client.FailedRequests;
                }

                return failedRequests;
            }
        }

        public double Progress
        {
            get
            {
                double progress = 0.0;

                foreach (BenchmarkClient client in m_Clients)
                {
                    progress += client.Progress;
                }

                return progress / Math.Max(1, m_Clients.Count);
            }
        }
        #endregion

        #region singleton
        private BenchmarkRunner()
        {
            if (!Directory.Exists(OUTPUT_DIR))
            {
                Directory.CreateDirectory(OUTPUT_DIR);
            }

            File.WriteAllText(OUTPUT_FILE, $"api_base;sql_file;clients;tot_requests;tot_time;min_time;max_time;avg_time;suc_requests;bad_requests{Environment.NewLine}");
        }

        private static BenchmarkRunner instance;

        public static BenchmarkRunner Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BenchmarkRunner();
                }

                return instance;
            }
        }
        #endregion

        #region props
        public IRequestFactory RequestFactory
        {
            get { return m_RequestFactory; }
        }
        #endregion

        #region public methods
        public void Run(BenchmarkConfiguration Configuration, SqlImage SqlImage)
        {
            if (m_Running)
            {
                return;
            }

            m_Running = true;
            m_Configuration = Configuration;
            m_SqlImage = SqlImage;
            m_RequestFactory = new ArgosRequestFactory(Configuration, SqlImage);

            Started?.Invoke();

            m_Clients = new List<BenchmarkClient>();
            CreateClients(Configuration);
            StartClients();
        }

        public void Stop()
        {
            if (!m_Running)
            {
                return;
            }

            m_Running = false;
            Finished?.Invoke();

            StopClients();
            PrintResults();
        }
        #endregion

        #region private members
        private bool m_Running = false;
        private BenchmarkConfiguration m_Configuration;
        private SqlImage m_SqlImage;
        private List<BenchmarkClient> m_Clients = new List<BenchmarkClient>();
        private IRequestFactory m_RequestFactory;

        private static readonly string OUTPUT_DIR = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}output";
        private static readonly string OUTPUT_FILE = $"{OUTPUT_DIR}{Path.DirectorySeparatorChar}{DateTime.Now.ToString().Replace(".", "_").Replace(":", "_")}.csv";
        #endregion

        #region private const
        private static readonly int MAX_THREADS = Environment.ProcessorCount;
        #endregion

        #region private methods
        private void StartClients()
        {
            foreach (BenchmarkClient client in m_Clients)
            {
                client.Finished += Client_Finished;
                client.Start();
            }
        }

        private void StopClients()
        {
            foreach (BenchmarkClient client in m_Clients)
            {
                client.Finished -= Client_Finished;
                client.Stop();
            }
        }

        private void CreateClients(BenchmarkConfiguration Configuration)
        {
            long requests = Configuration.Requests;
            if (Configuration.Clients <= MAX_THREADS)
            {
                for (int i = 0; i < Configuration.Clients; i++)
                {
                    if (i + 1 >= Configuration.Clients)
                    {
                        m_Clients.Add(new BenchmarkClient(requests, 1));
                        requests = 0;
                    }
                    else
                    {
                        long clientRequests = Math.Min(requests, Configuration.Requests / Math.Max(1, Configuration.Clients));
                        m_Clients.Add(new BenchmarkClient(clientRequests, 1));

                        requests -= clientRequests;
                    }
                }
            }
            else
            {
                long simultaneosRequests = Configuration.Clients;
                for (int i = 0; i < MAX_THREADS; i++)
                {
                    if (i + 1 >= MAX_THREADS)
                    {
                        m_Clients.Add(new BenchmarkClient(requests, simultaneosRequests));
                        requests = 0;
                        simultaneosRequests = 0;
                    }
                    else
                    {
                        long clientRequests = Math.Min(requests, Configuration.Requests / Math.Max(1, MAX_THREADS));
                        long clientSimultaneosRequests = Math.Min(simultaneosRequests, Configuration.Clients / Math.Max(1, MAX_THREADS));
                        m_Clients.Add(new BenchmarkClient(clientRequests, clientSimultaneosRequests));

                        requests -= clientRequests;
                        simultaneosRequests -= clientSimultaneosRequests;
                    }
                }
            }
        }

        private void PrintResults()
        {
            File.AppendAllText(OUTPUT_FILE, $"{m_Configuration.ApiBase};{m_SqlImage.SqlFilePath};{m_Configuration.Clients};{m_Configuration.Requests};{TotTime.TotalMilliseconds};{MinTime.TotalMilliseconds};{MaxTime.TotalMilliseconds};{AvgTime.TotalMilliseconds};{SucceededRequests};{FailedRequests}{Environment.NewLine}");

            Console.Write(
$@"Benchmark Results:
[TotTime] {TotTime.TotalMilliseconds} ms
[MinTime] {MinTime.TotalMilliseconds} ms
[MaxTime] {MaxTime.TotalMilliseconds} ms
[AvgTime] {AvgTime.TotalMilliseconds} ms
[Success] {SucceededRequests} ({string.Format("{0:P2}", SucceededRequests / (double)(SucceededRequests + FailedRequests))})
[Failure] {FailedRequests} ({string.Format("{0:P2}", FailedRequests / (double)(SucceededRequests + FailedRequests))})
"
);
        }

        private void Client_Finished(BenchmarkClient Sender)
        {
            foreach (BenchmarkClient client in m_Clients)
            {
                if (client.Running)
                {
                    return;
                }
            }

            Stop();
        }
        #endregion
    }
}
