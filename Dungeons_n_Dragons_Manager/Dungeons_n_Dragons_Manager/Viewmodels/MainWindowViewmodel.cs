namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// Main
    /// </summary>
    internal class MainWindowViewmodel
    {
        #region Sub Viewmodels

        private DiceRollTabViewmodel m_diceRollTabViewmodel = new DiceRollTabViewmodel();

        public DiceRollTabViewmodel DiceRollTabViewmodel
        {
            get { return m_diceRollTabViewmodel; }
        }

        private CharactersTabViewmodel m_charactersTabViewmodel = new CharactersTabViewmodel();

        public CharactersTabViewmodel CharactersTabViewmodel
        {
            get { return m_charactersTabViewmodel; }
        }

        private EncountersTabViewmodel m_encountersTabViewmodel = new EncountersTabViewmodel();

        public EncountersTabViewmodel EncountersTabViewmodel
        {
            get { return m_encountersTabViewmodel; }
        }

        #endregion Sub Viewmodels
    }
}