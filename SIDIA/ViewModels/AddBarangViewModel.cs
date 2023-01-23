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
using System.Globalization;

namespace SIDIA.ViewModels;

public class AddBarangViewModel : ViewModelBase
{
    private BarangModel _barang;
    private BarangRepository _barangRepository;
    public ICommand AddBarangCommand { get; set; }
    public BarangModel Barang
    {
        get { return _barang; }
        set { _barang = value; OnPropertyChanged(); }
    }
    public AddBarangViewModel()
    {
        Barang = new BarangModel();
        _barangRepository = new BarangRepository();
        AddBarangCommand = new DelegateCommand(AddBarang);
    }
    private void AddBarang()
    {
        if (Barang.TanggalKeluar != null)
        {
            DateTime tanggalKeluar = DateTime.ParseExact(Barang.TanggalKeluar, "dddd, d MMMM yyyy", CultureInfo.InvariantCulture);
            Barang.TanggalKeluar = tanggalKeluar.ToString("yyyy-MM-dd");
        }
        if (Barang.TanggalMasuk != null)
        {
            DateTime tanggalMasuk = DateTime.ParseExact(Barang.TanggalMasuk, "dddd, d MMMM yyyy", CultureInfo.InvariantCulture);
            Barang.TanggalMasuk = tanggalMasuk.ToString("yyyy-MM-dd");
        }
        _barangRepository.InsertBarang(Barang);
        MessageBoxResult res = MessageBox.Show("Berhasil!", "Barang berhasil ditambahkan!");
        if (res == MessageBoxResult.OK)
        {
            Barang = new BarangModel();
        }
    }

}
