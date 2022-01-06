using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingWorks.Models.Databasable.Tables.Workers
{
    public class WorkerSalary
    {
        [Key]
        public int SalaryCode { get; set; }
        public float BaseSalary { get; set; }
        public float Experience { get; set; }
        public int ChildrenCount { get; set; }
        public int WorkedDays { get; set; }
        public float TotalAmount { get; set; }
        public int PersonnelNumber { get; set; }
        [ForeignKey("PersonnelNumber")]
        public Worker Worker { get; set; }
    }
}
