using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace BuildingWorks.Models.Databasable.Tables
{
    public static class DbSetExtensions
    {
        public static IQueryable<T> FindByProperty<T>(
            this DbSet<T> tableToSearch,
            IProperty property,
            object paramToSearch)
            where T : class, ITableRecord
        {
            return tableToSearch.FromSqlRaw
                (
                    new TemplateConditionalSelectQuery
                    (
                        tableToSearch.EntityType.DisplayName(),
                        property.Name,
                        paramToSearch.ToString()
                    )
                    .Query
                );
        }
    }
}
