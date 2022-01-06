using BuildingWorks.GlobalConstants;
using BuildingWorks.Models.Databasable;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Workers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingWorks.Models.Bases
{
    public class WorkersBase : BaseTable<Worker>
    {
        private readonly BrigadeBase _brigadesBase;
        private readonly WorkersContext _workersContext;

        public WorkersBase(WorkersContext context) : base(context)
        {
            _workersContext = context;
            _brigadesBase = new BrigadeBase(context);
        }

        public void Create(Tuple<string, Brigade, DateTime, string> workerData)
        {
            var worker = new Worker
            {
                FullName = workerData.Item1,
                Brigade = workerData.Item2,
                StartWorkDate = workerData.Item3,
                WorkerPost = workerData.Item4
            };

            _workersContext.Workers.Add(worker);

            _workersContext.SaveChanges();
        }

        public void Delete(int codeToDelete)
        {
            _workersContext.Workers.Remove
                (
                    _workersContext.Workers
                        .Where(worker => worker.PersonnelNumber == codeToDelete).FirstOrDefault()
                );

            _workersContext.SaveChanges();
        }

        public void Update(int codeToUpdate, Tuple<string, Brigade, DateTime, string, string> workerData)
        {
            Worker workerToUpdate = _workersContext.Workers
                .Where
                (
                    provider => provider.PersonnelNumber == codeToUpdate
                ).FirstOrDefault();

            workerToUpdate.FullName = workerData.Item1;
            workerToUpdate.Brigade = workerData.Item2;
            workerToUpdate.StartWorkDate = workerData.Item3;
            workerToUpdate.WorkerPost = workerData.Item5;

            _workersContext.SaveChanges();
        }

        public IEnumerable<string> SelectPropertiesNames()
        {
            return _workersContext.Workers.EntityType.GetProperties()
                .Select(property => property.Name);
        }

        public IEnumerable<Worker> GetWorkersOfBrigade(int brigadeCode)
        {
            return FindAll()
                .Where(worker => worker.Brigade.BrigadeCode == brigadeCode);
        }

        public IEnumerable<Worker> SelectByCondition(Tuple<string, string> condition)
        {
            var conditionalSelectQuery = new TemplateConditionalSelectQuery
            (
                TableNames.WorkersName,
                condition.Item1,
                condition.Item2
            );

            return _workersContext.Workers.FromSqlRaw(conditionalSelectQuery.Query);
        }

        private void CreateSalaryInfo()
        {

        }
    }
}
