using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.BuildingObjects.Address
{
    public class Region : ITableRecord
    {
        [Key]
        public int RegionCode { get; set; }
        public string RegionName { get; set; }
        public List<Town> Towns { get; set; }
    }
}
