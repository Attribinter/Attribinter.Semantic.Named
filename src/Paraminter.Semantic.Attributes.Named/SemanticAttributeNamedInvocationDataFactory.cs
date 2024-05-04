namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="ISemanticAttributeNamedInvocationDataFactory"/>
public sealed class SemanticAttributeNamedInvocationDataFactory : ISemanticAttributeNamedInvocationDataFactory
{
    /// <summary>Instantiates a <see cref="SemanticAttributeNamedInvocationDataFactory"/>, handling creation of <see cref="ISemanticAttributeNamedInvocationData"/>.</summary>
    public SemanticAttributeNamedInvocationDataFactory() { }

    ISemanticAttributeNamedInvocationData ISemanticAttributeNamedInvocationDataFactory.Create(IReadOnlyList<string> parameters, IReadOnlyList<TypedConstant> arguments)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        if (arguments is null)
        {
            throw new ArgumentNullException(nameof(arguments));
        }

        return new SemanticAttributeNamedInvocationData(parameters, arguments);
    }

    private sealed class SemanticAttributeNamedInvocationData : ISemanticAttributeNamedInvocationData
    {
        private readonly IReadOnlyList<string> Parameters;
        private readonly IReadOnlyList<TypedConstant> Arguments;

        public SemanticAttributeNamedInvocationData(IReadOnlyList<string> parameters, IReadOnlyList<TypedConstant> arguments)
        {
            Parameters = parameters;
            Arguments = arguments;
        }

        IReadOnlyList<string> ISemanticAttributeNamedInvocationData.Parameters => Parameters;
        IReadOnlyList<TypedConstant> ISemanticAttributeNamedInvocationData.Arguments => Arguments;
    }
}
