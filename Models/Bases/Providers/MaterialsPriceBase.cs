using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Provides;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BuildingWorks.Models.Bases.Providers
{
    public class MaterialsPriceBase : BaseTable<ContractsByMaterials>
    {
        private new readonly ProviderContext _context;

        public MaterialsPriceBase(ProviderContext context) : base(context)
        {
            _context = context;
        }

        public float GetMaterialsPrice(int objectId)
        {
            IEnumerable<ContractsByMaterials> contractsByMaterials = GetContractsByMaterials(objectId).AsQueryable()
                .Include(contractPart => contractPart.Material);
            float totalPrice = 0;

            foreach (var contractParts in contractsByMaterials)
            {
                totalPrice += (float)(contractParts.Material.PricePerOne * contractParts.Amount);
            }
            
            return totalPrice;
        }

        private IEnumerable<ContractsByMaterials> GetContractsByMaterials(int objectId)
        {
            return FindAll().Where(contractPart => contractPart.BuildingObject.ObjectId == objectId);
        }
    }
}
