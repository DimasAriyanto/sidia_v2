using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using SIDIA.Models;
using SIDIA.Repositories;
using SIDIA.Services;
using SIDIA.Views;
using Prism.Commands;

namespace SIDIA.ViewModels
{
    public class KelolaBarangViewModel : ViewModelBase
    {
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DetailCommand { get; set; }
        public ICommand RedirectToAddCommand { get; set; }
        private INavigationService _navigationService;
        private List<BarangModel> _semuaBarang;
        private BarangRepository _barangRepository;
        public List<BarangModel> SemuaBarang
        {
            get { return _semuaBarang; }
            set { _semuaBarang = value; OnPropertyChanged(); }
        }
        public KelolaBarangViewModel(Frame frame)
        {
            _barangRepository = new BarangRepository();
            this.SemuaBarang = _barangRepository.Getbarang();
            _navigationService = new NavigationService(frame);

            DetailCommand = new DelegateCommand<BarangModel>(DetailItem);
            EditCommand = new DelegateCommand<BarangModel>(EditItem);
            DeleteCommand = new DelegateCommand<BarangModel>(DeleteItem);
            RedirectToAddCommand = new DelegateCommand(RedirectToAdd);
        }
        private void RedirectToAdd()
        {
            _navigationService.NavigateTo(new AddBarangView());
        }
        private void DetailItem(object parameter)
        {
            var item = parameter as BarangModel;
            Application.Current.Properties["DetailItemKelolaBarang"] = item;
            _navigationService.NavigateTo(new DetailBarangView());
        }

        private void EditItem(object parameter)
        {
            var item = parameter as BarangModel;
            Application.Current.Properties["EditItemKelolaBarang"] = item;
            _navigationService.NavigateTo(new EditBarangView());
        }

        private void DeleteItem(object parameter)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Apakah anda yakin ?", "Hapus item yang dipilih", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.No)
            {
                return;
            }
            var item = parameter as BarangModel;
            var index = SemuaBarang.FindIndex(i => i.IdBarang == item.IdBarang);
            var newBarang = new List<BarangModel>();
            bool terhapus = false;
            if (item == null) return;
            SemuaBarang.ForEach(barang =>
            {
                if (barang.IdBarang != item.IdBarang)
                {
                    newBarang.Add(barang);
                }
            });
            SemuaBarang = newBarang;
            terhapus = _barangRepository.DeleteBarang(item.IdBarang.GetValueOrDefault(-1));
            if (terhapus)
            {
                MessageBoxResult result = MessageBox.Show("Berhasil hapus!", "Barang berhasil di hapus");
            }
        }
    }
}
