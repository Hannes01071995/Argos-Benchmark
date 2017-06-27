using ArgosBenchmark.data.entities;
using ArgosBenchmark.data.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data.mappings
{
    public class EventEntityMapping : Artifact
    {
        #region props
        public string TargetStatus { get; set; }

        public EntityType EntityType { get; set; } = null;

        public EventType EventType { get; set; } = null;

        public List<MappingCondition> Conditions { get; } = new List<MappingCondition>();
        #endregion
    }
}
