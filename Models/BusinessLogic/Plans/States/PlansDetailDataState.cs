using System.Collections;
using System.Linq;

namespace BuildingWorks.Models.BusinessLogic.Plans.States
{
    public sealed class PlansDetailDataState : StateOfPlansData
    {
        private readonly int _planId;

        public PlansDetailDataState(int planId)
        {
            _planId = planId;
        }

        public override IEnumerable GetSourceData()
        {
            return Context.PlansDetails
                .Where(detail => detail.PlanId == _planId);
        }
    }
}
