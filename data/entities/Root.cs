using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.data.entities
{
    public class Root : Entity
    {
        #region props
        public override long Id
        {
            get { return -1; }
            set { }
        }

        public override string Name
        {
            get { return "Root"; }
            set { }
        }

        public override Entity Parent
        {
            get { return this; }
            set { }
        }

        public override EntityType Type
        {
            get { return RootType.Instance; }
            set { }
        }
        #endregion

        #region singleton
        private static Entity m_Instance;

        private Root()
        {

        }

        public static Entity Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Root();
                }

                return m_Instance;
            }
        }
        #endregion
    }
}
