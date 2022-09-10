using System.Collections;
using BuildingWorks.Models.Databasable.Contexts;

namespace BuildingWorks.Models.BusinessLogic.Plans.States
{
    public abstract class StateOfPlansData
    {
        protected PlansContext Context { get; } = new PlansContext();
        public abstract IEnumerable GetSourceData();
    }
}
