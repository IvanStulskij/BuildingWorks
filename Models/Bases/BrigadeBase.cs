using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Workers;
using System.Collections.Generic;
using System.Linq;

namespace BuildingWorks.Models.Bases
{
    public class BrigadeBase : BaseTable<Brigade>
    {
        private readonly WorkersContext _workersContext;

        public BrigadeBase(WorkersContext context) : base(context)
        {
            _workersContext = context;
        }

        public IEnumerable<int> SelectBrigadesCodes()
        {
            return FindAll().Select(brigade => brigade.BrigadeCode);
        }

        public IEnumerable<Brigade> GetBrigadesOfObject(int objectCode)
        {
            return FindAll()
                .Where(brigade => brigade.Object.ObjectId == objectCode);
        }
    }
}
