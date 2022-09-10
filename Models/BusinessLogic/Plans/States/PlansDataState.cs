using System.Collections;

namespace BuildingWorks.Models.BusinessLogic.Plans.States
{
    public sealed class PlansDataState : StateOfPlansData
    {
        public override IEnumerable GetSourceData()
        {
            return Context.Plans;
        }
    }
}
