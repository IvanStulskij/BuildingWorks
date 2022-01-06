using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.Provides
{
    public class Contract : IProvidersNamespaceRecord
    {
        [Key]
        public int ContractCode { get; set; }
        public string Conditions { get; set; }
        public int ProviderCode { get; set; }
        public Provider Provider { get; set; }
        public List<Material> Materials { get; set; }
    }
}
