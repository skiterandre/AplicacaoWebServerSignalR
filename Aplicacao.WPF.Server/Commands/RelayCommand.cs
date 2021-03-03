using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Aplicacao.WPF.Server.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        private readonly Predicate<object> _checkExecute;
        private readonly string _checkFailExecuteMessage;

        public RelayCommand(Action<object> execute)
            : this(execute, null, null, string.Empty)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute, Predicate<object> checkExecute, string checkFailExecuteMessage)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
            _checkExecute = checkExecute;
            _checkFailExecuteMessage = checkFailExecuteMessage;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (_checkExecute != null && !_checkExecute(parameter))
            {
                //                MessageBox.Show(_checkFailExecuteMessage, "Alerta!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                throw new Exception("Erro Ao Executar Command");
            }
            else
            {
                _execute(parameter);
            }
        }
    }

    public class RelayCommand<TInput> : RelayCommand
    {
        public RelayCommand(Action<TInput> execute)
            : base((o) => execute((TInput)Convert.ChangeType(o, typeof(TInput))))
        {
        }

        public RelayCommand(Action<TInput> execute, Predicate<object> checkExecute, string checkFailExecuteMessage)
            : base((o) => execute((TInput)Convert.ChangeType(o, typeof(TInput))), null, checkExecute, checkFailExecuteMessage)
        {
        }

        public void Execute(TInput parameter)
        {
            base.Execute(parameter);
        }
    }
}
