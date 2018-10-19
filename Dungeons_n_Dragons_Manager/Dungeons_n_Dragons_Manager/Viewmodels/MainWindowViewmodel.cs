using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// Main 
    /// </summary>
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
        }

        private DiceRollTabViewmodel m_diceRollTabViewModel = new DiceRollTabViewmodel();
        public DiceRollTabViewmodel DiceRollTabViewmodel
        {
            get
            {
                return m_diceRollTabViewModel;
            }
        }


        #endregion
    }
}
