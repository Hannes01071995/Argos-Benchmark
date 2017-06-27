using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data.mappings
{
    public class MappingCondition : Artifact
    {
        #region props
        public long EventTypeAttributeId { get; set; }

        public long EntityTypeAttributeId { get; set; }

        public EventEntityMapping Mapping { get; set; } = null;
        #endregion
    }
}
