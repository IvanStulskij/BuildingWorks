using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BuildingWorks.ViewModels
{
    public class AnaliticsArchiveViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AnaliticsArchiveViewModel()
        {

        }

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
