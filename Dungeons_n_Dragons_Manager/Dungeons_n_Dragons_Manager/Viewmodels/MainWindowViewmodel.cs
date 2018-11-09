namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// Viewmodel for the main window.
    /// </summary>
    public class MainWindowViewmodel
    {
        #region Sub Viewmodels

        /// <summary>
        /// Viewmodel for the Dice Roll Tab.
        /// </summary>
        private DiceRollTabViewmodel m_diceRollTabViewmodel = new DiceRollTabViewmodel();

        /// <summary>
        /// Public accessor for m_diceRollTabViewmodel.
        /// </summary>
        public DiceRollTabViewmodel DiceRollTabViewmodel
        {
            get { return m_diceRollTabViewmodel; }
        }

        /// <summary>
        /// Viewmodel for the Characters Tab.
        /// </summary>
        private CharactersTabViewmodel m_charactersTabViewmodel = new CharactersTabViewmodel();

        /// <summary>
        /// Public accessor for m_charactersTabViewmodel.
        /// </summary>
        public CharactersTabViewmodel CharactersTabViewmodel
        {
            get { return m_charactersTabViewmodel; }
        }

        /// <summary>
        /// Viewmodel for the EncountersTab.
        /// </summary>
        private EncountersTabViewmodel m_encountersTabViewmodel = new EncountersTabViewmodel();

        /// <summary>
        /// Public accessor for m_encountersTabViewmodel.
        /// </summary>
        public EncountersTabViewmodel EncountersTabViewmodel
        {
            get { return m_encountersTabViewmodel; }
        }

        /// <summary>
        /// Viewmodel for the MusicPlayerTab.
        /// </summary>
        private MusicPlayerTabViewmodel m_MusicPlayerTabViewmodel = new MusicPlayerTabViewmodel();

        /// <summary>
        /// Public accessor for m_MusicPlayerTabViewmodel.
        /// </summary>
        
        public MusicPlayerTabViewmodel MusicPlayerTabViewmodel
        {
            get { return m_MusicPlayerTabViewmodel; }
        }
       

        #endregion Sub Viewmodels
    }
}