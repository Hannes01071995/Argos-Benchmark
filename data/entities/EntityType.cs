using ArgosBenchmark.data.mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data.entities
{
    public class EntityType : Artifact, IArgosType
    {
        #region props
        public virtual string Name { get; set; }

        public virtual EntityType Parent { get; set; } = null;

        public List<EntityType> Children { get; } = new List<EntityType>();

        public List<Entity> Instances { get; } = new List<Entity>();

        public Dictionary<long, string> Attributes { get; } = new Dictionary<long, string>();

        public List<EventEntityMapping> Mappings { get; } = new List<EventEntityMapping>();
        #endregion
    }
}
