using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.BuildingObjects.Address
{
    public class ObjectAddress : ITableRecord
    {
        [Key]
        public int AddressCode { get; set; }
        public Region Region { get; set; }
        public Town Town { get; set; }
        public Street Street { get; set; }
    }
}
