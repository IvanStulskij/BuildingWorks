using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BuildingWorks.Models.Databasable;

namespace BuildingWorks.Models.Bases
{
    public class SelectionBase<T> where T : class
    {
        private readonly DbSet<T> _data;

        public SelectionBase(DbSet<T> data)
        {
            _data = data;
        }

        public IEnumerable<T> SelectByCondition(Tuple<string, string> condition)
        {
            var conditionalSelectQuery = new TemplateConditionalSelectQuery
            (
                _data.EntityType.GetTableName(),
                condition.Item1,
                condition.Item2
            );

            return _data.FromSqlRaw(conditionalSelectQuery.Query);
        }

        public IEnumerable<string> GetPropertiesNames()
        {
            return _data.EntityType.GetProperties()
                .Select(property => property.Name);
        }
    }
}
