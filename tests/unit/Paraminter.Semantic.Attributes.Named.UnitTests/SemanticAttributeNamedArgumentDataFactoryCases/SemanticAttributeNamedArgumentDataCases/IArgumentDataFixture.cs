namespace Paraminter.Semantic.SemanticAttributeNamedArgumentDataFactoryCases.SemanticAttributeNamedArgumentDataCases;

using Microsoft.CodeAnalysis;

internal interface IArgumentDataFixture
{
    public abstract ISemanticAttributeNamedArgumentData Sut { get; }

    public abstract TypedConstant Value { get; }
}
