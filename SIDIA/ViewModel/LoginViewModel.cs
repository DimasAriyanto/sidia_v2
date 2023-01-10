﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SIDIA.ViewModel
{
    public class LoginViewModel: ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

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
        public SecureString Password { get => _password; set => _password = value; }
        public string ErrorMessage { get => _errorMessage; set => _errorMessage = value; }
        public bool IsViewVisible { get => _isViewVisible; set => _isViewVisible = value; }
    }
}
