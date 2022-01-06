using BuildingWorks.Models.Databasable.Tables.Plans;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Models.Databasable.Contexts
{
    public class PlansContext : ApplicationContext
    {
        public DbSet<Plan> Plans { get; private set; }
        public DbSet<PlanDetail> PlansDetails { get; private set; }
    }
}
