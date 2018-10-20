using System;
using System.Windows.Input;

namespace DungeonsDungeons_n_Dragons_Manager.Tools
{
    /// <summary>
    /// Class that handles the command routing.
    /// </summary>
    public class CommandHandler : ICommand
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="p_action">Reprents the action.</param>
        /// <param name="p_canExecute">Represents the execution check.</param>
        public CommandHandler(Action p_action, bool p_canExecute)
        {
            m_action = p_action;
            m_canExecute = p_canExecute;
        }

        /// <summary>
        /// Event determining if CanExecute has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Represents the boolean to determine if the action can be executed.
        /// </summary>
        private bool m_canExecute;
        /// <summary>
        /// Public accessor for m_canExecute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return m_canExecute;
        }

        /// <summary>
        /// Represents the action to be executed.
        /// </summary>
        private Action m_action;
        /// <summary>
        /// Public accessor for m_action.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            m_action();
        }
    }
}