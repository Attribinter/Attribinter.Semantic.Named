namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

using System.Collections.Generic;

/// <summary>Handles creation of <see cref="ISemanticAttributeNamedInvocationData"/>.</summary>
public interface ISemanticAttributeNamedInvocationDataFactory
{
    /// <summary>Creates a <see cref="ISemanticAttributeNamedInvocationData"/>, representing the named parameters and named arguments of an attribute invocation.</summary>
    /// <param name="parameters">The named parameters of the invocation.</param>
    /// <param name="arguments">The named arguments of the invocation.</param>
    /// <returns>The created <see cref="ISemanticAttributeNamedInvocationData"/>.</returns>
    public abstract ISemanticAttributeNamedInvocationData Create(IReadOnlyList<string> parameters, IReadOnlyList<TypedConstant> arguments);
}
