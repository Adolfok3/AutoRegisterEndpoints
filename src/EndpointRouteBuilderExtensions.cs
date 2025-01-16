using System;
using System.Linq;
using Microsoft.AspNetCore.Routing;

namespace AutoRegisterEndpoints;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        var endpointsDefinitions = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
            .Where(type => typeof(IEndpoint).IsAssignableFrom(type)
                           && type is { IsInterface: false, IsAbstract: false })
            .Select(Activator.CreateInstance)
            .Cast<IEndpoint>();

        foreach (var endpoint in endpointsDefinitions)
            endpoint.Map(app);

        return app;
    }
}