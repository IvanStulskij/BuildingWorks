using BuildingWorks.Models.Databasable.Contexts;
using System.Collections;

namespace BuildingWorks.Models.BusinessLogic.Providers.ProvidersStates
{
    public abstract class StateOfProvidersNamespace
    {
        protected ProviderContext ProviderContext { get; } = new ProviderContext();
        public abstract IEnumerable GetSourceData();
    }
}
