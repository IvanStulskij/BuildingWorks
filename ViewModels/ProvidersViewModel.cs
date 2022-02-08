using System;
using GalaSoft.MvvmLight.Command;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Provides;
using BuildingWorks.Models.Bases;
using BuildingWorks.ViewModels.Materials;
using BuildingWorks.ViewModels.Operations;

namespace BuildingWorks.ViewModels
{
    public class ProvidersViewModel : ViewModel
    {

        public MaterialsCostViewModel MaterialsCostViewModel { get; private set; } = new MaterialsCostViewModel();
        public ProviderStatesViewModel ProviderStatesViewModel { get; private set; } = new ProviderStatesViewModel();
        public DataViewModel<Provider> DataViewModel { get; private set; }
        public RemoveViewModel<Provider> RemoveViewModel { get; set; }

        private readonly ProviderContext _context = new ProviderContext();
        private ProvidersBase _providersBase;

        public ProvidersViewModel()
        {
            _providersBase = new ProvidersBase(_context);
            DataViewModel = new DataViewModel<Provider>(_context.Providers);
            RemoveViewModel = new RemoveViewModel<Provider>(DataViewModel, _context.Providers, _providersBase);
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
    }
}
