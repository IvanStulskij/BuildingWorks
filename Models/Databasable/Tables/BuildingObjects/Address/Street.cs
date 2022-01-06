using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.BuildingObjects.Address
{
    public class Street : ITableRecord
    {
        [Key]
        public int StreetCode { get; set; }
        public string StreetName { get; set; }
        public Town Town { get; set; }
    }
}
