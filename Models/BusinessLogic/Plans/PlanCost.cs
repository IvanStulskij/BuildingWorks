namespace BuildingWorks.Models.BusinessLogic.Plans
{
    public class PlanCost : IPlanParam
    {
        private readonly float _salariesExpences;
        private readonly float _taxesExpences;
        private readonly float _materialsExpences;

        public PlanCost(float salariesExpences, float taxesExpences, float materialsExpences)
        {
            _salariesExpences = salariesExpences;
            _taxesExpences = taxesExpences;
            _materialsExpences = materialsExpences;
        }

        public float Count()
        {
            return _salariesExpences + _taxesExpences + _materialsExpences;
        }
    }
}
