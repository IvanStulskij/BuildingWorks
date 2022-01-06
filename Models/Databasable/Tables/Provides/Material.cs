using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.Provides
{
    public class Material : IProvidersNamespaceRecord
    {
        [Key]
        public int MaterialCode { get; set; }
        public string Name { get; set; }
        public decimal PricePerOne { get; set; }
        public string Measure { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
