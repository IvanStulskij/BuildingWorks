using BuildingWorks.Models.Bases.Providers;
using BuildingWorks.Models.Databasable.Tables.Provides;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BuildingWorks.Models.BusinessLogic.Providers.ProvidersStates
{
    public class MaterialsState : StateOfProvidersNamespace
    {
        private readonly int _contractCode;

        public MaterialsState(int contractCode)
        {
            _contractCode = contractCode;
        }

        public override IEnumerable GetSourceData()
        {
            //List<int> a = new List<object>();
            //var a = ProviderContext.Contracts.EntityType.GetProperties().Where(property => property.Name == "abc");
            /*MaterialsBase materialsBase = new MaterialsBase(new Databasable.Contexts.ProviderContext());
            
            materialsBase.FindByCondition(material => material.PricePerOne > 5);*/
            return ProviderContext.Contracts
                .Where(contract => contract.ContractCode == _contractCode)
                .FirstOrDefault()
                .Materials;
        }
    }
}
