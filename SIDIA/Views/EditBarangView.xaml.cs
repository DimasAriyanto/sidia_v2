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
using SIDIA.ViewModels;

namespace SIDIA.Views
{
    /// <summary>
    /// Interaction logic for DetailBarangView.xaml
    /// </summary>
    public partial class EditBarangView : Page
    {
        public EditBarangView()
        {
            InitializeComponent();
            EditBarangViewModel viewModel = new EditBarangViewModel();
            DataContext = viewModel;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var frame = (Frame) Application.Current.Properties["RootFrame"];
            frame.Navigate(new KelolaBarangView());
        }
    }
}
