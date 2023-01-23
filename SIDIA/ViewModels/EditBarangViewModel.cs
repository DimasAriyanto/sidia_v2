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

public class EditBarangViewModel : ViewModelBase
{
    private BarangModel _barang;
    private BarangRepository _barangRepository;
    public ICommand EditBarangCommand { get; set; }
    public string TanggalMasuk { get; set; }
    public string TanggalKeluar { get; set; }
    public BarangModel Barang
    {
        get { return _barang; }
        set { _barang = value; OnPropertyChanged(); }
    }
    public EditBarangViewModel()
    {
        _barangRepository = new BarangRepository();
        EditBarangCommand = new DelegateCommand(EditBarang);
        var item = Application.Current.Properties["EditItemKelolaBarang"];
        if (item != null)
        {
            string inputFormat = "MM/dd/yyyy HH:mm:ss";
            string outputFormat = "dddd, dd MMMM yyyy";

            Barang = (BarangModel)item;
            if (Barang.TanggalMasuk != null)
            {
                DateTime date = DateTime.ParseExact(Barang.TanggalMasuk, inputFormat, CultureInfo.InvariantCulture);
                TanggalMasuk = date.ToString(outputFormat);
            }
            if (Barang.TanggalKeluar != null)
            {
                DateTime date = DateTime.ParseExact(Barang.TanggalKeluar, inputFormat, CultureInfo.InvariantCulture);
                TanggalKeluar = date.ToString(outputFormat);
            }
        }
    }

    private void EditBarang()
    {
        string inputFormat = "dddd, dd MMMM yyyy";
        string outputFormat = "yyyy-MM-dd";

        if (!string.IsNullOrWhiteSpace(TanggalMasuk))
        {
            DateTime date = DateTime.ParseExact(TanggalMasuk, inputFormat, CultureInfo.InvariantCulture);
            Barang.TanggalMasuk = date.ToString(outputFormat);
        }
        if (!string.IsNullOrWhiteSpace(TanggalKeluar))
        {
            DateTime date = DateTime.ParseExact(TanggalKeluar, inputFormat, CultureInfo.InvariantCulture);
            Barang.TanggalKeluar = date.ToString(outputFormat);
        }
        bool updated = _barangRepository.UpdateBarang(Barang.IdBarang.GetValueOrDefault(-1), Barang);
        if (!updated)
        {
            MessageBox.Show("Gagal", "Gagal mengubah data!");
            return;
        }
        MessageBox.Show("Berhasil", "Berhasil mengubah data!");
    }

}
