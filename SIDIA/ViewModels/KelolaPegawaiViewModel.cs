using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SIDIA.Models;
using SIDIA.Repositories;
using Prism.Commands;

namespace SIDIA.ViewModels
{
    public class KelolaPegawaiViewModel : ViewModelBase
    {
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private List<UserModel> _semuaAdmin;
        public List<UserModel> SemuaAdmin
        {
            get { return _semuaAdmin; }
            set { _semuaAdmin = value; OnPropertyChanged(); }
        }
        public KelolaPegawaiViewModel()
        {
            UserRepository userRepository = new UserRepository();
            this.SemuaAdmin = userRepository.GetPegawais();

            EditCommand = new DelegateCommand<UserModel>(EditItem);
            DeleteCommand = new DelegateCommand<UserModel>(DeleteItem);
        }

        private void EditItem(object parameter)
        {
            var item = parameter as UserModel;
            if (item != null)
            {
                // Perform edit operations here
            }
        }

        private void DeleteItem(object parameter)
        {
            var item = parameter as UserModel;
            if (item != null)
            {
                SemuaAdmin.Remove(item);
            }
        }
    }
}
