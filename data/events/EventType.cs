using ArgosBenchmark.data.mappings;
using ArgosBenchmark.data.queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data.events
{
    public class EventType : Artifact, IArgosType
    {
        #region props
        public string Name { get; set; }

        public bool IsDeletable { get; set; } = true;

        public long TimestampAttributeId { get; set; }

        public string TimestampAttribute { get; set; }

        public Dictionary<long, string> Attributes { get; } = new Dictionary<long, string>();

        public List<Event> Instances { get; set; } = new List<Event>();

        public List<EventQuery> Queries { get; } = new List<EventQuery>();

        public List<EventEntityMapping> Mappings { get; } = new List<EventEntityMapping>();
        #endregion
    }
}
