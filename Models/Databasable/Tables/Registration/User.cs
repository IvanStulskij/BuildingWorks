using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Models.Databasable.Tables.Registration
{
    public class User : ITableRecord
    {
        /*public User(UnregisteredCode userCode, string fullName, string password)
        {
            FullName = fullName;
            UserCode = userCode.Code;
            Password = password;
        }*/

        [Key]
        public int UserCode { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }

    }
}
