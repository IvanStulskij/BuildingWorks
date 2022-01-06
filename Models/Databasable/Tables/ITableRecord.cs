using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Models.Databasable.Tables
{
    public interface ITableRecord
    {
        public void AddRecord(DbSet<ITableRecord> tableRecords, ITableRecord recordToAdd)
        {
            tableRecords.Add(recordToAdd);
        }

        public void RemoveRecord(DbSet<ITableRecord> tableRecords, ITableRecord recordToRemove)
        {
            tableRecords.Remove(recordToRemove);
        }
    }
}
