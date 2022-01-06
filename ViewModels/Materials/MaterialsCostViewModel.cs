using BuildingWorks.Models.Bases.Providers;
using BuildingWorks.Models.Databasable.Contexts;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BuildingWorks.ViewModels.Materials
{
    public class MaterialsCostViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly MaterialsPriceBase _materialsPriceBase;
        private readonly ProviderContext _providersContext = new ProviderContext();

        public MaterialsCostViewModel()
        {
            _materialsPriceBase = new MaterialsPriceBase(_providersContext);
        }

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        public RelayCommand<string> CountMaterialsCostByObject
        {
            get
            {
                return new RelayCommand<string>
                    (
                        objectId =>
                        {
                            _materialsPriceBase.GetMaterialsPrice(System.Convert.ToInt32(objectId));
                        }
                    );
            }
        }
    }
}
