using System;
using System.Windows.Input;

namespace StoreTestWPF.ViewModel.Utils
{
    public class RelayCommandWithSender<T> : ICommand where T : class
    {
        private Action<T> execute;
        private Func<T, bool> canExecute;

        public RelayCommandWithSender(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute(parameter as T);

        public void Execute(object parameter)
        {
            Execute(parameter as T);
        }

        public void Execute(T parameter)
        {
            execute(parameter);
        }
    }
}
