using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.BuildingObjects.Address
{
    public class Town : ITableRecord
    {
        [Key]
        public int TownCode { get; set; }
        public string TownName { get; set; }

        public Region Region { get; set; }
        public List<Street> Streets { get; set; }
    }
}
