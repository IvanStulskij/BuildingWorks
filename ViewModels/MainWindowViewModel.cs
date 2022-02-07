namespace BuildingWorks.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public AnaliticsArchiveViewModel AnaliticsArchiveViewModel { get; set; }
            = new AnaliticsArchiveViewModel();
        public BuildingObjectViewModel BuildingObjectViewModel { get; set; }
            = new BuildingObjectViewModel();
        public PlansViewModel PlansViewModel { get; set; } = new PlansViewModel();
        public ProvidersViewModel ProvidersViewModel { get; set; } = new ProvidersViewModel();
        public WorkersViewModel WorkersViewModel { get; set; } = new WorkersViewModel();
    }
}
