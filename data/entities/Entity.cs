using ArgosBenchmark.data.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data.entities
{
    public class Entity : Artifact, IArgosInstance
    {
        #region props
        public virtual string Name { get; set; }

        public virtual Entity Parent { get; set; } = null;

        public List<Entity> Children { get; set; } = new List<Entity>();

        public List<Event> Events { get; set; } = new List<Event>();

        public virtual EntityType Type { get; set; } = null;

        IArgosType IArgosInstance.Type
        {
            get { return Type; }
        }

        public string Status { get; set; }

        public Dictionary<string, string> Attributes { get; } = new Dictionary<string, string>();
        #endregion
    }
}
