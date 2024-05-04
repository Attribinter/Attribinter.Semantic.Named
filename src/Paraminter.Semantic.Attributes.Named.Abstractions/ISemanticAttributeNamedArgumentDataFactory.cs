namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="ISemanticAttributeNamedArgumentData"/>.</summary>
public interface ISemanticAttributeNamedArgumentDataFactory
{
    /// <summary>Creates a <see cref="ISemanticAttributeNamedArgumentData"/>, representing an attribute named argument.</summary>
    /// <param name="value">The value of the argument.</param>
    /// <returns>The created <see cref="ISemanticAttributeNamedArgumentData"/>.</returns>
    public abstract ISemanticAttributeNamedArgumentData Create(TypedConstant value);
}
