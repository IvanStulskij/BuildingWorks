using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingWorks.Models.Databasable.Tables.Plans
{
    public class PlanDetail : ITableRecord
    {
        [Key]
        public int PlanDetailCode { get; set; }
        public string WorkPart { get; set; }
        public bool IsCompleted { get; set; }
        public float Price { get; set; }
        [Column("PlanCode")]
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
