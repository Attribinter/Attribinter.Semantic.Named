namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

/// <summary>Represents an attribute named argument.</summary>
public interface ISemanticAttributeNamedArgumentData
{
    /// <summary>The value of the argument.</summary>
    public abstract TypedConstant Value { get; }
}
