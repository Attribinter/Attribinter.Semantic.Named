namespace Paraminter.Semantic.SemanticAttributeNamedArgumentDataFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        SemanticAttributeNamedArgumentDataFactory sut = new();

        return new FactoryFixture(sut);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly ISemanticAttributeNamedArgumentDataFactory Sut;

        public FactoryFixture(ISemanticAttributeNamedArgumentDataFactory sut)
        {
            Sut = sut;
        }

        ISemanticAttributeNamedArgumentDataFactory IFactoryFixture.Sut => Sut;
    }
}
