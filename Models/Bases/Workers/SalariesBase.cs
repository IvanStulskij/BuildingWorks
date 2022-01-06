using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Workers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BuildingWorks.Models.Bases.Workers
{
    public class SalariesBase : BaseTable<WorkerSalary>
    {
        private readonly BrigadeBase _brigadesBase;
        private readonly WorkersContext _workersContext;
        private readonly WorkersBase _workersBase;
        public SalariesBase(WorkersContext context) : base(context)
        {
            _workersContext = context;
            _brigadesBase = new BrigadeBase(_workersContext);
            _workersBase = new WorkersBase(_workersContext);
        }

        public float GetTotalSalariesOfObject(int objectCode)
        {
            IEnumerable<Brigade> brigades = _brigadesBase.GetBrigadesOfObject(objectCode).AsQueryable()
                .Include("Workers.WorkersSalaries");
            float totalSalariesAmount = 0;

            foreach (var brigade in brigades)
            {
                foreach (var worker in brigade.Workers)
                {
                    IEnumerable<WorkerSalary> workerSalaries = worker.WorkersSalaries;
                    float workerSalaryByPeriod = 0;

                    if (workerSalaries != null)
                    {
                        foreach (var salaryData in workerSalaries)
                        {
                            workerSalaryByPeriod += salaryData.TotalAmount;
                        }
                    }
                    
                    totalSalariesAmount += workerSalaryByPeriod;
                }
            }

            return totalSalariesAmount;
        }
    }
}
