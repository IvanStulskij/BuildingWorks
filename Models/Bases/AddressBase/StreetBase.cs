using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects.Address;
using System.Collections.Generic;
using System.Linq;

namespace BuildingWorks.Models.Bases.AddressBase
{
    public class StreetBase : BaseTable<Street>
    {
        private readonly new BuildingObjectContext _context;

        public StreetBase(BuildingObjectContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Street> FindByTown(string townName)
        {
            if (townName != null)
            {
                return _context.Streets.Where(street => street.Town.TownName == townName);
            }
            else
            {
                return FindAll();
            }
        }

        public Street FindByName(string streetName)
        {
            return FindByCondition(street => street.StreetName == streetName)
                .FirstOrDefault();
        }
    }
}
