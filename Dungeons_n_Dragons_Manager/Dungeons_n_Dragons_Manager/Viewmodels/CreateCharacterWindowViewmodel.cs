using Dungeons_n_Dragons_Manager.Models;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    internal class CreateCharacterWindowViewmodel
    {
        public CreateCharacterWindowViewmodel(ref Character character)
        {
            m_newCharacter = character;
        }

        private Character m_newCharacter { get; set; }
    }
}