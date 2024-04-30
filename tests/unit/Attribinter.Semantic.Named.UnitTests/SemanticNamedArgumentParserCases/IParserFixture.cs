namespace Attribinter.Semantic.SemanticNamedArgumentParserCases;

using Attribinter.Parameters;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IParserFixture
{
    public abstract IArgumentParser<INamedParameter, TypedConstant, AttributeData> Sut { get; }

    public abstract Mock<INamedParameterFactory> ParameterFactoryMock { get; }
}
