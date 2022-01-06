using BuildingWorks.Models.Databasable.Tables.BuildingObjects;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingWorks.Models.Databasable.Tables.Plans
{
    public class Plan : ITableRecord
    {
        [Key]
        public int PlanCode { get; set; }
        [Column("CompleteTime")]
        public DateTime ComplitionTime { get; set; }
        public bool IsCompleted { get; set; }
        public decimal Cost { get; set; }
        public string PathToImage { get; set; }
        public BuildingObject Object { get; set; }
    }
}