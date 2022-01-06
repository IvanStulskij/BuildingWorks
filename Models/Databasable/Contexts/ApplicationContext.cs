using BuildingWorks.GlobalConstants;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace BuildingWorks.Models.Databasable.Contexts
{
    public abstract class ApplicationContext : DbContext, IContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnectionConstants.ConnectionString);
        }
    }
}
