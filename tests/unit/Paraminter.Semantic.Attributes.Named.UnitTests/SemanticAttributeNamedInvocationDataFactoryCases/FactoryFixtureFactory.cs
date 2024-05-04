namespace Paraminter.Semantic.SemanticAttributeNamedInvocationDataFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        SemanticAttributeNamedInvocationDataFactory sut = new();

        return new FactoryFixture(sut);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly ISemanticAttributeNamedInvocationDataFactory Sut;

        public FactoryFixture(ISemanticAttributeNamedInvocationDataFactory sut)
        {
            Sut = sut;
        }

        ISemanticAttributeNamedInvocationDataFactory IFactoryFixture.Sut => Sut;
    }
}
