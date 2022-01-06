using BuildingWorks.Models.Databasable.Tables.BuildingObjects;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects.Address;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Models.Databasable.Contexts
{
    public class BuildingObjectContext : ApplicationContext
    {
        public DbSet<BuildingObject> BuildingObject { get; set; }
        public DbSet<ObjectAddress> ObjectAddress { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Street> Streets { get; set; }
    }
}
