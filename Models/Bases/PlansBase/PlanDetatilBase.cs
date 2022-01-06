using BuildingWorks.GlobalConstants;
using BuildingWorks.Models.BusinessLogic.Plans;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Plans;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingWorks.Models.Bases.PlansBase
{
    public class PlanDetatilBase : BaseTable<PlanDetail>
    {
        private readonly PlansContext _plansContext;

        public PlanDetatilBase(PlansContext context) : base(context)
        {
            _plansContext = context;
        }

        public float CountDonePercent(int plan)
        {
            IEnumerable<PlanDetail> plansDetails = FindDetailsByPlan(plan);
            IEnumerable<PlanDetail> donePlanDetails = FindDoneDetailByPlan(plansDetails);

            float totalCount = Convert.ToSingle(plansDetails.Count());
            float doneCount = Convert.ToSingle(donePlanDetails.Count());

            var planBenefit = new PlanCompletePercent(totalCount, doneCount);

            return MathF.Round(planBenefit.Count() * 100, MathConstants.DigitsToOutput);
        }

        private IEnumerable<PlanDetail> FindDoneDetailByPlan(IEnumerable<PlanDetail> planDetails)
        {
            return planDetails.Where(planDetail => planDetail.IsCompleted == true);
        }

        private IEnumerable<PlanDetail> FindDetailsByPlan(int planCode)
        {
            return _plansContext.PlansDetails
                .Where(planDetail => planDetail.Plan.PlanCode == planCode);
        }
    }
}
