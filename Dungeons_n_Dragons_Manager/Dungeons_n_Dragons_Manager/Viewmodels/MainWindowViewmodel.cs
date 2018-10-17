using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    class MainWindowViewmodel
    {
        #region Sub Viewmodels

        private EncountersTabViewmodel m_encountersTabViewmodel = new EncountersTabViewmodel();
        public EncountersTabViewmodel EncountersTabViewmodel
        {
            get
            {
                return m_encountersTabViewmodel;
            }
            set { }
        }

        #endregion
    }
}
