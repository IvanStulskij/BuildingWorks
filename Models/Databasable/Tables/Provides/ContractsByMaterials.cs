using BuildingWorks.Models.Databasable.Tables.BuildingObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingWorks.Models.Databasable.Tables.Provides
{
    public class ContractsByMaterials : ITableRecord
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("BuildingObjectId")]
        public BuildingObject BuildingObject { get; set; }
        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }
        [ForeignKey("MaterialId")]
        public Material Material { get; set; }
        public int Amount { get; set; }
    }
}
