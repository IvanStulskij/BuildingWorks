using BuildingWorks.Models.BusinessLogic.Providers.ProvidersStates;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections;
using System.Windows;

namespace BuildingWorks.ViewModels
{
    public class ProviderStatesViewModel : ViewModel
    {
        private StateOfProvidersNamespace _state;

        public IEnumerable DataToSelect
        {
            get
            {
                if (_state != null)
                {
                    return _state.GetSourceData();
                }
                else
                {
                    return new ProvidersState().GetSourceData();
                }
            }
            set
            {
                //_dataToSelect = value;
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
                        MessageBox.Show(_state.GetType().ToString());
                    }
                );
            }
        }

        public RelayCommand<string> SelectContractsCommad
        {
            get
            {
                return new RelayCommand<string>
                (
                    providerCode =>
                    {
                        _state = new ContractsState(Convert.ToInt32(providerCode));
                        MessageBox.Show(_state.GetType().ToString());
                    }
                );
            }
        }

        public RelayCommand<string> SelectMaterialsCommad
        {
            get
            {
                return new RelayCommand<string>
                (
                    contractCode =>
                    {
                        _state = new ContractsState(Convert.ToInt32(contractCode));
                        MessageBox.Show(_state.GetType().ToString());
                    }
                );
            }
        }
    }
}
