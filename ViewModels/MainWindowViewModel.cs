using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BuildingWorks.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public AnaliticsArchiveViewModel AnaliticsArchiveViewModel { get; set; }
            = new AnaliticsArchiveViewModel();
        public BuildingObjectViewModel BuildingObjectViewModel { get; set; }
            = new BuildingObjectViewModel();
        public PlansViewModel PlansViewModel { get; set; } = new PlansViewModel();
        public ProvidersViewModel ProvidersViewModel { get; set; } = new ProvidersViewModel();
        public WorkersViewModel WorkersViewModel { get; set; } = new WorkersViewModel();
        

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            
        }

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
