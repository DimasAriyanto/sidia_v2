using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SIDIA.Services
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;
        public NavigationService(Frame frame)
        {
            _frame = frame;
        }
        public void NavigateTo(Type pageType)
        {
            _frame.Navigate(pageType);
        }
        public void NavigateTo(Type pageType, object parameter)
        {
            _frame.Navigate(pageType, parameter);
        }
        public void NavigateTo(object content, object parameter)
        {
            _frame.Navigate(content, parameter);
        }
        public void NavigateTo(object content)
        {
            _frame.Navigate(content);
        }
        public void GoBack()
        {
            _frame.GoBack();
        }
    }
}
