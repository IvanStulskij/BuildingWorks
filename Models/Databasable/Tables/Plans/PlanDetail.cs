using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.Plans
{
    public class PlanDetail : ITableRecord
    {
        [Key]
        public int PlanDetailCode { get; set; }
        public string WorkPart { get; set; }
        public bool IsCompleted { get; set; }
        public float Price { get; set; }
        public Plan Plan { get; set; }
    }
}
