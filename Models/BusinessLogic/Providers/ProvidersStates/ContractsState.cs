using System.Collections;
using System.Linq;

namespace BuildingWorks.Models.BusinessLogic.Providers.ProvidersStates
{
    public class ContractsState : StateOfProvidersNamespace
    {
        private readonly int _providerCode;

        public ContractsState(int providerCode)
        {
            _providerCode = providerCode;
        }

        public override IEnumerable GetSourceData()
        {
            return ProviderContext.Contracts
                .Where(contract => contract.Provider.ProviderCode == _providerCode);
        }
    }
}
