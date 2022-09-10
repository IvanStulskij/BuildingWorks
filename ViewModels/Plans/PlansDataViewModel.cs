using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using BuildingWorks.Models.BusinessLogic.Plans.States;
using BuildingWorks.Models.Databasable.Tables.Plans;
using GalaSoft.MvvmLight.Command;

namespace BuildingWorks.ViewModels.Plans
{
    public sealed class PlansDataViewModel : ViewModel
    {
        private StateOfPlansData _state;

        private ObservableCollection<object> _dataToSelect;
        public ObservableCollection<object> DataToSelect
        {
            get
            {
                if (_state != null && _state.GetSourceData() != null)
                {
                    return _dataToSelect;
                }
                else
                {
                    return new ObservableCollection<object>(new PlansDataState().GetSourceData().Cast<Plan>());
                }
            }
            set
            {
                _dataToSelect = value;
                OnPropertyChanged(nameof(DataToSelect));
            }
        }

        public RelayCommand SelectAllPlansCommand
        {
            get
            {
                return new RelayCommand
                (
                    () =>
                    {
                        _state = new PlansDataState();
                        IEnumerable sourceData = _state.GetSourceData();
                        if (sourceData != null)
                        {
                            DataToSelect = new ObservableCollection<object>(sourceData.Cast<Plan>());
                        }
                    }
                );
            }
        }

        public RelayCommand<Plan> SelectDetailsCommand
        {
            get
            {
                return new RelayCommand<Plan>
                (
                    plan =>
                    {
                        _state = new PlansDetailDataState(plan.PlanCode);
                        IEnumerable sourceData = _state.GetSourceData();
                        if (sourceData != null)
                        {
                            DataToSelect = new ObservableCollection<object>(sourceData.Cast<PlanDetail>());
                        }
                    }
                );
            }
        }
    }
}
