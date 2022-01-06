using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Provides;
using System;

namespace BuildingWorks.Models.Bases.Providers
{
    public class MaterialsBase : BaseTable<Material>
    {
        private new readonly ProviderContext _context;

        public MaterialsBase(ProviderContext context) : base(context)
        {
            _context = context;
        }

        public void Create(Tuple<string, decimal, string> dataToCreate)
        {
            Create
                (
                    new Material
                    {
                        Name = dataToCreate.Item1,
                        PricePerOne = dataToCreate.Item2,
                        Measure = dataToCreate.Item3
                    }
                );

            _context.SaveChanges();
        }
    }
}
