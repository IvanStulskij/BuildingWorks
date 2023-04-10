using BuildingWorks.BuildingWorks.RefitAPI.APIs;
using BuildingWorks.Models;
using BuildingWorks.Models.Resources.BuildingObject.Addresses;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingWorks.BuildingWorks.RefitAPI
{
    public class ServiceReceiver<TResource, TApi>
        where TApi : IApi<TResource>
    {
        private const string BaseRequest = "http://localhost:5000/api/v1/";
        private readonly TApi _api;

        public ServiceReceiver(string table)
        {
            _api = RestService.For<TApi>($"{BaseRequest}{table}");
        }

        public async Task<IEnumerable<TResource>> GetAll()
        {
            var response = await _api.GetAll();

            return response;
        }

        public async Task<TResource> GetById(int id)
        {
            var response = await _api.GetById(id);

            return response;
        }

        public async Task<TResource> Create()
        {
            var response = await _api.Create();

            return response;
        }

        public async Task Delete(int id)
        {
            await _api.Delete(id);
        }
    }

    public class OverviewServiceReceiver<TResource, TOverview, TApi> : ServiceReceiver<TResource, TApi>
        where TApi : IOverviewApi<TResource, TOverview>
    {
        private const string BaseRequest = "http://localhost:5000/api/v1/";
        private readonly TApi _api;
        
        public OverviewServiceReceiver(string table) : base(table)
        {
            _api = RestService.For<TApi>($"{BaseRequest}{table}");
        }

        public async Task<IEnumerable<TOverview>> GetAllOverview(PaginationParameters pagination)
        {
            var response = await _api.GetAllOverview(pagination);

            return response;
        }
    }
}
