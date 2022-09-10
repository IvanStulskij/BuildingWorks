using BuildingWorks.Models.Databasable.Tables.BuildingObjects.Address;
using BuildingWorks.Models.Databasable.Tables.Provides;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.BuildingObjects
{
    public class BuildingObject : ITableRecord
    {
        [Key]
        public int ObjectId { get; private set; }
        [Display(Name = "Наименование")]
        public string ObjectName { get; set; }
        [Display(Name = "Тип")]
        public string ObjectType { get; set; }
        public string ObjectCustomer { get; set; }
        public Region Region { get; set; }
        public Town Town { get; set; }
        public Street Street { get; set; }
        public List<ContractsByMaterials> Contracts { get; set; }
    }
}
