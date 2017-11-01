using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlyoutMvvmFriendly.UWP.Example
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string CurrentValue
        {
            get { return _currentValue; }
            set { _currentValue = value; RaisePropertyChanged(); }
        }
        private string _currentValue = string.Empty;

        public string NewValue
        {
            get { return _newValue; }
            set { _newValue = value; RaisePropertyChanged(); }
        }
        private string _newValue = string.Empty;

        public ICommand ApplyNewValue
        {
            get { return new CommandHandler(ApplyNewValueCommand); }
        }
        private void ApplyNewValueCommand()
        {
            CurrentValue = NewValue;
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region ICommand dummy implementation, to be replaced with your MVVM framework command

        private class CommandHandler : ICommand
        {
            private Action _action;
            private bool _canExecute;
            public CommandHandler(Action action, bool canExecute = true)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action();
            }
        }

        #endregion
    }
}
