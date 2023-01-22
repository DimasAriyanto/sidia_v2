using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Mvvm.Services;
using SIDIA.ViewModels;

namespace SIDIA.Views
{
    /// <summary>
    /// Interaction logic for KelolaBarangView.xaml
    /// </summary>
    public partial class KelolaBarangView : Page
    {
        public KelolaBarangView()
        {
            InitializeComponent();

            Window winwow = Window.GetWindow(this);
            var frame = (Frame)this.FindName("RootFrame");
            var kelolaBarangViewModel = new KelolaBarangViewModel(frame);
            DataContext = kelolaBarangViewModel;
        }
    }
}
