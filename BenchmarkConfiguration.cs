using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark
{
    public class BenchmarkConfiguration
    {
        #region props
        public string ApiBase { get; set; } = "http://localhost:8989/argos";

        public SqlImage SqlImage { get; set; } = null;

        public List<BenchmarkRun> Runs { get; } = new List<BenchmarkRun>();
        #endregion
    }
}
