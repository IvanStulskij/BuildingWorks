using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using BuildingWorks.Models.Bases.Providers;
using BuildingWorks.Models.Databasable.Contexts;

namespace BuildingWorks.ViewModels.Providers
{
    public class MaterialViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ProviderContext _providerContext = new ProviderContext();
        private MaterialsBase _materialsBase;

        public MaterialViewModel()
        {
            _materialsBase = new MaterialsBase(_providerContext);
        }

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        public RelayCommand<Tuple<string, decimal, string>> AddCommand
        {
            get
            {
                return new RelayCommand<Tuple<string, decimal, string>>
                    (
                        materialInfo =>
                        {
                            _materialsBase.Create(materialInfo);
                        }
                    );
            }
        }
    }
}
