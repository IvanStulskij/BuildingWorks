using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects.Address;
using System.Collections.Generic;
using System.Linq;

namespace BuildingWorks.Models.Bases.AddressBase
{
    public class TownBase : BaseTable<Town>
    {
        private new readonly BuildingObjectContext _context;

        public TownBase(BuildingObjectContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Town> FindByRegion(string regionName)
        {
            if (regionName != null)
            {
                return _context.Towns.Where(town => town.Region.RegionName == regionName);
            }
            else
            {
                return FindAll();
            }
        }

        public Town FindByName(string townName)
        {
            return FindByCondition(town => town.TownName == townName)
                .FirstOrDefault();
        }
    }
}
