using BuildingWorks.Models.Databasable.Tables.Provides;
using System.Collections;
using System.Linq;

namespace BuildingWorks.Models.BusinessLogic.Providers.ProvidersStates
{
    public class MaterialsState : StateOfProvidersNamespace
    {
        private readonly Contract _contract;

        public MaterialsState(Contract contract)
        {
            _contract = contract;
        }

        public override IEnumerable GetSourceData()
        {
            return ProviderContext.ContractsByMaterials
                .Where(contract => contract.Contract == _contract)
                .Select(contract => contract.Material);
        }
    }
}
