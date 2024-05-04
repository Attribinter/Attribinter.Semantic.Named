namespace Paraminter.Semantic;

using Microsoft.Extensions.DependencyInjection;

using Paraminter.Parameters;

using System;

/// <summary>Allows the services provided by <i>Paraminter.Semantic.Named</i> to be registered with <see cref="IServiceCollection"/>.</summary>
public static class ParaminterSemanticAttributeNamedServices
{
    /// <summary>Registers the services provided by <i>Paraminter.Semantic.Named</i> with the provided <see cref="IServiceCollection"/>.</summary>
    /// <param name="services">The <see cref="IServiceCollection"/> with which services are registered.</param>
    /// <returns>The provided <see cref="IServiceCollection"/>, so that calls can be chained.</returns>
    public static IServiceCollection AddParaminterSemanticAttributeNamed(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddParaminterNamedParameters();

        services.AddTransient<IArgumentDataParser<INamedParameter, ISemanticAttributeNamedArgumentData, ISemanticAttributeNamedInvocationData>, SemanticAttributeNamedArgumentDataParser>();

        services.AddTransient<ISemanticAttributeNamedArgumentDataFactory, SemanticAttributeNamedArgumentDataFactory>();
        services.AddTransient<ISemanticAttributeNamedInvocationDataFactory, SemanticAttributeNamedInvocationDataFactory>();

        return services;
    }
}
