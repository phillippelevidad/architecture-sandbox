using CatalogGrpc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Shopping.HttpAggregator.Configs;
using static CatalogGrpc.Catalog;

namespace Web.Shopping.HttpAggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly UrlsConfig urls;

        public CatalogService(IOptions<UrlsConfig> config)
        {
            urls = config.Value;
        }

        public async Task<IReadOnlyList<Models.CatalogItem>> ListCatalogItems(int startIndex = 0, int pageSize = 10)
        {
            return await GrpcCallerService.CallService(urls.CatalogGrpc, async channel =>
            {
                var client = new CatalogClient(channel);
                var request = new ListCatalogItemsRequest { StartIndex = startIndex, PageSize = pageSize };
                var response = await client.ListCatalogItemsAsync(request);
                return MapResponse(response);
            });
        }

        private IReadOnlyList<Models.CatalogItem> MapResponse(ListCatalogItemsResponse response)
        {
            return response.Data.Select(item => new Models.CatalogItem
            {
                Id = item.Id,
                Name = item.Name,
                Price = (decimal)item.Price
            })
            .ToList().AsReadOnly();
        }
    }
}
