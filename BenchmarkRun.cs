using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark
{
    public class BenchmarkRun
    {
        #region props
        public long Clients { get; set; } = 1;

        public long Requests { get; set; } = (long)10e4;

        public long Repetitions { get; set; } = 1;
        #endregion

        #region public methods
        public BenchmarkRun Copy()
        {
            return new BenchmarkRun() { Clients = Clients, Repetitions = Repetitions, Requests = Requests };
        }
        #endregion
    }
}
