using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data
{
    public interface IArgosType
    {
        Dictionary<long, string> Attributes { get; }
    }
}
