using BuildingWorks.Models.BusinessLogic.Providers.ProvidersStates;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.Linq;
using System.Collections.ObjectModel;
using BuildingWorks.Models.Databasable.Tables.Provides;

namespace BuildingWorks.ViewModels
{
    public class ProviderStatesViewModel : ViewModel
    {
        private StateOfProvidersNamespace _state;

        private  ObservableCollection<object> _dataToSelect;
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
                    return new ObservableCollection<object>(new ProvidersState().GetSourceData().Cast<Provider>());
                }
            }
            set
            {
                _dataToSelect = value;
                OnPropertyChanged(nameof(DataToSelect));
                //MessageBox.Show(DataToSelect.GetType().ToString());
            }
        }

        public RelayCommand SelectAllProvidersCommand
        {
            get
            {
                return new RelayCommand
                (
                    () =>
                    {
                        _state = new ProvidersState();
                        IEnumerable sourceData = _state.GetSourceData();
                        if (sourceData != null)
                        {
                            DataToSelect = new ObservableCollection<object>(sourceData.Cast<Provider>());
                        }
                    }
                );
            }
        }

        public RelayCommand<Provider> SelectContractsCommad
        {
            get
            {
                return new RelayCommand<Provider>
                (
                    provider =>
                    {
                        _state = new ContractsState(provider);
                        IEnumerable sourceData = _state.GetSourceData();
                        if (sourceData != null)
                        {
                            DataToSelect = new ObservableCollection<object>(sourceData.Cast<Contract>());
                        }
                    }
                );
            }
        }

        public RelayCommand<Contract> SelectMaterialsCommad
        {
            get
            {
                return new RelayCommand<Contract>
                (
                    contractCode =>
                    {
                        _state = new MaterialsState(contractCode);
                        IEnumerable sourceData = _state.GetSourceData();
                        if (sourceData != null)
                        {
                            DataToSelect = new ObservableCollection<object>(sourceData.Cast<Material>());
                        }
                    }
                );
            }
        }
    }
}
