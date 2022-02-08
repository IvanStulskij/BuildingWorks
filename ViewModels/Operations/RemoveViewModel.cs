using BuildingWorks.Models.Bases;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace BuildingWorks.ViewModels.Operations
{
    public class RemoveViewModel<T> where T : class
    {
        private readonly DataViewModel<T> _dataViewModel;
        private readonly DbSet<T> _databaseData;
        private readonly BaseTable<T> _baseTable;

        public RemoveViewModel(DataViewModel<T> dataViewModel, DbSet<T> databaseData, BaseTable<T> baseTable)
        {
            _dataViewModel = dataViewModel;
            _databaseData = databaseData;
            _baseTable = baseTable;
        }

        public RelayCommand RemoveCommand
        {
            get
            {
                return new RelayCommand
                (
                    () =>
                    {
                        if (_dataViewModel.SelectedValue != null)
                        {
                            _baseTable.Delete(_dataViewModel.SelectedValue);
                            _dataViewModel.DataToSelect = new ObservableCollection<T>(_databaseData);
                        }
                    }
                );
            }
        }
    }
}
