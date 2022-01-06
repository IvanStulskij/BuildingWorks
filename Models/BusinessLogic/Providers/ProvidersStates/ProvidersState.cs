using System.Collections;

namespace BuildingWorks.Models.BusinessLogic.Providers.ProvidersStates
{
    public class ProvidersState : StateOfProvidersNamespace
    {
        public override IEnumerable GetSourceData()
        {
            return ProviderContext.Providers;
        }
    }
}
