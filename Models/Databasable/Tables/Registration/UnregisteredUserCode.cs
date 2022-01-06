using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.Registration
{
    public class UnregisteredUserCode : ITableRecord
    {
        public UnregisteredUserCode(int code)
        {
            Code = code;
        }

        [Key]
        public int Code { get; private set; }
    }
}
