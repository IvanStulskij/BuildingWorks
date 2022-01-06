using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.Workers
{
    public class Worker
    {
        [Key]
        public int PersonnelNumber { get; set; }
        public string FullName { get; set; }
        public DateTime StartWorkDate { get; set; }
        public string WorkerPost { get; set; }
        public Brigade Brigade { get; set; }
        public List<WorkerSalary> WorkersSalaries { get; set; }
    }
}
