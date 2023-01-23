using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDIA.Models;

namespace SIDIA.ViewModels;

 public class EditBarangViewModel: ViewModelBase
{
    private BarangModel _barang;
    public BarangModel Barang
    {
        get { return _barang; }
        set { _barang = value; OnPropertyChanged(); }
    }
    public EditBarangViewModel()
    {
        var item = Application.Current.Properties["EditItemKelolaBarang"];
        if (item != null)
        {
            Barang = (BarangModel)item;
        }
    }

}
