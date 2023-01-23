using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDIA.Models;

namespace SIDIA.ViewModels;

 public class DetailBarangViewModel: ViewModelBase
{
    private BarangModel _barang;
    public BarangModel Barang
    {
        get { return _barang; }
        set { _barang = value; OnPropertyChanged(); }
    }
    public DetailBarangViewModel()
    {
        var item = Application.Current.Properties["DetailItemKelolaBarang"];
        if (item != null)
        {
            Barang = (BarangModel)item;
        }
    }

}
