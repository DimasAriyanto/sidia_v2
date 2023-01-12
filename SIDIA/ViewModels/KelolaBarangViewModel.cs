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
    public class KelolaBarangViewModel : ViewModelBase
    {
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private List<BarangModel> _semuaBarang;
        public List<BarangModel> SemuaBarang
        {
            get { return _semuaBarang; }
            set { _semuaBarang = value; OnPropertyChanged(); }
        }
        public KelolaBarangViewModel()
        {
            BarangRepository barangRepository = new BarangRepository();
            this.SemuaBarang = barangRepository.Getbarang();

            EditCommand = new DelegateCommand<BarangModel>(EditItem);
            DeleteCommand = new DelegateCommand<BarangModel>(DeleteItem);
        }

        private void EditItem(object parameter)
        {
            var item = parameter as BarangModel;
            if (item != null)
            {
                // Perform edit operations here
            }
        }

        private void DeleteItem(object parameter)
        {
            var item = parameter as BarangModel;
            if (item != null)
            {
                SemuaBarang.Remove(item);
            }
        }
    }
}
