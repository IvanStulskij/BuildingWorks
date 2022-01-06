﻿using BuildingWorks.GlobalConstants;
using BuildingWorks.Models.Databasable;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Provides;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingWorks.Models.Bases
{
    public class ProvidersBase : BaseTable<Provider>
    {
        private readonly ProviderContext _providersContext;

        public ProvidersBase(ProviderContext context) : base(context)
        {
            _providersContext = context;
        }

        public void Create(Tuple<string, string, string> data)
        {
            Create(new Provider()
            {
                Name = data.Item1,
                Country = data.Item2,
                AdditionalData = data.Item3
            });

            _providersContext.SaveChanges();
        }

        public void Delete(int codeToRemove)
        {
            _providersContext.Providers
                .Remove
                (
                    _providersContext.Providers
                    .Where(provider => provider.ProviderCode == codeToRemove)
                    .FirstOrDefault()
                );

            _providersContext.SaveChanges();
        }

        public void Update(int codeToUpdate, Tuple<string, string, string> newData)
        {
            Provider providerToUpdate = _providersContext.Providers
                .Where
                (
                    provider => provider.ProviderCode == codeToUpdate
                ).FirstOrDefault();
            providerToUpdate.Name = newData.Item1;
            providerToUpdate.Country = newData.Item2;
            providerToUpdate.AdditionalData = newData.Item3;

            _providersContext.SaveChanges();
        }

        public IEnumerable<Provider> SelectByCondition(Tuple<string, string> condition)
        {
            var conditionalSelectQuery = new TemplateConditionalSelectQuery
            (
                TableNames.ProvidersBase,
                condition.Item1,
                condition.Item2
            );
            return _providersContext.Providers.FromSqlRaw(conditionalSelectQuery.Query);
        }

        public IEnumerable<string> SelectPropertiesNames()
        {
            return _providersContext.Providers.EntityType.GetProperties()
                .Select(property => property.Name);
        }
    }
}
