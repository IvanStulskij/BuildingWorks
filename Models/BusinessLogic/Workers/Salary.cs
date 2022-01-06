namespace BuildingWorks.Models.BusinessLogic.Workers
{
    public class Salary
    {
        private readonly float _baseSalary;
        private readonly int _childrenCount;
        private readonly float _deductions;
        private readonly float _taxes;

        public Salary
            (
                float baseSalary,
                int childrenCount,
                float deductions,
                float taxes
            )
        {
            _baseSalary = baseSalary;
            _childrenCount = childrenCount;
            _deductions = deductions;
            _taxes = taxes;
        }

        public float CountSalary()
        {
            return 0;
        }

        private float CountChildrenFactor()
        {
            return 0;
        }

        private float CountDeductions()
        {
            return 0;
        }

        private float CountTaxes()
        {
            return 0;
        }
    }
}
