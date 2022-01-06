using BuildingWorks.Models.Bases;
using BuildingWorks.Models.Databasable.Contexts;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using BuildingWorks.Models.Databasable.Tables.Workers;
using System;
using BuildingWorks.ViewModels.Workers;
using BuildingWorks.Models.BusinessLogic.Workers.Types;

namespace BuildingWorks.ViewModels
{
    public class WorkersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public SalariesViewModel SalariesViewModel { get; private set; } = new SalariesViewModel();
        private readonly WorkersContext _workersContext = new WorkersContext();
        private readonly WorkersBase _workersBase;
        private List<Worker> _dataToSelect;

        public WorkersViewModel()
        {
            _workersBase = new WorkersBase(_workersContext);
        }

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        public List<string> PropertiesNames
        {
            get
            {
                return _workersBase.SelectPropertiesNames().ToList();
            }
            set
            {
                OnPropertyChanged(nameof(PropertiesNames));
            }
        }
        public List<string> WorkersTypes
        {
            get
            {
                return WorkerType.List.Select(type => type.Name).ToList();
            }
            set
            {
                OnPropertyChanged(nameof(WorkersTypes));
            }
        }

        public List<Worker> DataToSelect
        {
            get
            {
                return _dataToSelect;
            }
            set
            {
                _dataToSelect = value;
                OnPropertyChanged(nameof(DataToSelect));
            }
        }

        public RelayCommand<Tuple<string, string>> FindByConditionCommand
        {
            get
            {
                return new RelayCommand<Tuple<string, string>>
                (
                    condition =>
                    {
                        DataToSelect = _workersBase.SelectByCondition(condition).ToList();
                    }
                );
            }
        }

        public RelayCommand<Tuple<string, Brigade, DateTime, string>> AddCommand
        {
            get
            {
                return new RelayCommand<Tuple<string, Brigade, DateTime, string>>
                    (
                        dataToAdd =>
                        {
                            _workersBase.Create(dataToAdd);
                        }
                    );
            }
        }
    }
}
