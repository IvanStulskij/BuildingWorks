using BuildingWorks.Models.Bases.PlansBase;
using BuildingWorks.Models.Databasable.Contexts;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace BuildingWorks.ViewModels.Plans
{
    public class PlansDetailsViewModel : ViewModel
    {
        private readonly PlansContext _plansContext = new PlansContext();
        private readonly PlanDetatilBase _planDetatilBase;

        public PlansDetailsViewModel()
        {
            _planDetatilBase = new PlanDetatilBase(_plansContext);
        }

        private float _donePercent;

        public float DonePercent
        {
            get
            {
                return _donePercent;
            }
            set
            {
                _donePercent = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<string> CountDonePercentCommand
        {
            get
            {
                return new RelayCommand<string>
                    (
                        done =>
                        {
                            DonePercent = _planDetatilBase.CountDonePercent(Convert.ToInt32(done));
                        }
                    );
            }
        }
    }
}
