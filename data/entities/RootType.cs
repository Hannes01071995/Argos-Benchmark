using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data.entities
{
    public class RootType : EntityType
    {
        #region props
        public override long Id
        {
            get { return -1; }
            set { }
        }

        public override string Name
        {
            get
            {
                return "RootType";
            }
            set { }
        }

        public override EntityType Parent
        {
            get { return this; }
            set { }
        }
        #endregion

        #region singleton
        private static EntityType m_Instance;

        private RootType()
        {

        }

        public static EntityType Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new RootType();
                }

                return m_Instance;
            }
        }
        #endregion
    }
}
