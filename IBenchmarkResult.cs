using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark
{
    public interface IBenchmarkResult
    {
        TimeSpan MinTime { get; }

        TimeSpan MaxTime { get; }

        TimeSpan TotTime { get; }

        TimeSpan AvgTime { get; }

        long SucceededRequests { get; }

        long FailedRequests { get; }

        double Progress { get; }
    }
}
