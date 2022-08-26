using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_ICommand4.Commands
{
    public class RelayCommand : ICommand
    {
        Action executeAction;
        Func<bool> canExecuteAction;
        bool canExecuteChanged;

        public RelayCommand(Action executeAction):this(executeAction, null, false) { }
        public RelayCommand(Action executeAction, Func<bool> canExecuteAction, bool canExecuteChanged)
        {
            this.executeAction = executeAction;
            this.canExecuteAction = canExecuteAction;
            this.canExecuteChanged = canExecuteChanged;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecuteAction == null) return true;
            return canExecuteAction();
        }

        public void Execute(object parameter)
        {
            executeAction();
        }
    }
}
