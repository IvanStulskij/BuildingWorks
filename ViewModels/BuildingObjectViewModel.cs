using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using BuildingWorks.ViewModels.BuildingObjects;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using BuildingWorks.Models.Bases;
using BuildingWorks.Models.BusinessLogic.BuildingObjects;

namespace BuildingWorks.ViewModels
{
    public class BuildingObjectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AddressViewModel AddressViewModel { get; set; } = new AddressViewModel();
        private BuildingObjectBase _buildingObjectBase;
        private List<BuildingObject> _dataToSelect;

        public BuildingObjectViewModel()
        {
            _buildingObjectBase = new BuildingObjectBase(new BuildingObjectContext());
        }

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
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

        public List<BuildingObject> DataToSelect
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

        public List<string> PropertiesNames
        {
            get
            {
                return _buildingObjectBase.SelectPropertiesNames().ToList();
            }
            set
            {
                OnPropertyChanged(nameof(PropertiesNames));
            }
        }

        public RelayCommand<(string, object, object, object, string, string)> AddCommand
        {
            get
            {
                return new RelayCommand<(string name, object region, object town, object street, string customer, string type)>
                    (
                        buildingObject =>
                        {
                            _buildingObjectBase.Create(buildingObject);
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

        public RelayCommand<Tuple<string, string>> FindByConditionCommand
        {
            get
            {
                return new RelayCommand<Tuple<string, string>>
                    (
                        condition =>
                        {
                            DataToSelect = _buildingObjectBase.SelectByCondition(condition).ToList();
                        }
                    );
            }
        }
    }
}
