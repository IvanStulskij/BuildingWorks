using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Plans;
using BuildingWorks.ViewModels.Plans;

namespace BuildingWorks.ViewModels
{
    public class PlansViewModel : ViewModel
    {
        public PlansDetailsViewModel PlansDetailsViewModel { get; } = new PlansDetailsViewModel();
        public DataViewModel<Plan> DataViewModel { get; set; }
        private readonly PlansContext _plansContext = new PlansContext();

        public PlansViewModel()
        {
            DataViewModel = new DataViewModel<Plan>(_plansContext.Plans);
        }
    }
}
