using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Shopping.HttpAggregator.Models;

namespace Web.Shopping.HttpAggregator.Services
{
    public interface ICatalogService
    {
        Task<IReadOnlyList<CatalogItem>> ListCatalogItems(int startIndex = 0, int pageSize = 10);
    }
}