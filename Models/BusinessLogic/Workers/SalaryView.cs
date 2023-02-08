using BuildingWorks.Models.Databasable.Tables.Workers;

namespace BuildingWorks.Models.BusinessLogic.Workers
{
    public sealed class SalaryView
    {
        public SalaryView(WorkerSalary salaryInfo)
        {
            Worker = salaryInfo.Worker.FullName;
            BaseSalary = salaryInfo.BaseSalary;
            Experience = salaryInfo.Experience;
            Experience = salaryInfo.Experience;
            ChildrenCount = salaryInfo.ChildrenCount;
            WorkedDays = salaryInfo.WorkedDays;
            TotalAmount = salaryInfo.TotalAmount;
        }

        public string Worker { get; }

        public float BaseSalary { get;  }

        public float Experience { get; }
        
        public int ChildrenCount { get; }

        public int WorkedDays { get; }

        public float TotalAmount { get; }
    }
}
