namespace Paraminter.Semantic.SemanticAttributeNamedArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

internal static class ParserFixtureFactory
{
    public static IParserFixture Create()
    {
        Mock<INamedParameterFactory> parameterFactoryMock = new();
        Mock<ISemanticAttributeNamedArgumentDataFactory> argumentDataFactoryMock = new();

        SemanticAttributeNamedArgumentDataParser sut = new(parameterFactoryMock.Object, argumentDataFactoryMock.Object);

        return new ParserFixture(sut, parameterFactoryMock, argumentDataFactoryMock);
    }

    private sealed class ParserFixture : IParserFixture
    {
        private readonly IArgumentDataParser<INamedParameter, ISemanticAttributeNamedArgumentData, ISemanticAttributeNamedInvocationData> Sut;

        private readonly Mock<INamedParameterFactory> ParameterFactoryMock;
        private readonly Mock<ISemanticAttributeNamedArgumentDataFactory> ArgumentDataFactoryMock;

        public ParserFixture(IArgumentDataParser<INamedParameter, ISemanticAttributeNamedArgumentData, ISemanticAttributeNamedInvocationData> sut, Mock<INamedParameterFactory> parameterFactoryMock, Mock<ISemanticAttributeNamedArgumentDataFactory> argumentDataFactoryMock)
        {
            Sut = sut;

            ParameterFactoryMock = parameterFactoryMock;
            ArgumentDataFactoryMock = argumentDataFactoryMock;
        }

        IArgumentDataParser<INamedParameter, ISemanticAttributeNamedArgumentData, ISemanticAttributeNamedInvocationData> IParserFixture.Sut => Sut;

        Mock<INamedParameterFactory> IParserFixture.ParameterFactoryMock => ParameterFactoryMock;
        Mock<ISemanticAttributeNamedArgumentDataFactory> IParserFixture.ArgumentDataFactoryMock => ArgumentDataFactoryMock;
    }
}
