﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaveMyURL.MVVM
{
    public class Command : ICommand
    {
        private readonly Action<Object> action;
        private readonly Predicate<Object> predicate;

        public Command(Action<Object> action) : this(action, null)
        {
        }

        public Command(Action<Object> action, Predicate<Object> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action", "You must specify an Action<T>.");
            }

            this.action = action;
            this.predicate = predicate;
        }

        #region Implementation of ICommand

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public bool CanExecute(object parameter)
        {
            if (predicate == null)
            {
                return true;
            }
            return predicate(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            action(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute()
        {
            Execute(null);
        }

        #endregion
    }
}
