using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Windows.Input;
using SIDIA.Repositories;
using SIDIA.ViewModels;

namespace SIDIA.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            LoginViewModel viewModel = new LoginViewModel();
            DataContext = viewModel;
            viewModel.CloseViewEvent += (s, e) => Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Register_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var registerView = new RegisterView();
            registerView.Show();
            this.Close();
        }
    }
}
