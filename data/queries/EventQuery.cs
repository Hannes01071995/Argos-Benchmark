using ArgosBenchmark.data.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data.queries
{
    public class EventQuery : Artifact
    {
        #region props
        public string Description { get; set; }

        public string Query { get; set; }

        public string Uuid { get; set; }

        public EventType Type { get; set; } = null;
        #endregion
    }
}
