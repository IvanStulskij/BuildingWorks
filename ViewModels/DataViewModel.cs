using System;
using System.Collections.ObjectModel;
using BuildingWorks.Models.Bases;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.ViewModels
{
    public class DataViewModel<T> : ViewModel where T : class
    {
        private readonly SelectionBase<T> _selectionBase;
        private readonly DbSet<T> _data;

        public DataViewModel(DbSet<T> data)
        {
            _data = data;
            _dataToSelect = new ObservableCollection<T>(_data);
            _selectionBase = new SelectionBase<T>(_data);
            _propertiesNames = new ObservableCollection<string>(_selectionBase.GetPropertiesNames());
        }

        private T _selectedValue;
        public T SelectedValue
        {
            get
            {
                return _selectedValue;
            }
            set
            {
                _selectedValue = value;
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private ObservableCollection<T> _dataToSelect;
        public ObservableCollection<T> DataToSelect
        {
            get
            {
                if (_dataToSelect == null)
                {
                    return new ObservableCollection<T>();
                }

                return _dataToSelect;
            }
            set
            {
                _dataToSelect = value;
                OnPropertyChanged(nameof(DataToSelect));
            }
        }

        private ObservableCollection<string> _propertiesNames;
        public ObservableCollection<string> PropertiesNames
        {
            get
            {
                if (_propertiesNames == null)
                {
                    return new ObservableCollection<string>();
                }

                return _propertiesNames;
            }
            set
            {
                _propertiesNames = PropertiesNames;
                OnPropertyChanged(nameof(PropertiesNames));
            }
        }

        public RelayCommand<Tuple<string, string>> Select
        {
            get
            {
                return new RelayCommand<Tuple<string, string>>
                (
                    condition =>
                    {
                        if (condition != null)
                        {
                            
                            DataToSelect = new ObservableCollection<T>(_selectionBase.SelectByCondition(condition));
                        }
                    }
                );
            }
        }
    }
}