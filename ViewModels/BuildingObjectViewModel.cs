using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects;
using System.Linq;
using BuildingWorks.ViewModels.BuildingObjects;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using BuildingWorks.Models.Bases;
using BuildingWorks.Models.BusinessLogic.BuildingObjects;

namespace BuildingWorks.ViewModels
{
    public class BuildingObjectViewModel : ViewModel
    {
        public AddressViewModel AddressViewModel { get; set; } = new AddressViewModel();
        public DataViewModel<BuildingObject> DataViewModel { get; set; }

        private readonly BuildingObjectContext _objectContext = new BuildingObjectContext();

        private BuildingObjectBase _buildingObjectBase;


        public BuildingObjectViewModel()
        {
            _buildingObjectBase = new BuildingObjectBase(_objectContext);
            DataViewModel = new DataViewModel<BuildingObject>(_objectContext.BuildingObject);
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
                            _buildingObjectBase.Create(buildingObject.ToValueTuple());
                        }
                    );
            }
        }

        public RelayCommand<int> RemoveCommand
        {
            get
            {
                return new RelayCommand<int>
                    (
                        codeToRemove =>
                        {
                            _buildingObjectBase.Delete(codeToRemove);
                        }
                    );
            }
        }

        public RelayCommand<Tuple<int, Tuple<string, object, object, object, string, string>>> UpdateCommand
        {
            get
            {
                return new RelayCommand<Tuple<int, Tuple<string, object, object, object, string, string>>>
                    (
                        newData =>
                        {
                            _buildingObjectBase.Update(newData.Item1, newData.Item2);
                        }
                    );
            }
        }
    }
}
