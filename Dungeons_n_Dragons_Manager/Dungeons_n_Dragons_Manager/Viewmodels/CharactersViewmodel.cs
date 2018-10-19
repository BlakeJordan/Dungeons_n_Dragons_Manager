using Dungeons_n_Dragons_Manager.Models;
using DungeonsDungeons_n_Dragons_Manager.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    class CharactersViewmodel
    {

        //Constructor
        public CharactersViewmodel()
        {
            Characters = new ObservableCollection<Character>();
            // parseMonstersResource();
        }

        public ObservableCollection<Character> Characters { get; set; }

        private Character m_SelectedCharacter;
        public Character SelectedCharacter
        {
            get
            {
                if (m_SelectedCharacter == null)
                {
                    m_SelectedCharacter = Characters[0];
                }
                return m_SelectedCharacter;
            }
            set
            {
                if (value != m_SelectedCharacter)
                {
                    m_SelectedCharacter = value;
                    OnPropertyRaised(nameof(SelectedCharacter));
                }
            }
        }

        #region Interfaces

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion
    }
}