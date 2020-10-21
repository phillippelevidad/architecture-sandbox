# Ideia no Ar Marketplace - V2 Sandbox

## Performance

* [Performance best practices with gRPC](https://docs.microsoft.com/en-us/aspnet/core/grpc/performance?view=aspnetcore-3.1): create a channel pool to ensure that each channel is reused for up to 100 simultaneous connections, and that new channels are created when there are more than 100 connections in the previous channel.

## Done

* [Serilog](https://github.com/serilog/serilog/wiki/Configuration-Basics) is used for logging.
* [Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-3.1) is autogenerating the Rest API documentation.
* The [BFF pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/backends-for-frontends) (Backend for Frontend) is used to expose a Rest API, which internally interfaces with a gRPC service. This approach enables that each Rest API be tailored for each use case, exposing only the relevant endpoints. For instance, the Catalog gRPC service exposes endpoints for both querying and modifying products. The modification endpoints would better be kept hidden from a Shopping API. Now we can have a Shopping API, as well as a Management API; a client may be authorized on none, either or both APIs; also, each API may be scaled independently.

## Roadmap

* Authenticate API calls with an Identity Server
* Dockerize everything
* Promote discoverability with a centralized manager service
* Add a secrets storage service
* Add health checks