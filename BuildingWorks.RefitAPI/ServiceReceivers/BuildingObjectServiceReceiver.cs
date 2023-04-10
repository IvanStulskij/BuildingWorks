using BuildingWorks.BuildingWorks.RefitAPI.APIs;
using BuildingWorks.Models.Overview;
using BuildingWorks.Models.Resources.BuildingObject;

namespace BuildingWorks.BuildingWorks.RefitAPI.ServiceReceivers
{
    public class BuildingObjectServiceReceiver : OverviewServiceReceiver<BuildingObjectResource, BuildingObjectOverview, IBuildingObjectApi>
    {
        public BuildingObjectServiceReceiver() : base("building-objects")
        {
        }
    }
}
