namespace Paraminter.Semantic.SemanticAttributeNamedArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

internal interface IParserFixture
{
    public abstract IArgumentDataParser<INamedParameter, ISemanticAttributeNamedArgumentData, ISemanticAttributeNamedInvocationData> Sut { get; }

    public abstract Mock<INamedParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<ISemanticAttributeNamedArgumentDataFactory> ArgumentDataFactoryMock { get; }
}
