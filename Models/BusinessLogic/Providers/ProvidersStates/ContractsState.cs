using BuildingWorks.Models.Databasable.Tables.Provides;
using System.Collections;
using System.Linq;

namespace BuildingWorks.Models.BusinessLogic.Providers.ProvidersStates
{
    public class ContractsState : StateOfProvidersNamespace
    {
        private readonly Provider _provider;

        public ContractsState(Provider provider)
        {
            _provider = provider;
        }

        public override IEnumerable GetSourceData()
        {
            return ProviderContext.Contracts
                .Where(contract => contract.Provider == _provider);
        }
    }
}
