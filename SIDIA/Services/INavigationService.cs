using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDIA.Services
{
    public interface INavigationService
    {
        void NavigateTo(Type pageType);
        void NavigateTo(Type pageType, object parameter);
        void NavigateTo(object content, object parameter);
        void NavigateTo(object content);
        void GoBack();
    }
}
