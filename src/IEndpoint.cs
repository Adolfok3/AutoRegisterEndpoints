using Microsoft.AspNetCore.Routing;

namespace AutoRegisterEndpoints;

public interface IEndpoint
{
    void Map(IEndpointRouteBuilder endpointRouteBuilder);
}