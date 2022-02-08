using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using BuildingWorks.Models.Bases;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Workers;
using BuildingWorks.ViewModels.Workers;
using BuildingWorks.Models.BusinessLogic.Workers.Types;
using BuildingWorks.ViewModels.Operations;

namespace BuildingWorks.ViewModels
{
    public class WorkersViewModel : ViewModel
    {
        public SalariesViewModel SalariesViewModel { get; private set; } = new SalariesViewModel();
        public DataViewModel<Worker> DataViewModel { get; private set; }
        public RemoveViewModel<Worker> RemoveViewModel { get; set; }
        private readonly WorkersContext _workersContext = new WorkersContext();
        private readonly WorkersBase _workersBase;

        public WorkersViewModel()
        {
            _workersBase = new WorkersBase(_workersContext);
            DataViewModel = new DataViewModel<Worker>(_workersContext.Workers);
            RemoveViewModel = new RemoveViewModel<Worker>(DataViewModel, _workersContext.Workers, _workersBase);
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
