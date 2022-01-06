using BuildingWorks.Models.Databasable.Tables.Workers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Models.Databasable.Contexts
{
    public class WorkersContext : ApplicationContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Brigade> Brigades { get; set; }
        public DbSet<WorkerSalary> WorkersSalaries { get; set; }
    }
}
