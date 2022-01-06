namespace BuildingWorks.Models.BusinessLogic.Plans
{
    public class PlanBenefit : IPlanParam
    {
        private readonly PlanCost _planCost;
        private readonly float _planBenefit;

        public PlanBenefit(PlanCost planCost, float planBenefit)
        {
            _planCost = planCost;
            _planBenefit = planBenefit;
        }

        public float Count()
        {
            return _planBenefit - _planCost.Count();
        }
    }
}
