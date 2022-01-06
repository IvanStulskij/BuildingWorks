using Ardalis.SmartEnum;

namespace BuildingWorks.Models.BusinessLogic.Workers.Types
{
    public abstract class WorkerType : SmartEnum<WorkerType>
    {
        public static readonly WorkerType Worker = new Builder();
        public static readonly WorkerType Brigadier = new Brigadier();
        public static readonly WorkerType Driver = new Driver();

        public WorkerType(string name, int value) : base(name, value)
        {

        }
    }
}
