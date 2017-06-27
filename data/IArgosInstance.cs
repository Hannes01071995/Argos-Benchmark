using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data
{
    public interface IArgosInstance
    { 
        IArgosType Type { get; }

        Dictionary<string, string> Attributes { get; }
    }
}
