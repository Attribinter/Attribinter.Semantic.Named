namespace Paraminter.Semantic.SemanticAttributeNamedArgumentDataFactoryCases.SemanticAttributeNamedArgumentDataCases;

using Microsoft.CodeAnalysis;

internal static class ArgumentDataFixtureFactory
{
    public static IArgumentDataFixture Create()
    {
        var value = TypedConstantStore.GetNext();

        ISemanticAttributeNamedArgumentDataFactory factory = new SemanticAttributeNamedArgumentDataFactory();

        var sut = factory.Create(value);

        return new ArgumentDataFixture(sut, value);
    }

    private sealed class ArgumentDataFixture : IArgumentDataFixture
    {
        private readonly ISemanticAttributeNamedArgumentData Sut;

        private readonly TypedConstant Value;

        public ArgumentDataFixture(ISemanticAttributeNamedArgumentData sut, TypedConstant value)
        {
            Sut = sut;

            Value = value;
        }

        ISemanticAttributeNamedArgumentData IArgumentDataFixture.Sut => Sut;

        TypedConstant IArgumentDataFixture.Value => Value;
    }
}
