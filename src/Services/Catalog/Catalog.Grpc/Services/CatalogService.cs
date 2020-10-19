using System;
using System.Linq;
using System.Threading.Tasks;
using CatalogGrpc;
using Grpc.Core;
using static CatalogGrpc.Catalog;

namespace Catalog.Grpc
{
    public class CatalogService : CatalogBase
    {
        private const int totalCount = 5_000_000;

        public override Task<ListCatalogItemsResponse> ListCatalogItems(ListCatalogItemsRequest request, ServerCallContext context)
        {
            var priceGenerator = new Random();
            var sampleItems = Enumerable.Range(request.StartIndex, request.PageSize).Select(index => new CatalogItem
            {
                Id = index,
                Name = $"Item {index}",
                Price = priceGenerator.Next(10, 100)
            });

            var response = new ListCatalogItemsResponse
            {
                StartIndex = request.StartIndex,
                PageSize = request  .PageSize,
                TotalCount = totalCount
            };
            response.Data.AddRange(sampleItems);

            return Task.FromResult(response);
        }
    }
}