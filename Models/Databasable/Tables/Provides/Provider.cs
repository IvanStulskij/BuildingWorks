using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.Provides
{
    public class Provider : IProvidersNamespaceRecord
    {
        [Key]
        public int ProviderCode { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string AdditionalData { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
