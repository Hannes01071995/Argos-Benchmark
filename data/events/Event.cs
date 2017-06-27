using ArgosBenchmark.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data.events
{
    public class Event : Artifact, IArgosInstance
    {
        #region props
        public EventType Type { get; set; } = null;

        IArgosType IArgosInstance.Type
        {
            get { return Type; }
        }

        public Entity Entity { get; set; } = null;

        public Dictionary<string, string> Attributes { get; } = new Dictionary<string, string>();
        #endregion
    }
}
