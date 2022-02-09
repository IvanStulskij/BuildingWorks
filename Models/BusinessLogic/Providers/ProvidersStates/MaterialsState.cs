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
            //List<int> a = new List<object>();
            //var a = ProviderContext.Contracts.EntityType.GetProperties().Where(property => property.Name == "abc");
            /*MaterialsBase materialsBase = new MaterialsBase(new Databasable.Contexts.ProviderContext());
            
            materialsBase.FindByCondition(material => material.PricePerOne > 5);*/
            return ProviderContext.ContractsByMaterials
                .Where(contract => contract.Contract == _contract)
                .Select(contract => contract.Material);
        }
    }
}
