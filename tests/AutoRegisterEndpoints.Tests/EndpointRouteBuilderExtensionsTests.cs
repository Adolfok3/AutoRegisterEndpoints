using FluentAssertions;
using Microsoft.AspNetCore.Routing;
using NSubstitute;

namespace AutoRegisterEndpoints.Tests;

public class EndpointRouteBuilderExtensionsTests
{
    [Fact]
    public void MapEndpoints_ShouldInvokeMapOnAllEndpoints()
    {
        // Arrange
        var endpointRouteBuilder = Substitute.For<IEndpointRouteBuilder>();

        // Act
        var act = () => endpointRouteBuilder.MapEndpoints();

        // Assert
        act.Should().NotThrow();
    }
    
    internal class EndpointMock1 : IEndpoint
    {
        public void Map(IEndpointRouteBuilder endpointRouteBuilder)
        {
            // do nothing
        }
    }
    
    internal class EndpointMock2 : IEndpoint
    {
        public void Map(IEndpointRouteBuilder endpointRouteBuilder)
        {
            // do nothing
        }
    }
}