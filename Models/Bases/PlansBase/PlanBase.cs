using System;
using System.Collections.Generic;
using System.Linq;
using BuildingWorks.GlobalConstants;
using BuildingWorks.Models.Databasable;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects;
using BuildingWorks.Models.Databasable.Tables.Plans;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Models.Bases.PlansBase
{
    public class PlanBase : BaseTable<Plan>
    {
        private readonly PlansContext _plansContext;

        public PlanBase(PlansContext context) : base(context)
        {
            _plansContext = context;
        }

        public void Create(Tuple<BuildingObject, DateTime, bool, decimal, string> data)
        {
            Create(new Plan()
            {
                Object = data.Item1,
                ComplitionTime = data.Item2,
                IsCompleted = data.Item3,
                Cost = data.Item4,
                PathToImage = data.Item5
            });

            _plansContext.SaveChanges();
        }

        public void Update(int codeToUpdate, Tuple<BuildingObject, DateTime, bool, decimal, string> newData)
        {
            Plan planToUpdate = _plansContext.Plans
                .Where
                (
                    provider => provider.PlanCode == codeToUpdate
                ).FirstOrDefault();

            planToUpdate.Object = newData.Item1;
            planToUpdate.ComplitionTime = newData.Item2;
            planToUpdate.IsCompleted = newData.Item3;
            planToUpdate.Cost = newData.Item4;
            planToUpdate.PathToImage = newData.Item5;

            _plansContext.SaveChanges();
        }

        public IEnumerable<string> SelectPropertiesNames()
        {
            return _plansContext.Plans.EntityType.GetProperties()
                .Select(property => property.Name);
        }

        public IEnumerable<Plan> SelectByCondition(Tuple<string, string> condition)
        {
            var conditionalSelectQuery = new TemplateConditionalSelectQuery
            (
                TableNames.PlanName,
                condition.Item1,
                condition.Item2
            );

            return _plansContext.Plans.FromSqlRaw(conditionalSelectQuery.Query);
        }
    }
}
