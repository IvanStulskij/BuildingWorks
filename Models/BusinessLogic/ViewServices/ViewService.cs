using System;
using System.Windows;

namespace BuildingWorks.Models.BusinessLogic.ViewServices
{
    public class ViewService<T> : IViewService where T : Window
    {
        private T _view;

        public ViewService(T view)
        {
            _view = view;
        }
        
        public void Open()
        {
            if (_view != null)
            {
                _view.Activate();
                //_view.
            }
        }
    }
}
