using BuildingWorks.Models.Databasable.Tables.Provides;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Models.Databasable.Contexts
{
    public class ProviderContext : ApplicationContext
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ContractsByMaterials> ContractsByMaterials { get; set; }
    }
}
