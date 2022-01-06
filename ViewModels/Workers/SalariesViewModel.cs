using BuildingWorks.Models.Bases.Workers;
using BuildingWorks.Models.Databasable.Contexts;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BuildingWorks.ViewModels.Workers
{
    public class SalariesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly SalariesBase _salariesBase;
        private readonly WorkersContext _workersContext = new WorkersContext();

        public SalariesViewModel()
        {
            _salariesBase = new SalariesBase(_workersContext);
        }

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        public RelayCommand<string> CountWorkersSalariesByObject
        {
            get
            {
                return new RelayCommand<string>
                    (
                        buildingObject =>
                        {
                            _salariesBase.GetTotalSalariesOfObject(Convert.ToInt32(buildingObject));
                        }
                    );
            }
        }
    }
}
