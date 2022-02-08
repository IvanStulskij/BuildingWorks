using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects;
using System.Linq;
using BuildingWorks.ViewModels.BuildingObjects;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using BuildingWorks.Models.Bases;
using BuildingWorks.Models.BusinessLogic.BuildingObjects;
using BuildingWorks.ViewModels.Operations;

namespace BuildingWorks.ViewModels
{
    public class BuildingObjectViewModel : ViewModel
    {
        public AddressViewModel AddressViewModel { get; set; } = new AddressViewModel();
        public DataViewModel<BuildingObject> DataViewModel { get; set; }
        public RemoveViewModel<BuildingObject> RemoveViewModel { get; set; }

        private readonly BuildingObjectContext _context = new BuildingObjectContext();
        private BuildingObjectBase _baseTable;

        public BuildingObjectViewModel()
        {
            _baseTable = new BuildingObjectBase(_context);
            DataViewModel = new DataViewModel<BuildingObject>(_context.BuildingObject);
            RemoveViewModel = new RemoveViewModel<BuildingObject>(DataViewModel, _context.BuildingObject, _baseTable);
        }

        public List<string> BuildingObjectsTypes
        {
            get
            {
                return BuildingsTypes.List.Select(type => type.Name).ToList();
            }
            set
            {
                OnPropertyChanged(nameof(BuildingObjectsTypes));
            }
        }

        public RelayCommand<Tuple<string, object, object, object, string, string>> AddCommand
        {
            get
            {
                return new RelayCommand<Tuple<string, object, object, object, string, string>>
                    (
                        buildingObject =>
                        {
                            _baseTable.Create(buildingObject.ToValueTuple());
                        }
                    );
            }
        }

        public RelayCommand<Tuple<BuildingObject, string, object, object, object, string, string>> UpdateCommand
        {
            get
            {
                return new RelayCommand<Tuple<BuildingObject, string, object, object, object, string, string>>
                    (
                        newData =>
                        {
                            _baseTable.Update(newData.ToValueTuple());
                        }
                    );
            }
        }
    }
}
