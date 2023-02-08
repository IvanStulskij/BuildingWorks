using BuildingWorks.Models.Bases.AddressBase;
using BuildingWorks.Models.Databasable.Contexts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BuildingWorks.ViewModels.BuildingObjects
{
    public class AddressViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly BuildingObjectContext _buildingObjectContext = new BuildingObjectContext();

        private StreetBase _streetBase;
        private TownBase _townBase;
        private RegionBase _regionBase;

        private IReadOnlyList<string> _townsNames;
        private IReadOnlyList<string> _streetsNames;

        private string _selectedRegion;
        private string _selectedTown;

        public AddressViewModel()
        {
            _regionBase = new RegionBase(_buildingObjectContext);
            _townBase = new TownBase(_buildingObjectContext);
            _streetBase = new StreetBase(_buildingObjectContext);
        }

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
            }
        }

        public IReadOnlyList<string> StreetsNames
        {
            get
            {
                return _streetsNames;
            }
            set
            {
                _streetsNames = value;
                OnPropertyChanged(nameof(StreetsNames));
            }
        }

        public IReadOnlyList<string> TownsNames
        {
            get
            {
                return _townsNames;
            }
            set
            {
                _townsNames = value;
                OnPropertyChanged(nameof(TownsNames));
            }
        }
        
        public IReadOnlyList<string> RegionsNames
        {
            get
            {
                return _regionBase.FindAll().Select(region => region.RegionName).ToList();
            }
        }

        public string SelectedRegion
        {
            get
            {
                return _selectedRegion;
            }
            set
            {
                _selectedRegion = value;
                OnPropertyChanged(nameof(SelectedRegion));

                TownsNames = _townBase.FindByRegion(SelectedRegion)
                    .Select(town => town.TownName).ToList();
            }
        }

        public string SelectedTown
        {
            get
            {
                return _selectedTown;
            }
            set
            {
                _selectedTown = value;
                OnPropertyChanged(nameof(SelectedTown));

                StreetsNames = _streetBase.FindByTown(SelectedTown)
                    .Select(street => street.StreetName).ToList();
            }
        }
    }
}
