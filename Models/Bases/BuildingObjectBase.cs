using BuildingWorks.Models.Bases.AddressBase;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects;

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

        public void Create((string name, object region, object town, object street, string customer, string type) dataToCreate)
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

        public void Update((BuildingObject objectToUpdate, string name, object region, object town, object street, string customer, string type) data)
        {
            data.objectToUpdate.ObjectName = data.name;
            data.objectToUpdate.ObjectCustomer = data.customer;
            data.objectToUpdate.ObjectType = data.type;

            _buildingObjectContext.SaveChanges();
        }
    }
}