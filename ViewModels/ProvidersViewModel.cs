using BuildingWorks.Models.BusinessLogic.Providers.ProvidersStates;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Provides;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using BuildingWorks.Models.Bases;
using BuildingWorks.ViewModels.Materials;

namespace BuildingWorks.ViewModels
{
    public class ProvidersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MaterialsCostViewModel MaterialsCostViewModel { get; private set; } = new MaterialsCostViewModel();
        public ProviderStatesViewModel ProviderStatesViewModel { get; private set; } = new ProviderStatesViewModel();
        private readonly ProviderContext _providersContext = new ProviderContext();
        private StateOfProvidersNamespace _state;
        private List<Provider> _dataToSelect = new List<Provider>();
        private ProvidersBase _providersBase;

        public ProvidersViewModel()
        {
            _providersBase = new ProvidersBase(_providersContext);
        }

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        public List<string> PropertiesNames
        {
            get
            {
                return _providersBase.SelectPropertiesNames().ToList();
            }
            set
            {
                OnPropertyChanged(nameof(PropertiesNames));
            }
        }

        public List<Provider> DataToSelect
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

        public RelayCommand<Tuple<string, string, string>> AddProvider
        {
            get
            {
                return new RelayCommand<Tuple<string, string, string>>
                (
                    providerData =>
                    {
                        _providersBase.Create(providerData);
                    }
                );
            }
        }
        
        public RelayCommand<int> RemoveProviderCommand
        {
            get
            {
                return new RelayCommand<int>
                (
                    codeToRemove =>
                    {
                        _providersBase.Delete(codeToRemove);
                    }
                );
            }
        }

        public RelayCommand<Tuple<int, Tuple<string, string, string>>> UpdateCommand
        {
            get
            {
                return new RelayCommand<Tuple<int, Tuple<string, string, string>>>
                    (
                        newData =>
                        {
                            _providersBase.Update(newData.Item1, newData.Item2);
                        }
                    );
            }
        }

        /*public RelayCommand SelectAllProvidersCommand
        {
            get
            {
                return new RelayCommand
                (
                    () =>
                    {
                        _state = new ProvidersState();
                        DataToSelect = _state.GetSourceData();
                    }
                );
            }
        }*/

        public RelayCommand<Tuple<string, string>> SelectProviders
        {
            get
            {
                return new RelayCommand<Tuple<string, string>>
                (
                    condition =>
                    {
                        if (condition != null)
                        {
                            DataToSelect = _providersBase.SelectByCondition(condition).ToList();
                        }
                    }
                );
            }
        }
    }
}
