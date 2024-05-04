namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="ISemanticAttributeNamedArgumentDataFactory"/>
public sealed class SemanticAttributeNamedArgumentDataFactory : ISemanticAttributeNamedArgumentDataFactory
{
    /// <summary>Instantiates a <see cref="ISemanticAttributeNamedArgumentDataFactory"/>, handling creation of <see cref="ISemanticAttributeNamedArgumentData"/>.</summary>
    public SemanticAttributeNamedArgumentDataFactory() { }

    ISemanticAttributeNamedArgumentData ISemanticAttributeNamedArgumentDataFactory.Create(TypedConstant value) => new SemanticAttributeNamedArgumentData(value);

    private sealed class SemanticAttributeNamedArgumentData : ISemanticAttributeNamedArgumentData
    {
        private readonly TypedConstant Value;

        public SemanticAttributeNamedArgumentData(TypedConstant value)
        {
            Value = value;
        }

        TypedConstant ISemanticAttributeNamedArgumentData.Value => Value;
    }
}
