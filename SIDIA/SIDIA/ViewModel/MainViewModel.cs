using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Input;


namespace SIDIA.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Window _currentWindow;
        public Window CurrentWindow
        {
            get { return _currentWindow; }
            set
            {
                _currentWindow = value;
                OnPropertyChanged(nameof(CurrentWindow));
            }
        }

        public ICommand NavigateCommand { get; set; }

        public MainViewModel()
        {
            CurrentWindow = new MainWindow();
            NavigateCommand = new RelayCommand<Type>(Navigate);
        }

        private void Navigate(Type windowType)
        {
            CurrentWindow = (Window)Activator.CreateInstance(windowType);
            CurrentWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
