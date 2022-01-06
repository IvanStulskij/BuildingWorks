using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects.Address;
using System.Linq;

namespace BuildingWorks.Models.Bases.AddressBase
{
    public class ObjectAddressBase : BaseTable<ObjectAddress>
    {
        private ObjectAddressBase _addressBase;
        private TownBase _townBase;
        private StreetBase _streetBase;
        private RegionBase _regionBase;

        public ObjectAddressBase(BuildingObjectContext context) : base(context)
        {

        }

        public ObjectAddress FindAddress(string regionName, string townName, string streetName)
        {
            _addressBase = new ObjectAddressBase(new BuildingObjectContext());
            return _addressBase.FindAll()
                .Where(address => address.Region.RegionName == regionName)
                .Where(address => address.Town.TownName == townName)
                .Where(address => address.Street.StreetName == streetName)
                .FirstOrDefault();
        }
    }
}
