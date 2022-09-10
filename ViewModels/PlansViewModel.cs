using BuildingWorks.Models.Bases.PlansBase;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Plans;
using BuildingWorks.ViewModels.Operations;
using BuildingWorks.ViewModels.Plans;

namespace BuildingWorks.ViewModels
{
    public class PlansViewModel : ViewModel
    {
        public PlansDataViewModel PlansDataViewModel { get; private set; } = new PlansDataViewModel();
        public PlansDetailsViewModel PlansDetailsViewModel { get; } = new PlansDetailsViewModel();
        public DataViewModel<Plan> DataViewModel { get; set; }
        public RemoveViewModel<Plan> RemoveViewModel { get; set; }
        private readonly PlansContext _context = new PlansContext();
        private readonly PlanBase _planBase;

        public PlansViewModel()
        {
            _planBase = new PlanBase(_context);
            DataViewModel = new DataViewModel<Plan>(_context.Plans);
            RemoveViewModel = new RemoveViewModel<Plan>(DataViewModel, _context.Plans, _planBase);
        }
    }
}
