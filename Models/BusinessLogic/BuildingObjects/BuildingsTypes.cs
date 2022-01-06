using Ardalis.SmartEnum;

namespace BuildingWorks.Models.BusinessLogic.BuildingObjects
{
    public class BuildingsTypes : SmartEnum<BuildingsTypes>
    {
        public static readonly BuildingsTypes LiveHouse = new BuildingsTypes("Жилой дом", 1);
        public static readonly BuildingsTypes Education = new BuildingsTypes("Образовательное учреждение", 2);
        
        public BuildingsTypes(string name, int value) : base(name, value)
        {

        }
    }
}
