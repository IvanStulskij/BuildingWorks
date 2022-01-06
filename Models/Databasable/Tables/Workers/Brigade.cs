using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingWorks.Models.Databasable.Tables.BuildingObjects;

namespace BuildingWorks.Models.Databasable.Tables.Workers
{
    public class Brigade
    {
        [Key]
        public int BrigadeCode { get; set; }
        [Column("ObjectCode")]
        public BuildingObject Object { get; set; }
        [NotMapped]
        public Worker BrigadierCode { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
