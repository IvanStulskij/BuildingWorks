using BuildingWorks.Models.Databasable.Tables.Registration;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Models.Databasable.Contexts
{
    public class UserContext : ApplicationContext
    {
        public DbSet<User> Users { get; private set; }
        public DbSet<UnregisteredUserCode> UnregisteredUsersCodes { get; private set; }
    }
}
