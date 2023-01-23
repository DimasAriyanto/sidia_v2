using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Runtime.InteropServices;
using SIDIA.Models;
using SIDIA.Repositories;
using SIDIA.Views;
using System.Windows;

namespace SIDIA.ViewModels
{
    public class RegisterViewModel: ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _nama;
        private string _domisili;
        private string _user_type;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private bool _isPegawaiSelected;
        public bool IsPegawaiSelected
        {
            get => _isPegawaiSelected;
            set
            {
                _isPegawaiSelected = value;
                if (IsAdminSelected)
                {
                    IsAdminSelected = !value;
                }
                OnPropertyChanged();
            }
        }

        private bool _isAdminSelected;
        public bool IsAdminSelected
        {
            get => _isAdminSelected;
            set
            {
                _isAdminSelected = value;
                if (IsPegawaiSelected)
                {
                    IsPegawaiSelected = !value;
                }
                OnPropertyChanged();
            }
        }

        private IUserRepository userRepository;

        public string Username { 
            get 
            { 
                return _username; 
            }
            set 
            { 
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Nama
        {
            get
            {
                return _nama;
            }
            set
            {
                _nama = value;
                OnPropertyChanged(nameof(Nama));
            }
        }
        public string Domisili
        {
            get
            {
                return _domisili;
            }
            set
            {
                _domisili = value;
                OnPropertyChanged(nameof(Domisili));
            }
        }
        public string UserType
        {
            get
            {
                return _user_type;
            }
            set
            {
                _user_type = value;
                OnPropertyChanged(nameof(UserType));
            }
        }
        public string ErrorMessage {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand RegisterCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public RegisterViewModel()
        {
            userRepository = new UserRepository();
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand);
        }
        private bool CanExecuteRegisterCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3 || (!IsPegawaiSelected && !IsAdminSelected))
                validData = false;
            else
                validData = true;
            return validData;
        }
        private void ExecuteRegisterCommand(object obj)
        {
            if (IsPegawaiSelected)
            {
                UserType = "pegawai";
            } else if (IsAdminSelected)
            {
                UserType = "admin";
            } 

            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
            {
                ErrorMessage = "* Username / passwod must be more than 3 characthers";
                return;
            }

            if (!IsPegawaiSelected && !IsAdminSelected)
            {
                ErrorMessage = "* User type must be selected";
                return;
            }

            UserModel existingUser = userRepository.GetByUsername(Username);
            if (existingUser != null)
            {
                ErrorMessage = "* Username already registered";
                return;
            }

            UserModel userModel = new UserModel()
            {
                Username = Username,
                Password = ConvertToUnsecureString(Password),
                Nama = Nama,
                Domisili = Domisili,
                UserType = UserType
            };
            int userCreated = userRepository.Add(userModel);
            if (userCreated != 0)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
                var dashboardView = new DashboardView();
                var loginView = new LoginView();

                MessageBoxResult result = MessageBox.Show("Register Berhasil");
                if (result == MessageBoxResult.OK)
                {
                    loginView.Show();

                    this.CloseView();
                }
            }
            else
            {
                ErrorMessage = "* Cant create user";
            }
        }
        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }

}