using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects.Address;
using System.Linq;

namespace BuildingWorks.Models.Bases.AddressBase
{
    public class RegionBase : BaseTable<Region>
    {
        public RegionBase(BuildingObjectContext context) : base(context)
        {

        }

        public Region FindByName(string regionName)
        {
            return FindByCondition(region => region.RegionName == regionName)
                .FirstOrDefault();
        }
    }
}
