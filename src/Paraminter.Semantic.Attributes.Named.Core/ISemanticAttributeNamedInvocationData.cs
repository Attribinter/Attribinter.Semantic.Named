namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

using System.Collections.Generic;

/// <summary>Represents the named parameters and named arguments of an attribute invocation.</summary>
public interface ISemanticAttributeNamedInvocationData
{
    /// <summary>The named parameters of the invocation.</summary>
    public abstract IReadOnlyList<string> Parameters { get; }

    /// <summary>The named arguments of the invocation.</summary>
    public abstract IReadOnlyList<TypedConstant> Arguments { get; }
}
