namespace Attribinter.Semantic.SemanticNamedArgumentParserCases;

using Attribinter.Parameters;

using Microsoft.CodeAnalysis;

using Moq;

internal static class ParserFixtureFactory
{
    public static IParserFixture Create()
    {
        Mock<INamedParameterFactory> parameterFactoryMock = new();

        SemanticNamedArgumentParser sut = new(parameterFactoryMock.Object);

        return new ParserFixture(sut, parameterFactoryMock);
    }

    private sealed class ParserFixture : IParserFixture
    {
        private readonly IArgumentParser<INamedParameter, TypedConstant, AttributeData> Sut;

        private readonly Mock<INamedParameterFactory> ParameterFactoryMock;

        public ParserFixture(IArgumentParser<INamedParameter, TypedConstant, AttributeData> sut, Mock<INamedParameterFactory> parameterFactoryMock)
        {
            Sut = sut;

            ParameterFactoryMock = parameterFactoryMock;
        }

        IArgumentParser<INamedParameter, TypedConstant, AttributeData> IParserFixture.Sut => Sut;

        Mock<INamedParameterFactory> IParserFixture.ParameterFactoryMock => ParameterFactoryMock;
    }
}
