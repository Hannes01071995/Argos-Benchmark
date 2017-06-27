﻿using System;
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

        public long Clients { get; set; } = 1;

        public long Requests { get; set; } = (long)1e4;
        #endregion
    }
}
