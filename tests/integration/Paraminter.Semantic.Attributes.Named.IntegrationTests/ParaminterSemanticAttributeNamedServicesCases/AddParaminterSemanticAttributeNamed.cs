namespace Paraminter.Semantic.ParaminterSemanticAttributeNamedServicesCases;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Paraminter.Parameters;

using Xunit;

public sealed class AddParaminterSemanticAttributeNamed
{
    [Fact]
    public void IArgumentDataParser_ServiceCanBeResolved() => ServiceCanBeResolved<IArgumentDataParser<INamedParameter, ISemanticAttributeNamedArgumentData, ISemanticAttributeNamedInvocationData>>();

    [Fact]
    public void ISemanticAttributeNamedArgumentDataFactory_ServiceCanBeResolved() => ServiceCanBeResolved<ISemanticAttributeNamedArgumentDataFactory>();

    [Fact]
    public void ISemanticAttributeNamedInvocationDataFactory_ServiceCanBeResolved() => ServiceCanBeResolved<ISemanticAttributeNamedInvocationDataFactory>();

    private static void Target(IServiceCollection services) => ParaminterSemanticAttributeNamedServices.AddParaminterSemanticAttributeNamed(services);

    [AssertionMethod]
    private static void ServiceCanBeResolved<TService>()
        where TService : notnull
    {
        HostBuilder host = new();

        host.ConfigureServices(static (services) => Target(services));

        var serviceProvider = host.Build().Services;

        var result = serviceProvider.GetRequiredService<TService>();

        Assert.NotNull(result);
    }
}
