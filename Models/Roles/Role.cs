using Ardalis.SmartEnum;

namespace BuildingWorks.Models.Roles
{
    public abstract class Role : SmartEnum<Role>, IRole
    {
        public static readonly Role Accountant = new AccountantRole();
        public static readonly Role Constructor = new ConstructorRole();
        public static readonly Role Manager = new ManagerRole();

        public Role(string name, int value) : base(name, value)
        {

        }
    }
}
