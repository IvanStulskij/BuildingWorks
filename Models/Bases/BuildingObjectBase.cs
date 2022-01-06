using BuildingWorks.GlobalConstants;
using BuildingWorks.Models.Bases.AddressBase;
using BuildingWorks.Models.Databasable;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingWorks.Models.Bases
{
    public class BuildingObjectBase : BaseTable<BuildingObject>
    {
        private readonly BuildingObjectContext _buildingObjectContext;
        private readonly RegionBase _regionBase;
        private readonly TownBase _townBase;
        private readonly StreetBase _streetBase;

        public BuildingObjectBase(BuildingObjectContext context) : base(context)
        {
            _buildingObjectContext = context;
            _regionBase = new RegionBase(_buildingObjectContext);
            _townBase = new TownBase(_buildingObjectContext);
            _streetBase = new StreetBase(_buildingObjectContext);
        }

        public void Create(/*Tuple<string, object, object, object, string, string> dataToCreate*/ (string name, object region, object town, object street, string customer, string type) dataToCreate)
        {
            Create
                (
                    new BuildingObject
                    {
                        ObjectName = dataToCreate.name,
                        Region = _regionBase.FindByName(dataToCreate.region.ToString()),
                        Town = _townBase.FindByName(dataToCreate.town.ToString()),
                        Street = _streetBase.FindByName(dataToCreate.street.ToString()),
                        ObjectCustomer = dataToCreate.customer,
                        ObjectType = dataToCreate.type
                    }
                );

            _buildingObjectContext.SaveChanges();
        }

        public void Delete(int codeToRemove)
        {
            _buildingObjectContext.BuildingObject.Remove
                (
                    _buildingObjectContext.BuildingObject.Where
                    (
                        buildingObject => buildingObject.ObjectId == codeToRemove
                    ).FirstOrDefault()
                );

            _buildingObjectContext.SaveChanges();
        }

        public void Update(int codeToUpdate, Tuple<string, object, object, object, string, string> newData)
        {
            BuildingObject objectToUpdate = _buildingObjectContext.BuildingObject
                .Where(buildingObject => buildingObject.ObjectId == codeToUpdate)
                .FirstOrDefault();
            objectToUpdate.ObjectName = newData.Item1;
            objectToUpdate.ObjectCustomer = newData.Item5;
            objectToUpdate.ObjectType = newData.Item6;

            _buildingObjectContext.SaveChanges();
        }

        public IEnumerable<BuildingObject> SelectByCondition(Tuple<string, string> condition)
        {
            var conditionalSelectQuery = new TemplateConditionalSelectQuery
            (
                TableNames.BuildingObjectName,
                condition.Item1,
                condition.Item2
            );

            return _buildingObjectContext.BuildingObject.FromSqlRaw(conditionalSelectQuery.Query);
        }

        public IEnumerable<string> SelectPropertiesNames()
        {
            return _buildingObjectContext.BuildingObject.EntityType.GetProperties()
                .Select(property => property.Name);
        }
    }
}