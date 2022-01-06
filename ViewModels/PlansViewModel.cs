using BuildingWorks.Models.Databasable.Contexts;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using BuildingWorks.Models.Databasable.Tables.Plans;
using System.Collections.Generic;
using BuildingWorks.Models.Bases.PlansBase;
using BuildingWorks.ViewModels.Plans;

namespace BuildingWorks.ViewModels
{
    public class PlansViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public PlansDetailsViewModel PlansDetailsViewModel { get; } = new PlansDetailsViewModel();

        private readonly PlansContext _plansContext = new PlansContext();
        private readonly PlanBase _planBase;
        private List<Plan> _dataToSelect = new List<Plan>();

        public PlansViewModel()
        {
            _planBase = new PlanBase(_plansContext);
        }

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        public List<string> PropertiesNames
        {
            get
            {
                return _planBase.SelectPropertiesNames().ToList();
            }
            set
            {
                OnPropertyChanged(nameof(PropertiesNames));
            }
        }

        public List<Plan> DataToSelect
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

        public RelayCommand<Tuple<string, string>> FindPlansByCondition
        {
            get
            {
                return new RelayCommand<Tuple<string, string>>
                (
                    condition =>
                    {
                        if (condition != null)
                        {
                            DataToSelect = _planBase.SelectByCondition(condition).ToList();
                        }
                    }
                );
            }
        }
    }
}
