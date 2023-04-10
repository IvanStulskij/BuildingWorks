using BuildingWorks.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingWorks.BuildingWorks.RefitAPI.APIs
{
    public interface IApi<TResource>
    {
        [Get("/")]
        Task<IEnumerable<TResource>> GetAll();

        [Get("/{id}")]
        Task<TResource> GetById(int id);

        [Post("/")]
        Task<TResource> Create();

        [Delete("/{id}")]
        Task Delete(int id);
    }

    public interface IOverviewApi<TResource, TOveview> : IApi<TResource>
    {
        [Get("/overview")]
        Task<IEnumerable<TOveview>> GetAllOverview(PaginationParameters pagination);
    }
}
